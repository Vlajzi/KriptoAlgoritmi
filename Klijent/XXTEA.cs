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
        public XXTEA()
        {
            referenca = CreateXXTEA();
        }

        public unsafe void Encript( ref string data)
        {
            char[] proba = data.ToCharArray();
          
            fixed (char* re = &proba[0])
            {
                XXTEA_ENCRIPT(referenca, re, proba.Length / 2, key);
            }

            data = new string(proba);
            //System.GC.Collect();
        }

        public unsafe void Decript(ref string data)
        {
            char[] proba = data.ToCharArray();

            fixed (char* re = &proba[0])
            {
                XXTEA_DECRIPT(referenca, re, proba.Length / 2, key);
            }

            data = new string(proba);

        }

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreateXXTEA();
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void XXTEA_ENCRIPT( IntPtr obj, char* v, Int32 n, UInt32[] key);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void XXTEA_DECRIPT(IntPtr obj, char* v, Int32 n, UInt32[] key);

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeleteXXTA(out IntPtr obj);
    }
}
