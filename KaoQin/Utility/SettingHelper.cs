using System;
using System.IO;
using KaoQin.Modules;
using Newtonsoft.Json;

namespace KaoQin.Utility
{
    public static class SettingHelper
    {
        public static SettingMoudle _Setting = null;


        public static SettingMoudle Setting
        {
            get
            {
                if (_Setting == null)
                {
                    var str = File.ReadAllText(SettingHelper.FilePath);
                    str = RsaHelper.Decrypt(str);
                    _Setting = JsonConvert.DeserializeObject<SettingMoudle>(str); 
                }
                return _Setting;
            }
            set
            {
                _Setting = value; 
                string str = JsonConvert.SerializeObject(value);
                str = RsaHelper.Encrypt(str);
                File.WriteAllText(SettingHelper.FilePath, str);
                
            }
        }

        public static string FilePath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "/data.bin"; }
        }
    }
}
