//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        public class VarPublica //Variaveis publicas
        {         
            public static string GuardaHora;
            public static bool Pausa;
            public static string Formato = "jpg";

            //public static string UltimoHashPrint = "ND";        
            //public static string HashPrintAtual = "ND";
            //public static string CaminhoPrintAtual = "ND";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            ProcessStartInfo processStartInfo6 = new ProcessStartInfo("cmd.exe");
            processStartInfo6.RedirectStandardInput = true;
            processStartInfo6.RedirectStandardOutput = true;
            processStartInfo6.UseShellExecute = false;
            processStartInfo6.CreateNoWindow = true;
            Process process6 = Process.Start(processStartInfo6);

            if (process6 != null)
            {
                process6.StandardInput.WriteLine(fullPath + "\\adb.exe exec-out screencap -p > " + @textBox1.Text + "\\Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "." + VarPublica.Formato); 
                VarPublica.GuardaHora = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            }

            if (checkBox1.Checked)
            {
                StreamWriter EscreverTXT1 = new StreamWriter(@fullPathFind + "\\DumpScreencap.bat");
                EscreverTXT1.WriteLine($@"{fullPath + "\\adb.exe"} shell uiautomator dump && {fullPath + "\\adb.exe"} shell cat /sdcard/window_dump.xml > {@textBox1.Text}\DumpScreenshot{VarPublica.GuardaHora}.xml");
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
            }

            string pathTess = @"bin\tesseract";
            string fullPathTess;
            fullPathTess = Path.GetFullPath(pathTess);

            if (checkBoxOCR.Checked)
            {
                Thread.Sleep(1000);
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPathTess + "\\tesseract.exe";
                startInfo3.Arguments = @textBox1.Text + "\\Screenshot-" + VarPublica.GuardaHora + ".jpg " + @textBox1.Text + "\\Screenshot-" + VarPublica.GuardaHora + ".jpg";
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();
            }
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            textBox1.Text = file.ReadLine() + "\\print";
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

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
            button2.Enabled = false;
            button4.Enabled = true;
            button4.BackColor = Color.Red;
            pictureBox3.Visible = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
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
            label2.Text = process3.StandardOutput.ReadToEnd();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
         
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            VarPublica.Pausa = false;
            button2.Enabled = true;
            button4.BackColor = Color.Silver;
            button4.Enabled = false;
            pictureBox3.Visible = false;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            string pathTess = @"bin\tesseract";
            string fullPathTess;
            fullPathTess = Path.GetFullPath(pathTess);

            VarPublica.Pausa = true;

            ProcessStartInfo processStartInfo7 = new ProcessStartInfo("cmd.exe");
            processStartInfo7.RedirectStandardInput = true;
            processStartInfo7.RedirectStandardOutput = true;
            processStartInfo7.UseShellExecute = false;
            processStartInfo7.CreateNoWindow = true;
            Process process7 = Process.Start(processStartInfo7);
            if (process7 != null)
            {
                process7.StandardInput.WriteLine(fullPath + "\\adb.exe exec-out screencap -p > " + @textBox1.Text + "\\Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "." + VarPublica.Formato);
                VarPublica.GuardaHora = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                process7.StandardInput.Close();
                process7.StandardOutput.ReadToEnd();
                process7.Close();
            }

            if (checkBox1.Checked)
            {
                StreamWriter EscreverTXT1 = new StreamWriter(@fullPathFind + "\\DumpScreencap.bat");
                EscreverTXT1.WriteLine($@"{fullPath + "\\adb.exe"} shell uiautomator dump && {fullPath + "\\adb.exe"} shell cat /sdcard/window_dump.xml > {@textBox1.Text}\DumpScreenshot{VarPublica.GuardaHora}.xml");
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
            }

            if (checkBoxOCR.Checked)
            {
                Thread.Sleep(1000);
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPathTess + "\\tesseract.exe";
                startInfo3.Arguments = @textBox1.Text + "\\Screenshot-" + VarPublica.GuardaHora + ".jpg " + @textBox1.Text + "\\Screenshot-" + VarPublica.GuardaHora + ".jpg";
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();
            }

            while (VarPublica.Pausa == true)
            {
                Process process4 = new Process();
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.RedirectStandardOutput = true;
                startInfo4.FileName = fullPath + "\\adb.exe";
                if (radioButtonP.Checked)
                {
                    startInfo4.Arguments = " shell input swipe 0 700 0 1350";
                }
                else
                {
                    startInfo4.Arguments = " shell input swipe 0 700 0 0";
                }                
                process4.StartInfo = startInfo4;
                process4.Start();
                process4.StandardOutput.ReadToEnd();
                process4.Close();

                ProcessStartInfo processStartInfo6 = new ProcessStartInfo("cmd.exe");
                processStartInfo6.RedirectStandardInput = true;
                processStartInfo6.RedirectStandardOutput = true;
                processStartInfo6.UseShellExecute = false;
                processStartInfo6.CreateNoWindow = true;
                Process process6 = Process.Start(processStartInfo6);
                if (process6 != null)
                {                    
                    process6.StandardInput.WriteLine(fullPath + "\\adb.exe exec-out screencap -p > " + @textBox1.Text + "\\Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "." + VarPublica.Formato);
                    VarPublica.GuardaHora = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    process6.StandardInput.Close();
                    process6.StandardOutput.ReadToEnd();
                    process6.Close();
                }

                if (checkBox1.Checked)
                {
                    StreamWriter EscreverTXT1 = new StreamWriter(@fullPathFind + "\\DumpScreencap.bat");
                    EscreverTXT1.WriteLine($@"{fullPath + "\\adb.exe"} shell uiautomator dump && {fullPath + "\\adb.exe"} shell cat /sdcard/window_dump.xml > {@textBox1.Text}\DumpScreenshot{VarPublica.GuardaHora}.xml");
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
                }

                if (checkBoxOCR.Checked)
                {
                    Thread.Sleep(1000);
                    Process process3 = new Process();
                    ProcessStartInfo startInfo3 = new ProcessStartInfo();
                    startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo3.CreateNoWindow = true;
                    startInfo3.UseShellExecute = false;
                    startInfo3.RedirectStandardOutput = true;
                    startInfo3.FileName = fullPathTess + "\\tesseract.exe";
                    startInfo3.Arguments = @textBox1.Text + "\\Screenshot-" + VarPublica.GuardaHora + ".jpg " + @textBox1.Text + "\\Screenshot-" + VarPublica.GuardaHora + ".jpg";
                    process3.StartInfo = startInfo3;
                    process3.Start();
                    process3.StandardOutput.ReadToEnd();
                    process3.Close();
                }
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //panel7.Enabled = true;
            button2.Enabled = true;
            button4.BackColor = Color.Silver;
            button4.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            VarPublica.Formato = "jpg";
            LabelFomato.Text = "JPG";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            VarPublica.Formato = "png";
            LabelFomato.Text = "PNG";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            VarPublica.Formato = "bmp";
            LabelFomato.Text = "BMP";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            VarPublica.Formato = "jpeg";
            LabelFomato.Text = "JPEG";
        }

        private void checkBoxOCR_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
