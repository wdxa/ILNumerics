#pragma once
#include "f2c.h"

namespace NativeMathLib
{
	public ref class ManagedLapack
	{
		public:
		
		static int dgelsy(integer *m, integer *n, integer *nrhs, doublereal *a, integer *lda,
			doublereal *b, integer *ldb, integer * jpvt, doublereal *rcond, integer *rank,
			doublereal *work, integer * lwork, integer *info);

		static int dgesdd(char *jobz, integer *m, integer *n, doublereal *a, integer *lda, doublereal *s,
						  doublereal *u, integer *ldu, doublereal *vt, integer *ldvt, doublereal *work,
						  integer *lwork, integer *iwork, integer *info);
	};
}