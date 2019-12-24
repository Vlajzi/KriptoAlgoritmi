using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudStore
{
  

    class Proba
    {
        [DllImport("KriptoAlgoritmi.dll")]
        public static extern IntPtr CreateXXTEA();

    }
}
