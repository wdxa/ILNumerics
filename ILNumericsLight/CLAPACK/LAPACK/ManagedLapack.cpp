#include "ManagedLapack.h"
#include "blaswrap.h"

// These functions exist somewhere (trust me)
int dgeevx_(char*,char*,char*,char*,integer*,doublereal*,integer*,doublereal*,doublereal*,doublereal*,integer*,doublereal*,integer*,integer*,integer*,doublereal*,doublereal*,doublereal*,doublereal*,doublereal*,integer*,integer*,integer*);
int dgelsy_(integer*,integer*,integer*,doublereal*,integer*,doublereal*,integer*,integer*,doublereal*,integer*,doublereal*,integer*,integer*);
int dgesdd_(char*,integer*,integer*,doublereal*,integer*,doublereal*,doublereal*,integer*,doublereal*,integer*,doublereal*,integer*,integer*,integer*);
int dgetrf_(integer*,integer*,doublereal*,integer*,integer*,integer*);
int dgetrs_(char*,integer*,integer*,doublereal*,integer*,integer*,doublereal*,integer*,integer*);
int dpotrf_(char*,integer*,doublereal*,integer*,integer*);
int dpotrs_(char*,integer*,integer*,doublereal*,integer*,doublereal*,integer*,integer*);

extern int dgemm_(char*,char*,integer*,integer*,integer*,doublereal*,doublereal*,integer*,doublereal*,integer*,doublereal*,doublereal*,integer*);
extern int zgemm_(char*,char*,integer*,integer*,integer*,doublecomplex*,doublecomplex*,integer*,doublecomplex*,integer*,doublecomplex*,doublecomplex*,integer*);

namespace NativeMathLib
{ // Definitions for ManagedLapack class
	
	int ManagedLapack::dgeevx(char *balanc, char *jobvl, char *jobvr, char *sense, integer *n, doublereal *a, integer *lda,
		doublereal *wr, doublereal *wi, doublereal *vl, integer *ldvl, doublereal *vr, integer *ldvr, integer *ilo, integer *ihi,
		doublereal *scale, doublereal *abnrm, doublereal *rconde, doublereal *rcondv, doublereal *work, integer *lwork, integer *iwork, integer *info)
	{
		return dgeevx_(balanc,jobvl,jobvr,sense,n,a,lda,wr,wi,vl,ldvl,vr,ldvr,ilo,ihi,scale,abnrm,rconde,rcondv,work,lwork,iwork,info);
	}

	int ManagedLapack::dgelsy(integer *m, integer *n, integer *nrhs, doublereal *a, integer *lda, doublereal *b, integer *ldb,
		integer * jpvt, doublereal *rcond, integer *rank, doublereal *work, integer * lwork, integer *info)
	{
		return dgelsy_(m,n,nrhs,a,lda,b,ldb,jpvt,rcond,rank,work,lwork,info);
	}

	int ManagedLapack::dgemm(char *transa, char *transb, integer *m, integer *n, integer *k, doublereal *alpha, doublereal *a,
		integer *lda, doublereal *b, integer *ldb, doublereal *beta, doublereal *c__, integer *ldc)
	{
		return dgemm_(transa,transb,m,n,k,alpha,a,lda,b,ldb,beta,c__,ldc);
	}

	int ManagedLapack::dgesdd(char *jobz, integer *m, integer *n, doublereal *a, integer *lda, doublereal *s, doublereal *u,
		integer *ldu, doublereal *vt, integer *ldvt, doublereal *work, integer *lwork, integer *iwork, integer *info)
	{
		return dgesdd_(jobz,m,n,a,lda,s,u,ldu,vt,ldvt,work,lwork,iwork,info);
	}
	
	int ManagedLapack::dgetrf(integer *m, integer *n, doublereal *a, integer * lda, integer *ipiv, integer *info)
	{
		return dgetrf_(m,n,a,lda,ipiv,info);
	}
	
	int ManagedLapack::dgetrs(char *trans, integer *n, integer *nrhs, doublereal *a, integer *lda, integer *ipiv,
		doublereal *b, integer *ldb, integer *info)
	{
		return dgetrs_(trans,n,nrhs,a,lda,ipiv,b,ldb,info);
	}

	int ManagedLapack::dpotrf(char *uplo, integer *n, doublereal *a, integer * lda, integer *info)
	{
		return dpotrf_(uplo,n,a,lda,info);
	}
	
	int ManagedLapack::dpotrs(char *uplo, integer *n, integer *nrhs, doublereal *a, integer *lda, doublereal *b,
		integer *ldb, integer *info)
	{
		return dpotrs_(uplo,n,nrhs,a,lda,b,ldb,info);
	}

	int ManagedLapack::zgemm(char *transa, char *transb, integer *m, integer *n, integer *k, doublecomplex *alpha, doublecomplex *a,
		integer *lda, doublecomplex *b, integer *ldb, doublecomplex *beta, doublecomplex *c__, integer *ldc)
	{
		return zgemm_(transa,transb,m,n,k,alpha,a,lda,b,ldb,beta,c__,ldc);
	}
}