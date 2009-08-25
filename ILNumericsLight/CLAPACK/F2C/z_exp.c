#include "f2c.h"

double cos(double);
double sin(double);
double exp(double);

void z_exp(doublecomplex *r, doublecomplex *z)
{
	double expx, zi = z->i;

	expx = exp(z->r);
	r->r = expx * cos(zi);
	r->i = expx * sin(zi);
}
