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
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormOpus : Form
    {
        public FormOpus()
        {
            InitializeComponent();
        }

        ///////// SQL ////////////////////////////////////////////////
        
        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=" + Publica.caminhoDB + ";Version=3;New=True;Compress=True;");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch
            {

            }
            return sqlite_conn;
        }
        /////////////////////////////////////////////////////////

        public class Publica //Variável Pública
        {
            public static string texto;
            public static string caminhoDB = "";
            public static string raw_string_jid = "";
            public static string Media = "";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButtonArquivo.Checked)
            {

                //define as propriedades do controle 
                //OpenFileDialog
                this.ofd2.Multiselect = true;
                this.ofd2.Title = "Select file";
                ofd2.InitialDirectory = @"C:\";
                ofd2.Filter = "Files (*.opus)|*.opus";
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
                    button3.Enabled = true;

                    string pathListen = @"bin\listen";
                    string fullPath;
                    fullPath = Path.GetFullPath(pathListen);

                    Process process3 = new Process();
                    ProcessStartInfo startInfo3 = new ProcessStartInfo();
                    startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo3.CreateNoWindow = true;
                    startInfo3.UseShellExecute = false;
                    startInfo3.RedirectStandardOutput = true;
                    startInfo3.WorkingDirectory = fullPath;
                    startInfo3.FileName = fullPath + "\\listen.exe";
                    startInfo3.Arguments = " \"" + textBox3.Text + "\"";
                    process3.StartInfo = startInfo3;
                    process3.Start();
                    process3.StandardOutput.ReadToEnd();
                    process3.Close();

                    string fullPathTXT;
                    String str = textBox3.Text;
                    StringBuilder sb = new StringBuilder(str);
                    fullPathTXT = sb.Replace(".opus", ".txt").ToString();

                    string fullPathWAV;
                    String str2 = textBox3.Text;
                    StringBuilder sb2 = new StringBuilder(str2);
                    fullPathWAV = sb2.Replace(".opus", ".wav").ToString();

                    webBrowser1.Navigate(fullPathTXT);

                    File.Delete(fullPathWAV);

                    listBox1.Items.Add(textBox3.Text);
                }
            }
            else
            {
                FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
                backupfolderIPEDArquivo.Description = "Choose source folder";
                if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = backupfolderIPEDArquivo.SelectedPath;
                    webBrowser1.Navigate(backupfolderIPEDArquivo.SelectedPath);                    
                    listBox1.Items.Clear();

                    DirectoryInfo Dir = new DirectoryInfo(@textBox3.Text);
                    // Busca automaticamente todos os arquivos em todos os subdiretórios
                    FileInfo[] Files = Dir.GetFiles("*.opus", SearchOption.AllDirectories);
                    foreach (FileInfo File in Files)
                    {
                        listBox1.Items.Add(File.FullName);
                    }
                      
                    button2.Enabled = true;
                    checkBoxContatos.Enabled = true;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //panel3.Enabled = false;
            //panelProcesso.Visible = true;

            //timer1.Start();

            //backgroundWorker3.RunWorkerAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.new.seg.br/");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathListen = @"bin\listen";
            string fullPath;
            fullPath = Path.GetFullPath(pathListen);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.WorkingDirectory = fullPath;
            startInfo3.FileName = fullPath + "\\listen.exe";
            startInfo3.Arguments = " \"" + listBox1.Text + "\"";
            process3.StartInfo = startInfo3;
            process3.Start();
            process3.StandardOutput.ReadToEnd();
            process3.Close();

            string fullPathTXT;
            String str = listBox1.Text;
            StringBuilder sb = new StringBuilder(str);
            fullPathTXT = sb.Replace(".opus", ".txt").ToString();

            string fullPathWAV;
            String str2 = listBox1.Text;
            StringBuilder sb2 = new StringBuilder(str2);
            fullPathWAV = sb2.Replace(".opus", ".wav").ToString();            

            webBrowser1.Navigate(fullPathTXT);

            File.Delete(fullPathWAV);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            pictureBox2.Visible = true;

            listBox1.Enabled = false;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            StreamWriter EscreverTXT1 = new StreamWriter(textBox3.Text + "\\audio-report.html");
            EscreverTXT1.WriteLine($"<!doctype html>");
            EscreverTXT1.WriteLine($"<html lang='pt-BR'>");
            EscreverTXT1.WriteLine($"	<head>");
            EscreverTXT1.WriteLine($"		<meta charset='UTF-8'/>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<title>Audio file transcription report</title>");
            EscreverTXT1.WriteLine($"		<style>");
            EscreverTXT1.WriteLine($"			.d-none-logo {{display: none}}");
            EscreverTXT1.WriteLine($"			pre {{font - family: monospace;}}");
            EscreverTXT1.WriteLine($"			body {{margin: 0 auto; background: #EDEDED; color: #444444; font-family: Verdana; font-size: 14px; text-align: center; line-height: 1.2;}}");
            EscreverTXT1.WriteLine($"			#page {{margin: 0 auto; text-align: left; background: #fff; border: solid 1px #DDDDDD; width: 1000px;}}");
            EscreverTXT1.WriteLine($"			table {{background - color: #ffffff; border-collapse: collapse; border-style: solid; border-width: 1px; border-color: #8e8e8e; width: 80%; table-layout: fixed;line-height: 1.5;}}");
            EscreverTXT1.WriteLine($"			tr:nth-child(even) {{background: #CCC;}}");
            EscreverTXT1.WriteLine($"			tr:nth-child(odd) {{background: #FFF;}}");
            EscreverTXT1.WriteLine($"			span.play:before {{content: '\\25BA';}}");
            EscreverTXT1.WriteLine($"		</style>");
            EscreverTXT1.WriteLine($"		<script src='https://code.jquery.com/jquery-3.6.0.min.js'></script>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<script>");
            EscreverTXT1.WriteLine($"			$(document).ready(function() {{");
            EscreverTXT1.WriteLine($"				$('body').on('click', '.audio', function (e) {{");
            EscreverTXT1.WriteLine($"					e.preventDefault();");
            EscreverTXT1.WriteLine($"					$('.audio-control').remove();");
            EscreverTXT1.WriteLine($"					$(this).prepend(\"<audio controls class='audio-control'><source src='\" + $(this).attr('href') + \"' type='audio/ogg'></audio><br>\");");
            EscreverTXT1.WriteLine($"				}});");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"		</script>");
            EscreverTXT1.WriteLine($"	</head>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"	<body>");
            EscreverTXT1.WriteLine($"		<table border='1' align='center' cellpadding='3'>");
            EscreverTXT1.WriteLine($"			<tr>");
            EscreverTXT1.WriteLine($"				<th width='5%'><strong><span>.</span></strong></th>");
            EscreverTXT1.WriteLine($"				<th width='45%'><strong><span>File</span></strong></th>");
            EscreverTXT1.WriteLine($"				<th width='50%'><strong><span>Transcription</span></strong></th>");
            EscreverTXT1.WriteLine($"			</tr>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			<tbody>");
            EscreverTXT1.WriteLine($"");

            int contar = 1;

            foreach (string Items in listBox1.Items)
            {
                try 
                {
                    string pathListen = @"bin\listen";
                    string fullPath;
                    fullPath = Path.GetFullPath(pathListen);

                    Process process3 = new Process();
                    ProcessStartInfo startInfo3 = new ProcessStartInfo();
                    startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo3.CreateNoWindow = true;
                    startInfo3.UseShellExecute = false;
                    startInfo3.RedirectStandardOutput = true;
                    startInfo3.WorkingDirectory = fullPath;
                    startInfo3.FileName = fullPath + "\\listen.exe";
                    startInfo3.Arguments = " \"" + Items + "\"";
                    process3.StartInfo = startInfo3;
                    process3.Start();
                    process3.StandardOutput.ReadToEnd();
                    process3.Close();

                    string fullPathTXT = Items;
                    String str = Items;
                    StringBuilder sb = new StringBuilder(str);
                    fullPathTXT = sb.Replace(".opus", ".txt").ToString();

                    string fullPathWAV = Items;
                    String str2 = Items;
                    StringBuilder sb2 = new StringBuilder(str2);
                    fullPathWAV = sb2.Replace(".opus", ".wav").ToString();

                    webBrowser1.Navigate(fullPathTXT);

                    File.Delete(fullPathWAV);

                    /////// SQL ////////////////////////////////////
                    if (checkBoxContatos.Checked)
                    {                   
                        SQLiteConnection sqlite_conn;
                        sqlite_conn = CreateConnection();

                        SQLiteDataReader sqlite_datareader;
                        SQLiteCommand sqlite_cmd;
                        sqlite_cmd = sqlite_conn.CreateCommand();

                        string NameMedia;
                        String str3 = Items;
                        StringBuilder sb3 = new StringBuilder(str3);
                        NameMedia = sb3.Replace("PTT-", "*").ToString();

                        string[] SeparaMedia = NameMedia.Split('*');
                        Publica.Media = SeparaMedia[1];
                        Publica.Media = "PTT-" + Publica.Media;
                     
                        sqlite_cmd.CommandText = "SELECT * FROM message_media LEFT JOIN chat_view ON chat_view._id = message_media.chat_row_id WHERE file_path LIKE '%" + Publica.Media + "%'";

                        sqlite_datareader = sqlite_cmd.ExecuteReader();                      

                        while (sqlite_datareader.Read())
                        {
                            try
                            {
                                //ESQUEMA NOVO
                                Publica.raw_string_jid = sqlite_datareader.GetString(40); //raw_string_jid

                                //ESQUEMA ANTIGO
                                //Publica.raw_string_jid = sqlite_datareader.GetString(38); //raw_string_jid
                            }
                            catch
                            {
                                Publica.raw_string_jid = "NULL";
                            }
                        }

                        sqlite_conn.Close();                        
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////


                    /////////////// Leitura texto ////////////////////////////////////////////////////////////////////
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(fullPathTXT, Encoding.Default);
                    while ((line = file.ReadLine()) != null)
                    {
                        Publica.texto = line;
                    }
                    file.Close();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////

                    String strP = Items;
                    String ItemsP;

                    StringBuilder sbP = new StringBuilder(strP);
                    ItemsP = sbP.Replace(@textBox3.Text, ".").ToString();

                    EscreverTXT1.WriteLine($"				<tr>");
                    EscreverTXT1.WriteLine($"					<td>{contar}</td>");
                    EscreverTXT1.WriteLine($"					<td align='left'><strong>File:</strong> <a href='{ItemsP}' class='audio play'>{ItemsP}</a><br>");
                    //EscreverTXT1.WriteLine($"						<strong>Path:</strong> {ItemsP}<br>");
                    EscreverTXT1.WriteLine($"						<strong>MD5:</strong> {BytesToString(GetHashMD5(Items))}<br>");

                    //////// SQL /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (checkBoxContatos.Checked) 
                    {                 
                        EscreverTXT1.WriteLine($"						<strong>Contact:</strong> {Publica.raw_string_jid}<br>");
                        
                        if (checkBoxLINKhtml.Checked) 
                        { 
                            EscreverTXT1.WriteLine($"						<strong>Chat HTML:</strong> <a href='./WhatsAppChat-{Publica.raw_string_jid}.html'>{Publica.raw_string_jid}</a><br>");
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    EscreverTXT1.WriteLine($"					</td>");
                    EscreverTXT1.WriteLine($"					<td align='left'>{Publica.texto}</td>");
                    EscreverTXT1.WriteLine($"				</tr>");

                    contar++;
                }
                catch 
                {                
                
                }
            }

            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				<br> Avilla Forensics");
            EscreverTXT1.WriteLine($"			</tbody>");
            EscreverTXT1.WriteLine($"		</table>");
            EscreverTXT1.WriteLine($"	</body>");
            EscreverTXT1.WriteLine($"</html>");
            EscreverTXT1.Close();
        }

        //######################################################################################
        // Inicia o provedor do serviço de criptografia
        private MD5 Md5 = MD5.Create();

        // Calcula o Hash do arquivo
        private byte[] GetHashMD5(string arquivo)
        {
            using (FileStream stream = File.OpenRead(arquivo))
            {
                return Md5.ComputeHash(stream);
            }
        }

        // Inicia o provedor do serviço de criptografia
        // Cria uma nova instância da implementação padrão do SHA256.
        private SHA256 Sha256 = SHA256.Create();

        // Calcula o Hash do Arquivo
        private byte[] GetHashSha256(string arquivo)
        {
            using (FileStream stream = File.OpenRead(arquivo))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        // Retorna um array de bytes como uma sequencia de valores Hexa
        public static string BytesToString(byte[] bytes)
        {
            string resultado = "";
            foreach (byte b in bytes)
            {
                resultado += b.ToString("x2");
            }
            return resultado;
        }
        //######################################################################################

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel3.Enabled = true;
            pictureBox2.Visible = false;

            listBox1.Enabled = true;
        }

        private void FormOpus_Load(object sender, EventArgs e)
        {
            //textBox3.TextAlign 
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/delcristianoritta/whatsapptranscriber");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Uberi/speech_recognition");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd3.Multiselect = true;
            this.ofd3.Title = "Select File";
            ofd3.InitialDirectory = @"C:\";
            ofd3.Filter = "Files (*.db)|*.db";
            ofd3.CheckFileExists = true;
            ofd3.CheckPathExists = true;
            ofd3.FilterIndex = 2;
            ofd3.RestoreDirectory = true;
            ofd3.ReadOnlyChecked = true;
            ofd3.ShowReadOnly = true;

            DialogResult drIPED2 = this.ofd3.ShowDialog();

            if (drIPED2 == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd3.FileName;
                Publica.caminhoDB = ofd3.FileName;
                button2.Enabled = true;
            }
        }

        private void checkBoxLINKhtml_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBoxContatos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxContatos.Checked) 
            {
                checkBoxLINKhtml.Enabled = true;
                panel1.Enabled = true;
                button2.Enabled = false;
            }
            else 
            {
                checkBoxLINKhtml.Checked = false;
                checkBoxLINKhtml.Enabled = false;
                panel1.Enabled = false;
                button2.Enabled = true;
            }

        }
    }
}
