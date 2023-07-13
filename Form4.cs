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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public class contador //Contador P
        {
            public static int contar = 0;
            //public static string nude = "";
            public static string formato = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string pathFind = @"find/jpg";
            //string fullPathFind;
            //fullPathFind = Path.GetFullPath(pathFind);
            label1.Text = "";
            label1.Visible = false;

            textBox1.Visible = false;
            button2.Visible = false;
            panel1.Enabled = false;

            webBrowser1.Navigate("about:blank");
            webBrowser1.Navigate(Txtdestino.Text);

            pictureBox2.Visible = true;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            StreamWriter EscreverTXT = new StreamWriter(@fullPathFind + "\\" + contador.formato + ".bat");
            EscreverTXT.WriteLine($@"{fullPath + "\\adb.exe"} shell find '/sdcard/' -iname '*.{contador.formato}' > {fullPathFind + "\\" + contador.formato + ".txt"}");
            EscreverTXT.Close();

            Process process1 = new Process();
            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo1.CreateNoWindow = true;
            startInfo1.UseShellExecute = false;
            startInfo1.RedirectStandardOutput = true;
            startInfo1.FileName = fullPathFind + "\\" + contador.formato + ".bat";
            process1.StartInfo = startInfo1;
            process1.Start();
            process1.StandardOutput.ReadToEnd();

            webBrowser2.Navigate(fullPathFind + "\\" + contador.formato + ".txt");

            //int counter = 0;
            string line; 

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\" + contador.formato + ".txt");

            while ((line = file.ReadLine()) != null)
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPath + "\\adb.exe";
                startInfo3.Arguments = " pull \"" + line + "\" " + "\"" + Txtdestino.Text + "\"";
                process3.StartInfo = startInfo3;
                process3.Start();
                process3.StandardOutput.ReadToEnd();
                process3.Close();
                //counter++;
                //Thread.Sleep(250); 
            }
            file.Close();
            //contador.contar = counter;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //label1.Text = contador.contar.ToString() + " Arquivos detectados.";
            label1.Text = "Transfer Completed.";
            label1.Visible = true;

            pictureBox2.Visible = false;
            panel1.Enabled = true;                        
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            contador.formato = "jpg";
            comboBox1.Text = "jpg";

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            Txtdestino.Text = file.ReadLine() + "\\Quick-Scan\\jpg";
            file.Close();

            string folder = Txtdestino.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                       
        }

        private void button9_Click(object sender, EventArgs e)
        {          
            FolderBrowserDialog backupfolderAPK = new FolderBrowserDialog();
            backupfolderAPK.Description = "Choose destination folder";
            if (backupfolderAPK.ShowDialog() == DialogResult.OK)
            {
                Txtdestino.Text = backupfolderAPK.SelectedPath;
                button1.Enabled = true;
                button3_Click_1(null, null);
            }            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //label1.Text = contador.contar.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            button2.Visible = false;

            //backgroundWorker2.RunWorkerAsync();
            //Txtdestino.Text = contador.nude;
            //string pathBin = @"bin";
            //string fullPathBin;
            //fullPathBin = Path.GetFullPath(pathBin);

            //listBox1.Items.Clear();
            //DirectoryInfo Dir = new DirectoryInfo(@Txtdestino.Text);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            //FileInfo[] Files = Dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            //foreach (FileInfo File in Files)
            //{
            //ProcessStartInfo processStartInfoContatos = new ProcessStartInfo("cmd.exe");
            //processStartInfoContatos.RedirectStandardInput = true;
            //processStartInfoContatos.RedirectStandardOutput = true;
            //processStartInfoContatos.UseShellExecute = false;
            //processStartInfoContatos.CreateNoWindow = true;
            //Process processContatos = Process.Start(processStartInfoContatos);
            //if (processContatos != null)
            //{
            //processContatos.StandardInput.WriteLine(fullPathBin + "\\nude.py " + File.FullName);
            //processContatos.StandardInput.Close();
            //textBox1.Text += processContatos.StandardOutput.ReadToEnd();
            //contador.nude = "True";
            //}
            // listBox1.Items.Add(File.FullName);
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            contador.formato = "jpg";
            LabelFomato.Text = "*.JPG";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            contador.formato = "opus";
            LabelFomato.Text = "*.OPUS";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);            

            textBox1.Visible = true;
            button2.Visible = true; 

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\adb.exe";
            //startInfo3.Arguments = " shell getprop";
            startInfo3.Arguments = " devices -l";
            process3.StartInfo = startInfo3;
            process3.Start();
            textBox1.Text = process3.StandardOutput.ReadToEnd();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            contador.formato = comboBox1.Text;
            LabelFomato.Text = "*." + comboBox1.Text;

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            Txtdestino.Text = file.ReadLine() + "\\Quick-Scan\\" + comboBox1.Text;
            file.Close();

            string folder = Txtdestino.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
