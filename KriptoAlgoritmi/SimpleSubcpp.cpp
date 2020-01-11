#include "SimpleSub.h"

SimpleSub::SimpleSub(unsigned short Lenght, uint8_t* String, uint8_t* Map)
{
	this->charString = (uint8_t*)malloc(Lenght * sizeof(uint8_t));
	this->charMap = (uint8_t*)malloc(Lenght * sizeof(uint8_t));

	memcpy(this->charString, String, Lenght * sizeof(uint8_t));
	memcpy(this->charMap, Map, Lenght * sizeof(uint8_t));

	this->lenght = Lenght;
}

uint8_t* SimpleSub::Encode(uint8_t* string, unsigned long lenght)
{
	uint8_t* data = (uint8_t*)malloc(lenght * sizeof(uint8_t));
	memcpy(data, string, lenght * sizeof(uint8_t));

	for (int i = 0; i < lenght; i++)
	{
		data[i] = this->find(data[i]);
	}

	return data;
}

uint8_t* SimpleSub::Decode(uint8_t* string, unsigned long lenght)
{
	uint8_t* data = (uint8_t*)malloc(lenght * sizeof(uint8_t));
	memcpy(data, string, lenght * sizeof(uint8_t));

	for (int i = 0; i < lenght; i++)
	{
		data[i] = this->findD(data[i]);
	}

	return data;
}

uint8_t SimpleSub::find(uint8_t data)
{
	for (int i = 0; i < this->lenght; i++)
	{
		if (data == this->charString[i])
		{
			return this->charMap[i];
		}
	}

	return data;
}

uint8_t SimpleSub::findD(uint8_t data)
{
	for (int i = 0; i < this->lenght; i++)
	{
		if (data == this->charMap[i])
		{
			return this->charString[i];
		}
	}

	return data;
}