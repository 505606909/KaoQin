using System;
using System.Windows.Forms;
using KaoQin.Utility;

namespace KaoQin
{
    public partial class ApplyForm : Form
    {
        public ApplyDataModule ApplyData;
        public ApplyForm(ApplyDataModule applyData)
        {
            InitializeComponent();
            this.ApplyData = applyData;
            LoadData();
        }

        private void LoadData()
        {
            this.dtApplyDate.Value = DateTime.Parse(this.ApplyData.ApplyDate);
            this.txtApplyTime.Text = this.ApplyData.ApplyTime;
            this.txtApplyReason.Text = SettingHelper.Setting.YhKqJbResion; ;
            this.cbHasRemoveDearTime.Checked = SettingHelper.Setting.HasRemoveDearTime ?? true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.ApplyData.ApplyDate = this.dtApplyDate.Value.ToString("yyyy-MM-dd");
            this.ApplyData.ApplyTime = this.txtApplyTime.Text;
            this.ApplyData.ApplyReson=this.txtApplyReason.Text;
            if (string.IsNullOrEmpty(this.ApplyData.ApplyReson))
            {
                MessageBox.Show("加班原因不能为空!");
                return;
            }
            JBApply jbApply=new JBApply();
            jbApply.ApplyData = this.ApplyData;
            jbApply.Visible = false;
            jbApply.Show();
            this.Hide();
        }
        /// <summary>
        /// 是否扣除加班半个小时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHasRemoveDearTime_CheckedChanged(object sender, EventArgs e)
        {
            string offTime = "17:30";
            string dearOffTime = "18:00";
            if (cbHasRemoveDearTime.Checked)
            {
                this.txtApplyTime.Text = this.txtApplyTime.Text.Replace(offTime, dearOffTime);
            }
            else
            {
                this.txtApplyTime.Text = this.txtApplyTime.Text.Replace( dearOffTime,offTime);
            }
        }
    }
}
