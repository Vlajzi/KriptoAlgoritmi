#define _CRT_SECURE_NO_WARNINGS
#include"SimpleSub.h"
#include"PCBC.h"
#include <iostream>
#include <numeric>
#include "Knapsak.h"
#include "SHA2.h"
#include "HeaderExtern.h"





using namespace std;

char abc[27];
char* map;

void main()
{
	
	map = (char*)malloc(27 * sizeof(char));

	for (int i = 0; i < 26; i++)
	{
		abc[i] = 'a' + i;
	}
	
	map = "ZPBYJRGKFLXQNWVDHMSUTOIAEC";



	cout << "Test";


	XXTEA xt;

	uint32_t key[4] = {1,2,3,4};

	char* txta = (char*)malloc(sizeof(char) * 41);
	char* txtb = (char*)malloc(sizeof(char) * 41);

	uint16_t* txtr = (uint16_t*)malloc(sizeof(uint16_t) * 41);

	//char* txta = "Test 1 2 3. Koder Blokag";

	//txta = "Test 1 2 3. Koder Blokag"; // ne moze
	cout << endl;
	strcpy(txta, "Test 1 2 3. Koder Blokag kako bre to890K");
	/*cout << txta << endl;
	uint32_t initial[2] = {1232322,4132244};

	PCBC proba(initial,2);

	proba.Enkript((uint32_t*)txta, 10, key);

	cout << txta << endl;

	proba.Decript((uint32_t*)txta, 10, key);

	cout << txta << endl; 


	xt.Encript((uint32_t*)txta,10,key);

	cout << txta << endl;

	xt.Decript((uint32_t*)txta, 10, key);

	cout << txta << endl;

	*/


	/*Knapsak kp;

	txtr = (uint16_t*)kp.Encript((uint8_t*)txta,40);

	cout << (char*)txtr << endl;


	txtb = (char*)kp.Decript(txtr, 40);

	cout << txtb << endl;*/

	char* heh = "grape";

	SHA2 sh;

	uint32_t* rez = sh.GetHesh((uint8_t*)heh, strlen(heh));
	
	cout << "kraj";
}