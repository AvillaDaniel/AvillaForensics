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
using System.Management;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormUnlock : Form
    {
        public FormUnlock()
        {
            InitializeComponent();
        }

        public class M //Variável Pública
        {
            public static string Model = "";
            public static string LOG = "";
        }
             

        private void button1_Click(object sender, EventArgs e)
        {
            string pathADB = @"bin\odn\odin";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            pictureBox2.Visible = true;

            button1.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;
            button3.Enabled = false;

            backgroundWorker1.RunWorkerAsync();
        }
             
        private void button3_Click(object sender, EventArgs e)
        {
            string pathM = @"bin\odn\roms\" + comboBoxMODEL.Text;
            string fullPath2;
            fullPath2 = Path.GetFullPath(pathM);

            string pathTemp = @"temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            string link = "https://www.avillaforensics.com.br/avilla/" + comboBoxMODEL.Text + "/a.tar";
            string link2 = "https://www.avillaforensics.com.br/avilla/" + comboBoxMODEL.Text + "/b.tar";

            StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\link-rom.bat");
            EscreverTXT.WriteLine($"curl {link} -o {fullPath2}\\a.tar");
            EscreverTXT.WriteLine($"curl {link2} -o {fullPath2}\\b.tar");
            EscreverTXT.Close();

            System.Diagnostics.Process.Start(fullPathTemp + "\\link-rom.bat");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //labelMODEL.Text = comboBoxMODEL.Text;
            //M.Model = comboBoxMODEL.Text;

            //button12.Enabled = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelStep2.Visible = true;
            panelStep1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panelStep1.Visible = true;
            panelStep2.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.Enabled = false;
            button8.Enabled = false;

            pictureBox2.Visible = true;

            backgroundWorker2.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panelStep3.Visible = true;
            panelStep4.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panelStep4.Visible = true;
            panelStep3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelStep3.Visible = true;
            panelStep2.Visible = false;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            panelStep2.Visible = true;
            panelStep3.Visible = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"bin\odn\odin";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathM = @"bin\odn\roms\" + comboBoxMODEL.Text;
            string fullPath2;
            fullPath2 = Path.GetFullPath(pathM);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\odin.exe";
            startInfo3.Arguments = " -a " + fullPath2 + "\\a.tar";
            process3.StartInfo = startInfo3;
            process3.Start();
            M.LOG = process3.StandardOutput.ReadToEnd();
            process3.Close();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"bin\odn\odin";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathM = @"bin\odn\roms\" + comboBoxMODEL.Text;
            string fullPath2;
            fullPath2 = Path.GetFullPath(pathM);

            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\odin.exe";
            startInfo3.Arguments = " -a " + fullPath2 + "\\b.tar";
            process3.StartInfo = startInfo3;
            process3.Start();
            M.LOG = process3.StandardOutput.ReadToEnd();
            process3.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            textBox2.Text = M.LOG;

            button10.Enabled = true;
            button8.Enabled = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            textBox1.Text = M.LOG;

            button1.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            button3.Enabled = true;
        }           

        private void FormUnlock_Load(object sender, EventArgs e)
        {
            //labelMODEL.Text = comboBoxMODEL.Text;
            //M.Model = comboBoxMODEL.Text;

            string line;

            string pathM = @"bin\odn\roms\";
            string fullPath2;
            fullPath2 = Path.GetFullPath(pathM);

            System.IO.StreamReader file = new System.IO.StreamReader(@fullPath2 + "\\list");
            while ((line = file.ReadLine()) != null)
            {

                listView1.Items.Add(line, 0);
               
            }
            file.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelCOM.Text = "";

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_POTSModem");

            string name;
            string comport;

            foreach (ManagementObject managementObject in managementObjectSearcher.Get())
            {
                name = managementObject.GetPropertyValue("Name").ToString();
                comport = managementObject.GetPropertyValue("AttachedTo").ToString();
                labelCOM.Text = name + " | " + comport;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label13.Visible = false;
            labelMODELINFO.Text = "";
            comboBoxMODEL.Text = listView1.Items[listView1.FocusedItem.Index].Text;

            try
            {
                string pathM = @"bin\odn\roms\" + comboBoxMODEL.Text;
                string fullPath2;
                fullPath2 = Path.GetFullPath(pathM);

                System.IO.StreamReader file = new System.IO.StreamReader(fullPath2 + "\\" + comboBoxMODEL.Text);
                labelMODELINFO.Text = file.ReadLine();
                file.Close();

                pictureBox1.Image = Image.FromFile(@fullPath2 + "\\" + comboBoxMODEL.Text + ".png");

                button12.Enabled = true;
            }
            catch 
            {
                button12.Enabled = false;
                string pathM = @"bin\odn\roms\";
                string fullPath2;
                fullPath2 = Path.GetFullPath(pathM);
                pictureBox1.Image = Image.FromFile(@fullPath2 + "\\not-tested.png");

                label13.Visible = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //comboBoxMODEL.Enabled = false;
            panelStep1.Visible = true;
            panelSelectModel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //comboBoxMODEL.Enabled = true;
            panelSelectModel.Visible = true;
            panelStep1.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
