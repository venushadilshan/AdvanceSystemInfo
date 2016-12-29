using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advance_SystemInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string q = "";


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            backgroundWorker1.RunWorkerAsync();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            //richTextBox1.Text = "Cheking system";
            //label1.Visible = true;
        //   MessageBox.Show("Checking your system", "Info");
            // String command = @"Systeminfos.bat";
            System.Diagnostics.Process process = new System.Diagnostics.Process();

            //   process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.FileName = @"Systeminfos.bat";
            //  process.StartInfo.Arguments = "/C "+command;
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            
            while (!process.HasExited)
            {

                q += process.StandardOutput.ReadToEnd();
                //richTextBox1.Text = q;
             //  backgroundWorker2.RunWorkerAsync();
              
            }

            backgroundWorker2.RunWorkerAsync();
            //label1.Text = "Completed";
          //  MessageBox.Show("Scan Comleted!", "Info");
          //  MessageBox.Show(q);
            //richTextBox1.Text = q;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = q;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Visible = true;
        }
    }
}
