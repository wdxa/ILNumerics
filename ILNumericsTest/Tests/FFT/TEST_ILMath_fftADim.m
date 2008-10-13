function create()
filepath = 'TEST_ILMath.fftADim.cs'; 
% test array specification by size
dims = cell(1);
dims{1} = [1 1]; dims{2} = [5 1]; dims{3} = [1 5]; dims{4} = [4 5]; 
dims{5} = [5 4]; dims{6} = [5 5]; dims{7} = [5 10 5]; dims{8} = [5 1 5]; 
dims{9} = [1 5 10]; dims{10} = [1 10 5]; dims{11} = [5 10 1]; dims{12} = [14 5 1];
dims{13} = [5 4 3 2]; dims{14} = [1 5 4 3]; dims{15} = [5 1 4 3];
dims{16} = [5 4 1 3]; dims{17} = [5 4 3 1]; dims{18} = [5 1 4 1];
dims{19} = [10,30,11];

%%%%%%%%%%%%%%%%%%%% do not edit below this line! %%%%%%%%%%%%%%%%%%%
sCName = sprintf('TEST_ILMath_fft_ADim'); 

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
    fprintf(fid,'ILArray<%s> A,ResultR,ResultI;\r\n',sRType);
    fprintf(fid,'ILArray<%s> Result;\r\n',sCType); 
    PrintRealDef(fid,'A',A,sRType); 
    for u = 0:(d+2)
        Result = fft(A,[],u+1);
        PrintComplexDef(fid,'Result',Result,sRType);  
        fprintf(fid,'TEST_ILMath_fft_HELPER.forwBackwCheck1DAlongD(A, Result, %d);\r\n',u); 
    end
    fprintf(fid,'}\r\n');  
end 

    