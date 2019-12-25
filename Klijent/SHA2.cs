using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    class SHA2
    {
        private IntPtr referenca;
        public SHA2()
        {
            referenca = CreateSHA2();
        }

        public unsafe string GetHesh(ref byte[] data)
        {
           
            UInt32* tmp;
            fixed (byte* re = &data[0])
            {
               tmp = SHA2_GenHesh(referenca, re, data.Length);
            }

            string rez = string.Empty;

            rez = tmp[0].ToString("X");

            for (int i = 1; i < 8; i++)
            {
                rez += tmp[i].ToString("X");
            }
            
            return rez;

            //System.GC.Collect();
        }
     

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreateSHA2();
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern UInt32* SHA2_GenHesh(IntPtr obj, byte* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeleteSHA2(out IntPtr obj);
    }
}
