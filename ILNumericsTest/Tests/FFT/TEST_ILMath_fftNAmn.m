function create()
filepath = 'TEST_ILMath.fftNAmn.cs'; 
% test array specification by size
dims = cell(1);
dims{1} = [1 1]; dims{2} = [3 1]; dims{3} = [1 3]; dims{4} = [2 3]; 
dims{5} = [3 2]; dims{6} = [2 2]; dims{7} = [4 5 2]; dims{8} = [3 1 3]; 
dims{9} = [1 3 4]; dims{10} = [1 4 3]; dims{11} = [3 4 1]; dims{12} = [5 4 1];
dims{13} = [5 4 3 2]; dims{14} = [1 5 4 3]; dims{15} = [5 1 4 3];
dims{16} = [5 4 1 3]; dims{17} = [5 4 3 1]; dims{18} = [5 1 4 1];

%%%%%%%%%%%%%%%%%%%% do not edit below this line! %%%%%%%%%%%%%%%%%%%
sCName = sprintf('TEST_ILMath_fftN_Amn'); 

sFClose = '}\r\n'; 
% collect all funcnames on the run
funcNames = {}; 

% open file 
fid = fopen(filepath,'w+'); 
% write class header
sCHead = sprintf('using System;\r\nusing ILNumerics.BuiltInFunctions;\r\nusing ILNumerics.Misc;\r\nusing ILNumerics.Test;\r\nusing ILNumerics.Native; \r\n\r\nnamespace ILNumerics.Test {\r\npublic partial class %s {\r\n',sCName); 
fprintf(fid,'%s\r\n\r\n',sCHead); 

%%%%%%%%%% DOUBLE %%%%%%%%%%%%%%%%%%%
funcNames = iterate (fid,dims,'double','complex',funcNames); 
%%%%%%%%%%%%%%% FLOAT %%%%%%%%%%%%%%%%%%%%%%%%
funcNames = iterate (fid,dims,'float','fcomplex',funcNames); 

% print public func to call all generated functions
fprintf(fid,'public static void TEST_ALL() {\r\n'); 
for u = 1:length(funcNames) 
    fprintf(fid,'\t%s();\r\n',funcNames{u}); 
end
fprintf(fid,sFClose); % end func test all
fprintf(fid,sFClose); % end class
fprintf(fid,sFClose); % end namespace
fclose(fid); 

   
function funcNames = iterate (fid,dims,sRType,sCType,funcNames); 
% iterate over all distinct test array types 
for d = (1:length(dims))
    A = 1:prod(dims{d}); 
    A = reshape(A,dims{d}); 
        % write function header
    funcName = sprintf('TEST_FFT_%s_%s_%d',sRType,sCType,d);
    fprintf(fid,'private static void %s() { \r\n',funcName); 
    funcNames{end+1} = funcName; 
    fprintf(fid,'ILArray<%s> A,ResultR,ResultI,ResRA,ResIAI,ResIAR;\r\n',sRType);
    fprintf(fid,'ILArray<%s> Result,ResIA;\r\n',sCType); 
    PrintRealDef(fid,'A',A,sRType); 
    for m = 0:(size(A,1)+1) 
        for n = 0:(size(A,2)+1)
            for q = 0:(size(A,3)+1)
                sizeA = size(A); 
                sizeA(1:3) = [m n q]; 
                Result = fftn(A,sizeA);
                PrintComplexDef(fid,'Result',Result,sRType);  
                classtype = sRType; 
                if (strcmp(classtype,'float')) 
                    classtype = 'single'; 
                end
                try 
                    ResRA = real(ifftn(A+(eps*i),sizeA));
                catch 
                    sA = size(A); 
                    sA(1) = m; 
                    sA(2) = n; 
                    ResRA = zeros(sA,classtype); 
                end
                PrintRealDef(fid,'ResRA',ResRA,sRType);  
                try 
                    ResIA = ifftn(A+(eps*i),sizeA);
                catch 
                    sA = size(A); 
                    sA(1) = m; 
                    sA(2) = n; 
                    ResIA = zeros(sA,classtype); 
                end
                PrintComplexDef(fid,'ResIA',ResIA,sRType);  
                fprintf(fid,'TEST_ILMath_fft_HELPER.forwBackwCheckNDmn(A, Result,ResRA,ResIA,%d,%d,%d);\r\n',m,n,q); 
            end
        end
    end
    fprintf(fid,'}\r\n');  
end 

    