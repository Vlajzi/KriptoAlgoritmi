#pragma once


#include<stdlib.h>
#include<string.h>
#include <cstdint>


class SimpleSub
{
private:
	uint8_t* charString;
	uint8_t* charMap;
	unsigned long lenght;


	uint8_t find(uint8_t data);
	uint8_t findD(uint8_t data);
	SimpleSub() = delete;



	

public:
	SimpleSub(unsigned short Lenght, uint8_t* String, uint8_t* Map );
	

	uint8_t*  Encode(uint8_t* string,unsigned long lenght);
	uint8_t* Decode(uint8_t* string, unsigned long lenght);


};




