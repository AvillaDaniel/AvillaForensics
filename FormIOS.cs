//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormIOS : Form
    {
        public FormIOS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process5 = new Process();
            ProcessStartInfo startInfo5 = new ProcessStartInfo();
            startInfo5.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo5.CreateNoWindow = true;
            startInfo5.UseShellExecute = false;
            startInfo5.RedirectStandardOutput = true;
            startInfo5.FileName = fullPath + "\\idevicebackup2.exe";
            startInfo5.Arguments = " backup encryption off " + textBox4.Text;
            process5.StartInfo = startInfo5;
            process5.Start();
            textBox1.Text = process5.StandardOutput.ReadToEnd();
            process5.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            panel3.Visible = false;
            textBox4.Text = "";

            //MessageBox.Show("This process may take some time, please wait.", "Attention!");
            Process process4 = new Process();
            ProcessStartInfo startInfo4 = new ProcessStartInfo();
            startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo4.CreateNoWindow = true;
            startInfo4.UseShellExecute = false;
            startInfo4.RedirectStandardOutput = true;
            startInfo4.FileName = fullPath + "\\idevicename.exe";
            //startInfo3.Arguments = " -s";
            process4.StartInfo = startInfo4;
            process4.Start();
            labelName.Text = process4.StandardOutput.ReadToEnd();
            process4.Close();

            Process process1 = new Process();
            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo1.CreateNoWindow = true;
            startInfo1.UseShellExecute = false;
            startInfo1.RedirectStandardOutput = true;
            startInfo1.FileName = fullPath + "\\idevice_id.exe";
            //startInfo3.Arguments = " -s";
            process1.StartInfo = startInfo1;
            process1.Start();
            labelID.Text = process1.StandardOutput.ReadToEnd();
            process1.Close();

            string[] ID = labelID.Text.Split(' ');
            textBoxID.Text = ID[0];

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            //ProductVersion
            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\ideviceinfo.exe | findstr \"ProductVersion:\" > " + fullPathTEMP + "\\ProductVersion.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\ProductVersion.txt");
            LbVersion.Text = file.ReadLine();
            file.Close();

            //PhoneNumber
            ProcessStartInfo processStartInfoAPPT2 = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT2.RedirectStandardInput = true;
            processStartInfoAPPT2.RedirectStandardOutput = true;
            processStartInfoAPPT2.UseShellExecute = false;
            processStartInfoAPPT2.CreateNoWindow = true;
            Process processAPPT2 = Process.Start(processStartInfoAPPT2);
            if (processAPPT2 != null)
            {
                processAPPT2.StandardInput.WriteLine(fullPath + "\\ideviceinfo.exe | findstr \"PhoneNumber:\" > " + fullPathTEMP + "\\PhoneNumber.txt");
                processAPPT2.StandardInput.Close();
                processAPPT2.StandardOutput.ReadToEnd();
            }

            System.IO.StreamReader file2 = new System.IO.StreamReader(fullPathTEMP + "\\PhoneNumber.txt");
            Lbnumber.Text = file2.ReadLine();
            file2.Close();

            //CRIPTOGRAFAR BACKUP - SENHA: 1234
            if (radioBSenha.Checked)
            {
                
                Process process5 = new Process();
                ProcessStartInfo startInfo5 = new ProcessStartInfo();
                startInfo5.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo5.CreateNoWindow = true;
                startInfo5.UseShellExecute = false;
                startInfo5.RedirectStandardOutput = true;
                startInfo5.FileName = fullPath + "\\idevicebackup2.exe";
                startInfo5.Arguments = " backup encryption on 1234";
                process5.StartInfo = startInfo5;
                process5.Start();
                textBox1.Text = process5.StandardOutput.ReadToEnd();
                process5.Close();

                string TesteVerificaBackup; 

                string[] VerificaBackup = textBox1.Text.Split(':');

                try //Não Deu Certo a Criptografia
                {
                    TesteVerificaBackup = VerificaBackup[1];
                    MessageBox.Show("This device already has a backup password set, please remove it before proceeding (Este dispositivo já tem uma senha de backup definida, remova-a antes de prosseguir)", "Attention!");
                    textBox1.Text += "\r\n>> IOS collection not started.";
                    panel3.Visible = true;
                }
                catch //Deu Certo a Criptografia
                {
                    MessageBox.Show("This device does not have a backup password, for a complete acquisition the tool has set a default password of 1234, which will be removed at the end. (Este dispositivo não possui senha de backup, para uma aquisição completa a ferramenta definiu uma senha padrão de 1234, que será removida ao final.)", "Attention!");

                    textBox1.Text += "\r\n>> Collection with encryption initiated. (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                    button4.Text = "Wait...";
                    button4.Enabled = false;

                    backgroundWorker1.RunWorkerAsync();

                    panel1.Enabled = false;
                    pictureBox2.Visible = true;
                }               
            }
            else
            {
                textBox1.Text += "\r\n>> Unencrypted collection started. (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                button4.Text = "Wait...";
                button4.Enabled = false;

                backgroundWorker1.RunWorkerAsync();

                panel1.Enabled = false;
                pictureBox2.Visible = true;
            }
        }

        private void FormIOS_Load(object sender, EventArgs e)
        {
            //textBox1.Text = ">> Escolha a pasta correspondente ao seu Itunes.";

            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            //nome do diretorio a ser criado
            string folder = @userProfile + "\\AppData\\Roaming\\Apple Computer\\MobileSync\\Backup";
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);           
            }

            webBrowser1.Navigate(userProfile + "/AppData/Roaming/Apple Computer/MobileSync/Backup");
            textBox2.Text = userProfile + "\\AppData\\Roaming\\Apple Computer\\MobileSync\\Backup";
            textBox3.Text = userProfile + "\\Apple\\MobileSync\\Backup";

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathExplorer = @"bin\itunes-backup-explorer";
            string fullPathExplorer;
            fullPathExplorer = Path.GetFullPath(pathExplorer);

            //BACKUP 
            if (radioBLiB.Checked)
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPath + "\\idevicebackup2.exe";                       
                if (radioButton1.Checked)
                {
                    startInfo3.Arguments = " backup --full \"" + textBox2.Text + "\"";
                }
                else
                {
                    startInfo3.Arguments = " backup --full \"" + textBox3.Text + "\"";
                }
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();
            }
            else
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = "C:\\Program Files (x86)\\Common Files\\Apple\\Mobile Device Support\\AppleMobileBackup.exe";
                startInfo3.Arguments = " -s " + textBoxID.Text + " -b";
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();
            }

            //REMOVER SENHA
            Process process5 = new Process();
            ProcessStartInfo startInfo5 = new ProcessStartInfo();
            startInfo5.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo5.CreateNoWindow = true;
            startInfo5.UseShellExecute = false;
            startInfo5.RedirectStandardOutput = true;
            startInfo5.FileName = fullPath + "\\idevicebackup2.exe";
            startInfo5.Arguments = " backup encryption off 1234";
            process5.StartInfo = startInfo5;
            process5.Start();
            process5.StandardOutput.ReadToEnd();
            process5.Close();

            //Abrir Itunes Backup Explorer
            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(" java -jar " + fullPathExplorer + "\\itunes-backup-explorer-1.4.jar");
                processAPPT.StandardInput.Close();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Enabled = true;
            textBox1.Text += "\r\n>> IOS Collection Completed. (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            button4.Text = "Start";
            button4.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\ideviceinfo.exe";
            startInfo3.Arguments = " -s";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
            process3.Close();

            Process process4 = new Process();
            ProcessStartInfo startInfo4 = new ProcessStartInfo();
            startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo4.CreateNoWindow = true;
            startInfo4.UseShellExecute = false;
            startInfo4.RedirectStandardOutput = true;
            startInfo4.FileName = fullPath + "\\idevicename.exe";
            //startInfo4.Arguments = " -s";
            process4.StartInfo = startInfo4;
            process4.Start();
            labelName.Text = process4.StandardOutput.ReadToEnd();
            process4.Close();

            Process process5 = new Process();
            ProcessStartInfo startInfo5 = new ProcessStartInfo();
            startInfo5.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo5.CreateNoWindow = true;
            startInfo5.UseShellExecute = false;
            startInfo5.RedirectStandardOutput = true;
            startInfo5.FileName = fullPath + "\\idevice_id.exe";
            //startInfo5.Arguments = " -s";
            process5.StartInfo = startInfo5;
            process5.Start();
            labelID.Text = process5.StandardOutput.ReadToEnd();
            process5.Close();

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            //ProductVersion
            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\ideviceinfo.exe | findstr \"ProductVersion:\" > " + fullPathTEMP + "\\ProductVersion.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\ProductVersion.txt");
            LbVersion.Text = file.ReadLine();
            file.Close();

            string[] ID2 = LbVersion.Text.Split(' ');
            textBoxIOS.Text = ID2[1];

            //PhoneNumber
            ProcessStartInfo processStartInfoAPPT2 = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT2.RedirectStandardInput = true;
            processStartInfoAPPT2.RedirectStandardOutput = true;
            processStartInfoAPPT2.UseShellExecute = false;
            processStartInfoAPPT2.CreateNoWindow = true;
            Process processAPPT2 = Process.Start(processStartInfoAPPT2);
            if (processAPPT2 != null)
            {
                processAPPT2.StandardInput.WriteLine(fullPath + "\\ideviceinfo.exe | findstr \"PhoneNumber:\" > " + fullPathTEMP + "\\PhoneNumber.txt");
                processAPPT2.StandardInput.Close();
                processAPPT2.StandardOutput.ReadToEnd();
            }

            System.IO.StreamReader file2 = new System.IO.StreamReader(fullPathTEMP + "\\PhoneNumber.txt");
            Lbnumber.Text = file2.ReadLine();
            file2.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            webBrowser1.Navigate(userProfile + "/AppData/Roaming/Apple Computer/MobileSync/Backup");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            string folder = @userProfile + "\\Apple\\MobileSync\\Backup";
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            webBrowser1.Navigate(userProfile + "/Apple/MobileSync/Backup");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.apple.com/br/itunes/");
        }

        private void button6_Click(object sender, EventArgs e)
        {           
            string pathExplorer = @"bin\itunes-backup-explorer";
            string fullPathExplorer;
            fullPathExplorer = Path.GetFullPath(pathExplorer);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(" java -jar " + fullPathExplorer + "\\itunes-backup-explorer-1.4.jar");
                processAPPT.StandardInput.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", textBox2.Text);
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", textBox3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\ideviceinstaller.exe";
            startInfo3.Arguments = " -l";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\ideviceinstaller.exe";
            startInfo3.Arguments = " -l -o list_all";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\ideviceinstaller.exe";
            startInfo3.Arguments = " -l -o list_system";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\ideviceinfo.exe";
            //startInfo3.Arguments = " ";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
            process3.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string pathADB = @"itunes_backup2hashcat";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            this.ofd2.Multiselect = true;
            this.ofd2.Title = "Select plist file";
            ofd2.InitialDirectory = @fullPath;
            ofd2.Filter = "Files (plist; *.plist)|plist; *.plist";
            ofd2.CheckFileExists = true;
            ofd2.CheckPathExists = true;
            ofd2.FilterIndex = 2;
            ofd2.RestoreDirectory = true;
            ofd2.ReadOnlyChecked = true;
            ofd2.ShowReadOnly = true;

            DialogResult drIPED = this.ofd2.ShowDialog();

            if (drIPED == System.Windows.Forms.DialogResult.OK)
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = "C:\\Strawberry\\perl\\bin\\perl.exe";
                startInfo3.Arguments = " " + fullPath + "\\itunes_backup2hashcat.pl " + ofd2.FileName;
                process3.StartInfo = startInfo3;
                process3.Start();
                textBox1.Text = process3.StandardOutput.ReadToEnd();    
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);                     
   
            string pathPRINT = @"print";
            string fullPathPRINT;
            fullPathPRINT = Path.GetFullPath(pathPRINT);

            webBrowser1.Navigate(fullPathPRINT);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\idevicescreenshot.exe";
            startInfo3.Arguments = " " + fullPathPRINT + "\\Screenshot" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
            process3.Close();

            SoundPlayer simpleSound = new SoundPlayer(@"C:\teste\ss_ios164\Scroll-Up.wav");
            simpleSound.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);
            
            string pathPRINT = @"print";
            string fullPathPRINT;
            fullPathPRINT = Path.GetFullPath(pathPRINT);

            webBrowser1.Navigate(fullPathPRINT);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\idevicescreenshot.exe";
            startInfo3.Arguments = " " + fullPathPRINT + "\\Screenshot" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
            process3.Close();

            SoundPlayer simpleSound = new SoundPlayer(@"C:\teste\ss_ios164\Scroll-Up.wav");
            simpleSound.Play();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathDISK = @"Developer-Disk-Images";
            string fullPathDISK;
            fullPathDISK = Path.GetFullPath(pathDISK);

            ////////////////////////////////////////////////////////////////

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            //ProductVersion
            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\ideviceinfo.exe | findstr \"ProductVersion:\" > " + fullPathTEMP + "\\ProductVersion.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\ProductVersion.txt");
            LbVersion.Text = file.ReadLine();
            file.Close();

            string[] ID2 = LbVersion.Text.Split(' ');
            textBoxIOS.Text = ID2[1];

            ////////////////////////////////////////////////////////////////////
            
            Process process4 = new Process();
            ProcessStartInfo startInfo4 = new ProcessStartInfo();
            startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo4.CreateNoWindow = true;
            startInfo4.UseShellExecute = false;
            startInfo4.RedirectStandardOutput = true;
            startInfo4.FileName = fullPath + "\\ideviceimagemounter.exe";
            startInfo4.Arguments = " " + fullPathDISK + "\\" + textBoxIOS.Text + "\\DeveloperDiskImage.dmg";
            process4.StartInfo = startInfo4;
            process4.Start();
            textBox1.Text = process4.StandardOutput.ReadToEnd();
            process4.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string pathADB = @"libimobiledevice";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            //PAIR DEVICE
            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\idevicepair.exe";
            startInfo3.Arguments = " pair";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
            process3.Close();

            Thread.Sleep(6000);
                       
            //PAIR DEVICE
            Process process2 = new Process();
            ProcessStartInfo startInfo2 = new ProcessStartInfo();
            startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo2.CreateNoWindow = true;
            startInfo2.UseShellExecute = false;
            startInfo2.RedirectStandardOutput = true;
            startInfo2.FileName = fullPath + "\\idevicepair.exe";
            startInfo2.Arguments = " pair";
            process2.StartInfo = startInfo2;
            process2.Start();
            textBox1.Text = process2.StandardOutput.ReadToEnd();
            process2.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Avilla-Iphone-Screen.exe");
        }
    }
}
