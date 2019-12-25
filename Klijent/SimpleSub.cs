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
        public unsafe SimpleSub(UInt64 lenght,string azbuka,string key)
        {
            char[] probaA = azbuka.ToCharArray();
            char[] probaK = key.ToCharArray();

            fixed (char* reA = &probaA[0])
            {
                fixed (char* reK = &probaA[0])
                {
                    referenca = CreateSimpleSub(lenght,reA,reK);
                }
            }
        }

        public unsafe string Encript(ref string data)
        {
            char[] proba = data.ToCharArray();
            char* tmp;
            fixed (char* re = &proba[0])
            {
                tmp = SimpleSub_Encript(referenca, re, proba.Length);
            }

            string rez = new string(tmp);

            return rez;

            //System.GC.Collect();
        }

        public unsafe string Decript(ref string data)
        {
            char[] proba = data.ToCharArray();
            char* tmp;
            fixed (char* re = &proba[0])
            {
                tmp = SimpleSub_Decript(referenca, re, proba.Length);
            }

            string rez = new string(tmp);

            return rez;

            //System.GC.Collect();
        }



        //c++ funkcije
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreateSimpleSub(UInt64 duzina, char* azbuka,char* kljuc);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern char* SimpleSub_Encript(IntPtr obj, char* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern char* SimpleSub_Decript(IntPtr obj, char* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeleteSimpleSub(out IntPtr obj);
     
    }
}
