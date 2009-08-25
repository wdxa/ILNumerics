#include "f2c.h"

int s_cat(char *lp, char **rpp, long *rnp, long *np, long ll)
{
	ftnlen i, nc;
	char *rp;
	ftnlen n = *np;
	for(i = 0 ; i < n ; ++i) {
		nc = ll;
		if(rnp[i] < nc)
			nc = rnp[i];
		ll -= nc;
		rp = rpp[i];
		while(--nc >= 0)
			*lp++ = *rp++;
		}
	while(--ll >= 0)
		*lp++ = ' ';

	return 0;
}

