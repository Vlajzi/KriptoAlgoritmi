#pragma once
#include "XXTEA.h"
#include "PCBC.h"
#include "SHA2.h"
#include "Knapsak.h"

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

//SimpleSub
extern  "C"  __declspec(dllexport)  SimpleSub * __cdecl CreateSimpleSub(uint64_t lenght,uint16_t* alfabet,uint16_t* key) { return new SimpleSub(lenght,alfabet,key); };
extern "C"  __declspec(dllexport)  uint16_t * __cdecl  SimpleSub_Encript(SimpleSub * ref, uint16_t * string, uint64_t lenght) { return ref->Encode(string, lenght); };
extern "C"  __declspec(dllexport)  uint16_t * __cdecl  SimpleSub_Decript(SimpleSub * ref, uint16_t * string, uint64_t lenght) { return ref->Decode(string, lenght); };
extern "C" __declspec(dllexport)  void  __cdecl DeleteSimpleSub(SimpleSub * a) { a->~SimpleSub(); a = nullptr; };


//knapsak
extern  "C"  __declspec(dllexport)  Knapsak * __cdecl CreateKnapsak() { return new Knapsak(); };
extern "C"  __declspec(dllexport)  uint16_t * __cdecl Knapsak_Encript(Knapsak * ref, uint8_t * stream, uint64_t lenght) { return ref->Encript(stream, lenght); };
extern "C"  __declspec(dllexport)  uint8_t * __cdecl Knapsak_Decript(Knapsak * ref, uint16_t * stream, uint64_t lenght) { return ref->Decript(stream, lenght); };
extern "C"  __declspec(dllexport)  void __cdecl Knapsak_SetKey(Knapsak * ref, uint16_t PublicKey[8], uint16_t PrivateKey[8], uint32_t n, uint16_t im) { return ref->SetKey(PublicKey, PrivateKey,n,im); };

extern  "C"  __declspec(dllexport)  uint16_t * __cdecl GetPublicKey(Knapsak * ref) { return ref->GetPublicKey(); };
extern  "C"  __declspec(dllexport)  uint16_t * __cdecl GetPrivateKey(Knapsak * ref) { return ref->GetPrivateKey(); };
extern  "C"  __declspec(dllexport)  uint64_t  __cdecl Get_N(Knapsak * ref) { return ref->Get_N(); };
extern  "C"  __declspec(dllexport)  uint16_t  __cdecl Get_iM(Knapsak * ref) { return ref->Get_iM(); };

extern "C" __declspec(dllexport)  void  __cdecl DeleteKnapsak(Knapsak * a) { a->~Knapsak(); a = nullptr; };