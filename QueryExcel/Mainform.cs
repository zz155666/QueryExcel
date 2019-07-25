using client.common;
using client.controll;
using client.dal;
using client.web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryExcel
{
    public partial class Mainform : Form
    {
        private string keyValue;
        /// <summary>
        /// 0 文件列表 1 已下载列表
        /// </summary>
        private int state = 0;

        public Mainform()
        {
            InitializeComponent();
        }
      
      
        private void metroButton7_Click(object sender, EventArgs e)
        {
            metroLabel1.Text = keyValue;
            keyValue = "";
        }
        private void delete_Click(object sender, EventArgs e)
        {
           
        }
      

       
        private void Mainform_Load(object sender, EventArgs e)
        {
            
        }
    
        private Point mPoint = new Point();
        private void paneltop_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void paneltop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        private void Mainform_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            switch (key)
            {
                case Keys.NumPad0:
                    //按下小键盘0以后 
                    keyValue += 0;
                    break;
                case Keys.NumPad1:
                    //按下小键盘1以后 
                    keyValue += 1;
                    break;
            }
        }
    }
}
