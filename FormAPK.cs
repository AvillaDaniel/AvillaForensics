//Avilla Forensics - Copyright (C) 2023 – Daniel Hubscher Avilla 

//This program is free software: you can redistribute it and/or modify 
//it under the terms of the GNU General Public License as published by 
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program. If not, see <https://www.gnu.org/licenses/>.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormAPK : Form
    {
        public FormAPK()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ofd2.Multiselect = true;
            this.ofd2.Title = "Select file";
            ofd2.InitialDirectory = @"C:\";
            ofd2.Filter = "Files (*.apk)|*.apk";
            ofd2.CheckFileExists = true;
            ofd2.CheckPathExists = true;
            ofd2.FilterIndex = 2;
            ofd2.RestoreDirectory = true;
            ofd2.ReadOnlyChecked = true;
            ofd2.ShowReadOnly = true;

            DialogResult drIPED = this.ofd2.ShowDialog();

            if (drIPED == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd2.FileName;
                button1.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process processWhats1 = new Process();
            ProcessStartInfo startInfoWhats1 = new ProcessStartInfo();
            startInfoWhats1.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats1.CreateNoWindow = true;
            startInfoWhats1.UseShellExecute = false;
            startInfoWhats1.RedirectStandardOutput = true;
            startInfoWhats1.FileName = fullPath + "\\adb.exe";
            startInfoWhats1.Arguments = " shell cmd package uninstall -k " + textBox2.Text;
            processWhats1.StartInfo = startInfoWhats1;
            processWhats1.Start();
            processWhats1.StandardOutput.ReadToEnd();
            processWhats1.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            
            button3_Click(null, null);

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process processWhats2 = new Process();
            ProcessStartInfo startInfoWhats2 = new ProcessStartInfo();
            startInfoWhats2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats2.CreateNoWindow = true;
            startInfoWhats2.UseShellExecute = false;
            startInfoWhats2.RedirectStandardOutput = true;
            startInfoWhats2.FileName = fullPath + "\\adb.exe";
            startInfoWhats2.Arguments = " install -r -d \"" + textBox1.Text + "\"";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            textBox3.Text += "\r\n" + processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void FormAPK_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\adb.exe";
            startInfo3.Arguments = " devices -l";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox3.Text += "\r\n>> " + process3.StandardOutput.ReadToEnd();
            process3.Close();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
