namespace KaoQin
{
    partial class Setting
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
            this.cbAutoRun = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtYhApplyReason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYhPword = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtYGZZPword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRemoveDearTime = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAutoRun
            // 
            this.cbAutoRun.AutoSize = true;
            this.cbAutoRun.Location = new System.Drawing.Point(228, 15);
            this.cbAutoRun.Name = "cbAutoRun";
            this.cbAutoRun.Size = new System.Drawing.Size(84, 16);
            this.cbAutoRun.TabIndex = 2;
            this.cbAutoRun.Text = "开机自启动";
            this.cbAutoRun.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtYhApplyReason);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtYhPword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 54);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "忆华考勤";
            // 
            // txtYhApplyReason
            // 
            this.txtYhApplyReason.Location = new System.Drawing.Point(282, 16);
            this.txtYhApplyReason.Name = "txtYhApplyReason";
            this.txtYhApplyReason.Size = new System.Drawing.Size(403, 21);
            this.txtYhApplyReason.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "加班原因:";
            // 
            // txtYhPword
            // 
            this.txtYhPword.Location = new System.Drawing.Point(47, 16);
            this.txtYhPword.Name = "txtYhPword";
            this.txtYhPword.PasswordChar = '*';
            this.txtYhPword.Size = new System.Drawing.Size(136, 21);
            this.txtYhPword.TabIndex = 3;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(59, 13);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(136, 21);
            this.txtUserNo.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(321, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtYGZZPword);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(691, 54);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "员工自助(用于读取考勤记录)";
            // 
            // txtYGZZPword
            // 
            this.txtYGZZPword.Location = new System.Drawing.Point(47, 16);
            this.txtYGZZPword.Name = "txtYGZZPword";
            this.txtYGZZPword.PasswordChar = '*';
            this.txtYGZZPword.Size = new System.Drawing.Size(136, 21);
            this.txtYGZZPword.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "密码:";
            // 
            // cbRemoveDearTime
            // 
            this.cbRemoveDearTime.AutoSize = true;
            this.cbRemoveDearTime.Checked = true;
            this.cbRemoveDearTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemoveDearTime.Location = new System.Drawing.Point(20, 195);
            this.cbRemoveDearTime.Name = "cbRemoveDearTime";
            this.cbRemoveDearTime.Size = new System.Drawing.Size(180, 16);
            this.cbRemoveDearTime.TabIndex = 9;
            this.cbRemoveDearTime.Text = "是否默认扣除加班餐用餐时间";
            this.cbRemoveDearTime.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 335);
            this.Controls.Add(this.cbRemoveDearTime);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAutoRun);
            this.Name = "Setting";
            this.Text = "系统设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAutoRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtYhApplyReason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYhPword;
        private System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtYGZZPword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbRemoveDearTime;
    }
}