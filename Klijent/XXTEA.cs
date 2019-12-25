using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    class XXTEA
    {
        private IntPtr referenca;
        public UInt32[] key { set; get; }
        public XXTEA(UInt32[] key)
        {
            this.key = key;
            referenca = CreateXXTEA();
        }

        public unsafe void Encript( ref byte[] data)
        {
            //char[] proba = data.ToCharArray();
            fixed (byte* re = &data[0])
            {
                XXTEA_ENCRIPT(referenca, re, data.Length/4, key);
            }

 
         
            //System.GC.Collect();
        }

        public unsafe void Decript(ref byte[] data)
        {
          

            fixed (byte* re = &data[0])
            {
                XXTEA_DECRIPT(referenca, re, data.Length/4, key);
            }


        }

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreateXXTEA();
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void XXTEA_ENCRIPT( IntPtr obj, byte* v, Int32 n, UInt32[] key);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void XXTEA_DECRIPT(IntPtr obj, byte* v, Int32 n, UInt32[] key);

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeleteXXTA(out IntPtr obj);
    }
}
