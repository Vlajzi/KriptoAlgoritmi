
#include "PCBC.h"


PCBC::PCBC(uint32_t* init, int lenght)
{
	this->initialVektor = nullptr;
	this->initialVektor = (uint32_t*)malloc(lenght * sizeof(uint32_t));
	memcpy(initialVektor, init, lenght * sizeof(uint32_t));
	this->lenght = lenght;
}

PCBC::~PCBC()
{
	if (initialVektor != nullptr)
	{
		delete [] initialVektor;
		initialVektor = nullptr;
	}
}

bool PCBC::Enkript(uint32_t* v, int n, uint32_t const key[4])
{
	bool state = true;

	if (n < lenght)
	{
		return false;
	}
	uint32_t blokSize = sizeof(uint32_t) * lenght;
	uint32_t* helpVector = (uint32_t*)malloc(blokSize);
	uint32_t* xorVector = (uint32_t*)malloc(blokSize);


	memcpy(xorVector, initialVektor, blokSize);

	if (n % lenght != 0)
	{
		return false;
	}
	for (int i = 0; i < n; i+=lenght)
	{

		memcpy(helpVector, &v[i], blokSize);

		for (int j = 0; j < lenght; j++)//xor tmp
		{

			v[i+j] = v[i+j] ^ xorVector[j];
		}

		kriptoAlg.Encript(&v[i], lenght, key);


		for (int j = 0; j < lenght; j++)//xor tmp
		{

			xorVector[j] = v[i+j] ^ helpVector[j];
		}
	}

	free(helpVector);
	free(xorVector);
	return true;
}


bool PCBC::Decript(uint32_t* v, int n, uint32_t const key[4])
{
	bool state = true;

	if (n < lenght)
	{
		return false;
	}
	uint32_t blokSize = sizeof(uint32_t) * lenght;
	uint32_t* helpVector = (uint32_t*)malloc(blokSize);
	uint32_t* xorVector = (uint32_t*)malloc(blokSize);


	memcpy(xorVector, initialVektor, blokSize);

	if (n % lenght != 0)
	{
		return false;
	}
	for (int i = 0; i < n; i += lenght)
	{

		memcpy(helpVector, &v[i], blokSize);

		kriptoAlg.Decript(&v[i], lenght, key);

		for (int j = 0; j < lenght; j++)//xor tmp
		{

			v[i+j] = v[i+j] ^ xorVector[j];
		}

		for (int j = 0; j < lenght; j++)//xor tmp
		{

			xorVector[j] = v[i+j] ^ helpVector[j];
		}

		
	}

	free(helpVector);
	free(xorVector);
	return true;
}

void PCBC::Xor(uint32_t* dst, uint32_t* parm1, uint32_t* parm2)
{
	for (int j = 0; j < lenght; j++)//xor
	{

		dst[j] = parm1[j] ^ parm2[j];
	}
}
