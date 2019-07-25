using client.controll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryExcel
{
    public partial class LoginForm : Form
    {
        private logincontroll control;
        public LoginForm()
        {
            InitializeComponent();
            control = new logincontroll();
            this.StartPosition =FormStartPosition.CenterScreen;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("用户名不能为空");
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("用户名不能为空");
            }
            if (control.login(txtUser.Text, txtPass.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }else
            {
                MessageBox.Show("用户名密码错误");
            }
        }
    }
}
