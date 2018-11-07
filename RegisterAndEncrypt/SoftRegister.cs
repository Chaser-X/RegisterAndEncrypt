using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterAndEncrypt
{
    public static class SoftRegister
    {
        public static void RegisterID()
        {
            var content = HardWareInfo.GetInfo(HardWareInfo.InfoType.CPUID);
            var encryptstring =DESEncrypt.Encrypt(content);
            Registry.SetValue(Registry.LocalMachine.Name +  "\\SOFTWARE\\mySoftWare", "License", encryptstring);
        }

        public static void UnLoadID()
        {
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE" , true);
            key.DeleteSubKey("mySoftWare", false);
        }

        public static bool VerifyID()
        {
            var content = HardWareInfo.GetInfo(HardWareInfo.InfoType.CPUID);
            try
            {
                var license = Registry.GetValue(Registry.LocalMachine.Name + "\\SOFTWARE\\mySoftWare", "License", null);
                var decryptstring = DESEncrypt.Decrypt(license.ToString());
                return decryptstring == content;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
