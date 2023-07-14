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
    public partial class FormAbTar : Form
    {
        public FormAbTar()
        {
            InitializeComponent();
        }

        public class pacote //Variável Pública
        {
            public static int pausa = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            string caminho = file.ReadLine();
            file.Close();

            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = true;
            this.ofd1.Title = "Select File";
            ofd1.InitialDirectory = caminho;
            ofd1.Filter = "Files AB (*.ab)|*.ab";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true; 

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Txtorigem.Text = ofd1.FileName;
                textBoxPATH.Text = ofd1.InitialDirectory;
                textBox1.Text += ">> Origin:  " + ofd1.FileName;

                Txtdestino.Text = Txtorigem.Text + ".tar";
                textBox1.Text += "\r\n>> Destiny:  " + Txtdestino.Text;
                button2.Enabled = true;

                webBrowser1.Navigate(@caminho);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButtonSenha.Checked)
            {
                panelSenha.Visible = true;
                TxtSenha.Text = "";
                TxtSenha.Focus();
            }
            else
            {
                MessageBox.Show("This process may take", "Attention!");
                textBox1.Text += "\r\n>> Convert .AB to .Tar started.";
                button2.Text = "Wait...";
                button2.Enabled = false;
                button7.Enabled = false;
                panel2.Enabled = false;
                backgroundWorker2.RunWorkerAsync();

                pictureBox2.Visible = true;
                textBox1.Text = "\r\n>> Extract in Progress:";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtSenha.Text))
            {
                MessageBox.Show("Empty password field", "Attention!");
            }
            else
            {
                panelSenha.Visible = false;

                MessageBox.Show("This process may take some time, please wai", "Attention!");
                textBox1.Text += "\r\n>> Convert .AB to .Tar started.";
                button2.Text = "Wait...";
                button2.Enabled = false;
                button7.Enabled = false;

                panel2.Enabled = false;

                backgroundWorker2.RunWorkerAsync();

                pictureBox2.Visible = true;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panelSenha.Visible = false;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathExtractor = @"backup_extractor";
            string fullPath;
            fullPath = Path.GetFullPath(pathExtractor);

            /// Salva path do arquivo .tar
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);
            StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\TempPathAB3.txt");
            EscreverTXT4.WriteLine($"{Txtdestino.Text}");
            EscreverTXT4.Close();

            pacote.pausa = 0;
            backgroundWorker3.RunWorkerAsync();

            Process processAPK = new Process();
            ProcessStartInfo startInfoAPK = new ProcessStartInfo();
            startInfoAPK.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoAPK.CreateNoWindow = true;
            startInfoAPK.UseShellExecute = false;
            startInfoAPK.RedirectStandardOutput = true;
            startInfoAPK.FileName = "java.exe";

            if (radioButtonSSenha.Checked)
            {
                startInfoAPK.Arguments = " -jar " + fullPath + "\\abe.jar unpack \"" + Txtorigem.Text + "\" \"" + Txtdestino.Text + "\"";
            }
            else
            {
                startInfoAPK.Arguments = " -jar " + fullPath + "\\abe.jar unpack \"" + Txtorigem.Text + "\" \"" + Txtdestino.Text + "\"" + " " + TxtSenha.Text;
            }
            processAPK.StartInfo = startInfoAPK;
            processAPK.Start();
            processAPK.StandardOutput.ReadToEnd();

            pacote.pausa = 1;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;

            textBox1.Text += "\r\n>> Conversion Complete.";
            button2.Text = "Convert";

            button7.Enabled = true;

            panel2.Enabled = true;

            Txtorigem.Text = "";
            Txtdestino.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void FormAbTar_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panelSenha_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ofd1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            while (pacote.pausa != 1)
            {
                try
                {
                    string pathTEMP = @"temp";
                    string fullPathTEMP;
                    fullPathTEMP = Path.GetFullPath(pathTEMP);

                    System.IO.StreamReader file = new System.IO.StreamReader(@fullPathTEMP + "\\TempPathAB3.txt");

                    FileInfo fileInfo = new FileInfo(file.ReadLine());

                    StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\TempSizeAB3.txt");
                    EscreverTXT4.WriteLine($"File .ab size: {fileInfo.Length} bytes");
                    EscreverTXT4.Close();

                    webBrowser1.Navigate(@fullPathTEMP + "\\TempSizeAB3.txt");
                }
                catch { }
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            webBrowser1.Navigate(textBoxPATH.Text);
        }
    }
}
