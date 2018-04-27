using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using KaoQin.Utility;

namespace KaoQin
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
            CheckUpdate();
            Application.Run(new Main());
        }
        public static void CheckUpdate()
        {
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple(ConfigHelper.UpdateUrl);
        }
    }
}
