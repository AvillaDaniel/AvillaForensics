//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormDecript : Form
    {
        public FormDecript()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
            backupfolderIPEDArquivo.Description = "Choose source folder backups databases";
            if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = backupfolderIPEDArquivo.SelectedPath;
                webBrowser1.Navigate(backupfolderIPEDArquivo.SelectedPath);
                listBox1.Items.Clear();

                if (radioButtonC14.Checked)                 
                {
                    textBox2.Text = backupfolderIPEDArquivo.SelectedPath + "\\key";
                    DirectoryInfo Dir = new DirectoryInfo(@textBox1.Text);
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    FileInfo[] Files = Dir.GetFiles("*.crypt14", SearchOption.AllDirectories);
                    foreach (FileInfo File in Files)
                    {
                        listBox1.Items.Add(File.FullName);
                    }
                }
                else 
                {
                    textBox2.Text = backupfolderIPEDArquivo.SelectedPath + "\\encrypted_backup.key";
                    DirectoryInfo Dir = new DirectoryInfo(@textBox1.Text);
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    FileInfo[] Files = Dir.GetFiles("*.crypt15", SearchOption.AllDirectories);
                    foreach (FileInfo File in Files)
                    {
                        listBox1.Items.Add(File.FullName);
                    }
                }
                button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ofd2.Multiselect = true;
            this.ofd2.Title = "Select file";
            ofd2.InitialDirectory = @"C:\";
            ofd2.Filter = "Files (key; *.key)|Key; *.key";
            ofd2.CheckFileExists = true;
            ofd2.CheckPathExists = true;
            ofd2.FilterIndex = 2;
            ofd2.RestoreDirectory = true;
            ofd2.ReadOnlyChecked = true;
            ofd2.ShowReadOnly = true;

            DialogResult drIPED = this.ofd2.ShowDialog();

            if (drIPED == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd2.FileName;
            }
        }

        private void FormDecript_Load(object sender, EventArgs e)
        {
            string pathADB = @"bin\WhatsApp-Crypt14-Crypt15-Decrypter-main";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);
            textBox4.Text = fullPath + "\\decrypt14_15.py";
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.python.org/");
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            foreach (string Items in listBox1.Items)
            {
                //try
                ProcessStartInfo processStartInfo3 = new ProcessStartInfo("cmd.exe");
                processStartInfo3.RedirectStandardInput = true;
                processStartInfo3.RedirectStandardOutput = true;
                processStartInfo3.UseShellExecute = false;
                processStartInfo3.CreateNoWindow = true;

                Process process3 = Process.Start(processStartInfo3);

                if (process3 != null)
                {
                    process3.StandardInput.WriteLine("python \"" + textBox4.Text + "\"" + " \"" + textBox2.Text + "\"" + " \"" + Items + "\"" + " \"" + Items + ".db\"");
                    process3.StandardInput.Close();
                    process3.StandardOutput.ReadToEnd();
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
        }
    }
}
