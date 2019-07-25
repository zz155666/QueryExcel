using client.common;
using client.controll;
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

namespace EcPCclient
{
    public partial class DownloadFormcs : Form
    {
        private object updateLocker = new object();
        private BackgroundWorker bw;
        private DownloadControl trl;
        private TelRecord tel;
        public DownloadFormcs()
        {
            InitializeComponent();
            trl = new DownloadControl();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            CurrUserLogin.lastdownloaddir = metroLabel7.Text;
            trl.SaveOpt("lastdownloaddir", metroLabel7.Text);
            //启动更新线程
            bw = new BackgroundWorker();
            bw.DoWork += DoWork;
            bw.WorkerReportsProgress = true;
          //  bw.ProgressChanged += ProgressChanged;
            bw.WorkerSupportsCancellation = true;
         //   bw.RunWorkerCompleted += RunWorkerCompleted;

            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            lock (updateLocker)
            {
                try
                {
                    WXLog.Debug("LiveUpdate DoWork Start。");
                    if (!Directory.Exists(CurrUserLogin.lastdownloaddir))
                    {
                        Directory.CreateDirectory(CurrUserLogin.lastdownloaddir);
                    }
                    /* 开始下载更新文件*/
                    float progress = 0;
                    try
                    {
                        string path = Path.Combine(CurrUserLogin.lastdownloaddir, tel.calltono +" "+ tel.starttime.ToString("yyyy-MM-dd HH：mm：ss") + ".mp3");
                        System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(tel.path);
                        System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                        long totalBytes = myrp.ContentLength;
                        System.IO.Stream st = myrp.GetResponseStream();
                        System.IO.Stream so = new System.IO.FileStream(path, System.IO.FileMode.Create);
                        long totalDownloadedByte = 0;
                        byte[] by = new byte[1024];
                        this.Invoke(new ThreadStart(delegate ()
                        {
                            pgbProgress.Visible = true;
                        }));
                        int osize = st.Read(by, 0, (int)by.Length);
                        while (osize > 0)
                        {
                            totalDownloadedByte = osize + totalDownloadedByte;
                            System.Windows.Forms.Application.DoEvents();
                            so.Write(by, 0, osize);
                            osize = st.Read(by, 0, (int)by.Length);
                            progress = (float)totalDownloadedByte / (float)totalBytes * 100;
                            this.Invoke(new ThreadStart(delegate ()
                            {
                                pgbProgress.Value = Convert.ToInt32(progress);
                            }));
                        }
                        so.Close();
                        st.Close();
                        this.Invoke(new ThreadStart(delegate ()
                        {
                            trl.SaveDownloadToDB(tel,path);
                            MessageBox.Show("下载完成！");
                            this.Close();
                        }));
                    }
                    catch (System.Exception exc)
                    {
                        WXLog.Error("LiveUpdateController.DoWork failed,", exc);
                        Thread.Sleep(2000);
                        this.Invoke(new ThreadStart(delegate ()
                        {
                            MessageBox.Show("下载失败："+ exc.Message);
                        }));
                        //return;
                    }
                }
                catch (Exception ex)
                {
                    WXLog.Error("LiveUpdateController.DoWork failed,", ex);
                    Thread.Sleep(2000);
                }
            }
        }

        private void DownloadFormcs_Load(object sender, EventArgs e)
        {
            metroLabel7.Text = CurrUserLogin.lastdownloaddir;
            tel = Tag as TelRecord;
            metroLabel2.Text = tel.calltono + " " + tel.starttime.ToString("yyyy-MM-dd HH:mm:ss") + ".mp3";
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

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
