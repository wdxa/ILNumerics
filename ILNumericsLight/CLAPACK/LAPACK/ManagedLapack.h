#pragma once
#include "f2c.h"

namespace NativeMathLib
{
	public ref class ManagedLapack
	{
		public:
		
		static int dgeevx(char *balanc, char *jobvl, char *jobvr, char * sense, integer *n,
			doublereal *a, integer *lda, doublereal *wr, doublereal *wi, doublereal *vl,
			integer *ldvl, doublereal *vr, integer *ldvr, integer *ilo, integer *ihi,
			doublereal *scale, doublereal *abnrm, doublereal *rconde, doublereal *rcondv,
			doublereal *work, integer *lwork, integer *iwork, integer *info);

		static int dgelsy(integer *m, integer *n, integer *nrhs, doublereal *a, integer *lda,
			doublereal *b, integer *ldb, integer * jpvt, doublereal *rcond, integer *rank,
			doublereal *work, integer * lwork, integer *info);
		
		static int dgemm(char *transa, char *transb, integer *m, integer * n, integer *k,
			doublereal *alpha, doublereal *a, integer *lda, doublereal *b, integer *ldb,
			doublereal *beta, doublereal *c__, integer *ldc);

		static int dgesdd(char *jobz, integer *m, integer *n, doublereal *a, integer *lda, doublereal *s,
			doublereal *u, integer *ldu, doublereal *vt, integer *ldvt, doublereal *work,
			integer *lwork, integer *iwork, integer *info);
		
		static int dgetrf(integer *m, integer *n, doublereal *a, integer *lda,
			integer *ipiv, integer *info);
		
		static int dgetrs(char *trans, integer *n, integer *nrhs, doublereal *a, integer *lda,
			integer *ipiv, doublereal *b, integer *ldb, integer *info);

		static int dpotrf(char *uplo, integer *n, doublereal *a, integer * lda, integer *info);

		static int dpotrs(char *uplo, integer *n, integer *nrhs, doublereal *a, integer *lda,
			doublereal *b, integer *ldb, integer *info);

		static int zgemm(char *transa, char *transb, integer *m, integer *n, integer *k,
			doublecomplex *alpha, doublecomplex *a, integer *lda, doublecomplex *b, integer *ldb,
			doublecomplex *beta, doublecomplex *c__, integer *ldc);
	};
}