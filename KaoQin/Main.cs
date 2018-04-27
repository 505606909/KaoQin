using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using KaoQin.Modules;
using KaoQin.Utility;

namespace KaoQin
{
    public partial class Main : Form
    {
        public WorkTimeModule WorkTime=new WorkTimeModule();
        
        public Main()
        {
            InitializeComponent();
            System.Threading.Thread re = new System.Threading.Thread(Register);
            re.Start();
            this.CheckUpdate(); 
            this.Visible = true;
            Init();
        }

        private void Init()
        {
            
            if (this.CheckRunFirst())
            {
                ReadKqData();
            } 
        }
        /// <summary>
        /// 注册
        /// </summary>
        private void Register()
        {
            try
            {
                string ip = System.Net.Dns.GetHostByName(System.Environment.MachineName).AddressList[0].ToString();

                string pcName = System.Net.Dns.GetHostByName(System.Environment.MachineName).HostName;
                WsRegesiter.Regesiter re = new WsRegesiter.Regesiter();
                re.Set(pcName, ip);
            }
            catch (Exception)
            {
                 
            }
          

        }

        public void ReadKqData()
        {
            ReadKqData kqData = new ReadKqData();
            this.notifyIcon1.ContextMenuStrip = myMenu;
            kqData.Visible = false;
            kqData.Owner = this;
            kqData.Show();
        }

        public void CheckUpdate() 
        {
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple(ConfigHelper.UpdateUrl);
        }

        public bool CheckRunFirst()
        {
            /*是否第一次运行*/
            if (!File.Exists(SettingHelper.FilePath))
            {
                Setting st=new Setting();
                st.Text = "首次运行,请配置参数!";
                st.Owner = this;
                st.Show();
                this.Hide();
                return false;
            }
            return true;
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            Setting st = new Setting(); 
            st.Owner = this;
            st.Show();
            this.Hide(); 
        }
         

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
          
            this.timer1.Stop();
        }

        //private void Main_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生           
        //    {
        //        e.Cancel = true;
        //        this.ShowInTaskbar = false;
        //        this.notifyIcon1.Icon = this.Icon;
        //        this.Hide();
        //    }      
        //}

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                myMenu.Show();
            }

            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                { 
                    this.Visible = false;
                    this.WindowState = FormWindowState.Minimized;
                }
            }        
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        private void Main_Load(object sender, EventArgs e)
        {

        
        }

        //private void Main_MinimumSizeChanged(object sender, EventArgs e)
        //{
        //    this.ShowInTaskbar = false;
        //    this.notifyIcon1.Icon = this.Icon;
        //    this.Hide();
        //}
         
 
    }
}
