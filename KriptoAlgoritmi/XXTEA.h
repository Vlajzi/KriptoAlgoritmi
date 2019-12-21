#pragma once
#include <stdint.h>

class XXTEA
{
public:
	XXTEA();

	void Function(uint32_t* v, int n, uint32_t const key[4]);
public:
	void Encript(uint32_t* v, int n, uint32_t const key[4]);
	void Decript(uint32_t* v, int n, uint32_t const key[4]);


};