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

namespace EcPCclient
{
    public partial class ConFigFormcs : Form
    {
        private ConfigControll ctl;
        public ConFigFormcs()
        {
            InitializeComponent();
            ctl = new ConfigControll();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void ChooseDir_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.Description = "选择文件存放路径";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                metroLabel7.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int hour = 0;
            if(!int.TryParse(txthour.Text,out hour))
            {
                MessageBox.Show("请填入纯数字");
                return;
            }
            if (hour<0|| hour>23)
            {
                MessageBox.Show("请填入正确的小时数");
                return;
            }
            int min = 0;
            if (!int.TryParse(txtmin.Text, out min))
            {
                MessageBox.Show("请填入纯数字");
                return;
            }
            if (min < 0 || min >59)
            {
                MessageBox.Show("请填入正确的分钟数");
                return;
            }
            DateTime dotime = DateTime.Now;
            if (!DateTime.TryParse(DateTime.Now.ToString("yyyy-MM-dd") + " " + txthour.Text + ":" + txtmin.Text + ":00",out dotime))
            {
                MessageBox.Show("时间格式不正确");
                return;
            }
            ctl.SaveAllConfig(metroCheckBox1.Checked, txthour.Text, txtmin.Text, metroLabel7.Text);
            this.Close();
        }

        private void ConFigFormcs_Load(object sender, EventArgs e)
        {
            metroLabel7.Text = CurrUserLogin.downloaddir;
            if (CurrUserLogin.isautodownload=="1")
            {
                metroCheckBox1.Checked = true;
            }else
            {
                metroCheckBox1.Checked = false;
            }
            txthour.Text = CurrUserLogin.hour;
            txtmin.Text = CurrUserLogin.min;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
