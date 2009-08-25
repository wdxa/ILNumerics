#include "f2c.h"

#define log10e 0.43429448190325182765

double log(double);

double d_lg10(doublereal *x)
{
	return( log10e * log(*x) );
}

