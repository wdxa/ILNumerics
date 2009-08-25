#include "f2c.h"

double f__cabs(double real, double imag);

double c_abs(complex *z)
{
	return( f__cabs( z->r, z->i ) );
}
