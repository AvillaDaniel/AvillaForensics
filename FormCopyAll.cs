//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormCopyAll : Form
    {
        public FormCopyAll()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            panel1.Enabled = false;
            backgroundWorker1.RunWorkerAsync();        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathColetas = @"temp";
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
                processAPPT.StandardInput.WriteLine(fullPath + "\\adb.exe shell find \"/sdcard/\" > " + fullPathColetas + "\\temp-all.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();                
            }

            webBrowser3.Navigate(fullPathColetas + "\\temp-all.txt");

            //MessageBox.Show("Take advantage of this break if you want to delete patches in the .\\temp\\temp-all.txt file. Click OK after changing the .TXT file if this is the case.", "Attention!");

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathColetas + "\\temp-all.txt");

            while ((line = file.ReadLine()) != null) 
            {

                StreamWriter EscreverTXT1 = new StreamWriter(fullPathColetas + "\\log-temp.txt");
                EscreverTXT1.WriteLine($"{line}");
                EscreverTXT1.Close();

                webBrowser1.Navigate(fullPathColetas + "\\log-temp.txt");

                try
                {
                    string texto = line;

                    string TEXTOmod = texto;
                    String str = TEXTOmod;
                    StringBuilder sb = new StringBuilder(str);
                    TEXTOmod = sb.Replace("/", "\\").ToString(); //Barra invertida         

                    var inicioPalavra = TEXTOmod.LastIndexOf('\\'); //Pega o index
                    var palavra = TEXTOmod.Substring(inicioPalavra); //Obtem a string a partir do Index

                    if (palavra != "\\")
                    {
                        string TEXTOmod2 = TEXTOmod;
                        String str2 = TEXTOmod2;
                        StringBuilder sb2 = new StringBuilder(str2);
                        TEXTOmod2 = sb2.Replace(palavra, "").ToString();

                        string folder = textBox1.Text + TEXTOmod2;
                        if (!Directory.Exists(@folder))
                        {
                            Directory.CreateDirectory(@folder);
                        }

                        Process process3 = new Process();
                        ProcessStartInfo startInfo3 = new ProcessStartInfo();
                        startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo3.CreateNoWindow = true;
                        startInfo3.UseShellExecute = false;
                        startInfo3.RedirectStandardOutput = true;
                        startInfo3.FileName = fullPath + "\\adb.exe";
                        startInfo3.Arguments = " pull -a \"" + line + "\" " + "\"" + textBox1.Text + TEXTOmod2 + "\"";
                        process3.StartInfo = startInfo3;
                        process3.Start();
                        process3.StandardOutput.ReadToEnd();
                        process3.Close();
                    }
                }
                catch
                {


                }

            }
            file.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
            backupfolderIPEDArquivo.Description = "Choose source folder";
            if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = backupfolderIPEDArquivo.SelectedPath;
                button4.Enabled = true;
                webBrowser2.Navigate(backupfolderIPEDArquivo.SelectedPath);
            }
        }

        private void FormCopyAll_Load(object sender, EventArgs e)
        {
            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            textBox1.Text = file.ReadLine() + "\\CopyAll";            
            file.Close();

            string folder = textBox1.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }
            webBrowser2.Navigate(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
            string texto = "/data/data/";

            string TEXTOmod = texto;
            String str = TEXTOmod;
            StringBuilder sb = new StringBuilder(str);
            TEXTOmod = sb.Replace("/", "\\").ToString(); //Barra invertida         

            var inicioPalavra = TEXTOmod.LastIndexOf('\\');
            var palavra = TEXTOmod.Substring(inicioPalavra);
                       

            string TEXTOmod2 = TEXTOmod;
            String str2 = TEXTOmod2;
            StringBuilder sb2 = new StringBuilder(str2);
            TEXTOmod2 = sb2.Replace(palavra, "").ToString();

            textBox2.Text = TEXTOmod2;

        }
    }
}
