using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMitAllenControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
            errorProvider1.SetError(button1, "Ich bin der ErrorProvider");

            helpProvider1.SetShowHelp(button1, true);
            toolTip1.SetToolTip(button1, "Das ist der ToolTip");

        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                backgroundWorker1.ReportProgress(i, $"Worker bei {i}%");
                Thread.Sleep(500);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;

            toolStripProgressBar1.Value = e.ProgressPercentage;
            toolStripLabel1.Text = e.UserState.ToString();

            toolStripProgressBar2.Value = e.ProgressPercentage;
            toolStripStatusLabel1.Text = e.UserState.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(4000, "Eine unwichtige Information", "Wer das liest ist doof!", ToolTipIcon.Info);
        }
    }
}
