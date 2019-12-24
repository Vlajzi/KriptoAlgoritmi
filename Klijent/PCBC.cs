using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    class PCBC
    {
        private IntPtr referenca;
        public UInt32[] key { set; get; }
        public unsafe PCBC(ref UInt32[] init,UInt32[] key)
        {
            this.key = key;
            fixed (UInt32* refInti = &init[0])
            {
                referenca = CreatePCBC(refInti, init.Length);
            }

        }

        public unsafe void Encript(ref string data)
        {
            char[] proba = data.ToCharArray();

            fixed (char* re = &proba[0])
            {
                PCBC_Enkript(referenca, re, proba.Length / 2, key);
            }

            data = new string(proba);
            //System.GC.Collect();
        }

        public unsafe void Decript(ref string data)
        {
            char[] proba = data.ToCharArray();

            fixed (char* re = &proba[0])
            {
                PCBC_Decript(referenca, re, proba.Length / 2, key);
            }

            data = new string(proba);

        }

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreatePCBC(UInt32* init,int lenght);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void PCBC_Enkript(IntPtr obj, char* v, Int32 n, UInt32[] key);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void PCBC_Decript(IntPtr obj, char* v, Int32 n, UInt32[] key);

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeletePCBC(out IntPtr obj);
    }
}
