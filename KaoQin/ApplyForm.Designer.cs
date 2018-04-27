namespace KaoQin
{
    partial class ApplyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtApplyDate = new System.Windows.Forms.DateTimePicker();
            this.txtApplyTime = new System.Windows.Forms.TextBox();
            this.txtApplyReason = new System.Windows.Forms.TextBox();
            this.cbHasRemoveDearTime = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请日期:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "申请时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "申请原因:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(277, 227);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(139, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "提交";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(573, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtApplyDate
            // 
            this.dtApplyDate.CustomFormat = "yyyy-MM-dd";
            this.dtApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtApplyDate.Location = new System.Drawing.Point(106, 24);
            this.dtApplyDate.Name = "dtApplyDate";
            this.dtApplyDate.Size = new System.Drawing.Size(200, 21);
            this.dtApplyDate.TabIndex = 5;
            // 
            // txtApplyTime
            // 
            this.txtApplyTime.Location = new System.Drawing.Point(106, 51);
            this.txtApplyTime.Name = "txtApplyTime";
            this.txtApplyTime.Size = new System.Drawing.Size(200, 21);
            this.txtApplyTime.TabIndex = 6;
            // 
            // txtApplyReason
            // 
            this.txtApplyReason.Location = new System.Drawing.Point(106, 79);
            this.txtApplyReason.Multiline = true;
            this.txtApplyReason.Name = "txtApplyReason";
            this.txtApplyReason.Size = new System.Drawing.Size(397, 74);
            this.txtApplyReason.TabIndex = 7;
            // 
            // cbHasRemoveDearTime
            // 
            this.cbHasRemoveDearTime.AutoSize = true;
            this.cbHasRemoveDearTime.Checked = true;
            this.cbHasRemoveDearTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHasRemoveDearTime.ForeColor = System.Drawing.Color.Red;
            this.cbHasRemoveDearTime.Location = new System.Drawing.Point(106, 177);
            this.cbHasRemoveDearTime.Name = "cbHasRemoveDearTime";
            this.cbHasRemoveDearTime.Size = new System.Drawing.Size(144, 16);
            this.cbHasRemoveDearTime.TabIndex = 8;
            this.cbHasRemoveDearTime.Text = "扣除加班餐用餐半小时";
            this.cbHasRemoveDearTime.UseVisualStyleBackColor = true;
            this.cbHasRemoveDearTime.CheckedChanged += new System.EventHandler(this.cbHasRemoveDearTime_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(277, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "可在设置页面配置是否默认勾选";
            // 
            // ApplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbHasRemoveDearTime);
            this.Controls.Add(this.txtApplyReason);
            this.Controls.Add(this.txtApplyTime);
            this.Controls.Add(this.dtApplyDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ApplyForm";
            this.Text = "考勤助手提醒您申请加班单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtApplyDate;
        private System.Windows.Forms.TextBox txtApplyTime;
        private System.Windows.Forms.TextBox txtApplyReason;
        private System.Windows.Forms.CheckBox cbHasRemoveDearTime;
        private System.Windows.Forms.Label label4;
    }
}