#include "ManagedLapack.h"

// These functions exist somewhere (trust me)
int dgelsy_(integer*,integer*,integer*,doublereal*,integer*,doublereal*,integer*,integer*,doublereal*,integer*,doublereal*,integer*,integer*);
int dgesdd_(char*,integer*,integer*,doublereal*,integer*,doublereal*,doublereal*,integer*,doublereal*,integer*,doublereal*,integer*,integer*,integer*);

namespace NativeMathLib
{ // Definitions for ManagedLapack class

	int ManagedLapack::dgelsy(integer *m, integer *n, integer *nrhs, doublereal *a, integer *lda, doublereal *b, integer *ldb,
		integer * jpvt, doublereal *rcond, integer *rank, doublereal *work, integer * lwork, integer *info)
	{
		return dgelsy_(m,n,nrhs,a,lda,b,ldb,jpvt,rcond,rank,work,lwork,info);
	}

	int ManagedLapack::dgesdd(char *jobz, integer *m, integer *n, doublereal *a, integer *lda, doublereal *s, doublereal *u,
		integer *ldu, doublereal *vt, integer *ldvt, doublereal *work, integer *lwork, integer *iwork, integer *info)
	{
		return dgesdd_(jobz,m,n,a,lda,s,u,ldu,vt,ldvt,work,lwork,iwork,info);
	}
}