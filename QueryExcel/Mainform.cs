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
        /// <summary>
        /// 0 文件列表 1 已下载列表
        /// </summary>
        private int state = 0;
        private List<TelRecord> telrecords;
        /// <summary>
        /// 当前页码
        /// </summary>
        private int pagenum=1;
        /// <summary>
        /// 行数
        /// </summary>
        private int size = 20;
        /// <summary>
        /// 总页数
        /// </summary>
        private int pagesize = 0;
        public Mainform()
        {
            InitializeComponent();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            ConFigFormcs config = new ConFigFormcs();
            config.ShowDialog();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if (state==0) {
                string id = GetCurrRow();
                if (!string.IsNullOrEmpty(id))
                {
                    TelRecord rec = telrecords.FindAll(p => p.md5 == id).FirstOrDefault();
                    if (rec != null)
                    {
                        if (string.IsNullOrEmpty(rec.path))
                        {
                            MessageBox.Show("当前记录无下载地址");
                        } else
                        {
                            DownloadFormcs down = new DownloadFormcs();
                            down.Tag = rec;
                            down.ShowDialog();
                        }

                    }
                }
                else
                {
                    MessageBox.Show("您当前未选中记录");
                }
            }else
            {
                string id = GetCurrRow();
                if (!string.IsNullOrEmpty(id))
                {
                  
                    //{
                        Record rec = CurrUserLogin.dowload.FindAll(p => p.ID == id).FirstOrDefault();
                        if (rec != null)
                        {
                        if (!System.IO.File.Exists(rec.Path))
                        {
                            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                            DialogResult dr = MessageBox.Show("文件已被删除是否删除系统记录?", "删除记录", messButton);
                            if (dr == DialogResult.OK)
                            {
                                DownloadControl trl = new DownloadControl();
                                trl.Delete(id);
                                CurrUserLogin.dowload.Remove(rec);
                                refrsh();
                            }
                        }else
                        {
                            System.Diagnostics.Process.Start(rec.Path);
                        }
                        //存在则打开
                      
                          
                        }
                }
                else
                {
                    MessageBox.Show("您当前未选中记录");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CurrUserLogin.isautodownload=="0")
            {
                return;
            }
            if (CurrUserLogin.isdownloading)
            {
                return;
            }
            DateTime dotime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")+" "+ CurrUserLogin.hour+":"+ CurrUserLogin.min+":00");
            if (dotime<= DateTime.Now&& dotime> DateTime.Now.AddMinutes(-5)&& DateTime.Now > CurrUserLogin.lastupdatetime.AddMinutes(1))
            {
                CurrUserLogin.isdownloading = true;
                DownloadControl trl = new DownloadControl();
                List<TelRecord> tels = new List<TelRecord>();
                trl.Alldown(Getalldata(1, tels));
                CurrUserLogin.isdownloading = false;
            }
        }
        /// <summary>
        /// 请求上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uppage_Click(object sender, EventArgs e)
        {
            if (state==0)
            {
                pagenum--;
                loaddata(pagenum);
            }
            if (state == 1)
            {
                pagenum--;
                if (pagenum==1)
                {
                    uppage.Visible = false;
                }
                else
                {
                    uppage.Visible = true;
                }
                SetBindingSource(CurrUserLogin.dowload.Skip(size * (pagenum - 1)).Take(size).ToList());
            }
        }
        /// <summary>
        /// 请求下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextpage_Click(object sender, EventArgs e)
        {
            if (state==0)
            {
                pagenum++;
                loaddata(pagenum);
            }
            if (state==1)
            {
                uppage.Visible = true;
                pagenum++;
                if (pagesize > pagenum)
                {
                    nextpage.Visible = true;
                }else
                {
                    nextpage.Visible = false;
                }
                SetBindingSource(CurrUserLogin.dowload.Skip(size * (pagenum - 1)).Take(size).ToList());
            }
        }
        /// <summary>
        /// 切换已下载界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton3_Click(object sender, EventArgs e)
        {
            down.Text = "打开";
            down.BackgroundImage = Properties.Resources.打开24;
            down.Visible = true;
            delete.Visible = true;
            state = 1;
            pagesize = CurrUserLogin.dowload.Count / size;
            if (CurrUserLogin.dowload.Count% size>0)
            {
                pagesize++;
            }
            pagenum = 1;
            uppage.Visible = false;
            if (pagesize>1)
            {
                nextpage.Visible = true;
            }else
            {
                nextpage.Visible = false;
            }
            
            SetBindingSource(CurrUserLogin.dowload.Skip(size*(pagenum-1)).Take(size).ToList());
        }
        private void SetBindingSource(List<Record> posMembers)
        {
            metroGrid1.Rows.Clear();
            metroGrid1.DataSource = null;
            man.Visible = false;
            name.Visible = false;
           time.Visible = false;
            type.HeaderText = "储存路径";
            int i = 0;
            Action<List<Record>> initGridRow = s =>
            {
                s.ForEach(g =>
                {
                    i++;
                   
                    object[] info = {i,g.CallTTnO,g.StartTime,"",g.Path,g.ID,"", g.ID };//g.vipname
                    metroGrid1.Rows.Add(info);
                });
            };
            if (posMembers != null && posMembers.Count > 0)
            {
                initGridRow(posMembers);
                //_memberListView.labTotal.Text = "共有信息" + i + "条";
            }
        }
        private void SetBindingSource(List<TelRecord> posMembers)
        {
            metroGrid1.Rows.Clear();
            metroGrid1.DataSource = null;
            man.Visible = true;
            name.Visible = true;
            day.Visible = true;
            type.HeaderText = "通话方式";
            int i = 0;
            Action<List<TelRecord>> initGridRow = s =>
            {
                s.ForEach(g =>
                {
                    i++;
                    string type = "";
                    switch (g.type)
                    {
                        case 1:
                            type = "电话";
                            break;
                        case 2:
                            type = "传真";
                            break;
                        case 3:
                            type = "电话会议";
                            break;
                        case 4:
                            type = "盒子呼入";
                            break;
                        case 5:
                            type = "盒子呼出";
                            break;
                        case 6:
                            type = "ECLite 盒子呼入";
                            break;
                        case 7:
                            type = "ECLite 盒子呼出";
                            break;
                        case 8:
                            type = "微地产呼入";
                            break;
                        case 9:
                            type = "微地产呼出";
                            break;
                        case 10:
                            type = "金伦公司呼入";
                            break;
                        case 11:
                            type = "金伦公司呼出";
                            break;
                        case 12:
                            type = "企业付费拨打";
                            break;
                        case 13:
                            type = "通信服务器呼入";
                            break;
                        case 14:
                            type = "通信服务器呼出";
                            break;
                        case 15:
                            type = "金轮公司呼入通过 cos 上传";
                            break;
                        case 16:
                            type = "盒子呼入通过云cos 上传";
                            break;
                        case 17:
                            type = "金轮公司呼出通过 cos 上传";
                            break;
                        case 18:
                            type = "盒子呼出通过云cos上传";
                            break;
                        case 19:
                            type = "电话";
                            break;
                        case 20:
                            type = "电话";
                            break;
                        case 21:
                            type = "电话";
                            break;
                        case 22:
                            type = "TCL有线呼入";
                            break;
                        case 23:
                            type = "TCL有线呼出";
                            break;
                        case 24:
                            type = "TCL无线呼入";
                            break;
                        case 25:
                            type = "TCL无线呼出";
                            break;
                        case 26:
                            type = "TCL 盒子呼入";
                            break;
                        case 27:
                            type = "TCL";
                            break;
                        case 28:
                            type = "EC 云呼-tencent";
                            break;
                        default:
                            type = "未知";
                            break;
                    }
                    object[] info = { i, g.calltono, g.starttime, g.calltime, type, g.customerName, g.customerCompany, g.md5 };//g.vipname
                    metroGrid1.Rows.Add(info);
                });
            };
            if (posMembers != null && posMembers.Count > 0)
            {
                initGridRow(posMembers);
                //_memberListView.labTotal.Text = "共有信息" + i + "条";
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (state==0)
            {
                loaddata(pagenum);
            }else
            {
                refrsh();
            }
           
        }
        public void refrsh()
        {
            pagesize = CurrUserLogin.dowload.Count / size;
            if (CurrUserLogin.dowload.Count % size > 0)
            {
                pagesize++;
            }
            if (pagesize==pagenum&& pagenum > 1)
            {
                uppage.Visible = true;
                nextpage.Visible = false;
            }
            else if (pagesize > pagenum && pagenum > 1)
            {
                uppage.Visible = true;
                nextpage.Visible = true;
            }
            else
            if (pagesize< pagenum)
            {
                pagenum--;
                uppage.Visible = true;
                nextpage.Visible = false;
            }else
            if (pagenum==1)
            {
                uppage.Visible = false;
                nextpage.Visible = true;
            }
            SetBindingSource(CurrUserLogin.dowload.Skip(size * (pagenum - 1)).Take(size).ToList());
        }
        private void delete_Click(object sender, EventArgs e)
        {
            string id = GetCurrRow();
            if (!string.IsNullOrEmpty(id))
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗?", "删除文件", messButton);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    Record rec = CurrUserLogin.dowload.FindAll(p => p.ID == id).FirstOrDefault();
                    if (rec != null)
                    {
                        if (File.Exists(rec.Path))
                        {
                            File.Delete(rec.Path);
                        }
                        DownloadControl trl = new DownloadControl();
                        trl.Delete(id);
                        CurrUserLogin.dowload.Remove(rec);
                        refrsh();
                    }
                }
            }else
            {
                MessageBox.Show("您当前未选中记录");
            }
        }
        public string GetCurrRow()
        {
            string RecOrder;
            try
            {
                RecOrder =metroGrid1.Rows[metroGrid1.CurrentRow.Index].Cells[7].Value.ToString();
            }
            catch
            {
                RecOrder = "";
            }
            return RecOrder;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            state = 0;
            down.Visible = true;
            down.Text = "下载";
            down.BackgroundImage = Properties.Resources.下载24;
            delete.Visible = false;
            loaddata(1);
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            delete.Visible = false;
            loaddata(1);
        }
        public void loaddata(int pagenum)
        {
            new Thread(() =>
            {

                telRecordResult telr = Getwebdata(pagenum);
                if (telr.errCode=="200")
                {
                    pagesize = telr.data.total / telr.data.pageSize;
                    if (telr.data.total % telr.data.pageSize > 0)
                    {
                        pagesize++;
                    }
                    telrecords = telr.data.result;
                    this.Invoke(new ThreadStart(delegate ()
                    {
                        if (pagesize == pagenum && pagenum > 1)
                        {
                            uppage.Visible = true;
                            nextpage.Visible = false;
                        }else if (pagesize > pagenum && pagenum > 1)
                        {
                            uppage.Visible = true;
                            nextpage.Visible = true;
                        }
                        else
            if (pagesize < pagenum)
                        {
                            pagenum--;
                            uppage.Visible = true;
                            nextpage.Visible = false;
                        }
                        else
            if (pagenum == 1)
                        {
                            uppage.Visible = false;
                            nextpage.Visible = true;
                        }
                        SetBindingSource(telr.data.result);
                    }));
                }
                else
                {
                    this.Invoke(new ThreadStart(delegate ()
                    {
                        MessageBox.Show("获取数据发生错误："+ telr.errMsg);
                    }));
                }
            }).Start();
        }
        public telRecordResult Getwebdata(int pagenum)
        {
            string data = "{\"startDate\": \""+DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")+ "\",\"endDate\": \""+ DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "\",\"pageNo\": \""+ pagenum + "\"}";
            TelRecordService tels = new TelRecordService();
            return tels.getTelRecordResult(data);
        }
        public List<TelRecord> Getalldata(int pagenum, List<TelRecord> rec)
        {
            telRecordResult tel = Getwebdata(pagenum);
            if (tel.errCode=="200")
            {
                rec.AddRange(tel.data.result);
                int total = tel.data.total / tel.data.pageSize;
                if (tel.data.total % tel.data.pageSize > 0)
                {
                    total++;
                }
                if (pagenum< total)
                {
                    Getalldata(pagenum+1, rec);
                }
            }
            return rec;
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
    }
}
