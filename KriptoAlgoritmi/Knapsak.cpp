#include "Knapsak.h"
using namespace Test;
Knapsak::Knapsak()
{
	GenKey();
}

void Knapsak::SetKey(uint16_t PublicKey[8], uint8_t PrivateKey[8], uint32_t n, uint16_t im)
{
	this->im = im;
	for (int i = 0; i < 8; i++)
	{
		this->PublicKey[i] = PublicKey[i];
		this->PrivateKey[i] = PrivateKey[i];
	}

	this->n = n;

}

void Knapsak::GenKey()
{
	//srand(time(nullptr)); //PRIVREMENO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	srand(3);

	uint16_t sum = 0;
	for (int i = 0; i < 8; i++)
	{
		if (sum == 254)
		{
			PrivateKey[i] == 255;
		}
		else
		{
			PrivateKey[i] = sum + rand() % 2 + 1;//za sad
		}
		sum += PrivateKey[i];
	}

	n = sum + rand() % 32+1;
	unsigned int m = 2;
	m = rand()%UINT16_MAX;
	//m = 3334;
	while (true)
	{
		

		if (!(m == 0 || m == 1))
		{
			if (gcd(n,m) == 1)
			{
				break;
			}
		}
		m++;
	}

	for (int i = 0; i < 8; i++)
	{
		PublicKey[i] = (PrivateKey[i] * m) % n;
	}
	uint32_t tmp;
	while (true)
	{
		
			tmp = (n * rand() + 1);
			if (tmp%m == 0)
			{
				
				im = tmp / m;
				if (im != 0)
				{
					break;
				}
			}
	}



}

uint16_t* Knapsak::Encript(uint8_t* stream, uint64_t lenght)
{
	uint16_t* rez = (uint16_t*)malloc(sizeof(uint16_t) * lenght);

	int B[8];
	uint8_t value;
	for (int i = 0; i < lenght;i++)
	{
		value = stream[i];
		for (int j = 7; j >= 0; j--)
		{
			B[j] = value % 2;
			value /= 2;
		}

		uint16_t C = 0;

		for (int j = 0; j < 8; j++)
		{
			C += PublicKey[j] * B[j];
		}

		rez[i] = C;

	}
	

	return rez;
}

uint8_t* Knapsak::Decript(uint16_t* stream, uint64_t lenght)
{
	uint8_t* rez = (uint8_t*)malloc(sizeof(uint8_t) * lenght+1);

	uint16_t value;
	uint16_t k = 1;
	long int TC;

	for (int i = 0; i < lenght; i++)
	{
		value = stream[i];
		TC = (im * value) % n;

		uint8_t B[8];
		uint8_t M = 0;
		for (int j = 7; j >= 0; j--)
		{
			M <<= 1;
			if (TC - PrivateKey[j] >= 0)
			{
				B[j] = 1;
				TC -= PrivateKey[j];
			}
			else
			{
				B[j] = 0;
			}
			
		}
		M = 0;
		for (int j = 0; j < 8; j++)
		{
			M <<= 1;
			M += B[j];
		}
		rez[i] = M;
	}

	rez[lenght] = '\0';
	return rez;
}


