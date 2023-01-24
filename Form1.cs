using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace shutDownLater
{
    public partial class FormMain : Form
    {
        DateTime mShutDownTime;
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            //mShutDownTime   = DateTime.Now.AddHours(1);
            mShutDownTime = DateTime.Now.AddSeconds(10);
            labelInfo.Visible = true;
            labelInfo.Text = "";
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now < mShutDownTime)
            {
                TimeSpan ts = mShutDownTime - DateTime.Now;
                labelInfo.Text = "До выключения осталось " + ts.Minutes + " мин." + ts.Seconds + " сек.";
            }else
            {
                Close();
                Process.Start("shutdown.exe", "-h");
            }
        }
    }
}
