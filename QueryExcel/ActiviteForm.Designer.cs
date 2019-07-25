namespace QueryExcel
{
    partial class ActiviteForm
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
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtcorpid = new smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox();
            this.txtactivte = new smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel4.Location = new System.Drawing.Point(24, 28);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(62, 25);
            this.metroLabel4.TabIndex = 72;
            this.metroLabel4.Text = "企业id";
            // 
            // txtcorpid
            // 
            this.txtcorpid.BackColor = System.Drawing.Color.White;
            this.txtcorpid.IsShowBorder = true;
            this.txtcorpid.Lines = new string[0];
            this.txtcorpid.Location = new System.Drawing.Point(146, 18);
            this.txtcorpid.Margin = new System.Windows.Forms.Padding(30, 100, 30, 15);
            this.txtcorpid.MaxLength = 32767;
            this.txtcorpid.Name = "txtcorpid";
            this.txtcorpid.PasswordChar = '\0';
            this.txtcorpid.PromptText = "企业id";
            this.txtcorpid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtcorpid.SelectedText = "";
            this.txtcorpid.SelectionLength = 0;
            this.txtcorpid.SelectionStart = 0;
            this.txtcorpid.Size = new System.Drawing.Size(412, 45);
            this.txtcorpid.TabIndex = 75;
            this.txtcorpid.UseCustomBackColor = true;
            this.txtcorpid.UseSelectable = true;
            // 
            // txtactivte
            // 
            this.txtactivte.BackColor = System.Drawing.Color.White;
            this.txtactivte.IsShowBorder = true;
            this.txtactivte.Lines = new string[0];
            this.txtactivte.Location = new System.Drawing.Point(146, 94);
            this.txtactivte.Margin = new System.Windows.Forms.Padding(30, 100, 30, 15);
            this.txtactivte.MaxLength = 32767;
            this.txtactivte.Name = "txtactivte";
            this.txtactivte.PasswordChar = '\0';
            this.txtactivte.PromptText = "激活码";
            this.txtactivte.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtactivte.SelectedText = "";
            this.txtactivte.SelectionLength = 0;
            this.txtactivte.SelectionStart = 0;
            this.txtactivte.Size = new System.Drawing.Size(412, 45);
            this.txtactivte.TabIndex = 77;
            this.txtactivte.UseCustomBackColor = true;
            this.txtactivte.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel2.Location = new System.Drawing.Point(24, 103);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 25);
            this.metroLabel2.TabIndex = 78;
            this.metroLabel2.Text = "激活码";
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.Silver;
            this.metroButton1.BackgroundImageDown = null;
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.BackgroundImageUp = null;
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Px22;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.IsChecked = false;
            this.metroButton1.Location = new System.Drawing.Point(266, 164);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 10, 30, 10);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(144, 45);
            this.metroButton1.TabIndex = 80;
            this.metroButton1.Text = "退 出";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(152)))), ((int)(((byte)(246)))));
            this.btnLogin.BackgroundImageDown = null;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.BackgroundImageUp = null;
            this.btnLogin.FontSize = MetroFramework.MetroButtonSize.Px22;
            this.btnLogin.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.IsChecked = false;
            this.btnLogin.Location = new System.Drawing.Point(412, 164);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 10, 30, 10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 45);
            this.btnLogin.TabIndex = 79;
            this.btnLogin.Text = "生 成";
            this.btnLogin.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLogin.UseCustomBackColor = true;
            this.btnLogin.UseCustomForeColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ActiviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 243);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtactivte);
            this.Controls.Add(this.txtcorpid);
            this.Controls.Add(this.metroLabel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActiviteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActiviteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox txtcorpid;
        public smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox txtactivte;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroButton metroButton1;
        public MetroFramework.Controls.MetroButton btnLogin;
    }
}