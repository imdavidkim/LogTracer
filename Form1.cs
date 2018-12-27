using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace Tracer
{
    public partial class main_window : Form
    {
        public static PropertyForm prop = null;
        public main_window()
        {
            InitializeComponent();
            if (prop == null)
            {
                prop = new PropertyForm();
                //prop.Initializing();
            }
        }

        private void fileMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                if (file.FileNames.Length > 0)
                {
                    foreach (string filename in file.FileNames)
                    {
                        List<string> fileInfo = new List<string>();
                        string[] splitPath = filename.Split('\\');
                        fileInfo.Add(filename.Replace(splitPath[splitPath.Length - 1], ""));
                        fileInfo.Add(splitPath[splitPath.Length - 1]);
                        ChildForm tracer = new ChildForm("File", fileInfo.ToArray(), prop);
                        //ChildForm2 tracer = new ChildForm2("File", fileInfo.ToArray());
                        tracer.MdiParent = this;
                    }
                }
            }

        }

        private void envSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prop = new PropertyForm();
            prop.Show();
        }

        private void jMonServiceStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardError = true;
            proInfo.RedirectStandardInput = true;

            pro.StartInfo = proInfo;
            pro.Start();

            pro.StandardInput.Write(@"sc \\otc36 stop ""Pricing Center Gateway (JMon) Service""" + Environment.NewLine);
            pro.StandardInput.Close();

            string retValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();
            MessageBox.Show(retValue);

        }

        private void jMonServiceStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardError = true;
            proInfo.RedirectStandardInput = true;

            pro.StartInfo = proInfo;
            pro.Start();

            pro.StandardInput.Write(@"sc \\otc36 start ""Pricing Center Gateway (JMon) Service""" + Environment.NewLine);
            pro.StandardInput.Close();

            string retValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();
            MessageBox.Show(retValue);
        }

        private void qMonServiceStopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardError = true;
            proInfo.RedirectStandardInput = true;

            pro.StartInfo = proInfo;
            pro.Start();

            pro.StandardInput.Write(@"sc \\otc36 stop ""Pricing Center Gateway (QMon) Service""" + Environment.NewLine);
            pro.StandardInput.Close();

            string retValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();
            MessageBox.Show(retValue);
        }

        private void qMonServiceStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process pro = new System.Diagnostics.Process();

            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = true;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardError = true;
            proInfo.RedirectStandardInput = true;

            pro.StartInfo = proInfo;
            pro.Start();

            pro.StandardInput.Write(@"sc \\otc36 start ""Pricing Center Gateway (QMon) Service""" + Environment.NewLine);
            pro.StandardInput.Close();

            string retValue = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();
            pro.Close();
            MessageBox.Show(retValue);
        }
    }
}
