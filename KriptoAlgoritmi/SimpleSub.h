#pragma once


#include<stdlib.h>
#include<string.h>
#include <cstdint>


class SimpleSub
{
private:
	uint16_t* charString;
	uint16_t* charMap;
	unsigned long lenght;


	uint16_t find(uint16_t data);
	uint16_t findD(uint16_t data);
	SimpleSub() = delete;



	

public:
	SimpleSub(unsigned short Lenght, uint16_t* String, uint16_t* Map );
	

	uint16_t*  Encode(uint16_t* string,unsigned long lenght);
	uint16_t* Decode(uint16_t* string, unsigned long lenght);


};




