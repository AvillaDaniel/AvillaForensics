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
    public partial class FormTrash : Form
    {
        public FormTrash()
        {
            InitializeComponent();
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
            label1.Text = process3.StandardOutput.ReadToEnd();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderAPK = new FolderBrowserDialog();
            backupfolderAPK.Description = "Choose destination folder";
            if (backupfolderAPK.ShowDialog() == DialogResult.OK)
            {
                Txtdestino.Text = backupfolderAPK.SelectedPath;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";

            panel1.Enabled = false;

            webBrowser1.Navigate("about:blank");
            webBrowser1.Navigate(Txtdestino.Text);

            pictureBox3.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            StreamWriter EscreverTXT = new StreamWriter(@fullPathFind + "\\" + "Trash.bat");
            EscreverTXT.WriteLine($@"{fullPath + "\\adb.exe"} shell find '/sdcard/' | {fullPathBin + "\\grep.exe .trash > "}{fullPathFind + "\\Trash.txt"}");
            EscreverTXT.Close();

            Process process1 = new Process();
            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo1.CreateNoWindow = true;
            startInfo1.UseShellExecute = false;
            startInfo1.RedirectStandardOutput = true;
            startInfo1.FileName = fullPathFind + "\\" + "Trash.bat";
            process1.StartInfo = startInfo1;
            process1.Start();
            process1.StandardOutput.ReadToEnd();

            webBrowser2.Navigate(fullPathFind + "\\" + "Trash.txt");

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\" + "Trash.txt");

            while ((line = file.ReadLine()) != null)
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPath + "\\adb.exe";
                startInfo3.Arguments = " pull \"" + line + "\" " + "\"" + Txtdestino.Text + "\"";
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();
            }
            file.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
            panel1.Enabled = true;
        }

        private void FormTrash_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            Txtdestino.Text = file.ReadLine() + "\\AndroidTrash";
            file.Close();

            string folder = Txtdestino.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            webBrowser1.Navigate(Txtdestino.Text);
        }
    }
}
