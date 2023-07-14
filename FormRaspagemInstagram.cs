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
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormRaspagemInstagram : Form
    {
        public FormRaspagemInstagram()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin\instaloader";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            string Comentarios = "";
            string Localização = "";
            string Historias = "";
            string Destaques = "";
            string Marcacoes = "";
            string IGVT = "";

            if (checkBoxComentarios.Checked) 
            {
                Comentarios = "--comments";
            }

            if (checkBoxLocalizacao.Checked)
            {
                Localização = "--geotags";
            }

            if (checkBoxHistorias.Checked)
            {
                Historias = "--stories";
            }

            if (checkDestaques.Checked)
            {
                Destaques = "--highlights";
            }

            if (checkBoxMarcacoes.Checked)
            {
                Marcacoes = "--tagged";
            }

            if (checkBoxIGVT.Checked)
            {
                IGVT = "--igtv";
            }
           
            if (radioButtonAlvo.Checked)
            {
                StreamWriter EscreverTXT = new StreamWriter(TXTdestino.Text + "\\Raspagem-Alvo-" + TXTalvo.Text + ".bat");
                
                if (TXTlogin.Text != "" ^ TXTsenha.Text != "") 
                {
                    EscreverTXT.WriteLine($@"{fullPathBin + "\\instaloader.exe"} profile {TXTalvo.Text} {Comentarios} {Localização} {Historias} {Destaques} {Marcacoes} {IGVT} --login {TXTlogin.Text} --password {TXTsenha.Text}");
                }
                else
                {
                    EscreverTXT.WriteLine($@"{fullPathBin + "\\instaloader.exe"} profile {TXTalvo.Text} {Comentarios} {Localização} {Historias} {Destaques} {Marcacoes} {IGVT} ");
                }                
                EscreverTXT.Close();
            }
            else
            {
                StreamWriter EscreverTXT = new StreamWriter(TXTdestino.Text + "\\Raspagem-Alvo-Seguindo-" + TXTalvo.Text + ".bat");
                if (TXTlogin.Text != "" ^ TXTsenha.Text != "")
                {
                    EscreverTXT.WriteLine($@"{fullPathBin + "\\instaloader.exe"} @{TXTalvo.Text} {Comentarios} {Localização} {Historias} {Destaques} {Marcacoes} {IGVT} --login {TXTlogin.Text} --password {TXTsenha.Text}");
                }
                else
                {
                    EscreverTXT.WriteLine($@"{fullPathBin + "\\instaloader.exe"} @{TXTalvo.Text} {Comentarios} {Localização} {Historias} {Destaques} {Marcacoes} {IGVT} ");
                }
                EscreverTXT.Close();
            }
        }

        private void FormRaspagemInstagram_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(TXTdestino.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPED = new FolderBrowserDialog();
            backupfolderIPED.Description = "Choose destination folder";
            if (backupfolderIPED.ShowDialog() == DialogResult.OK)
            {
                TXTdestino.Text = backupfolderIPED.SelectedPath;
                //textBox1.Text += "\r\n>> Destino: " + ipedtextbox.Text;
                webBrowser1.Navigate(backupfolderIPED.SelectedPath);
                button1.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://instaloader.github.io/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/instaloader/instaloader");       
        }
    }
}
