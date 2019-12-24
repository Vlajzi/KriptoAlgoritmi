#pragma once
#include <cstdint>

#include <stdlib.h>
#include<string.h>
#include "XXTEA.h"

class PCBC
{
private:
	XXTEA kriptoAlg;
	uint32_t* initialVektor;
	int lenght;
public:
	PCBC(uint32_t* init ,int lenght);
	~PCBC();



	bool Enkript(uint32_t* v, int n,uint32_t const key[4]);
	bool Decript(uint32_t* v, int n, uint32_t const key[4]);

private:
	void Xor(uint32_t* dst, uint32_t* parm1, uint32_t* parm2);



};