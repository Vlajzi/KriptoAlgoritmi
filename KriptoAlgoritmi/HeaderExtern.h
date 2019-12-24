#pragma once
#include "XXTEA.h"

extern  "C"  __declspec(dllexport)  XXTEA * __cdecl CreateXXTEA() { return new XXTEA; };
extern "C"  __declspec(dllexport)  void __cdecl  XXTEA_ENCRIPT(XXTEA * ref, uint32_t * v, int n, uint32_t const key[4]) { ref->Encript(v, n, key); };
extern "C"  __declspec(dllexport)  void __cdecl  XXTEA_DECRIPT(XXTEA * ref, uint32_t * v, int n, uint32_t const key[4]) { ref->Decript(v, n, key); };
extern "C" __declspec(dllexport)  void  __cdecl DeleteXXTA(XXTEA* a) { a->~XXTEA(); a = nullptr; };