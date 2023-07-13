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
    public partial class Hash : Form
    {
        public Hash()
        {
            InitializeComponent();
        }
        
        public class tipoHASH //Variável Pública
        {
            public static string THash = "SHA256";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker3.RunWorkerAsync();

            pictureBox2.Visible = true;
            panel3.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
            backupfolderIPEDArquivo.Description = "Choose source folder";
            if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
            {
                txtOrigem.Text = backupfolderIPEDArquivo.SelectedPath;
                //button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
            backupfolderIPEDArquivo.Description = "Choose source folder";
            if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
            {
                txtDestino.Text = backupfolderIPEDArquivo.SelectedPath;
                webBrowser2.Navigate(backupfolderIPEDArquivo.SelectedPath);
                button3.Enabled = true;
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            string fullPathOrigem;
            fullPathOrigem = txtOrigem.Text;

            string fullPathDestino;
            fullPathDestino = txtDestino.Text;

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine("Get-ChildItem -Path \"" + txtOrigem.Text + "*\" -Recurse -Filter *.* | Get-FileHash -Algorithm " + tipoHASH.THash + " | Format-List > \"" + txtDestino.Text + "/" + tipoHASH.THash + "Hash.txt" + "\"");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser1.Navigate(fullPathDestino + "\\" + tipoHASH.THash + "Hash.txt");
            }

            //string pathFind = @"find";
            //string fullPathFind;
            //fullPathFind = Path.GetFullPath(pathFind);

            //StreamWriter EscreverTXT = new StreamWriter(@fullPathFind + "\\Hash.ps1");
            //EscreverTXT.WriteLine($"Get-ChildItem -Path '{fullPathOrigem}*' -Recurse -Filter *.* | Get-FileHash -Algorithm MD5 | Format-List > '{fullPathDestino}\\Hash.txt'");
            //EscreverTXT.Close();

            //webBrowser1.Navigate(fullPathDestino + "\\Hash.txt");

            //Process process1 = new Process();
            //ProcessStartInfo startInfo1 = new ProcessStartInfo();
            //startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo1.CreateNoWindow = true;
            //startInfo1.UseShellExecute = false;
            //startInfo1.RedirectStandardOutput = true;
            //startInfo1.FileName = fullPathFind + "\\Hash.ps1";
            //process1.StartInfo = startInfo1;
            //process1.Start();
            //process1.StandardOutput.ReadToEnd();
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel3.Enabled = true;
        }

        private void radioSHA1_CheckedChanged(object sender, EventArgs e)
        {
            tipoHASH.THash = "SHA1";
        }

        private void radioSHA256_CheckedChanged(object sender, EventArgs e)
        {
            tipoHASH.THash = "SHA256";
        }

        private void radioSHA384_CheckedChanged(object sender, EventArgs e)
        {
            tipoHASH.THash = "SHA384";
        }

        private void radioSHA512_CheckedChanged(object sender, EventArgs e)
        {
            tipoHASH.THash = "SHA512";
        }

        private void radioMD5_CheckedChanged(object sender, EventArgs e)
        {
            tipoHASH.THash = "MD5";
        }

        private void Hash_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            txtOrigem.Text = file.ReadLine();
            file.Close();
        }
    }
}
