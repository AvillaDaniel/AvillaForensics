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
    public partial class FormIPED : Form
    {
        public FormIPED()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButtonArquivo.Checked)
            {
                string pathTEMP = @"temp";
                string fullPathTEMP;
                fullPathTEMP = Path.GetFullPath(pathTEMP);

                System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
                string caminho = file.ReadLine();
                file.Close();

                //define as propriedades do controle 
                //OpenFileDialog
                this.ofd2.Multiselect = true;
                this.ofd2.Title = "Select file";
                ofd2.InitialDirectory = @caminho;
                ofd2.Filter = "Files (*.tar; *.zip; *.dd; *.ufdr)|*.tar; *.zip; *.dd; *.ufdr|All files (*.*)|*.*";
                ofd2.CheckFileExists = true;
                ofd2.CheckPathExists = true;
                ofd2.FilterIndex = 2;
                ofd2.RestoreDirectory = true;
                ofd2.ReadOnlyChecked = true;
                ofd2.ShowReadOnly = true;

                DialogResult drIPED = this.ofd2.ShowDialog();

                if (drIPED == System.Windows.Forms.DialogResult.OK)
                {
                    textBox3.Text = ofd2.FileName;
                    textBox1.Text += "\r\n>> Origin:  " + textBox3.Text;
                    button4.Enabled = true;
                }
            }
            else
            {
                FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
                backupfolderIPEDArquivo.Description = "Choose source folder";
                if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = backupfolderIPEDArquivo.SelectedPath;
                    textBox1.Text += "\r\n>> Origin: " + textBox3.Text;
                    button4.Enabled = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPED = new FolderBrowserDialog();
            backupfolderIPED.Description = "Choose destination folder";
            if (backupfolderIPED.ShowDialog() == DialogResult.OK)
            {
                ipedtextbox.Text = backupfolderIPED.SelectedPath;
                textBox1.Text += "\r\n>> Destiny: " + ipedtextbox.Text;
                webBrowser1.Navigate(backupfolderIPED.SelectedPath);
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This process may take some time, please wait", "Attention!");
            textBox1.Text += "\r\n>> IPED indexing started.";
            button3.Text = "whait...";
            button3.Enabled = false;
            button4.Enabled = false;
            button10.Enabled = false;

            backgroundWorker3.RunWorkerAsync();

            panel3.Enabled = false;
            pictureBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
            backupfolderIPEDArquivo.Description = "Choose source folder";
            if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = backupfolderIPEDArquivo.SelectedPath;
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            Process processIPED = new Process();
            ProcessStartInfo startInfoIPED = new ProcessStartInfo();
            startInfoIPED.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoIPED.CreateNoWindow = true;
            startInfoIPED.UseShellExecute = false;
            startInfoIPED.RedirectStandardOutput = true;
            startInfoIPED.FileName = textBox2.Text + "\\iped.exe";
            startInfoIPED.Arguments = " -d \"" + textBox3.Text + "\" -o \"" + ipedtextbox.Text + "\"";
            processIPED.StartInfo = startInfoIPED;
            processIPED.Start();
            processIPED.StandardOutput.ReadToEnd();
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel3.Enabled = true;

            textBox1.Text += "\r\n>> Generated Indexer.";
            button3.Text = "Generate";

            button10.Enabled = true;

            textBox3.Text = "";
            ipedtextbox.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.java.com/pt-BR/download/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/sepinf-inc/IPED");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void FormIPED_Load(object sender, EventArgs e)
        {
            string pathIPED = @"IPED-4.1.3_and_plugins\iped-4.1.3";
            string fullPath;
            fullPath = Path.GetFullPath(pathIPED);
            textBox2.Text = fullPath;
        }
    }
}
