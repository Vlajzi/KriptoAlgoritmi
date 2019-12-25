using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Klijent
{
    class Knapsak
    {
        private IntPtr referenca;
        public Knapsak()
        {
           
            referenca = CreateKnapsak();//
        }

        public unsafe byte[] Encript(ref byte[] data)
        {
            byte[] nov;

            fixed (byte* re = &data[0])
            {
                byte* tmp;
                tmp = Knapsak_Encript(referenca, re, data.Length);

                nov = new byte[data.Length * 2];
                for(int i = 0; i < data.Length*2;i++)
                {
                    nov[i] = tmp[i];
                }
            }

            return nov;
            //System.GC.Collect();
        }

        public unsafe byte[] Decript(ref byte[] data)
        {

            byte[] nov;
            fixed (byte* re = &data[0])
            {
                byte* tmp;
                tmp = Knapsak_Decript(referenca, re, data.Length/2);
                nov = new byte[data.Length/2];
                for (int i = 0; i < data.Length/2; i++)
                {
                    nov[i] = tmp[i];
                }
            }

            return nov;

        }

        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern IntPtr CreateKnapsak();
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern byte* Knapsak_Encript(IntPtr obj, byte* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern byte* Knapsak_Decript(IntPtr obj, byte* v, Int64 n);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void DeleteKnapsak(out IntPtr obj);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern void Knapsak_SetKey(IntPtr obj, UInt16[] PublicKey, UInt16[] PrivateKey, UInt32 n, UInt16 im);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern UInt16[] GetPublicKey(IntPtr obj);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern UInt16[] GetPrivateKey(IntPtr obj);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern UInt64 Get_N(IntPtr obj);
        [DllImport("KriptoAlgoritmi.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static unsafe extern UInt16 Get_iM(IntPtr obj);

    }
}
