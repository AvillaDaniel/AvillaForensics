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
    public partial class FormSpecialDump : Form
    {
        public FormSpecialDump()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

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
            startInfo3.Arguments = " shell dumpsys -l";
            process3.StartInfo = startInfo3;
            process3.Start();

            StreamWriter EscreverTXT4 = new StreamWriter(@fullPathFind + "\\listaservices.txt");
            EscreverTXT4.WriteLine($"{process3.StandardOutput.ReadToEnd()}");
            EscreverTXT4.Close();

            process3.Close();

            string line;
            System.IO.StreamReader file2 = new System.IO.StreamReader(@fullPathFind + "\\listaservices.txt");
            while ((line = file2.ReadLine()) != null)
            {
                if (line != "" & line != "Currently running services:")
                {
                    listBox1.Items.Add(line);
                }
            }
            file2.Close();

            button6.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            //string pathColetas = @"coletas";
            //string fullPathColetas;
            //fullPathColetas = Path.GetFullPath(pathColetas);

            foreach (string Items in listBox1.Items)
            {

                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPath + "\\adb.exe";
                startInfo3.Arguments = " shell dumpsys " + Items + " " + textBox1.Text;
                process3.StartInfo = startInfo3;
                process3.Start();

                StreamWriter EscreverTXT4 = new StreamWriter(@textBox2.Text + "\\" + Items + ".txt");
                EscreverTXT4.WriteLine($"{process3.StandardOutput.ReadToEnd()}");
                EscreverTXT4.Close();

                process3.Close();

                webBrowser2.Navigate(@textBox2.Text + "\\" + Items + ".txt");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            button1.Enabled = true;
            button6.Enabled = true;
            listBox1.Enabled = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            //string pathColetas = @"coletas";
            //string fullPathColetas;
            //fullPathColetas = Path.GetFullPath(pathColetas);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\adb.exe";
            startInfo3.Arguments = " shell dumpsys " + listBox1.Text + " " + textBox1.Text;
            process3.StartInfo = startInfo3;
            process3.Start();

            StreamWriter EscreverTXT4 = new StreamWriter(@textBox2.Text + "\\" + listBox1.Text + ".txt");
            EscreverTXT4.WriteLine($"{process3.StandardOutput.ReadToEnd()}");
            EscreverTXT4.Close();

            process3.Close();

            webBrowser2.Navigate(@textBox2.Text + "\\" + listBox1.Text + ".txt");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            button1.Enabled = false;
            button6.Enabled = false;
            listBox1.Enabled = false;

            backgroundWorker1.RunWorkerAsync();
        }

        private void FormSpecialDump_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            textBox2.Text = file.ReadLine() + "\\coletas";
            file.Close();

            string folder = @textBox2.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }
            webBrowser1.Navigate(@textBox2.Text);
        }
    }
}
