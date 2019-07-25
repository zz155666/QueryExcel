using client.common;
using client.controll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcPCclient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartingUtil.InitSystemSettings();
            StartingUtil.CheckDbVersion();
            Application.Run(new ActiviteForm());
           
        }
    }
}
