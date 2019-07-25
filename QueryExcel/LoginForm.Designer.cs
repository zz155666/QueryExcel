namespace EcPCclient
{
    partial class LoginForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.txtPass = new smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox();
            this.txtUser = new smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Px22;
            this.metroLabel1.Location = new System.Drawing.Point(78, 45);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(290, 36);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "用户登录";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnLogin.Location = new System.Drawing.Point(224, 257);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 10, 30, 10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 45);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "登 录";
            this.btnLogin.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLogin.UseCustomBackColor = true;
            this.btnLogin.UseCustomForeColor = true;
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.Icon = global::EcPCclient.Properties.Resources.密码;
            this.txtPass.IsShowBorder = true;
            this.txtPass.Lines = new string[0];
            this.txtPass.Location = new System.Drawing.Point(78, 164);
            this.txtPass.Margin = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.PromptText = "密码";
            this.txtPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.Size = new System.Drawing.Size(290, 45);
            this.txtPass.TabIndex = 18;
            this.txtPass.UseCustomBackColor = true;
            this.txtPass.UseSelectable = true;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.Icon = global::EcPCclient.Properties.Resources.用户;
            this.txtUser.IsShowBorder = true;
            this.txtUser.Lines = new string[0];
            this.txtUser.Location = new System.Drawing.Point(78, 108);
            this.txtUser.Margin = new System.Windows.Forms.Padding(30, 100, 30, 15);
            this.txtUser.MaxLength = 32767;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.PromptText = "工号";
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.Size = new System.Drawing.Size(290, 45);
            this.txtUser.TabIndex = 17;
            this.txtUser.UseCustomBackColor = true;
            this.txtUser.UseSelectable = true;
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
            this.metroButton1.Location = new System.Drawing.Point(78, 257);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 10, 30, 10);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(144, 45);
            this.metroButton1.TabIndex = 20;
            this.metroButton1.Text = "退 出";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 360);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroButton btnLogin;
        public smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox txtPass;
        public smartpos.wpos.App.Components.UserDefined.Controls.MetroTextBox txtUser;
        public MetroFramework.Controls.MetroButton metroButton1;
    }
}