#include"SimpleSub.h"
#include <iostream>


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

	SimpleSub<char> test(26, abc, map);
	
	char* tmpp = test.Encode("does this mean that a simple substitution chiper is secure", 59);

	cout << tmpp << endl;
	cout << "Test";


}