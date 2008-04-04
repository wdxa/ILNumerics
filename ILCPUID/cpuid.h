/***************************************************************
* C file:   cpuid.h... for cpuinf32 DLL
*
*       This program has been developed by Intel Corporation.  
*		You have Intel's permission to incorporate this code 
*       into your product, royalty free.  Intel has various 
*	    intellectual property rights which it may assert under
*       certain circumstances, such as if another manufacturer's
*       processor mis-identifies itself as being "GenuineIntel"
*		when the CPUID instruction is executed.
*
*       Intel specifically disclaims all warranties, express or
*       implied, and all liability, including consequential and
*		other indirect damages, for the use of this code, 
*		including liability for infringement of any proprietary
*		rights, and including the warranties of merchantability
*		and fitness for a particular purpose.  Intel does not 
*		assume any responsibility for any errors which may 
*		appear in this code nor any responsibility to update it.
*
*  * Other brands and names are the property of their respective
*    owners.
*
*  Copyright (c) 1995, Intel Corporation.  All rights reserved.
***************************************************************/

#ifndef cpuid_h
#define cpuid_h



// OPCODE DEFINITIONS //////////////////////////////////////////
// #define CPU_ID _asm _emit 0x0f _asm _emit 0xa2 	
#define CPU_ID _asm 0x0f _asm 0xa2 	
						// CPUID instruction

#define RDTSC  _asm _emit 0x0f _asm _emit 0x31	
										// RDTSC instruction


// VERSION DEFINITION //////////////////////////////////////////
#define VERSION		0x0101		// Must be 2 bytes in length. 
								//   First two digits (upper 
								//   byte) is the major version.
								//   Second two digits (lower
								//   byte) is the minor version.
								//   i.e. 0x0100  = major version
								//   of 1 and minor version 00.



// VARIABLE STRUCTURE DEFINITIONS //////////////////////////////
struct TIME_STAMP
{
	DWORD High;					// Upper 32-bits of Time Stamp
								//   Register value
	
	DWORD Low;					// Lower 32-bits of Time Stamp
};								//   Register value



// Function Prototypes /////////////////////////////////////////

/***************************************************************
* WORD wincpuidsupport()
* =================================
* Wincpuidsupport() tells the caller whether the host processor
* supports the CPUID opcode or not.
*
* Inputs: none
*
* Returns:
*  1 = CPUID opcode is supported
*  0 = CPUID opcode is not supported
***************************************************************/

WORD wincpuidsupport();


/***************************************************************
* WORD wincpuid()
* ===============
* This routine uses the standard Intel assembly code to 
* determine what type of processor is in the computer, as
* described in application note AP-485 (Intel Order #241618).
* Wincpuid() returns the CPU type as an integer (that is, 
* 2 bytes, a WORD) in the AX register.
*
* Returns:
*  0 = 8086/88
*  2 = 80286
*  3 = 80386
*  4 = 80486
*  5 = Pentium(R) Processor
*  6 = PentiumPro(R) Processor
*  7 or higher = Processor beyond the PentiumPro6(R) Processor
*
*  Note: This function also sets the global variable clone_flag
***************************************************************/
WORD  wincpuid();


/***************************************************************
* WORD wincpuidext()
* ==================
* Similar to wincpuid(), but returns more data, in the order
* reflecting the actual output of a CPUID instruction execution:
*
* Returns:
* AX(15:14) = Reserved (mask these off in the calling code 
*				before using)
* AX(13:12) = Processor type (00=Standard OEM CPU, 01=OverDrive,
*				10=Dual CPU, 11=Reserved)
* AX(11:8)  = CPU Family (the same 4-bit quantity as wincpuid())
* AX(7:4)   = CPU Model, if the processor supports the CPUID 
*				opcode; zero otherwise
* AX(3:0)   = Stepping #, if the processor supports the CPUID 
*				opcode; zero otherwise
*
*  Note: This function also sets the global variable clone_flag
***************************************************************/
WORD  wincpuidext();


/***************************************************************
* DWORD wincpufeatures()
* ======================
* Wincpufeatures() returns the CPU features flags as a DWORD 
*    (that is, 32 bits).
*
* Inputs: none
*
* Returns:
*   0 = Processor which does not execute the CPUID instruction.
*          This includes 8086, 8088, 80286, 80386, and some 
*		   older 80486 processors.                       
*
* Else
*   Feature Flags (refer to App Note AP-485 for description).
*      This DWORD was put into EDX by the CPUID instruction.
*
*	Current flag assignment is as follows:
*
*		bit31..10   reserved (=0)
*		bit9=1      CPU contains a local APIC (iPentium-3V)
*		bit8=1      CMPXCHG8B instruction supported
*		bit7=1      machine check exception supported
*		bit6=0      reserved (36bit-addressing & 2MB-paging)
*		bit5=1      iPentium-style MSRs supported
*		bit4=1      time stamp counter TSC supported
*		bit3=1      page size extensions supported
*		bit2=1      I/O breakpoints supported
*		bit1=1      enhanced virtual 8086 mode supported
*		bit0=1      CPU contains a floating-point unit (FPU)
*
*	Note: New bits will be assigned on future processors... see
*         processor data books for updated information
*
*	Note: This function also sets the global variable clone_flag
***************************************************************/
DWORD wincpufeatures();


/***************************************************************
* struct TIME_STAMP winrdtsc()
* ============================
* Winrdtsc() returns the value in the Time Stamp Counter (if one
* exists).
*
* Inputs: none
*
* Returns:
*   0 = CPU does not support the time stamp register
*
* Else
*   Returns a variable of type TIME_STAMP which is composed of 
*      two DWORD variables. The 'High' DWORD contains the upper
*      32-bits of the Time Stamp Register. The 'Low' DWORD 
*      contains the lower 32-bits of the Time Stamp Register.
*
*  Note: This function also sets the global variable clone_flag
***************************************************************/
struct TIME_STAMP winrdtsc();


/***************************************************************
* unsigned short getdllversion()
* ==============================
* Getdllversion() returns the Major and minor version of this
* DLL.
*
* Inputs: none
*
* Returns:  Major and Minor version of this DLL.
* 		
*		i.e.	getdllversion() = 0x01 00
*					  Major Version<--|-->Minor Version
*			
***************************************************************/
unsigned short getdllversion(void);



// Private Function Declarations ///////////////////////////////

/***************************************************************
* static WORD check_clone()
*
* Inputs: none
*
* Returns:
*   1      if processor is clone (limited detection ability)
*   0      otherwise
***************************************************************/
static WORD check_clone();


/***************************************************************
* static WORD check_8086()
*
* Inputs: none
*
* Returns: 
*   0      if processor 8086
*   0xffff otherwise
***************************************************************/
static WORD check_8086();


/***************************************************************
* static WORD check_80286()
*
* Inputs: none
*
* Returns:
*   2      if processor 80286
*   0xffff otherwise
***************************************************************/
static WORD check_80286();


/***************************************************************
* static WORD check_80386()
*
* Inputs: none
*
* Returns:
*   3      if processor 80386
*   0xffff otherwise
***************************************************************/
static WORD check_80386();


/***************************************************************
* static WORD check_IDProc()
* ==========================
* Check_IDProc() uses the CPUID opcode to find the family type
* of the host processor.
*
* Inputs: none
*
* Returns:
*  CPU Family (i.e. 4 if Intel 486, 5 if Pentium(R) Processor)
*
*  Note: This function also sets the global variable clone_flag
***************************************************************/
static int check_IDProc(char* vendor);

#endif cpuid_h
