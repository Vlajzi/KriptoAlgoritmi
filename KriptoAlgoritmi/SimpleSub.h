#pragma once


#include<stdlib.h>
#include<string.h>


template <class T>
class SimpleSub
{
private:
	T* charString;
	T* charMap;
	unsigned long lenght;


	T find(T data);
	SimpleSub() = delete;



	

public:
	SimpleSub(unsigned short Lenght,T* String,T* Map );
	

	T*  Encode(T* string,unsigned long lenght);

};




template <class T>
SimpleSub<T>::SimpleSub(unsigned short Lenght, T* String, T* Map)
{
	this->charString = (T*)malloc(Lenght*sizeof(T));
	this->charMap = (T*)malloc(Lenght*sizeof(T));

	memcpy(this->charString, String, Lenght*sizeof(T));
	memcpy(this->charMap, Map, Lenght*sizeof(T));

	this->lenght = Lenght;
}

template <class T>
T*  SimpleSub<T>::Encode(T* string, unsigned long lenght)
{
	T* data = (T*)malloc(lenght*sizeof(T));
	memcpy(data, string, lenght*sizeof(T));

	for (int i = 0; i < lenght; i++)
	{
		data[i] = this->find(data[i]);
	}

	return data;
}

template <class T>
T SimpleSub<T>::find(T data)
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