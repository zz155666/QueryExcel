namespace EcPCclient
{
    partial class DownloadFormcs
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
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.pgbProgress = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.ChooseDir = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.Silver;
            this.metroButton2.BackgroundImageDown = null;
            this.metroButton2.BackgroundImageUp = null;
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.ForeColor = System.Drawing.Color.White;
            this.metroButton2.IsChecked = false;
            this.metroButton2.Location = new System.Drawing.Point(477, 174);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(100, 32);
            this.metroButton2.TabIndex = 72;
            this.metroButton2.Text = "取消";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.IsShowBorder = true;
            this.metroLabel2.Location = new System.Drawing.Point(139, 81);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(438, 32);
            this.metroLabel2.TabIndex = 71;
            this.metroLabel2.Text = "储存文件夹";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel1.Location = new System.Drawing.Point(31, 83);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(102, 25);
            this.metroLabel1.TabIndex = 70;
            this.metroLabel1.Text = "储存文件名";
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.metroButton1.BackgroundImageDown = null;
            this.metroButton1.BackgroundImageUp = null;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.IsChecked = false;
            this.metroButton1.Location = new System.Drawing.Point(593, 174);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(100, 32);
            this.metroButton1.TabIndex = 69;
            this.metroButton1.Text = "开始下载";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(31, 126);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(662, 31);
            this.pgbProgress.Style = MetroFramework.MetroColorStyle.Blue;
            this.pgbProgress.TabIndex = 68;
            this.pgbProgress.Visible = false;
            // 
            // metroLabel7
            // 
            this.metroLabel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.IsShowBorder = true;
            this.metroLabel7.Location = new System.Drawing.Point(139, 24);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(438, 32);
            this.metroLabel7.TabIndex = 67;
            this.metroLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChooseDir
            // 
            this.ChooseDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.ChooseDir.BackgroundImageDown = null;
            this.ChooseDir.BackgroundImageUp = null;
            this.ChooseDir.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.ChooseDir.ForeColor = System.Drawing.Color.White;
            this.ChooseDir.IsChecked = false;
            this.ChooseDir.Location = new System.Drawing.Point(593, 24);
            this.ChooseDir.Name = "ChooseDir";
            this.ChooseDir.Size = new System.Drawing.Size(100, 32);
            this.ChooseDir.TabIndex = 66;
            this.ChooseDir.Text = "路径选择";
            this.ChooseDir.UseCustomBackColor = true;
            this.ChooseDir.UseCustomForeColor = true;
            this.ChooseDir.Click += new System.EventHandler(this.ChooseDir_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel4.Location = new System.Drawing.Point(31, 28);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(102, 25);
            this.metroLabel4.TabIndex = 65;
            this.metroLabel4.Text = "储存文件夹";
            // 
            // DownloadFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(705, 231);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.ChooseDir);
            this.Controls.Add(this.metroLabel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DownloadFormcs";
            this.Text = "DownloadFormcs";
            this.Load += new System.EventHandler(this.DownloadFormcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton ChooseDir;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroProgressBar pgbProgress;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}