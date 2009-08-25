#include "f2c.h"

double exp(double);
double cos(double);
double sin(double);

void c_exp(complex *r, complex *z)
{
	double expx, zi = z->i;

	expx = exp(z->r);
	r->r = expx * cos(zi);
	r->i = expx * sin(zi);
}
