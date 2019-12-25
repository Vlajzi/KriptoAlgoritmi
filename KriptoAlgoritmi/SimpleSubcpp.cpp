#include "SimpleSub.h"

SimpleSub::SimpleSub(unsigned short Lenght, uint16_t* String, uint16_t* Map)
{
	this->charString = (uint16_t*)malloc(Lenght * sizeof(uint16_t));
	this->charMap = (uint16_t*)malloc(Lenght * sizeof(uint16_t));

	memcpy(this->charString, String, Lenght * sizeof(uint16_t));
	memcpy(this->charMap, Map, Lenght * sizeof(uint16_t));

	this->lenght = Lenght;
}

uint16_t* SimpleSub::Encode(uint16_t* string, unsigned long lenght)
{
	uint16_t* data = (uint16_t*)malloc(lenght * sizeof(uint16_t));
	memcpy(data, string, lenght * sizeof(uint16_t));

	for (int i = 0; i < lenght; i++)
	{
		data[i] = this->find(data[i]);
	}

	return data;
}

uint16_t* SimpleSub::Decode(uint16_t* string, unsigned long lenght)
{
	uint16_t* data = (uint16_t*)malloc(lenght * sizeof(uint16_t));
	memcpy(data, string, lenght * sizeof(uint16_t));

	for (int i = 0; i < lenght; i++)
	{
		data[i] = this->findD(data[i]);
	}

	return data;
}

uint16_t SimpleSub::find(uint16_t data)
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

uint16_t SimpleSub::findD(uint16_t data)
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