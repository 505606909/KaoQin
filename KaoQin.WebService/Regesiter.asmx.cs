 
using System;
using System.IO;
using System.Web.Services;

namespace KaoQin.WebService
{
    /// <summary>
    /// Regesiter 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Regesiter : System.Web.Services.WebService
    {

        #region 设定IP和PCName
            
        [WebMethod]
        public void Set(string pcName,string ip)
        {

            try
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "/User";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath += "/"+(pcName + ip).Replace(".", "_") + ".txt"; 
                File.WriteAllText(filePath, string.Format("{0}|{1}|{2}", pcName, ip,
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch
            {
                //ignore
            }

        }

        #endregion
    }
}
