#include "SHA2.h"
#include <stdlib.h>
#include <string.h>
#include <stdint.h>

uint32_t* SHA2::GetHesh(uint8_t* message, uint64_t lenght_inByte)//512 bits blok
{
	uint64_t bitLenght = lenght_inByte * 8;
	uint64_t L = lenght_inByte*8;
	uint32_t* rez = (uint32_t*)malloc(sizeof(uint32_t) * 16);
	uint64_t K = 0;

	K = 512 - (bitLenght + 64) % 512;

	uint32_t tmp = K / 8;

	uint8_t* Padding = (uint8_t*)malloc(tmp);

	Padding[0] = 128;

	for (int i = 1; i < tmp; i++)
	{
		Padding[i] = 0;
	}



	bitLenght += K + 65;
	bitLenght /= 8;//u bajtove

	uint8_t* newMessage = (uint8_t*)malloc(sizeof(uint8_t) * bitLenght);

	memcpy(newMessage,message,lenght_inByte);

	memcpy(&newMessage[lenght_inByte], Padding, tmp);

	memcpy(&newMessage[lenght_inByte + tmp], &L, 8);

	uint32_t test2 = ((uint32_t*)newMessage)[0];


	//SvapBuffer(newMessage, bitLenght / 4);
	test2 = ((uint32_t*)newMessage)[0];
	uint32_t test = bitLenght % 64;
	uint32_t chunkCnt = bitLenght / 64;

	uint32_t W[64];

	uint32_t H[8];

	for (int i = 0; i < 8; i++)
	{
		H[i] = h[i];
	}

	for (int i = 0; i < chunkCnt; i++)
	{
		for (int j = 0; j < 16; j++)
		{
			W[j] = ((uint32_t*)newMessage)[i * 16 + j];//svaki 512 bitni cank
		}

		for (int j = 16; j < 64; j++)
		{
			W[j] = SSIG1(W[j - 2]) + W[j - 7] + SSIG0(W[j - 15]) + W[j - 16];
		}


		uint32_t a = H[0];
		uint32_t b = H[1];
		uint32_t c = H[2];
		uint32_t d = H[3];
		uint32_t e = H[4];
		uint32_t f = H[5];
		uint32_t g = H[6];
		uint32_t h_ = H[7];

		for (int j = 0; j < 64; j++)
		{
			uint32_t T1 = h_ + BSIG1(e) + CH(e, f, g) + k[j] + W[j];
			uint32_t T2 = BSIG0(a) + MAJ(a, b, c);
			h_ = g;
			g = f;
			f = e;
			e = d + T1;
			d = c;
			c = b;
			b = a;
			a = T1 + T2;
		}

		H[0] = a + H[0];
		H[1] = b + H[1];
		H[2] = c + H[2];
		H[3] = d + H[3];
		H[4] = e + H[4];
		H[5] = f + H[5];
		H[6] = g + H[6];
		H[7] = h_ + H[7];

	}

	for(int i = 0; i < 8; i++)
	{
		rez[i] = H[i];
	}
	free(Padding);
	return rez;
}

uint32_t SHA2::CH(uint32_t x, uint32_t y, uint32_t z)
{
	return ((x & y) ^ ((~x) & z));
}

uint32_t SHA2::MAJ(uint32_t x, uint32_t y, uint32_t z)
{
	return ((x & y) ^ (x & z) ^ (y & z));
}

int SHA2::leftRotate(uint32_t n, uint32_t d)
{
	return (n << d) | (n >> (INT_BITS - d));
}

int SHA2::rightRotate(uint32_t n, uint32_t d)
{
	return (n >> d) | (n << (INT_BITS - d));
}

void SHA2::SvapBuffer(uint8_t* message, uint32_t size)
{
	uint8_t tmp = 0;
	for (int i = 0; i < size; i+=4)
	{
		tmp = message[i];
		message[i] = message[i + 3];
		message[i + 3] = tmp;
		tmp = message[i + 1];
		message[i + 1] = message[i + 2];
		message[i + 2] = tmp;
	}
}

uint32_t SHA2::BSIG0(uint32_t x)
{
	return ((rightRotate(x, 12)) ^ (rightRotate(x, 13)) ^ (rightRotate(x, 22)));
}

uint32_t SHA2::BSIG1(uint32_t x)
{
	return ((rightRotate(x, 6)) ^ (rightRotate(x, 11)) ^ (rightRotate(x, 25)));
}

uint32_t SHA2::SSIG0(uint32_t x)
{
	return ((rightRotate(x, 7)) ^ (rightRotate(x, 18)) ^ (x >> 3));
}

uint32_t SHA2::SSIG1(uint32_t x)
{
	return ((rightRotate(x, 17)) ^ (rightRotate(x, 19)) ^ (x >> 10));
}
