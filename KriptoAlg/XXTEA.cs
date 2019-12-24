

using System;

namespace KriptoAlg
{
    public class XXTEA
    {
        const UInt32 DELTA = 0x9e3779b9;


       public XXTEA()
        { 
        }

        unsafe private void Function(ref UInt32[] v, int n, UInt32[] key)
        {

        UInt32 y, z, sum;
        UInt32 p, rounds, e;
        if (n > 1)
        {
            rounds = Convert.ToUInt32(6 + (52 / n));
            sum = 0;
            z = v[n - 1];
            do
            {
                sum += DELTA;
                e = (sum >> 2) & 3;
                for (p = 0; p < n - 1; p++)
                {
                    y = v[p + 1];
                    z = v[p] += (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                }
                y = v[0];
                z = v[n - 1] += (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
            } while ((--rounds != 0));
        }
        else if (n < -1)
        {
            n = -n;
            rounds = Convert.ToUInt32(6 + (52 / n));
                sum = rounds * DELTA;
            y = v[0];
            do
            {
                e = (sum >> 2) & 3;
                for (p = Convert.ToUInt32(n - 1); p > 0; p--)
                {
                    z = v[p - 1];
                    y = v[p] -= (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                }
                z = v[n - 1];
                y = v[0] -= (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                sum -= DELTA;
            } while ((--rounds!= 0));
        }

    }

   unsafe public void Encript(ref UInt32[] v, int n, UInt32[]  key)
    {
        Function(ref v, n, key);
    }

        unsafe public void Decript(ref UInt32[] v, int n, UInt32[] key)
    {
            Function(ref v, -n, key);
    }


}
}
