using System;
using System.Collections.Generic;
using System.IO;
using KaoQin.Modules;

namespace KaoQin.Utility
{
 
    public static class KaoQinDataHelper
    {
        
        public static List<KQDataModule> GetData(DateTime dt)
        {
            List<KQDataModule> rtn=new List<KQDataModule>();
            string filePath= AppDomain.CurrentDomain.BaseDirectory+"/KQData/"+dt.ToString("yyyy-MM-dd.bin");
            if (File.Exists(filePath))
            {
                string s = File.ReadAllText(filePath);
            }
            return rtn;
        }
    }
}
