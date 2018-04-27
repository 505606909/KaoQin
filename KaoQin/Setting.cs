using System;
using System.IO;
using System.Windows.Forms;
using KaoQin.Modules;
using KaoQin.Utility;

namespace KaoQin
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
            this.LoadData();   
        }

        private void LoadData()
        {
            if (File.Exists(SettingHelper.FilePath))
            { 
                SettingMoudle sm = SettingHelper.Setting;
                this.txtUserNo.Text = sm.UserNo;
                this.cbAutoRun.Checked = sm.AutoRun;
                this.txtYhApplyReason.Text = sm.YhKqJbResion;
                this.txtYhPword.Text = sm.YhKqPwd;
                this.txtYGZZPword.Text = sm.YGZZPword;
                this.cbRemoveDearTime.Checked = sm.HasRemoveDearTime ?? true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.StartUp(this.cbAutoRun.Checked);
            SettingMoudle sm =new SettingMoudle();
            sm.UserNo = this.txtUserNo.Text;
            sm.AutoRun = this.cbAutoRun.Checked;
            sm.YhKqJbResion = this.txtYhApplyReason.Text;
            sm.YhKqPwd = this.txtYhPword.Text;
            sm.YGZZPword = this.txtYGZZPword.Text;
            sm.HasRemoveDearTime = this.cbRemoveDearTime.Checked;
            if (string.IsNullOrEmpty(sm.UserNo) || string.IsNullOrEmpty(sm.YGZZPword) ||
                string.IsNullOrEmpty(sm.YhKqPwd))
            {
                MessageBox.Show("编号和密码不能为空!");
                return;
            }
            SettingHelper.Setting = sm;

            MessageBox.Show("保存成功!");
            Main main=this.Owner as Main;
            main.Show(); 
            this.Hide();
        }
        /// <summary>  
        /// 修改程序在注册表中的键值  
        /// </summary>  
        /// <param name="flag">1:开机启动</param>  
        private void StartUp(bool flag)
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("\\") + 1);
            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (flag)
            {
                if (Rkey == null)
                {
                    Rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Rkey.SetValue(keyName, path + @"\KaoQin.exe");
            }
            else
            {
                if (Rkey != null)
                {
                    Rkey.DeleteValue(keyName, false);
                }
            }
        }  
    }
}
