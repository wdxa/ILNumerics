#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

#include <windows.h> 
#include "cpuid.h"
#include "stdafx.h"
/***************************************************************
* wincpuidsupport()
*
* Inputs: none
*
* Returns:
*  1 = CPUID opcode is supported
*  0 = CPUID opcode is not supported
***************************************************************/

WORD wincpuidsupport() {
	int cpuid_support = 1;

	_asm {
        pushfd					// Get original EFLAGS
		pop		eax
		mov 	ecx, eax
        xor     eax, 200000h	// Flip ID bit in EFLAGS
        push    eax				// Save new EFLAGS value on
        						//   stack
        popfd					// Replace current EFLAGS value
        pushfd					// Get new EFLAGS
        pop     eax				// Store new EFLAGS in EAX
        xor     eax, ecx		// Can not toggle ID bit,
        jnz     support			// Processor=80486
		
		mov cpuid_support,0		// Clear support flag
support:
      }
	
	return cpuid_support;

} // wincpuidsupport()

/***************************************************************
* check_IDProc()
*
* Inputs: none
*
* Returns:
*  CPU Family (i.e. 4 if Intel 486, 5 if Pentium(R) Processor)
***************************************************************/

 int check_IDProc(unsigned char** vendorID12char, unsigned int* reax, 
			unsigned int* rebx, unsigned int* recx, unsigned int* redx) {

		if (wincpuidsupport() == 0)
			return 0; 
		int i=0;
		unsigned char vendor_id[13]="------------";
		unsigned int _eax=0; 
		unsigned int _ebx=0; 
		unsigned int _ecx=0; 
		unsigned int _edx=0; 

_asm {      
        xor     eax, eax;
		cpuid
		//CPU_ID;
		mov     dword ptr vendor_id, ebx
		mov     dword ptr vendor_id[+4], edx
		mov     dword ptr vendor_id[+8], ecx

}
for (int i = 0; i < 13; i ++) 
		(*vendorID12char)[i] = vendor_id[i]; 
_asm {
        cmp     eax, 1			// Make sure 1 is valid input 
        						//   for CPUID
        jl      end_IDProc		// If not, jump to end
        xor     eax, eax
        inc		eax
        cpuid					// Get family/model/stepping/
        						//   features
		mov		dword ptr _eax , eax; 
		mov		dword ptr _ebx , ebx; 
		mov		dword ptr _ecx , ecx; 
		mov		dword ptr _edx , edx; 
end_IDProc:
      }
	*reax = _eax; 
	*rebx = _ebx; 
	*recx = _ecx; 
	*redx = _edx; 
	return 0;
} // Check_IDProc()