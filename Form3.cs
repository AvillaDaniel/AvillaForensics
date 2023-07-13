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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop > " + @textBox1.Text + "\\Propriedades.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Propriedades.txt");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "Aguarde...";
            button2.Enabled = false;
            MessageBox.Show("Esse processo pode demorar alguns minutos, durante o processo você pode fazer outras coletas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //startInfo3.Arguments = " shell dumpsys diskstats";
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys diskstats > " + @textBox1.Text + "\\Diskstats.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys diskstats | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Diskstats.txt");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //startInfo3.Arguments = " shell dumpsys location";
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys location > " + @textBox1.Text + "\\Localizacao.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys location | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Localizacao.txt");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell service call iphonesubinfo 1 > " + @textBox1.Text + "\\IMEI_01.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell service call iphonesubinfo | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\IMEI_01.txt");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell service call iphonesubinfo 4 i32 1 > " + @textBox1.Text + "\\IMEI_02.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell service call iphonesubinfo 4 i32 1 | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\IMEI_02.txt");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            textBox1.Text = file.ReadLine() + "\\coletas";
            file.Close();

            string folder = @textBox1.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }
            webBrowser1.Navigate(@textBox1.Text);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys > " + @textBox1.Text + "\\Dumpsys.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Dumpsys.txt");
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Coleta DUMP concluída", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            button2.Text = "Dumpsys";
            button2.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //adb shell cmd netpolicy list wifi-networks
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell cmd netpolicy list wifi-networks > " + @textBox1.Text + "\\Dump_Wifi.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell cmd netpolicy list wifi-networks | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Dump_Wifi.txt");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys wifi
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys wifi > " + @textBox1.Text + "\\Dump_Wifi_Detalhado.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys wifi | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Dump_Wifi_Detalhado.txt");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //adb shell cat /proc/cpuinfo
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell cat /proc/cpuinfo > " + @textBox1.Text + "\\CPU.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell cat /proc/cpuinfo | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\CPU.txt");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //adb shell cat /proc/meminfo
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell cat /proc/meminfo > " + @textBox1.Text + "\\Memoria.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell cat /proc/meminfo | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Memoria.txt");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys window displays
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys window displays > " + @textBox1.Text + "\\Displays.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys window displays | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Displays.txt");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //adb shell pm list packages -s
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list packages -s > " + @textBox1.Text + "\\Lista_APP_Nativos.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list packages -s | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Lista_APP_Nativos.txt");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //adb shell pm list packages - 3
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list packages -3 > " + @textBox1.Text + "\\Lista_APP_Terceiros.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list packages -3 | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Lista_APP_Terceiros.txt");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //adb shell getprop ro.boot.serialno
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";    
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop ro.boot.serialno > " + @textBox1.Text + "\\Serial.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop ro.boot.serialno | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Serial.txt");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //adb shell pm list features
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list features > " + @textBox1.Text + "\\Recursos.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list features | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Recursos.txt");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button18.Text = "Aguarde...";
            button18.Enabled = false;
            //MessageBox.Show("Esse processo pode demorar alguns minutos, durante o processo você pode fazer outras coletas", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            backgroundWorker2.RunWorkerAsync();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //adb shell ps
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell ps > " + @textBox1.Text + "\\Processos.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell ps | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Processos.txt");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //adb shell wm size
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell wm size > " + @textBox1.Text + "\\Resolucao.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell wm size | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Resolucao.txt");
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //adb shell pm list users
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list users > " + @textBox1.Text + "\\Usuarios.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell pm list users | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Usuarios.txt");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //adb shell getprop persist.sys.boot.reason.history
            //formato timestamp, ou seja, a data e a hora do evento usa o registro de segundos UNIX time
            //(ex. 1639411876, representa o dia 13 de dezembro 2021 16:11:16).
            //https://www.unixtimestamp.com/

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop persist.sys.boot.reason.history > " + @textBox1.Text + "\\Historico_liga_desliga.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop persist.sys.boot.reason.history | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Historico_liga_desliga.txt");
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //adb logcat -d
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe logcat -d > " + @textBox1.Text + "\\Logcat.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe logcat -d | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Logcat.txt");
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //adb shell df /data
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell df /data > " + @textBox1.Text + "\\Espaco_em_uso.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell df /data | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Espaco_em_uso.txt");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //shell getprop gsm.sim.operator.alpha
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop gsm.sim.operator.alpha > " + @textBox1.Text + "\\Operadora.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop gsm.sim.operator.alpha | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Operadora.txt");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //shell content query --uri content://com.android.contacts/data/phones/ --projection display_name:data1:account_name
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoContatos = new ProcessStartInfo("powershell.exe");
            processStartInfoContatos.RedirectStandardInput = true;
            processStartInfoContatos.RedirectStandardOutput = true;
            processStartInfoContatos.UseShellExecute = false;
            processStartInfoContatos.CreateNoWindow = true;
            Process processContatos = Process.Start(processStartInfoContatos);
            if (processContatos != null)
            {
                processContatos.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://com.android.contacts/data/phones/ --projection display_name:data1:account_name > " + @textBox1.Text + "\\Contatos.txt");
                processContatos.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://com.android.contacts/data/phones/ --projection display_name:data1:account_name | clip");
                processContatos.StandardInput.Close();
                processContatos.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Contatos.txt");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //shell content query --uri content://sms/inbox --projection address:date:read:status:type:body
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoDados = new ProcessStartInfo("powershell.exe");
            processStartInfoDados.RedirectStandardInput = true;
            processStartInfoDados.RedirectStandardOutput = true;
            processStartInfoDados.UseShellExecute = false;
            processStartInfoDados.CreateNoWindow = true;
            Process processDados = Process.Start(processStartInfoDados);
            if (processDados != null)
            {
                processDados.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://sms/inbox --projection address:date:read:status:type:body > " + @textBox1.Text + "\\SMS.txt");
                processDados.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://sms/inbox --projection address:date:read:status:type:body | clip");
                processDados.StandardInput.Close();
                processDados.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\SMS.txt");
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://media/external/file --projection _data:date_modified:datetaken:_display_name:mime_type:height:width:_size | " + fullPathBin + "\\grep.exe" + " mime_type=image > " + @textBox1.Text + "\\Imagens.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://media/external/file --projection _data:date_modified:datetaken:_display_name:mime_type:height:width:_size | " + fullPathBin + "\\grep.exe" + " mime_type=image | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Imagens.txt");
            }

            //fullPathBin + "\\grep.exe

            //não esquecer do grep
            //shell content query --uri content://media/external/file --projection _data:date_modified:datetaken:_display_name:mime_type:height:width:_size | grep mime_type=image
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //shell content query --uri content://com.android.calendar/events --projection title:account_name:calendar_displayName:dtstart:description
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://com.android.calendar/events --projection title:account_name:calendar_displayName:dtstart:description > " + @textBox1.Text + "\\Eventos.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://com.android.calendar/events --projection title:account_name:calendar_displayName:dtstart:description | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Eventos.txt");
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://media/external/file --projection date_modified:title:_display_name:mime_type:_data:_size:album:artist | " + fullPathBin + "\\grep.exe" + " mime_type=audio > " + @textBox1.Text + "\\Audios.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://media/external/file --projection date_modified:title:_display_name:mime_type:_data:_size:album:artist | " + fullPathBin + "\\grep.exe" + " mime_type=audio | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Audios.txt");
            }
            //não esquecer do grep
            //shell content query --uri content://media/external/file --projection date_modified:title:_display_name:mime_type:_data:_size:album:artist | grep mime_type=audio
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //não esquecer do grep
            //shell content query --uri content://media/external/file  --projection mime_type:_data:_display_name:duration:bucket_display_name:date_modified:datetaken:_size | grep mime_type=video
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://media/external/file --projection mime_type:_data:_display_name:duration:bucket_display_name:date_modified:datetaken:_size | " + fullPathBin + "\\grep.exe" + " mime_type=video > " + @textBox1.Text + "\\Videos.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://media/external/file --projection mime_type:_data:_display_name:duration:bucket_display_name:date_modified:datetaken:_size | " + fullPathBin + "\\grep.exe" + " mime_type=video > | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Videos.txt");
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            string GuardaPath = "";

            StreamWriter EscreverTXT1 = new StreamWriter(@fullPathFind + "\\DumpScreencap.bat");
            EscreverTXT1.WriteLine($@"{fullPath + "\\adb.exe"} shell uiautomator dump && {fullPath + "\\adb.exe"} shell cat /sdcard/window_dump.xml > {@textBox1.Text}\DumpScreenshot{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.xml");
            GuardaPath = @textBox1.Text + "\\DumpScreenshot" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xml";
            EscreverTXT1.Close();

            Process process2 = new Process();
            ProcessStartInfo startInfo2 = new ProcessStartInfo();
            startInfo2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo2.CreateNoWindow = true;
            startInfo2.UseShellExecute = false;
            startInfo2.RedirectStandardOutput = true;
            startInfo2.FileName = fullPathFind + "\\DumpScreencap.bat";
            process2.StartInfo = startInfo2;
            process2.Start();
            process2.StandardOutput.ReadToEnd();

            webBrowser2.Navigate(GuardaPath);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //adb shell getprop ro.build.version.release
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop ro.build.version.release > " + @textBox1.Text + "\\Versao_Android.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell getprop ro.build.version.release | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Versao_Android.txt");
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //adb shell netstat
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell netstat > " + @textBox1.Text + "\\TCP.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell netstat | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\TCP.txt");
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Coleta DUMP concluída", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            button18.Text = "TCP";
            button18.Enabled = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //shell dumpsys bluetooth_manager
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys bluetooth_manager > " + @textBox1.Text + "\\Bluetooth.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys bluetooth_manager | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Bluetooth.txt");
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys account
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);  

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys account > " + @textBox1.Text + "\\Contas.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys account | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Contas.txt");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys backup
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys backup > " + @textBox1.Text + "\\DUMP_Backup.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys backup | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\DUMP_Backup.txt");
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys dbinfo
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys dbinfo > " + @textBox1.Text + "\\DBinfo.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys dbinfo | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\DBinfo.txt");
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys face
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys face > " + @textBox1.Text + "\\DUMP_Reconhecimento_Facial.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys face | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\DUMP_Reconhecimento_Facial.txt");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            //adb reboot recovery
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe reboot recovery");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd(); ;
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            //adb reboot bootloader
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe reboot bootloader");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd(); ;
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //adb reboot
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe reboot");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();;
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            //adb reboot fastboot
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe reboot fastboot");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd(); ;
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //adb shell settings list global
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell settings list global > " + @textBox1.Text + "\\Configuracoes_Globais.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell settings list global | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Configuracoes_Globais.txt");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            //adb shell settings list secure
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell settings list secure > " + @textBox1.Text + "\\Configuracoes_Seguranca.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell settings list secure | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Configuracoes_Seguranca.txt");
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //adb shell settings list system
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell settings list system > " + @textBox1.Text + "\\Configuracoes_Sistema.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell settings list system | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Configuracoes_Sistema.txt");
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell locksettings clear --old " + TxtPin.Text + " > " + @textBox1.Text + "\\Remover_PIN.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Remover_PIN.txt");
            }
            panel2.Visible = false;
            TxtADDpin.Text = "";
            TxtPin.Text = "";
        }

        private void button46_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell locksettings set-pin " + TxtADDpin.Text + " > " + @textBox1.Text + "\\Adicionar_PIN.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Adicionar_PIN.txt");
            }
            panel2.Visible = false;
            TxtADDpin.Text = "";
            TxtPin.Text = "";
        }

        private void button47_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys adb > " + @textBox1.Text + "\\Adb.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys adb > | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Adb.txt");
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" | " + fullPathBin + "\\grep.exe .trash > " + @textBox1.Text + "\\Android-trash.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" | " + fullPathBin + "\\grep.exe .trash | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Android-trash.txt");
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" | " + fullPathBin + "\\grep.exe .thumbnails  > " + @textBox1.Text + "\\Thumbnails.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" | " + fullPathBin + "\\grep.exe .thumbnails | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Thumbnails.txt");
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" | " + fullPathBin + "\\grep.exe FB_IMG  > " + @textBox1.Text + "\\FB_IMG.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" | " + fullPathBin + "\\grep.exe FB_IMG | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\FB_IMG.txt");
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys -l > " + @textBox1.Text + "\\listservices.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys -l | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\listservices.txt");
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            //adb shell "dumpsys wifi | grep 'Networks filtered'"
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell \"dumpsys wifi | grep 'Networks filtered'\" > " + @textBox1.Text + "\\Networks-filtered.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell \"dumpsys wifi | grep 'Networks filtered'\" | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Networks-filtered.txt");
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            //adb shell dumpsys telephony.registry
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("powershell.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys telephony.registry > " + @textBox1.Text + "\\Telephony-registry.txt");
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell dumpsys telephony.registry | clip");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
                webBrowser2.Navigate(@textBox1.Text + "\\Telephony-registry.txt");
            }
        }
    }
}
