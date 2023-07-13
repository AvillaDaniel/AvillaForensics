//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormADB : Form
    {
        public FormADB()
        {
            InitializeComponent();
        }

        public class pacote //Variável Pública
        {
            public static int pausa = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolder = new FolderBrowserDialog();
            backupfolder.Description = "Choose destination folder";
            if (backupfolder.ShowDialog() == DialogResult.OK)
            {
                backupTextbox.Text = backupfolder.SelectedPath;
                textBox1.Text += "\r\n>> Destiny:  " + backupTextbox.Text;
                webBrowser1.Navigate(backupfolder.SelectedPath);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
            MessageBox.Show("This process may take some time. The full backup will be requested on the device screen, enter a password if necessary.", "Attention!");
            
            textBox1.Text += "\r\n>> Destiny:  " + backupTextbox.Text;
            textBox1.Text += "\r\n>> Extraction Started. (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            textBox1.Text += "\r\n>> On the device click (Backup my data)";
            button1.Text = "Wait...";
            button1.Enabled = false;
            button9.Enabled = false;
            pictureBox3.Visible = true;
            panel1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathABU = @"abu";
            string fullPathABU;
            fullPathABU = Path.GetFullPath(pathABU);

            //Remove proteções de verificação da instalação de aplicativos via USB
            ////////////////////////////////////////////////////////////////////////////////////////
            Process processWhats13 = new Process();
            ProcessStartInfo startInfoWhats13 = new ProcessStartInfo();
            startInfoWhats13.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats13.CreateNoWindow = true;
            startInfoWhats13.UseShellExecute = false;
            startInfoWhats13.RedirectStandardOutput = true;
            startInfoWhats13.FileName = fullPath + "\\adb.exe";
            startInfoWhats13.Arguments = " shell settings put global verifier_verify_adb_installs 0";
            processWhats13.StartInfo = startInfoWhats13;
            processWhats13.Start();
            processWhats13.StandardOutput.ReadToEnd();
            processWhats13.Close();

            Process processWhats14 = new Process();
            ProcessStartInfo startInfoWhats14 = new ProcessStartInfo();
            startInfoWhats14.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats14.CreateNoWindow = true;
            startInfoWhats14.UseShellExecute = false;
            startInfoWhats14.RedirectStandardOutput = true;
            startInfoWhats14.FileName = fullPath + "\\adb.exe";
            startInfoWhats14.Arguments = " shell settings put global package_verifier_enable 0";
            processWhats14.StartInfo = startInfoWhats14;
            processWhats14.Start();
            processWhats14.StandardOutput.ReadToEnd();
            processWhats14.Close();

            //Removendo bloqueio de tela automatico
            ////////////////////////////////////////////////////////////////////////////////////////
            Process processWhats19 = new Process();
            ProcessStartInfo startInfoWhats19 = new ProcessStartInfo();
            startInfoWhats19.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats19.CreateNoWindow = true;
            startInfoWhats19.UseShellExecute = false;
            startInfoWhats19.RedirectStandardOutput = true;
            startInfoWhats19.FileName = fullPath + "\\adb.exe";
            startInfoWhats19.Arguments = " shell settings put global stay_on_while_plugged_in 3";
            processWhats19.StartInfo = startInfoWhats19;
            processWhats19.Start();
            processWhats19.StandardOutput.ReadToEnd();
            processWhats19.Close();

            /// Salva path do arquivo .ab
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);
            StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\TempPathAB2.txt");
            EscreverTXT4.WriteLine($"{backupTextbox.Text}\\backup-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.ab");
            EscreverTXT4.Close();

            pacote.pausa = 0;
            backgroundWorker2.RunWorkerAsync();

            //Iniciando o Backup ADB
            ////////////////////////////////////////////////////////////////////////////////////////
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = fullPath + "\\adb.exe";
            startInfo.Arguments = " backup -apk -obb -system -all -shared -f \"" + backupTextbox.Text + "\\backup-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".ab" + "\"";
            process.StartInfo = startInfo;
            process.Start();       
            process.StandardOutput.ReadToEnd();
            process.Close();

            pacote.pausa = 1;

            //Retornando bloqueio de tela automatico
            ////////////////////////////////////////////////////////////////////////////////////////
            Process processWhats20 = new Process();
            ProcessStartInfo startInfoWhats20 = new ProcessStartInfo();
            startInfoWhats20.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats20.CreateNoWindow = true;
            startInfoWhats20.UseShellExecute = false;
            startInfoWhats20.RedirectStandardOutput = true;
            startInfoWhats20.FileName = fullPath + "\\adb.exe";
            startInfoWhats20.Arguments = " shell settings put global stay_on_while_plugged_in 0";
            processWhats20.StartInfo = startInfoWhats20;
            processWhats20.Start();
            processWhats20.StandardOutput.ReadToEnd();
            processWhats20.Close();

            //Pega o Path do caminho do arquivo .AB
            System.IO.StreamReader file = new System.IO.StreamReader(@fullPathTEMP + "\\TempPathAB2.txt");
            string caminho = file.ReadLine();
            file.Close();

            //textBox1.Text += "\r\n>> Expanding .ab file data (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            //Convertendo backup com o ABU.
            //Process processWhats40 = new Process();
            //ProcessStartInfo startInfoWhats40 = new ProcessStartInfo();
            //startInfoWhats40.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfoWhats40.RedirectStandardInput = true;
            //startInfoWhats40.CreateNoWindow = true;
            //startInfoWhats40.UseShellExecute = false;
            //startInfoWhats40.RedirectStandardOutput = true;
            //startInfoWhats40.FileName = fullPathABU + "\\abu.exe";
            //startInfoWhats40.Arguments = " \"" + caminho + "\" --unpack \"" + backupTextbox.Text + "\\DATA\" --password " + textBoxPassAB.Text;
            //processWhats40.StartInfo = startInfoWhats40;
            //processWhats40.Start();
            //processWhats40.StandardOutput.ReadToEnd();
            //processWhats40.Close();

            if (checkBox3.Checked) 
            {
                textBox1.Text += "\r\n>> Generating logs, please wait... (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                string Hasmd5 = BytesToString(GetHashMD5(@caminho));
                string Hassha1 = BytesToString(GetHashSha256(@caminho));

                FileInfo fileInfo = new FileInfo(@caminho);
                textBox1.Text += "\r\n>> .ab file size: " + fileInfo.Length + " bytes";                

                textBox1.Text += "\r\n>> MD5 hash of the .ab file: " + Hasmd5;
                textBox1.Text += "\r\n>> SHA-256 hash of the .ab file: " + Hassha1;

                StreamWriter EscreverTXT2 = new StreamWriter(@backupTextbox.Text + "\\Logs_Ferramenta.txt");
                EscreverTXT2.WriteLine($"{textBox1.Text}");
                EscreverTXT2.Close();

                //shell getprop ro.boot.serialno
                //shell getprop ro.build.version.release
                //shell getprop ro.product.model 

                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPath + "\\adb.exe";
                startInfo3.Arguments = " shell getprop ro.boot.serialno";
                process3.StartInfo = startInfo3;
                process3.Start();
                string NSerie = process3.StandardOutput.ReadToEnd();
                process3.Close();

                Process process4 = new Process();
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.RedirectStandardOutput = true;
                startInfo4.FileName = fullPath + "\\adb.exe";
                startInfo4.Arguments = " shell getprop ro.build.version.release";
                process4.StartInfo = startInfo4;
                process4.Start();
                string NVer = process4.StandardOutput.ReadToEnd();
                process4.Close();

                Process process5 = new Process();
                ProcessStartInfo startInfo5 = new ProcessStartInfo();
                startInfo5.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo5.CreateNoWindow = true;
                startInfo5.UseShellExecute = false;
                startInfo5.RedirectStandardOutput = true;
                startInfo5.FileName = fullPath + "\\adb.exe";
                startInfo5.Arguments = " shell getprop ro.product.model";
                process5.StartInfo = startInfo5;
                process5.Start();
                string Modelo = process5.StandardOutput.ReadToEnd();
                process5.Close();

                StreamWriter EscreverTXT = new StreamWriter(backupTextbox.Text + "\\Logs_Coleta.txt");
                EscreverTXT.WriteLine($"AVILLA FORENSICS 3.0");
                EscreverTXT.WriteLine($"");
                EscreverTXT.WriteLine($"Collected Device: {Modelo}");
                EscreverTXT.WriteLine($"Operating System Version: {NVer}");
                EscreverTXT.WriteLine($"Device Serial Number: {NSerie}");
                EscreverTXT.WriteLine($"Data: {DateTime.Now.ToString("dd-MM-yyyy")}");
                EscreverTXT.WriteLine($"Hour: {DateTime.Now.ToString("HH-mm-ss")}");
                EscreverTXT.WriteLine($"");
                EscreverTXT.WriteLine($"Extraction type: Logic");
                EscreverTXT.WriteLine($"Generated File: {caminho}");
                EscreverTXT.WriteLine($"File size: {fileInfo.Length} bytes");
                EscreverTXT.WriteLine($"Hash MD5: {Hasmd5}");
                EscreverTXT.WriteLine($"Hash SHA-256: {Hassha1}");
                EscreverTXT.WriteLine($"");
                EscreverTXT.WriteLine($"Tool logs: {backupTextbox.Text}" + "\\Logs_Ferramenta.txt");
                EscreverTXT.WriteLine($"Hash MD5: {BytesToString(GetHashMD5(backupTextbox.Text + "\\Logs_Ferramenta.txt"))}");
                EscreverTXT.WriteLine($"Hash SHA-256: {BytesToString(GetHashSha256(backupTextbox.Text + "\\Logs_Ferramenta.txt"))}");
                EscreverTXT.Close();

                textBox1.Text += "\r\n>> Generated logs (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox3.Visible = false;
            panel1.Enabled = true;
            textBox1.Text += "\r\n>> Extraction Completed. " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            button1.Text = "Extract";
            button1.Enabled = true;
            button9.Enabled = true;            

            //backupTextbox.Text = "";
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

        private void FormADB_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            backupTextbox.Text = file.ReadLine() + "\\BackupADB";
            file.Close();

            string folder = backupTextbox.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            webBrowser1.Navigate(backupTextbox.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
  
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            while (pacote.pausa != 1)
            {
                try
                {
                    string pathTEMP = @"temp";
                    string fullPathTEMP;
                    fullPathTEMP = Path.GetFullPath(pathTEMP);

                    System.IO.StreamReader file = new System.IO.StreamReader(@fullPathTEMP + "\\TempPathAB2.txt");

                    FileInfo fileInfo = new FileInfo(file.ReadLine());

                    file.Close();

                    StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\TempSizeAB2.txt");
                    EscreverTXT4.WriteLine($"File .ab size: {fileInfo.Length} bytes");
                    EscreverTXT4.Close();

                    webBrowser1.Navigate(@fullPathTEMP + "\\TempSizeAB2.txt");
                }
                catch { }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //timer2.Start();
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
            textBox1.Text = process3.StandardOutput.ReadToEnd();
            process3.Close();

            //string arquivo = @"C:\Teste\manipulacao2\backup-tar-2022-11-04-00-36-39\apps\com.whatsapp\files\Logs\whatsapp-2022-11-04.1.log.gz";

            //string extensao = Path.GetExtension(arquivo);

            //textBox1.Text = extensao;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            webBrowser1.Navigate(@backupTextbox.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {       
         
            //Process process3 = new Process();
            //ProcessStartInfo startInfo3 = new ProcessStartInfo();
            //startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo3.CreateNoWindow = true;
            //startInfo3.UseShellExecute = false;            
            //startInfo3.RedirectStandardOutput = true;
            //startInfo3.Verb = "runas";
            //startInfo3.FileName = "C:\\Windows\\System32\\cmd.exe";
            //startInfo3.Arguments = " C:\\dd-0.6beta3\\teste.bat";
            //process3.StartInfo = startInfo3;
            //process3.Start();
            //process3.StandardOutput.ReadToEnd();
            //process3.Close();

        }
    }
}
