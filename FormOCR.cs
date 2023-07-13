//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormOCR : Form
    {
        public FormOCR()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderImagens = new FolderBrowserDialog();
            FolderImagens.Description = "Choose source directory";
            if (FolderImagens.ShowDialog() == DialogResult.OK)
            {
                TxtDiretorio.Text = FolderImagens.SelectedPath;
                webBrowser1.Navigate(TxtDiretorio.Text);
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            pictureBox2.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathTess = @"bin\tesseract";
            string fullPathTess;
            fullPathTess = Path.GetFullPath(pathTess);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(" dir /s /b " + "\"" + TxtDiretorio.Text + "\" > " + fullPathFind + "\\ocr.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\ocr.txt");

            while ((line = file.ReadLine()) != null)
            {
                string pathTemp = @"temp";
                string fullPathTemp;
                fullPathTemp = Path.GetFullPath(pathTemp);

                StreamWriter EscreverTXT1 = new StreamWriter(fullPathTemp + "\\log-temp-OCR.txt");
                EscreverTXT1.WriteLine($"{line}");
                EscreverTXT1.Close();

                webBrowser2.Navigate(fullPathTemp + "\\log-temp-OCR.txt");

                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPathTess + "\\tesseract.exe";
                startInfo3.Arguments = "\"" + line + "\" " + "\"" + line + "\"";
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();

                webBrowser3.Navigate(line + ".txt");

                try 
                {
                    pictureBox1.Image = Image.FromFile(@line);
                }
                catch 
                {
                    pictureBox1.Image = Image.FromFile(fullPathTess + "\\noimage.jpg");
                }
            }

            file.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Enabled = true;

            MessageBox.Show("Completed Process", "Attention!");
        }

        private void FormOCR_Load(object sender, EventArgs e)
        {

        }
    }
}
