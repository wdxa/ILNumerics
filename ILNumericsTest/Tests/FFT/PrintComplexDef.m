function PrintComplexDef(fid,OutName,Result,prec) 
   if (strcmp(prec,'float'))
        resR = sprintf('%1.15ff,',real(Result(:))); 
        resR = resR(1:end-1); 
        fprintf(fid,'%sR = new %s[]{%s};\r\n',OutName,prec,resR);
        resI = sprintf('%1.15ff,',imag(Result(:))); 
        resI = resI(1:end-1); 
        fprintf(fid,'%sI = new %s[]{%s};\r\n',OutName,prec,resI);
        fprintf(fid,'%s = ILMath.ccomplex(%sR,%sI);\r\n',OutName,OutName,OutName);
        dims = sprintf('%d,',size(Result));
        dims = dims(1:end-1); 
        fprintf(fid,'%s.Reshape(new ILDimension(%s));\r\n',OutName,dims);
    else 
        resR = sprintf('%1.15f,',real(Result(:))); 
        resR = resR(1:end-1); 
        fprintf(fid,'%sR = new %s[]{%s};\r\n',OutName,prec,resR);
        resI = sprintf('%1.15f,',imag(Result(:))); 
        resI = resI(1:end-1); 
        fprintf(fid,'%sI = new %s[]{%s};\r\n',OutName,prec,resI);
        fprintf(fid,'%s = ILMath.ccomplex(%sR,%sI);\r\n',OutName,OutName,OutName);
        dims = sprintf('%d,',size(Result));
        dims = dims(1:end-1); 
        fprintf(fid,'%s.Reshape(new ILDimension(%s));\r\n',OutName,dims);
    end
