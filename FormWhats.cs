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
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormWhats : Form
    {
        public FormWhats()
        {
            InitializeComponent();
        }

        public class pacote //Variável Pública
        {
            public static string package = "";
            public static string DowngradeOK = "0";
            public static string PathDestino = "0";
            public static int pausa = 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("This process may take some time, please wait. This type of extraction involves risks, so do not disconnect the cable or interrupt the operation, DO YOU WANT TO CONTINUE? (Este processo pode levar algum tempo, por favor aguarde. Este tipo de extração envolve riscos, por isso não desconecte o cabo ou interrompa a operação, DESEJA CONTINUAR?)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {                

                textBox1.Text += "\r\n>> Destiny:  " + TxtDestinoWhats.Text;
                textBox1.Text += "\r\n>> Extraction of " + pacote.package + " started." + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
                button17.Text = "Wait...";
                button1.Enabled = false;
                button18.Enabled = false;
                button17.Enabled = false;                
                listView1.Enabled = false;
                panel6.Enabled = false;

                if (checkBox1.Checked) 
                {
                    button2_Click(null, null);
                }

                if (checkBox2.Checked)
                {
                    button5_Click(null, null);

                    if (pacote.DowngradeOK == "0")
                    {
                        if (DialogResult.Yes == MessageBox.Show("Attention!, The device has NOT passed the application test, therefore it is not recommended to perform the DOWNGRADE process at this time, do you want to proceed at your own risk? (O dispositivo NÃO passou no teste do aplicativo, portanto não é recomendado realizar o processo de DOWNGRADE neste momento, deseja continuar por sua conta e risco?)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                        {
                            pacote.DowngradeOK = "0";
                            pictureBox2.Visible = true;
                            //TxtDestinoWhats.Text += "\\" + pacote.package;
                            webBrowser1.Navigate(TxtDestinoWhats.Text);
                            backgroundWorker1.RunWorkerAsync();
                        }
                        else
                        {
                            pacote.DowngradeOK = "0";
                            textBox1.Text += "\r\n>> Operation cancelled, nothing changed.";
                            button17.Text = "Extract";
                            button1.Enabled = true;
                            panel6.Enabled = true;
                            button18.Enabled = false;
                            button2.Enabled = false;
                            listView1.Clear();
                            listView1.Enabled = true;
                        }
                    }
                    else
                    {
                        pacote.DowngradeOK = "0";
                        pictureBox2.Visible = true;
                        //TxtDestinoWhats.Text += "\\" + pacote.package;
                        webBrowser1.Navigate(TxtDestinoWhats.Text);
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    pictureBox2.Visible = true;
                    //TxtDestinoWhats.Text += "\\" + pacote.package;
                    webBrowser1.Navigate(TxtDestinoWhats.Text);
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                panel6.Enabled = true;
                textBox1.Text += "\r\n>> Operation cancelled, nothing changed.";
            }            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolder = new FolderBrowserDialog();
            backupfolder.Description = "Choose destination folder";
            if (backupfolder.ShowDialog() == DialogResult.OK)
            {
                //TxtdestinoTemp.Text = backupfolder.SelectedPath;               
                //TxtDestinoWhats.Text = backupfolder.SelectedPath + "\\backup-" + pacote.package + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".ab";
                TxtDestinoWhats.Text = backupfolder.SelectedPath + "\\" + pacote.package;
                textBox1.Text += "\r\n>> Destiny:  " + TxtDestinoWhats.Text + "\\" + pacote.package;
                button2.Enabled = true;

                string folder = TxtDestinoWhats.Text;
                //Se o diretório não existir..
                if (!Directory.Exists(folder))
                {
                    //Criamos um com o nome folder
                    Directory.CreateDirectory(folder);
                }

                webBrowser1.Navigate(@TxtDestinoWhats.Text);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathABU = @"abu";
            string fullPathABU;
            fullPathABU = Path.GetFullPath(pathABU);

            string pathTemp = @"down\1\temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            textBox1.Text += "\r\n>> Getting path of base.apk (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            //Obtendo path do base.apk
            ////////////////////////////////////////////////////////////////////////////////////////
            ProcessStartInfo processStartInfopath = new ProcessStartInfo("cmd.exe");
            processStartInfopath.RedirectStandardInput = true;
            processStartInfopath.RedirectStandardOutput = true;
            processStartInfopath.UseShellExecute = false;
            processStartInfopath.CreateNoWindow = true;
            Process processpath = Process.Start(processStartInfopath);
            if (processpath != null)
            {
                //processpath.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm path " + pacote.package + " | " + fullPathBin + "\\grep.exe package > " + fullPathTemp + "\\" + pacote.package + ".txt");
                processpath.StandardInput.WriteLine(fullPath + "\\adb.exe shell \" pm path " + pacote.package + " | grep package | cut -c 9- \" > " + fullPathTemp + "\\" + pacote.package + ".txt");
                processpath.StandardInput.Close();
                processpath.StandardOutput.ReadToEnd();
            }

            //Stream entrada = File.Open(fullPathTemp + "\\" + pacote.package + ".txt", FileMode.Open);
            //StreamReader leitor = new StreamReader(entrada);
            //string linha = leitor.ReadLine();  //Variável          
            //leitor.Close();
            //entrada.Close();
            //string[] CaminhoWhats = linha.Split(':'); //Variável
            
            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTemp + "\\" + pacote.package + ".txt");
            string linha = file.ReadLine();
            file.Close();

            textBox1.Text += "\r\n>> " + linha + " " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            textBox1.Text += "\r\n>> Forcing the stop " + pacote.package + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            //Forçando a parada do APP
            ////////////////////////////////////////////////////////////////////////////////////////
            Process processWhats9 = new Process();
            ProcessStartInfo startInfoWhats9 = new ProcessStartInfo();
            startInfoWhats9.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats9.CreateNoWindow = true;
            startInfoWhats9.UseShellExecute = false;
            startInfoWhats9.RedirectStandardOutput = true;
            startInfoWhats9.FileName = fullPath + "\\adb.exe";
            startInfoWhats9.Arguments = " shell am force-stop " + pacote.package;
            processWhats9.StartInfo = startInfoWhats9;
            processWhats9.Start();
            processWhats9.StandardOutput.ReadToEnd();
            processWhats9.Close();

            textBox1.Text += "\r\n>> Copying base.apk to temp folder (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            //Copiando base.apk para a pasta temp (PULL)
            ////////////////////////////////////////////////////////////////////////////////////////
            Process processWhats0 = new Process();
            ProcessStartInfo startInfoWhats0 = new ProcessStartInfo();
            startInfoWhats0.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats0.CreateNoWindow = true;
            startInfoWhats0.UseShellExecute = false;
            startInfoWhats0.RedirectStandardOutput = true;
            startInfoWhats0.FileName = fullPath + "\\adb.exe";
            startInfoWhats0.Arguments = " pull " + linha + " " + fullPathTemp;
            processWhats0.StartInfo = startInfoWhats0;
            processWhats0.Start();
            processWhats0.StandardOutput.ReadToEnd();
            processWhats0.Close();

            textBox1.Text += "\r\n>> Backing up base.apk (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            //Realizando Backup do base.apk
            ////////////////////////////////////////////////////////////////////////////////////////
            //nome do diretorio a ser criado
            string folder = @TxtDestinoWhats.Text + "\\basebackups" + "\\backup-base-" + pacote.package + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            //Copiando base.apk para a pasta backup(PULL)
            ////////////////////////////////////////////////////////////////////////////////////////
            Process processWhats12 = new Process();
            ProcessStartInfo startInfoWhats12 = new ProcessStartInfo();
            startInfoWhats12.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats12.CreateNoWindow = true;
            startInfoWhats12.UseShellExecute = false;
            startInfoWhats12.RedirectStandardOutput = true;
            startInfoWhats12.FileName = fullPath + "\\adb.exe";
            startInfoWhats12.Arguments = " pull " + linha + " " + folder;
            processWhats12.StartInfo = startInfoWhats12;
            processWhats12.Start();
            processWhats12.StandardOutput.ReadToEnd();
            processWhats12.Close();

            textBox1.Text += "\r\n>> Backup of base.apk saved in: " + folder + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            webBrowser2.Navigate(folder);

            if (DialogResult.Yes == MessageBox.Show("Attention!, before proceeding check on the tab (Base.apk Backup Folder) if the base.apk has been collected, because from that moment on, the current version of the application will be uninstalled and at the end of the process the original version will return to the device, DO YOU WANT TO CONTINUE? (Atenção!, antes de prosseguir verifique na aba (Base.apk Backup Folder) se o base.apk foi coletado, pois a partir desse momento a versão atual do aplicativo será desinstalada e ao final do processo a versão original retornará ao aparelho, DESEJA CONTINUAR?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                textBox1.Text += "\r\n>> Removing verification protections from installing apps via USB" + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Remove proteções de verificação da instalação de aplicativos via USB
                ////////////////////////////////////////////////////////////////////////////////////////                
                //disabled Google Play Services apps verification
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

                //disabled Google Play Protect
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

                //enabled installation of non-market apps
                Process processWhats30 = new Process();
                ProcessStartInfo startInfoWhats30 = new ProcessStartInfo();
                startInfoWhats30.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats30.CreateNoWindow = true;
                startInfoWhats30.UseShellExecute = false;
                startInfoWhats30.RedirectStandardOutput = true;
                startInfoWhats30.FileName = fullPath + "\\adb.exe";
                startInfoWhats30.Arguments = " shell settings put global install_non_market_apps 1";
                processWhats30.StartInfo = startInfoWhats30;
                processWhats30.Start();
                processWhats30.StandardOutput.ReadToEnd();
                processWhats30.Close();
                ////////////////////////////////////////////////////////////////////////////////////////
                
                textBox1.Text += "\r\n>> Uninstalling the Current Version (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Desinstalando a Versão Atual
                ////////////////////////////////////////////////////////////////////////////////////////        

                Process processWhats122 = new Process();
                ProcessStartInfo startInfoWhats122 = new ProcessStartInfo();
                startInfoWhats122.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats122.CreateNoWindow = true;
                startInfoWhats122.UseShellExecute = false;
                startInfoWhats122.RedirectStandardOutput = true;
                startInfoWhats122.FileName = fullPath + "\\adb.exe";
                startInfoWhats122.Arguments = " shell cmd package uninstall -k " + pacote.package;
                processWhats122.StartInfo = startInfoWhats122;
                processWhats122.Start();
                processWhats122.StandardOutput.ReadToEnd();
                processWhats122.Close();

                Process processWhats1 = new Process();
                ProcessStartInfo startInfoWhats1 = new ProcessStartInfo();
                startInfoWhats1.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats1.CreateNoWindow = true;
                startInfoWhats1.UseShellExecute = false;
                startInfoWhats1.RedirectStandardOutput = true;
                startInfoWhats1.FileName = fullPath + "\\adb.exe";
                startInfoWhats1.Arguments = " shell pm uninstall -k --user 0 " + pacote.package;
                processWhats1.StartInfo = startInfoWhats1;
                processWhats1.Start();
                processWhats1.StandardOutput.ReadToEnd();
                processWhats1.Close();


                if (DialogResult.Yes == MessageBox.Show("Attention!, For the aplication version to return successfully you must restart your device, do you want to restart? (Atenção!, Para que a versão do aplicativo retorne com sucesso você deve reiniciar seu aparelho, deseja reiniciar?)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    textBox1.Text += "\r\n>> Restarting the Phone (Reboot) (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                    //Reiniciando o Celular (Reboot)
                    //////////////////////////////////////////////////////////////////////////////////////// 
                    Process processWhats10 = new Process();
                    ProcessStartInfo startInfoWhats10 = new ProcessStartInfo();
                    startInfoWhats10.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfoWhats10.CreateNoWindow = true;
                    startInfoWhats10.UseShellExecute = false;
                    startInfoWhats10.RedirectStandardOutput = true;
                    startInfoWhats10.FileName = fullPath + "\\adb.exe";
                    startInfoWhats10.Arguments = " reboot";
                    processWhats10.StartInfo = startInfoWhats10;
                    processWhats10.Start();
                    processWhats10.StandardOutput.ReadToEnd();
                    processWhats10.Close();
                    MessageBox.Show("WARNING!, READ BEFORE PROCEEDING - Device has restarted. Wait for the reboot process, unlock the screen and proceed (Click OK only after unlocking the device screen). (ATENÇÃO!, LEIA ANTES DE PROSSEGUIR - O dispositivo foi reiniciado. Aguarde o processo de reinicialização, desbloqueie a tela e prossiga (Clique em OK somente após desbloquear a tela do dispositivo)). ", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }                 

                textBox1.Text += "\r\n>> Removing automatic screen lock (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Removendo bloqueio de tela automatico
                ////////////////////////////////////////////////////////////////////////////////////////
                Process processWhats15 = new Process();
                ProcessStartInfo startInfoWhats15 = new ProcessStartInfo();
                startInfoWhats15.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats15.CreateNoWindow = true;
                startInfoWhats15.UseShellExecute = false;
                startInfoWhats15.RedirectStandardOutput = true;
                startInfoWhats15.FileName = fullPath + "\\adb.exe";
                startInfoWhats15.Arguments = " shell settings put global stay_on_while_plugged_in 3";
                processWhats15.StartInfo = startInfoWhats15;
                processWhats15.Start();
                processWhats15.StandardOutput.ReadToEnd();
                processWhats15.Close();

                textBox1.Text += "\r\n>> Installing the exploit " + pacote.package + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Instalando o exploit
                //////////////////////////////////////////////////////////////////////////////////////// 
                string pathWhats = @"down";
                string fullPathWhats;
                fullPathWhats = Path.GetFullPath(pathWhats);

                Process processWhats222 = new Process();
                ProcessStartInfo startInfoWhats222 = new ProcessStartInfo();
                startInfoWhats222.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats222.CreateNoWindow = true;
                startInfoWhats222.UseShellExecute = false;
                startInfoWhats222.RedirectStandardOutput = true;
                startInfoWhats222.FileName = fullPath + "\\adb.exe";
                startInfoWhats222.Arguments = " install -r -d " + fullPathWhats + "\\" + pacote.package + ".apk";
                processWhats222.StartInfo = startInfoWhats222;
                processWhats222.Start();
                processWhats222.StandardOutput.ReadToEnd();
                processWhats222.Close();

                //PUSH EXPLOIT XIAOMI
                if (checkBoxPush.Checked) 
                {
                    Process processWhats2221 = new Process();
                    ProcessStartInfo startInfoWhats2221 = new ProcessStartInfo();
                    startInfoWhats2221.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfoWhats2221.CreateNoWindow = true;
                    startInfoWhats2221.UseShellExecute = false;
                    startInfoWhats2221.RedirectStandardOutput = true;
                    startInfoWhats2221.FileName = fullPath + "\\adb.exe";
                    startInfoWhats2221.Arguments = " push " + fullPathWhats + "\\" + pacote.package + ".apk /sdcard/";
                    processWhats2221.StartInfo = startInfoWhats2221;
                    processWhats2221.Start();
                    processWhats2221.StandardOutput.ReadToEnd();
                    processWhats2221.Close();
                }

                //if (pacote.package == "org.telegram.messenger")
                //{
                //    //Iniciando o org.telegram.messenger
                //    ////////////////////////////////////////////////////////////////////////////////////////
                //    Process processWhats20 = new Process();
                //    ProcessStartInfo startInfoWhats20 = new ProcessStartInfo();
                //    startInfoWhats20.WindowStyle = ProcessWindowStyle.Hidden;
                //    startInfoWhats20.CreateNoWindow = true;
                //    startInfoWhats20.UseShellExecute = false;
                 //   startInfoWhats20.RedirectStandardOutput = true;
                 //   startInfoWhats20.FileName = fullPath + "\\adb.exe";
                 //   startInfoWhats20.Arguments = " shell am start -n org.telegram.messenger/org.telegram.ui.LaunchActivity";
                 //   processWhats20.StartInfo = startInfoWhats20;
                 //   processWhats20.Start();
                 //   processWhats20.StandardOutput.ReadToEnd();
                 //   processWhats20.Close();
                //}

                if (pacote.package == "com.aplicacaoteste")
                {
                    //Iniciando a com.aplicacaoteste
                    ////////////////////////////////////////////////////////////////////////////////////////
                    Process processWhats21 = new Process();
                    ProcessStartInfo startInfoWhats21 = new ProcessStartInfo();
                    startInfoWhats21.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfoWhats21.CreateNoWindow = true;
                    startInfoWhats21.UseShellExecute = false;
                    startInfoWhats21.RedirectStandardOutput = true;
                    startInfoWhats21.FileName = fullPath + "\\adb.exe";
                    startInfoWhats21.Arguments = " shell am start -n com.aplicacaoteste/com.aplicacaoteste.MainActivity";
                    processWhats21.StartInfo = startInfoWhats21;
                    processWhats21.Start();
                    processWhats21.StandardOutput.ReadToEnd();
                    processWhats21.Close();
                }

                if (checkBoxPush.Checked)
                {
                    MessageBox.Show("Attention!, READ BEFORE CONTINUE - On XIAOMI devices manually install the exploit (com.whatsapp.apk) which has been moved to /SDCARD/. Only then click OK. (Atenção!, LEIA ANTES DE CONTINUAR - Em dispositivos XIAOMI instale manualmente o exploit (com.whatsapp.apk) que foi transferido para /SDCARD/. Somente após isso clique em OK.)", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else 
                {
                    MessageBox.Show("Attention!, READ BEFORE CONTINUE - If prompted, press the (continue) button on the device to activate the permissions, then click BACK UP MY DATA. Enter a password if necessary. IF THE DEVICE DOES NOT REQUEST (CONTINUE), MANUALLY OPEN THE APP TO GIVE PERMISSIONS. (Atenção!, LEIA ANTES DE CONTINUAR - Se solicitado, pressione o botão (continuar) no dispositivo para ativar as permissões e clique em BACKUP DO MEUS DADOS. Digite uma senha, se necessário. SE O DISPOSITIVO NÃO SOLICITAR (CONTINUAR), ABRA MANUALMENTE O APLICATIVO PARA DAR PERMISSÕES)", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBox1.Text += "\r\n>> Starting ADB Backup " + pacote.package + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Iniciando o Backup ADB (com.whatsapp)
                ////////////////////////////////////////////////////////////////////////////////////////
                Process processWhats3 = new Process();
                ProcessStartInfo startInfoWhats3 = new ProcessStartInfo();
                startInfoWhats3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats3.CreateNoWindow = true;
                startInfoWhats3.UseShellExecute = false;
                startInfoWhats3.RedirectStandardOutput = true;
                startInfoWhats3.FileName = fullPath + "\\adb.exe";

                /// Salva path do arquivo .ab
                string pathTEMP = @"temp";
                string fullPathTEMP;
                fullPathTEMP = Path.GetFullPath(pathTEMP);
                StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\TempPathAB.txt");
                EscreverTXT4.WriteLine($"{TxtDestinoWhats.Text}\\backup-{pacote.package}-{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.ab");
                EscreverTXT4.Close();

                pacote.pausa = 0;
                backgroundWorker3.RunWorkerAsync();

                if (radioButtonADBAPP.Checked) 
                {
                    startInfoWhats3.Arguments = " backup -apk " + pacote.package + " -f \"" + TxtDestinoWhats.Text + "\\backup-" + pacote.package + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".ab";
                }                               
                else
                {
                    startInfoWhats3.Arguments = " backup -apk -all -f \"" + TxtDestinoWhats.Text + "\\backup-" + pacote.package + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".ab";
                }

                processWhats3.StartInfo = startInfoWhats3;
                processWhats3.Start();
                processWhats3.StandardOutput.ReadToEnd();
                processWhats3.Close();

                textBox1.Text += "\r\n>> ADB backup completed " + pacote.package + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                pacote.pausa = 1;

                //Forçando a parada do APP
                ////////////////////////////////////////////////////////////////////////////////////////
                Process processWhats17 = new Process();
                ProcessStartInfo startInfoWhats17 = new ProcessStartInfo();
                startInfoWhats17.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats17.CreateNoWindow = true;
                startInfoWhats17.UseShellExecute = false;
                startInfoWhats17.RedirectStandardOutput = true;
                startInfoWhats17.FileName = fullPath + "\\adb.exe";
                startInfoWhats17.Arguments = " shell am force-stop " + pacote.package;
                processWhats17.StartInfo = startInfoWhats17;
                processWhats17.Start();
                processWhats17.StandardOutput.ReadToEnd();
                processWhats17.Close();

                textBox1.Text += "\r\n>> Returning to the original version (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Retornando a Versão original
                ////////////////////////////////////////////////////////////////////////////////////////
                Process processWhats5 = new Process();
                ProcessStartInfo startInfoWhats5 = new ProcessStartInfo();
                startInfoWhats5.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats5.CreateNoWindow = true;
                startInfoWhats5.UseShellExecute = false;
                startInfoWhats5.RedirectStandardOutput = true;
                startInfoWhats5.FileName = fullPath + "\\adb.exe";
                startInfoWhats5.Arguments = " install -r -d " + fullPathTemp + "\\base.apk";
                processWhats5.StartInfo = startInfoWhats5;
                processWhats5.Start();
                processWhats5.StandardOutput.ReadToEnd();
                processWhats5.Close();

                //PUSH BASE XIAOMI
                if (checkBoxPush.Checked)
                {
                    Process processWhats2223 = new Process();
                    ProcessStartInfo startInfoWhats2223 = new ProcessStartInfo();
                    startInfoWhats2223.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfoWhats2223.CreateNoWindow = true;
                    startInfoWhats2223.UseShellExecute = false;
                    startInfoWhats2223.RedirectStandardOutput = true;
                    startInfoWhats2223.FileName = fullPath + "\\adb.exe";
                    startInfoWhats2223.Arguments = " push " + fullPathTemp + "\\base.apk /sdcard/";
                    processWhats2223.StartInfo = startInfoWhats2223;
                    processWhats2223.Start();
                    processWhats2223.StandardOutput.ReadToEnd();
                    processWhats2223.Close();
                }

                if (checkBoxPush.Checked)
                {
                    MessageBox.Show("Attention!, READ BEFORE CONTINUE - On XIAOMI devices manually install the base.apk that was transferred to /SDCARD/ to return the original version. Only then click OK. (Atenção!, LEIA ANTES DE CONTINUAR - Em dispositivos XIAOMI instale manualmente o base.apk que foi transferido para /SDCARD/ para retornar a versão original. Somente após isso clique em OK.)", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                textBox1.Text += "\r\n>> Collection of media files (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                textBox1.Text += "\r\n>> Returning automatic screen lock (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                //Retornando bloqueio de tela automatico
                ////////////////////////////////////////////////////////////////////////////////////////
                Process processWhats16 = new Process();
                ProcessStartInfo startInfoWhats16 = new ProcessStartInfo();
                startInfoWhats16.WindowStyle = ProcessWindowStyle.Hidden;
                startInfoWhats16.CreateNoWindow = true;
                startInfoWhats16.UseShellExecute = false;
                startInfoWhats16.RedirectStandardOutput = true;
                startInfoWhats16.FileName = fullPath + "\\adb.exe";
                startInfoWhats16.Arguments = " shell settings put global stay_on_while_plugged_in 0";
                processWhats16.StartInfo = startInfoWhats16;
                processWhats16.Start();
                processWhats16.StandardOutput.ReadToEnd();
                processWhats16.Close();

                //Pega o Path do caminho do arquivo .AB
                System.IO.StreamReader file2 = new System.IO.StreamReader(@fullPathTEMP + "\\TempPathAB.txt");
                string caminho = file2.ReadLine();
                file2.Close();

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
                //startInfoWhats40.Arguments = " \"" + caminho + "\" --unpack \"" + TxtDestinoWhats.Text + "\\DATA\" --password " + textBoxPassAB.Text;
                //processWhats40.StartInfo = startInfoWhats40;
                //processWhats40.Start();
                //processWhats40.StandardOutput.ReadToEnd();
                //processWhats40.Close();

                //Coleta dos arquivos de midia
                /////////////////////////////////////////////////////////////////////////////////////////////
                if (DialogResult.Yes == MessageBox.Show("Do you want to extract the media files from " + pacote.package + " if any?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    /////////// Whatsapp /////////////////////////////////////////////////////////////////////
                    if (pacote.package == "com.whatsapp")
                    {                 
                        textBox1.Text += "\r\n>> Collection of media files (/sdcard/WhatsApp/) (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                        Process processWhats6 = new Process();
                        ProcessStartInfo startInfoWhats6 = new ProcessStartInfo();
                        startInfoWhats6.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfoWhats6.CreateNoWindow = true;
                        startInfoWhats6.UseShellExecute = false;
                        startInfoWhats6.RedirectStandardOutput = true;
                        startInfoWhats6.FileName = fullPath + "\\adb.exe";
                        startInfoWhats6.Arguments = " pull /sdcard/WhatsApp/ \"" + TxtDestinoWhats.Text + "\"";
                        processWhats6.StartInfo = startInfoWhats6;
                        processWhats6.Start();
                        processWhats6.StandardOutput.ReadToEnd();
                        processWhats6.Close();
                        textBox1.Text += "\r\n>> Collection of media files (/sdcard/Android/media/com.whatsapp/) (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                        Process processWhats7 = new Process();
                        ProcessStartInfo startInfoWhats7 = new ProcessStartInfo();
                        startInfoWhats7.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfoWhats7.CreateNoWindow = true;
                        startInfoWhats7.UseShellExecute = false;
                        startInfoWhats7.RedirectStandardOutput = true;
                        startInfoWhats7.FileName = fullPath + "\\adb.exe";
                        startInfoWhats7.Arguments = " pull /sdcard/Android/media/com.whatsapp/ \"" + TxtDestinoWhats.Text + "\"";
                        processWhats7.StartInfo = startInfoWhats7;
                        processWhats7.Start();
                        processWhats7.StandardOutput.ReadToEnd();
                        processWhats7.Close();
                        textBox1.Text += "\r\n>> Collected media files (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                    }

                    ///////////  Telegram  /////////////////////////////////////////////////////////////////////////                
                    if (pacote.package == "org.telegram.messenger")
                    {
                        textBox1.Text += "\r\n>> Collection of media files (/sdcard/Telegram/)";

                        Process processWhats6 = new Process();
                        ProcessStartInfo startInfoWhats6 = new ProcessStartInfo();
                        startInfoWhats6.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfoWhats6.CreateNoWindow = true;
                        startInfoWhats6.UseShellExecute = false;
                        startInfoWhats6.RedirectStandardOutput = true;
                        startInfoWhats6.FileName = fullPath + "\\adb.exe";
                        startInfoWhats6.Arguments = " pull -a /sdcard/Telegram/ \"" + TxtDestinoWhats.Text + "\"";
                        processWhats6.StartInfo = startInfoWhats6;
                        processWhats6.Start();
                        processWhats6.StandardOutput.ReadToEnd();
                        processWhats6.Close();

                        textBox1.Text += "\r\n>> Collection of media files (/sdcard/Android/data/org.telegram.messenger/) " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");

                        Process processWhats7 = new Process();
                        ProcessStartInfo startInfoWhats7 = new ProcessStartInfo();
                        startInfoWhats7.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfoWhats7.CreateNoWindow = true;
                        startInfoWhats7.UseShellExecute = false;
                        startInfoWhats7.RedirectStandardOutput = true;
                        startInfoWhats7.FileName = fullPath + "\\adb.exe";
                        startInfoWhats7.Arguments = " pull -a /sdcard/Android/data/org.telegram.messenger/ \"" + TxtDestinoWhats.Text + "\"";
                        processWhats7.StartInfo = startInfoWhats7;
                        processWhats7.Start();
                        processWhats7.StandardOutput.ReadToEnd();
                        processWhats7.Close();
                        textBox1.Text += "\r\n>> Collected media files (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                    }
                }
                else
                {
                    textBox1.Text += "\r\n>> Media files NOT collected (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                }

                if (checkBox3.Checked)
                {
                    textBox1.Text += "\r\n>> Generating logs, please wait... (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";



                    string Hasmd5 = BytesToString(GetHashMD5(@caminho));
                    string Hassha1 = BytesToString(GetHashSha256(@caminho));

                    FileInfo fileInfo = new FileInfo(@caminho);
                    textBox1.Text += "\r\n>> .ab file size: " + fileInfo.Length + " bytes";

                    textBox1.Text += "\r\n>> MD5 hash of the .ab file: " + Hasmd5;
                    textBox1.Text += "\r\n>> Hash SHA-256 of .ab file: " + Hassha1;

                    StreamWriter EscreverTXT2 = new StreamWriter(TxtDestinoWhats.Text + "\\Logs_Ferramenta.txt");
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

                    StreamWriter EscreverTXT = new StreamWriter(TxtDestinoWhats.Text + "\\Logs_Coleta.txt");
                    EscreverTXT.WriteLine($"AVILLA FORENSICS 3.0");
                    EscreverTXT.WriteLine($"");
                    EscreverTXT.WriteLine($"Collected Device: {Modelo}");
                    EscreverTXT.WriteLine($"Operating System Version: {NVer}");
                    EscreverTXT.WriteLine($"Device Serial Number: {NSerie}");
                    EscreverTXT.WriteLine($"Date: {DateTime.Now.ToString("dd-MM-yyyy")}");
                    EscreverTXT.WriteLine($"Hour: {DateTime.Now.ToString("HH-mm-ss")}");
                    EscreverTXT.WriteLine($"");
                    EscreverTXT.WriteLine($"Application collected: {pacote.package}");
                    EscreverTXT.WriteLine($"Generated file: {@caminho}");
                    EscreverTXT.WriteLine($"File size: {fileInfo.Length} bytes");
                    EscreverTXT.WriteLine($"Hash MD5: {Hasmd5}");
                    EscreverTXT.WriteLine($"Hash SHA-256: {Hassha1}");
                    EscreverTXT.WriteLine($"");
                    EscreverTXT.WriteLine($"Tool Logs: {TxtDestinoWhats.Text}" + "\\Logs_Ferramenta.txt");
                    EscreverTXT.WriteLine($"Hash MD5: {BytesToString(GetHashMD5(TxtDestinoWhats.Text + "\\Logs_Ferramenta.txt"))}");
                    EscreverTXT.WriteLine($"Hash SHA-256: {BytesToString(GetHashSha256(TxtDestinoWhats.Text + "\\Logs_Ferramenta.txt"))}");
                    EscreverTXT.Close();

                    textBox1.Text += "\r\n>> Generated logs (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

                    //Txthashmd5.Text = BytesToString(GetHashMD5(textBox1.Text));
                    //Txthash256.Text = BytesToString(GetHashSha256(textBox1.Text));
                }
            }
            else
            {
                textBox1.Text += "\r\n>> Operation Canceled, nothing has been changed (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            }            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;

            TxtDestinoWhats.Text = "";

            textBox1.Text += "\r\n>> Extraction of " + pacote.package + " completed (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            button17.Text = "Extract";
            button1.Enabled = true;
            panel6.Enabled = true;
            button2.Enabled = true;
            button18.Enabled = false;            
            listView1.Clear();            
            listView1.Enabled = true;
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

        private void FormWhats_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            TxtDestinoWhats.Text = file.ReadLine() + "\\downgrade";
            pacote.PathDestino = @TxtDestinoWhats.Text;
            file.Close();

            string folder = TxtDestinoWhats.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            webBrowser1.Navigate(TxtDestinoWhats.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

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
            textBox1.Text += "\r\n" + process3.StandardOutput.ReadToEnd();
            process3.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);

            labelAndroidVER.Text = "";
            labelSDKAtual.Text = "";
            labelSDKFabrica.Text = "";

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            try
            {
                string ver = "";
                string verFabrica = "";
                string verAtual = "";

                //Versão Android
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPath + "\\adb.exe";
                startInfo3.Arguments = " shell getprop ro.build.version.release";
                process3.StartInfo = startInfo3;
                process3.Start();
                ver = process3.StandardOutput.ReadToEnd();
                process3.Close();

                //Versão SDK Atual
                Process process2 = new Process();
                ProcessStartInfo startInfo2 = new ProcessStartInfo();
                startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo2.CreateNoWindow = true;
                startInfo2.UseShellExecute = false;
                startInfo2.RedirectStandardOutput = true;
                startInfo2.FileName = fullPath + "\\adb.exe";
                startInfo2.Arguments = " shell getprop ro.build.version.sdk";
                process2.StartInfo = startInfo2;
                process2.Start();
                verAtual = process2.StandardOutput.ReadToEnd();
                process2.Close();

                //Versão SDK Frabrica
                Process process1 = new Process();
                ProcessStartInfo startInfo1 = new ProcessStartInfo();
                startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo1.CreateNoWindow = true;
                startInfo1.UseShellExecute = false;
                startInfo1.RedirectStandardOutput = true;
                startInfo1.FileName = fullPath + "\\adb.exe";
                startInfo1.Arguments = " shell getprop ro.vendor.build.version.sdk";
                process1.StartInfo = startInfo1;
                process1.Start();
                verFabrica = process1.StandardOutput.ReadToEnd();
                process1.Close();

                labelAndroidVER.Text = ver;
                labelSDKAtual.Text = verAtual;
                labelSDKFabrica.Text = verFabrica;

                if (Convert.ToInt64(verFabrica) > 30)
                {
                    listView1.Enabled = false;
                    textBox1.Text += "\r\n Don't Downgrade on Android 12, 13 or 14, tab locked";
                }
                else
                {
                    listView1.Enabled = true;
                }
            }
            catch
            {

            }
             
            string pathTemp = @"temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list packages -3");
                processAPPT.StandardInput.Close();
                TXTlistaApp.Text =  processAPPT.StandardOutput.ReadToEnd();               
                StreamWriter EscreverTXT2 = new StreamWriter(@fullPathTemp + "\\Lista_Aplicativos_Terceiros.txt");
                EscreverTXT2.WriteLine($"{TXTlistaApp.Text}");
                EscreverTXT2.Close();
            }

            int counter = 0;
            string line;

            listView1.Clear();
            button18.Enabled = false;
            label4.Text = "Select the detected application:";
            pacote.package = "";

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(@fullPathTemp + "\\Lista_Aplicativos_Terceiros.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line == "package:com.aplicacaoteste")
                {
                    listView1.Items.Add("com.aplicacaoteste", 16);
                }

                if (line == "package:com.whatsapp")
                {
                    listView1.Items.Add("com.whatsapp", 3);                    
                }

                if (line == "package:org.telegram.messenger")
                {
                    listView1.Items.Add("org.telegram.messenger", 4);                    
                }

                if (line == "package:org.thoughtcrime.securesms")
                {
                    listView1.Items.Add("org.thoughtcrime.securesms", 5);                    
                }

                if (line == "package:com.facebook.orca")
                {
                    listView1.Items.Add("com.facebook.orca", 1);                    
                }

                if (line == "package:com.instagram.android")
                {
                    listView1.Items.Add("com.instagram.android", 2);                    
                }

                if (line == "package:com.twitter.android")
                {
                    listView1.Items.Add("com.twitter.android", 0);                    
                }

                if (line == "package:com.tinder")
                {
                    listView1.Items.Add("com.tinder", 7);                    
                }

                if (line == "package:org.mozilla.firefox")
                {
                    listView1.Items.Add("org.mozilla.firefox", 6);                    
                }

                if (line == "package:com.linkedin.android")
                {
                    listView1.Items.Add("com.linkedin.android", 8);                    
                }

                if (line == "package:com.snapchat.android")
                {
                    listView1.Items.Add("com.snapchat.android", 9);                    
                }

                if (line == "package:com.dropbox.android")
                {
                    listView1.Items.Add("com.dropbox.android", 10);                    
                }

                if (line == "package:com.icq.mobile.client")
                {
                    listView1.Items.Add("com.icq.mobile.client", 12);                    
                }

                if (line == "package:com.badoo.mobile")
                {
                    listView1.Items.Add("com.badoo.mobile", 13);                    
                }

                //if (line == "package:com.viber.voip")
                //{
                //    listView1.Items.Add("com.viber.voip", 11);
                //}

                if (line == "package:com.alibaba.intl.android.apps.poseidon")
                {
                    listView1.Items.Add("com.alibaba.intl.android.apps.poseidon", 14);                    
                }

                if (line == "package:com.zhiliaoapp.musically")
                {
                    listView1.Items.Add("com.zhiliaoapp.musically", 15);                    
                }

                counter++;
            }
            file.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pacote.package = listView1.Items[listView1.FocusedItem.Index].Text;
            TxtDestinoWhats.Text = pacote.PathDestino + "\\" + pacote.package;

            //webBrowser1.Navigate(@TxtDestinoWhats.Text);

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
            startInfo3.Arguments = " shell \"dumpsys package " + pacote.package + " | grep firstInstallTime | cut -c 22-40\"";
            process3.StartInfo = startInfo3;
            process3.Start();
            label4.Text = "Select the detected application: " + pacote.package + "    |     firstInstallTime: " + process3.StandardOutput.ReadToEnd();
            process3.Close();            

            string folder = TxtDestinoWhats.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }
            button17.Enabled = true;
            button18.Enabled = true;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            //string pathColetas = @"coletas";
            //string fullPathColetas;
            //fullPathColetas = Path.GetFullPath(pathColetas);           

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys dbinfo " + pacote.package);
                processAPPT.StandardInput.Close();
                textDumpDB.Text = processAPPT.StandardOutput.ReadToEnd();
            }

            StreamWriter EscreverTXT2 = new StreamWriter(@TxtDestinoWhats.Text + "\\DUMP_DBinfo.txt");
            EscreverTXT2.WriteLine($"{textDumpDB.Text}");
            EscreverTXT2.Close();

            ProcessStartInfo processStartInfoAPPT2 = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT2.RedirectStandardInput = true;
            processStartInfoAPPT2.RedirectStandardOutput = true;
            processStartInfoAPPT2.UseShellExecute = false;
            processStartInfoAPPT2.CreateNoWindow = true;
            Process processAPPT2 = Process.Start(processStartInfoAPPT2);
            if (processAPPT != null)
            {
                processAPPT2.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys package " + pacote.package);
                processAPPT2.StandardInput.Close();
                textDump.Text = processAPPT2.StandardOutput.ReadToEnd();
            }

            StreamWriter EscreverTXT1 = new StreamWriter(@TxtDestinoWhats.Text + "\\DUMP_Package.txt");
            EscreverTXT1.WriteLine($"{textDump.Text}");
            EscreverTXT1.Close();
            
            //System.Diagnostics.Process.Start("explorer.exe", fullPathColetas);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FileInfo fileInfo = new FileInfo(@"C:\Users\danie\Desktop\Nova pasta\backup-2022-02-01-17-54-32.ab");
            //textBox1.Text += fileInfo.Length + " bytes";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pacote.DowngradeOK = "0";

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathWhats = @"down";
            string fullPathWhats;
            fullPathWhats = Path.GetFullPath(pathWhats);

            textBox1.Text += "\r\n>>" + "Test application started." + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            textBox1.Text += "\r\n>> Removing verification protections from installing apps via USB" + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            //Remove proteções de verificação da instalação de aplicativos via USB
            ////////////////////////////////////////////////////////////////////////////////////////                
            //disabled Google Play Services apps verification
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

            //disabled Google Play Protect
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

            //enabled installation of non-market apps
            Process processWhats21 = new Process();
            ProcessStartInfo startInfoWhats21 = new ProcessStartInfo();
            startInfoWhats21.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats21.CreateNoWindow = true;
            startInfoWhats21.UseShellExecute = false;
            startInfoWhats21.RedirectStandardOutput = true;
            startInfoWhats21.FileName = fullPath + "\\adb.exe";
            startInfoWhats21.Arguments = " shell settings put global install_non_market_apps 1";
            processWhats21.StartInfo = startInfoWhats21;
            processWhats21.Start();
            processWhats21.StandardOutput.ReadToEnd();
            processWhats21.Close();
            ////////////////////////////////////////////////////////////////////////////////////////

            textBox1.Text += "\r\n>>" + "Uninstalling test application." + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            Process processWhats1 = new Process();
            ProcessStartInfo startInfoWhats1 = new ProcessStartInfo();
            startInfoWhats1.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats1.CreateNoWindow = true;
            startInfoWhats1.UseShellExecute = false;
            startInfoWhats1.RedirectStandardOutput = true;
            startInfoWhats1.FileName = fullPath + "\\adb.exe";
            startInfoWhats1.Arguments = " shell cmd package uninstall -k com.aplicacaoteste";
            processWhats1.StartInfo = startInfoWhats1;
            processWhats1.Start();
            processWhats1.StandardOutput.ReadToEnd();
            textBox1.Text += "\r\n>>" + processWhats1.StandardOutput.ReadToEnd();
            processWhats1.Close();

            textBox1.Text += "\r\n>>" + "Installing test application." + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            Process processWhats2 = new Process();
            ProcessStartInfo startInfoWhats2 = new ProcessStartInfo();
            startInfoWhats2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats2.CreateNoWindow = true;
            startInfoWhats2.UseShellExecute = false;
            startInfoWhats2.RedirectStandardOutput = true;
            startInfoWhats2.FileName = fullPath + "\\adb.exe";
            startInfoWhats2.Arguments = " install -r -d " + fullPathWhats + "\\com.aplicacaoteste.apk";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            textBox1.Text += "\r\n>>" + processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            textBox1.Text += "\r\n>>" + "Starting test application." + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            Process processWhats3 = new Process();
            ProcessStartInfo startInfoWhats3 = new ProcessStartInfo();
            startInfoWhats3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats3.CreateNoWindow = true;
            startInfoWhats3.UseShellExecute = false;
            startInfoWhats3.RedirectStandardOutput = true;
            startInfoWhats3.FileName = fullPath + "\\adb.exe";
            startInfoWhats3.Arguments = " shell am start -n com.aplicacaoteste/com.aplicacaoteste.MainActivity";
            processWhats3.StartInfo = startInfoWhats3;
            processWhats3.Start();
            processWhats3.StandardOutput.ReadToEnd();
            processWhats3.Close();

            string pathTemp = @"temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            textBox1.Text += "\r\n>>" + "Tracking test application." + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list packages -3");
                processAPPT.StandardInput.Close();
                TXTlistaApp2.Text = processAPPT.StandardOutput.ReadToEnd();
                StreamWriter EscreverTXT2 = new StreamWriter(@fullPathTemp + "\\Lista_Aplicativos_Aplicacaoteste.txt");
                EscreverTXT2.WriteLine($"{TXTlistaApp2.Text}");
                EscreverTXT2.Close();
            }

           //int counter = 0;
            string line;
            string Naodetectado = "0";

            System.IO.StreamReader file = new System.IO.StreamReader(@fullPathTemp + "\\Lista_Aplicativos_Aplicacaoteste.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line == "package:com.aplicacaoteste")
                {
                    pacote.DowngradeOK = "1";
                    textBox1.Text += "\r\n>>" + "Test application successfully installed." + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
                    MessageBox.Show("Test application successfully installed, you can downgrade more safely.", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Naodetectado = "1";
                    break;
                }                
            }
            
            if (Naodetectado == "0")
            {
                //MessageBox.Show("ATENÇÃO, o dispositivo NÃO passou no teste de aplicativo, por esse motivo não é recomendável realizar o processo de DOWNGRADE neste momento.", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text += "\r\n>>" + "The device has NOT passed the application test" + " (" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ")";
            }            
            
            file.Close();
        }

        private void label12_Click(object sender, EventArgs e)
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

                    System.IO.StreamReader file = new System.IO.StreamReader(@fullPathTEMP + "\\TempPathAB.txt");

                    FileInfo fileInfo = new FileInfo(file.ReadLine());

                    file.Close();

                    StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\TempSizeAB.txt");
                    EscreverTXT4.WriteLine($"File .ab size: {fileInfo.Length} bytes");
                    EscreverTXT4.Close();

                    webBrowser1.Navigate(@fullPathTEMP + "\\TempSizeAB.txt");
                }
                catch { }                
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            webBrowser1.Navigate(@TxtDestinoWhats.Text);
        }
    }
}
