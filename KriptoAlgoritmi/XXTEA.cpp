#include "XXTEA.h"


#define DELTA 0x9e3779b9
#define MX (((z>>5^y<<2) + (y>>3^z<<4)) ^ ((sum^y) + (key[(p&3)^e] ^ z)))


XXTEA::XXTEA()
{
}

void XXTEA::Function(uint32_t* v, int n, uint32_t const key[4])
{

    uint8_t* test = (uint8_t*)v;
         uint32_t y, z, sum;
        uint32_t p, rounds, e;
        if (n > 1) {          
            rounds = 6 + 52 / n;
            sum = 0;
            z = v[n - 1];
            do {
                sum += DELTA;
                e = (sum >> 2) & 3;
                for (p = 0; p < n - 1; p++) {
                    y = v[p + 1];
                    z = v[p] += MX;
                }
                y = v[0];
                z = v[n - 1] += MX;
            } while (--rounds);
        }
        else if (n < -1) {  
            n = -n;
            rounds = 6 + 52 / n;
            sum = rounds * DELTA;
            y = v[0];
            do {
                e = (sum >> 2) & 3;
                for (p = n - 1; p > 0; p--) {
                    z = v[p - 1];
                    y = v[p] -= MX;
                }
                z = v[n - 1];
                y = v[0] -= MX;
                sum -= DELTA;
            } while (--rounds);
        }
 
}

void XXTEA::Encript(uint32_t* v, int n, uint32_t const key[4])
{
    Function(v, n, key);
}

void XXTEA::Decript(uint32_t* v, int n, uint32_t const key[4])
{
    Function(v, -n, key);
}

