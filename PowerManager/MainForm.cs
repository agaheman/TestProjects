using System;
using System.Windows.Forms;
using System.Management;

namespace PowerManager
{
    public partial class PowerManager : Form
    {
        public PowerManager()
        {
            InitializeComponent();
        }
        public const string ShutdownFlag = "1";
        public const string RebootFlag = "2";
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            PowerManage(ShutdownFlag);
        }

        private void Reboot_Click(object sender, EventArgs e)
        {
            PowerManage(RebootFlag);
        }

        /// <summary>
        /// Flag 1 means we want to shut down the system. Use "2" to reboot.
        /// </summary>
        /// <param name="powerFlag"></param>
        private static void PowerManage(string powerFlag)
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");

            mboShutdownParams["Flags"] = powerFlag;
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
            }
        }
    }
}
