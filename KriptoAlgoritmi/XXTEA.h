#pragma once
#include <stdint.h>

class XXTEA
{
public:
	XXTEA();
	~XXTEA() = default;
	void Function(uint32_t* v, int n, uint32_t const key[4]);
public:
	void Encript(uint32_t* v, int n, uint32_t const key[4]);
	void Decript(uint32_t* v, int n, uint32_t const key[4]);



};




