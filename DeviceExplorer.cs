//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class DeviceExplorer : Form
    {
        public DeviceExplorer()
        {
            InitializeComponent();
        }

        public class caminho //Variável Pública
        {
            //public static string package = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            textBox1.Text = "";
            listBox1.Items.Clear();

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell ls / > " + fullPathFind + "\\files.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }
            
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\files.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    listBox1.Items.Add(line);
                }
            }
            file.Close();

            if (listBox1.Items.Count > 0) 
            {
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                button4.Enabled = false;
                button5.Enabled = false;
                MessageBox.Show("Device not recognized", "Heads up");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {     

            if (textBox1.Text != listBox1.Text)
            {
                textBox1.Text = textBox1.Text + listBox1.Text + "/";

                listBox1.Items.Clear();

                string pathADB = @"adb";
                string fullPath;
                fullPath = Path.GetFullPath(pathADB);

                string pathFind = @"find";
                string fullPathFind;
                fullPathFind = Path.GetFullPath(pathFind);

                ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
                processStartInfoAPPT.RedirectStandardInput = true;
                processStartInfoAPPT.RedirectStandardOutput = true;
                processStartInfoAPPT.UseShellExecute = false;
                processStartInfoAPPT.CreateNoWindow = true;
                Process processAPPT = Process.Start(processStartInfoAPPT);
                if (processAPPT != null)
                {
                    processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell ls \"" + textBox1.Text + "\" > " + fullPathFind + "\\files.txt");
                    processAPPT.StandardInput.Close();
                    processAPPT.StandardOutput.ReadToEnd();
                }

                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\files.txt");

                while ((line = file.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        listBox1.Items.Add(line);
                    }
                }
                file.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd2.Multiselect = true;
            this.ofd2.Title = "Select file";
            ofd2.InitialDirectory = @"C:\";
            ofd2.Filter = "All files (*.*)|*.*";
            ofd2.CheckFileExists = true;
            ofd2.CheckPathExists = true;
            ofd2.FilterIndex = 2;
            ofd2.RestoreDirectory = true;
            ofd2.ReadOnlyChecked = true;
            ofd2.ShowReadOnly = true;

            DialogResult drIPED = this.ofd2.ShowDialog();

            if (drIPED == System.Windows.Forms.DialogResult.OK)
            {
                TXTorigem.Text = ofd2.FileName;
                button3.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPED = new FolderBrowserDialog();
            backupfolderIPED.Description = "Choose destination folder";
            if (backupfolderIPED.ShowDialog() == DialogResult.OK)
            {
                TXTdestino.Text = backupfolderIPED.SelectedPath;
                webBrowser1.Navigate(backupfolderIPED.SelectedPath);
                button2.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe pull -a \"" + textBox1.Text + "\" \"" + TXTdestino.Text + "\"");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe push " + "\"" + TXTorigem.Text + "\" \"" + textBox1.Text + "\"");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            ProcessStartInfo processStartInfoAPPT2 = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT2.RedirectStandardInput = true;
            processStartInfoAPPT2.RedirectStandardOutput = true;
            processStartInfoAPPT2.UseShellExecute = false;
            processStartInfoAPPT2.CreateNoWindow = true;
            Process processAPPT2 = Process.Start(processStartInfoAPPT2);
            if (processAPPT2 != null)
            {
                processAPPT2.StandardInput.WriteLine(fullPath + "\\adb.exe shell ls " + textBox1.Text + " > " + fullPathFind + "\\files.txt");
                processAPPT2.StandardInput.Close();
                processAPPT2.StandardOutput.ReadToEnd();
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            listBox1.Items.Clear();

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\files.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    listBox1.Items.Add(line);
                }
            }
            file.Close();

            pictureBox2.Visible = false;
        }
    }
}
