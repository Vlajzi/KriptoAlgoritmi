using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    class SimpleSub
    {
        private IntPtr referenca;
        public unsafe SimpleSub(UInt64 lenght,byte[] azbuka, byte[] key)
        {
           

            fixed (byte* reA = &azbuka[0])
            {
                fixed (byte* reK = &key[0])
                {
                    referenca = CreateSimpleSub(lenght,reA,reK);
                }
            }
        }

        public unsafe byte[] Encript(ref byte[] data)
        {
            byte* tmp;
            byte[] nov;
            fixed (byte* re = &data[0])
            {
                tmp = SimpleSub_Encript(referenca, re, data.Length);
                nov = new byte[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    nov[i] = tmp[i];
                }
            }


            return nov;

            //System.GC.Collect();
        }

        public unsafe byte[] Decript(ref byte[] data)
        {

            byte* tmp;
            byte[] nov;
            fixed (byte* re = &data[0])
            {
                tmp = SimpleSub_Decript(referenca, re, data.Length);
                nov = new byte[data.Length];
                for (int i = 0; i < data.Length ; i++)
                {
                    nov[i] = tmp[i];
                }
            }

            return nov;

            //System.GC.Collect();
        }



        //c++ funkcije
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreateSimpleSub(UInt64 duzina, byte* azbuka, byte* kljuc);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern byte* SimpleSub_Encript(IntPtr obj, byte* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern byte* SimpleSub_Decript(IntPtr obj, byte* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeleteSimpleSub(out IntPtr obj);
     
    }
}
