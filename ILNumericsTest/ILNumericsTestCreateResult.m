A = reshape(1:24,4,3,2);
ind = reshape(repmat(24:-1:1,1,10),5,4,3,2,2); 
%ind = reshape(24:-1:1,1,24); 
b = A(ind); 
b = shiftdim(b,0);
disp(['new ILArray<double> (new double[] {' sprintf('%g,',b(:)) ...
      '},' sprintf('%d,',size(b)) ');']);