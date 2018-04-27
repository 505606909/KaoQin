using System.Configuration;

namespace KaoQin.Utility
{
    public static class ConfigHelper
    {
        /// <summary>
        /// 考勤地址
        /// </summary>
        public static string KqUrl
        {
            get { return ConfigurationSettings.AppSettings["KqUrl"].ToString(); }
        }
        /// <summary>
        /// 考勤更新地址
        /// </summary>
        public static string UpdateUrl
        {
            get { return ConfigurationSettings.AppSettings["UpdateUrl"].ToString(); }
        }
        /// <summary>
        /// 员工自助地址
        /// </summary>
        public static string YGZZ
        {
            get { return ConfigurationSettings.AppSettings["YGZZ"].ToString(); }
        }
         /// <summary>
        /// 数据库连接
        /// </summary>
        public static string ConnectionString
        {
            get { return ConfigurationSettings.AppSettings["ConnectionString"].ToString(); }
        }
         
        

    }
}
