using System;
using System.Windows.Forms;
using KaoQin.Utility;

namespace KaoQin
{
    public partial class JBApply : Form
    { 
        public int completed = 0;

        public ApplyDataModule ApplyData=new ApplyDataModule(){ApplyDate ="2017-05-06",ApplyReson = "软件开发",ApplyTime = "09:00-12:00,13:00-19:00"};
        public string ApplyDateId = "txt_overtimeday";//申请日期控件ID
        public string ApplyTimeId = "txt_timespans";//申请时间控件ID
        public string ApplyReasonId = "tb_remark";//申请原因控件ID
        public string ApplyBtnId = "btn_save";
        public string ApplyTableId = "gv_Tovertimes";//加班列表ID
        public JBApply()
        {
            InitializeComponent();
            this.webBrowser1.Url = new Uri(ConfigHelper.KqUrl); 
            this.webBrowser1.DocumentCompleted+=Login;
            
        }

        #region 登录页面

        private void Login(object sender, WebBrowserDocumentCompletedEventArgs e)
        {  
            string userName_id = "txt_username";
            string pword_id = "txt_pwd";
            string btn_id = "ddd";
            HtmlElement btnSubmit = webBrowser1.Document.All[btn_id];
            HtmlElement tbUserid = webBrowser1.Document.All[userName_id];
            HtmlElement tbPasswd = webBrowser1.Document.All[pword_id];
            if (tbUserid == null || tbPasswd == null || btnSubmit == null)
                return;
            tbUserid.SetAttribute("value", SettingHelper.Setting.UserNo);
            tbPasswd.SetAttribute("value", SettingHelper.Setting.YhKqPwd);
            btnSubmit.InvokeMember("click");
            completed = 0;
            this.webBrowser1.DocumentCompleted += LoginCompleted;
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
                webBrowser1.Navigate("http://10.255.56.31:81/employeeConsols/new_overtime_ofme.aspx");
                webBrowser1.DocumentCompleted -= LoginCompleted;
                webBrowser1.DocumentCompleted += OpenJbApply;
                completed = 0;
            } 
        }

        #endregion

        #region 加班页面
        /// <summary>
        /// 加班页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenJbApply(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                HtmlElement btnSubmit = webBrowser1.Document.All[this.ApplyBtnId];
                HtmlElement applyDate = webBrowser1.Document.All[this.ApplyDateId];
                HtmlElement applyTime = webBrowser1.Document.All[this.ApplyTimeId]; 
                HtmlElement applyReason = webBrowser1.Document.All[this.ApplyReasonId];
                if (applyDate == null || applyTime == null || applyReason == null)
                    return;
                applyDate.SetAttribute("value", this.ApplyData.ApplyDate);
                applyTime.SetAttribute("value", this.ApplyData.ApplyTime); 
                applyReason.SetAttribute("value", this.ApplyData.ApplyReson);
                btnSubmit.InvokeMember("click"); 
                completed = 0;
                webBrowser1.DocumentCompleted -= OpenJbApply;
                this.webBrowser1.DocumentCompleted += JbApplyCompleted;
            }
        }

        #endregion

        #region 加班完成后打开加班申请列表
        /// <summary>
        /// 加班完成后打开加班申请列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JbApplyCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            { 
                this.webBrowser1.DocumentCompleted += LoginCompleted;
                HtmlElement table = webBrowser1.Document.All[this.ApplyTableId];
                if (table.Children[0].Children[1].Children[3].InnerHtml.Trim() == this.ApplyData.ApplyDate.Trim())
                {
                    MessageBox.Show("申请成功!");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("申请失败,请到忆华考勤系统内手工申请!");
                }
                webBrowser1.DocumentCompleted -= JbApplyCompleted;
            }
        }

        #endregion

    }
}
