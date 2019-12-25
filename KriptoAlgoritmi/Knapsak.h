#pragma once
#include <cstdint>
#include <random>
#include <ctime>




	class Knapsak
	{
	public:
		uint16_t PrivateKey[8];
		unsigned int n;
		uint16_t im;
	public:
		uint16_t PublicKey[8];

		Knapsak();

		void SetKey(uint16_t PublicKey[8], uint16_t PrivateKey[8], uint32_t n, uint16_t im);
		void GenKey();
		uint16_t* Encript(uint8_t* stream, uint64_t lenght);
		uint8_t* Decript(uint16_t* stream, uint64_t lenght);
		uint16_t* GetPublicKey();
		uint16_t* GetPrivateKey();
		uint64_t Get_N();
		uint16_t Get_iM();



	private:
		static int gcd(int a, int b) {
			if (b == 0)
				return a;
			return gcd(b, a % b);
		}

	};
