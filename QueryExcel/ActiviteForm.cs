using client.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static client.common.CommonOp;

namespace EcPCclient
{
    public partial class ActiviteForm : Form
    {
        public ActiviteForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcorpid.Text))
            {
                MessageBox.Show("请输入企业id");
                return;
            }
            txtactivte.Text = StringSecurity.MD5Encrypt(StringSecurity.DESEncrypt(txtcorpid.Text) + "EC" + StringSecurity.DESEncrypt("YLTC") + DateTime.Now.Year);
        }
    }
}
