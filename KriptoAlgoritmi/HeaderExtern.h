#pragma once
#include "XXTEA.h"
#include "PCBC.h"
#include "SHA2.h"

//XXTEA
extern  "C"  __declspec(dllexport)  XXTEA * __cdecl CreateXXTEA() { return new XXTEA; };
extern "C"  __declspec(dllexport)  void __cdecl  XXTEA_ENCRIPT(XXTEA * ref, uint32_t * v, int n, uint32_t const key[4]) { ref->Encript(v, n, key); };
extern "C"  __declspec(dllexport)  void __cdecl  XXTEA_DECRIPT(XXTEA * ref, uint32_t * v, int n, uint32_t const key[4]) { ref->Decript(v, n, key); };
extern "C" __declspec(dllexport)  void  __cdecl DeleteXXTA(XXTEA* a) { a->~XXTEA(); a = nullptr; };




//PCBC
extern  "C"  __declspec(dllexport)  PCBC * __cdecl CreatePCBC(uint32_t * init, int lenght) { return new PCBC(init,lenght); };
extern "C"  __declspec(dllexport)  void __cdecl  PCBC_Enkript(PCBC * ref, uint32_t * v, int n, uint32_t const key[4]) { ref->Enkript(v, n, key); };
extern "C"  __declspec(dllexport)  void __cdecl  PCBC_Decript(PCBC * ref, uint32_t * v, int n, uint32_t const key[4]) { ref->Decript(v, n, key); };
extern "C" __declspec(dllexport)  void  __cdecl DeletePCBC(PCBC * a) { a->~PCBC(); a = nullptr; };


//SHA2
extern  "C"  __declspec(dllexport)  SHA2 * __cdecl CreateSHA2() { return new SHA2() ; };
extern "C"  __declspec(dllexport)  uint32_t* __cdecl  SHA2_GenHesh(SHA2 * ref, uint8_t * message, uint64_t lenght) { return ref->GetHesh(message,lenght); };
extern "C" __declspec(dllexport)  void  __cdecl DeleteSHA2(SHA2 * a) { a->~SHA2(); a = nullptr; };