function PrintRealDef(fid,Aname, A,prec) 
   if (strcmp(prec,'float'))
        a = sprintf('%1.15ff,',A(:)); 
        a = a(1:end-1); 
        fprintf(fid,'%s = new %s[]{%s};\r\n',Aname,prec,a);
        dims = sprintf('%d,',size(A));
        dims = dims(1:end-1); 
        fprintf(fid,'%s.Reshape(new ILDimension(%s));\r\n',Aname,dims);
   else 
        a = sprintf('%1.15f,',A(:)); 
        a = a(1:end-1); 
        fprintf(fid,'%s = new %s[]{%s};\r\n',Aname,prec,a);
        dims = sprintf('%d,',size(A));
        dims = dims(1:end-1); 
        fprintf(fid,'%s.Reshape(new ILDimension(%s));\r\n',Aname,dims);
    end