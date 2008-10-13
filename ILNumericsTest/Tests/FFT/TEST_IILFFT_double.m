function create()
filepath = 'TEST_IILFFT_double_complex.cs'; 
sInType = 'double'; 
sOutType = 'complex'; 
% test array specification by size
dims = cell(1);
dims{1} = [1 1]; dims{2} = [5 1]; dims{3} = [1 5]; dims{4} = [4 5]; 
dims{5} = [5 4]; dims{6} = [5 5]; dims{7} = [5 10 5]; dims{8} = [5 1 5]; 
dims{9} = [1 5 10]; dims{10} = [1 10 5]; dims{11} = [5 10 1]; dims{12} = [14 5 1];
dims{13} = [5 4 3 2]; dims{14} = [1 5 4 3]; dims{15} = [5 1 4 3];
dims{16} = [5 4 1 3]; dims{17} = [5 4 3 1]; dims{18} = [5 1 4 1];
dims{19} = [10,30,11];

%%%%%%%%%%%%%%%%%%%% do not edit below this line! %%%%%%%%%%%%%%%%%%%

sCName = sprintf('TEST_IILFFT_%s_%s',sInType,sOutType); 

sCHead = sprintf('using System;\r\nusing ILNumerics.BuiltInFunctions;\r\nusing ILNumerics.Misc;\r\nusing ILNumerics.Test;\r\nusing ILNumerics.Native; \r\n\r\nnamespace ILNumerics.Test {\r\npublic partial class %s {\r\n',sCName); 
sForwBackw1D = ['private static void forwBackwGenCheck(IILFFT fft, ILArray<double> A, ILArray<complex> Result, int dim, double mult) { ' 13 10 ...
    'ILArray<complex> B = fft.FFTForward1D(A, dim);'  13 10 ...
    'if (ILMath.sumall(ILMath.abs(Result - B))/A.Dimensions.NumberOfElements / A.Dimensions[dim] > ILMath.MachineParameterDouble.eps * mult)'  13 10 ...
    '    throw new Exception("invalid value");' 13 10 ...
    'ILArray<double> ResultR = fft.FFTBackwSym1D(B,dim);' 13 10 ... 
    'if (ILMath.sumall(ILMath.abs(ResultR - A))/A.Dimensions.NumberOfElements / A.Dimensions[dim] > ILMath.MachineParameterDouble.eps * mult)' 13 10 ...
    '   throw new Exception("invalid value");' 13 10 ...
    'B = fft.FFTBackward1D(B, dim);'  13 10 ...
    'if (ILMath.sumall(ILMath.abs(ILMath.tocomplex(A) - B))/A.Dimensions.NumberOfElements / A.Dimensions[dim] > ILMath.MachineParameterDouble.eps * mult)'  13 10 ...
    '    throw new Exception("invalid value");}' 13 10 ];
sForwBackwND = ['private static void forwBackwGenCheckND(IILFFT fft, ILArray<double> A, ILArray<complex> Result, int d, double mult) { ' 13 10 ...
'    try {' 13 10 ...
'    ILArray<complex> B = fft.FFTForward(A, d);' 13 10 ...
'    float errMult = A.Dimensions.NumberOfElements; ' 13 10 ...
'    for (int i = 0; i < d; i++) errMult *= A.Dimensions[i]; ' 13 10 ...
'    if (ILMath.sumall(ILMath.abs(Result - B))/errMult > (double)ILMath.MachineParameterDouble.eps * mult)' 13 10 ...
'        throw new Exception("invalid value");' 13 10 ...
'    ILArray<double> ResultR = fft.FFTBackwSym(B,d);' 13 10 ...
'    if (ILMath.sumall(ILMath.abs(ResultR - A))/errMult > (double)ILMath.MachineParameterDouble.eps * mult)' 13 10 ...
'       throw new Exception("invalid value");' 13 10 ...
'    B = fft.FFTBackward(B, d);' 13 10 ...
'    if (ILMath.sumall(ILMath.abs(ILMath.tocomplex(A) - B))/errMult > (double)ILMath.MachineParameterDouble.eps * mult)' 13 10 ...
'        throw new Exception("invalid value");' 13 10 ...
'    }catch(ILNumerics.Exceptions.ILArgumentException) {' 13 10 ...
'        if (d < 0) return; ' 13 10 ...
'        throw new Exception("unexpected exception was thrown -> error!");' 13 10 ... 
'    }' 13 10 ...
'}' 13 10]; 
sFHead = sprintf('private static void %%s(IILFFT fft) { \r\n', sInType, sOutType);
sFClose = '}\r\n'; 
% collect all funcnames on the run
funcNames = {}; 

% open file 
fid = fopen(filepath,'w+'); 
% write class header
fprintf(fid,'%s\r\n\r\n',sCHead); 
% write generic check function (evaluates a parameter variations)
fprintf(fid,'%s\r\n',sForwBackw1D);
fprintf(fid,'%s\r\n',sForwBackwND);
% iterate over all distinct test array types 
for d = (1:length(dims))
    A = 1:prod(dims{d}); 
    A = reshape(A,dims{d}); 
        % write function header
    funcName = sprintf('TEST_FFT1d%s_ALONG1_%d', ... 
                        sprintf('%d_',dims{d}),length(dims{d}));
    fprintf(fid,sFHead,funcName); 
    funcNames{end+1} = funcName; 
    fprintf(fid,'ILArray<%s> ResultR,ResultI, A;\r\n',sInType);
    fprintf(fid,'ILArray<%s> B, Result;\r\n',sOutType); 
    printADef(fid,A,sInType); 
        
    % iterate over dimensions
    for i = 1:length(dims{d})
        % test 1d
        Result = fft(A,[],i);
        printResDef(fid,Result,sInType);  
        fprintf(fid,'forwBackwGenCheck(fft, A, Result, %d, 1e%df);\r\n',i-1,length(dims{d})); 
        % test nd - the ilnumerics way
        ndDim = i; 
        if (ndDim > ndims(A)) ndDim = ndims(A); end
        if (ndDim < ndims(A)) 
            sizeA = size(A); 
            leads = sizeA(1:ndDim);
            if (length(leads) == 1) leads = [leads 1]; end
            trail = prod(sizeA(ndDim+1 : end)); 
            Result = zeros(size(A)); 
            for e = (1:trail)
                ind = 1:prod(leads); 
                ind = ind + prod(leads)*(e-1);
                tmp = fftn(reshape(A(ind),leads));
                Result(ind) = tmp(:); 
            end
        else 
            Result = fftn(A); 
        end 
        printResDef(fid,Result,sInType);  
        fprintf(fid,'forwBackwGenCheckND(fft, A, Result, %d, 1e%df);\r\n',i,length(dims{d})); 
    end 
    fprintf(fid,sFClose); 
end 
% print public func to call all generated functions
fprintf(fid,'public static void TEST_ALL(IILFFT fft) {\r\n'); 
for i = 1:length(funcNames) 
    fprintf(fid,'\t%s(fft);\r\n',funcNames{i}); 
end
fprintf(fid,sFClose); % end func test all
fprintf(fid,sFClose); % end class
fprintf(fid,sFClose); % end namespace
fclose(fid); 

function printResDef(fid,Result,prec) 
    resR = sprintf('%1.15f,',real(Result(:))); 
    resR = resR(1:end-1); 
    fprintf(fid,'ResultR = new %s[]{%s};\r\n',prec,resR);
    resI = sprintf('%1.15f,',imag(Result(:))); 
    resI = resI(1:end-1); 
    fprintf(fid,'ResultI = new %s[]{%s};\r\n',prec,resI);
    fprintf(fid,'Result = ILMath.ccomplex(ResultR,ResultI);\r\n');
    dims = sprintf('%d,',size(Result));
    dims = dims(1:end-1); 
    fprintf(fid,'Result.Reshape(new ILDimension(%s));\r\n',dims);
    
function printADef(fid,A,prec) 
    a = sprintf('%1.15f,',A(:)); 
    a = a(1:end-1); 
    fprintf(fid,'A = new %s[]{%s};\r\n',prec,a);
    dims = sprintf('%d,',size(A));
    dims = dims(1:end-1); 
    fprintf(fid,'A.Reshape(new ILDimension(%s));\r\n',dims);
    