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

        public unsafe void Encript(ref byte[] data)
        {
  

            fixed (byte* re = &data[0])
            {
                PCBC_Enkript(referenca, re, data.Length/4 , key);
            }

           
            //System.GC.Collect();
        }

        public unsafe void Decript(ref byte[] data)
        {
            

            fixed (byte* re = &data[0])
            {
                PCBC_Decript(referenca, re, data.Length / 4, key);
            }


        }

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreatePCBC(UInt32* init,int lenght);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void PCBC_Enkript(IntPtr obj, byte* v, Int32 n, UInt32[] key);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void PCBC_Decript(IntPtr obj, byte* v, Int32 n, UInt32[] key);

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeletePCBC(out IntPtr obj);
    }
}
