using System;
using System.Windows.Forms;
using KaoQin.Utility;

namespace KaoQin
{
    /// <summary>
    /// 读取考勤数据
    /// </summary>
    public partial class ReadKqData : Form
    {
        public ReadKqData()
        {
            InitializeComponent();
            Login();

        }

        public void Login()
        {
            this.webBrowser1.Url = new Uri(ConfigHelper.YGZZ + "/login2.aspx");
            this.webBrowser1.DocumentCompleted+=OpenLogin;
        }
        #region 打开登录界面

        /// <summary>
        /// 打开登录界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenLogin(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {

                HtmlElement tbUserid = webBrowser1.Document.All["tbUser"];
                HtmlElement tbPasswd = webBrowser1.Document.All["tbPassWord"];
                HtmlElement btnSubmit = webBrowser1.Document.All["btnLogin"];
                if (tbUserid == null || tbPasswd == null || btnSubmit == null)
                    return;
                tbUserid.SetAttribute("value", SettingHelper.Setting.UserNo);
                tbPasswd.SetAttribute("value", SettingHelper.Setting.YGZZPword);
                btnSubmit.InvokeMember("click");
                this.webBrowser1.DocumentCompleted -= OpenLogin;
                this.webBrowser1.DocumentCompleted += LoginCompleted;
            }
        }

        #endregion
        #region 登录完成

        /// <summary>
        /// 登录完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                Uri url = new Uri(ConfigHelper.YGZZ + "/Attendance/KaoQinList.aspx"); ;
                this.webBrowser1.Navigate(url, "_self", null, "Referer:" + ConfigHelper.YGZZ + "/ygzz/menu.aspx,Cache-Control:no-cache,Pragma:no-cache");
              
                //this.webBrowser1.Url = new Uri(ConfigHelper.YGZZ + "/ygzz/Attendance/KaoQinList1.aspx");
                 
                this.webBrowser1.DocumentCompleted -= LoginCompleted;
                this.webBrowser1.DocumentCompleted += OpenKqList;
            }
        }

        #endregion

        #region 打开考勤列表
        private bool IsNullDate(string dateTime)
        {
            
            if (string.IsNullOrEmpty(dateTime))
            {
                return true;
            }
            dateTime = dateTime.Trim();
            if(dateTime== "暂无")
            {
                return true;
            }
            if (dateTime == "未考勤")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 登录完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenKqList(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ApplyDataModule jiaban=new ApplyDataModule();
            string msg = "上个月最后一天数据请手动申请!";
            bool hasReadData = false;
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                this.webBrowser1.DocumentCompleted -= OpenKqList;
                var gridId = "form1";
                //读取当月数据 
                HtmlElementCollection trs = webBrowser1.Document.All[gridId].Children[4].Children[1].Children[0].Children;
                
                for (int i = trs.Count-1; i>0;i--)
                {
                    var tr = trs[i];
                    if (tr.TagName.ToLower() != "tr") { continue;}
                    var date = tr.Children[0].Children[0].InnerText.Trim();
                    DateTime applyDate = DateTime.Parse(date);
                    if (applyDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        continue;//当天的不处理;
                    }
                    var weekDay = tr.Children[1].InnerText.Trim();
                    var startTimeStr = tr.Children[3].InnerText.Trim(); 
                    var endTimeStr=tr.Children[5].InnerText.Trim();
                    if (IsNullDate(startTimeStr)&&IsNullDate(endTimeStr))
                    {
                        continue;
                    }
                    if (IsNullDate(endTimeStr))
                    {
                        msg = ("没有下班时间,无法申请加班!");
                        break;
                    } 
                    if(IsNullDate(startTimeStr))
                    {
                        startTimeStr = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    var startTime = DateTime.Parse( startTimeStr);
                    var endTime = DateTime.Parse(endTimeStr);
                    if (endTime == startTime)
                    {
                        msg = ("请检查上下班考勤,是否有未打卡现象");
                        break;
                    }
                    if ((endTime - startTime).Hours < 1)
                    { 
                        Application.Exit();
                        break;
                    }
                    if (startTime.Minute <= 30)
                    {
                        startTime = DateTime.Parse(startTime.ToString("yyyy-MM-dd HH:30"));
                    }
                    else
                    {
                        startTime = DateTime.Parse(startTime.AddHours(1).ToString("yyyy-MM-dd HH:00"));
                    }
                    if (endTime.Minute < 30)
                    {
                        endTime = DateTime.Parse(endTime.ToString("yyyy-MM-dd HH:00"));
                    }
                    else
                    {
                        endTime = DateTime.Parse(endTime.ToString("yyyy-MM-dd HH:30"));
                    }
                    jiaban.ApplyDate = applyDate.ToString("yyyy-MM-dd");
                    if (weekDay.Trim() == "星期六" || weekDay == "星期日")
                    {
                        if (startTime.Hour < 12 && endTime.Hour > 13)
                        {
                            jiaban.ApplyTime += string.Format("{0}-12:00,13:00-{1}", startTime.ToString("HH:mm"),
                                endTime.ToString("HH:mm"));
                            hasReadData = true;
                            ApplyJB(jiaban);
                            break;
                        }
                        else
                        {
                            msg = (string.Format("[{0}][{1}-{2}]不标准的的上下班时间,请手动申请!"
                                , applyDate.ToString("yyyy-MM-dd")
                                , startTime.ToString("HH:mm")
                                , endTime.ToString("HH:mm")
                            ));
                        }

                    }
                    else
                    {
                        jiaban.ApplyTime += string.Format("18:00-{0}", endTime.ToString("HH:mm"));
                        hasReadData = true;
                        ApplyJB(jiaban);
                        break;
                    } 
                }
                //读取表格数据;
                if (!hasReadData)
                {
                    MessageBox.Show(msg);
                }
            }
        }

        private void ApplyJB(ApplyDataModule applyData)
        {
            /*如果上班时间和下班时间差小于1个小时.则不提交加班*/
            string[] dateArr = applyData.ApplyTime.Split('-');
            DateTime dtBegin = DateTime.Parse("2000-01-01 " + dateArr[0] + ":00");
            DateTime dtEnd = DateTime.Parse("2000-01-01 " + dateArr[dateArr.Length-1] + ":00");
            if ((dtEnd-dtBegin).Minutes<0)
            {
                Application.Exit();
            }
            ApplyForm app = new ApplyForm(applyData); 
            app.Show();
            this.Hide();
        }

        #endregion
    }
}
