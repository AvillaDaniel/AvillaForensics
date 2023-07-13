//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using Analisador_Arquivos_DEIC_SBC;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);

            //label1.Parent = this;
            //label1.BackColor = Color.Transparent;  

            InitializeComponent();
        }

        public class pacote //Variável Pública
        {
            public static string Model;
            public static string Type;
            public static string Serial;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            //help newMDIChild = new help();
            //newMDIChild.MdiParent = this;
            //newMDIChild.Show();

            foreach (Control control in this.Controls)
            {

                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = System.Drawing.Color.SteelBlue;
                    break;
                }
            }

            string pathBin = @"acquisitions\";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            textBox1.Text = "Case-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");

            TextboxPath.Text = fullPathBin + textBox1.Text;

            backgroundWorker1.RunWorkerAsync();
            
            //System.Diagnostics.Process.Start("https://academiadeforensedigital.com.br/treinamentos/treinamento-de-avilla-forensics/");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormADB newMDIChild = new FormADB();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void Screenshot_Click(object sender, EventArgs e)
        {
            FormPrint newMDIChild = new FormPrint();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            toolStripButton6.Enabled = false;

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string folder = @TextboxPath.Text + "\\coletas";
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            ProcessStartInfo processStartInfoContatos = new ProcessStartInfo("powershell.exe");
            processStartInfoContatos.RedirectStandardInput = true;
            processStartInfoContatos.RedirectStandardOutput = true;
            processStartInfoContatos.UseShellExecute = false;
            processStartInfoContatos.CreateNoWindow = true;
            Process processContatos = Process.Start(processStartInfoContatos);
            if (processContatos != null)
            {
                processContatos.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://com.android.contacts/data/phones/ --projection display_name:data1:account_name > " + @folder + "\\contatos.csv");
                processContatos.StandardInput.Close();
                processContatos.StandardOutput.ReadToEnd();
                System.Diagnostics.Process.Start("explorer.exe", @folder);
            }

            toolStripButton6.Enabled = true;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            toolStripButton8.Enabled = false;

            string pathADB = @"bin\scrcpy";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            Process process1 = new Process();
            ProcessStartInfo startInfo1 = new ProcessStartInfo();
            startInfo1.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo1.CreateNoWindow = true;
            startInfo1.UseShellExecute = false;
            startInfo1.RedirectStandardOutput = true;
            startInfo1.FileName = fullPath + "\\scrcpy.exe";
            process1.StartInfo = startInfo1;
            process1.Start();

            toolStripButton8.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormWhats newMDIChild = new FormWhats();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            FormDecript newMDIChild = new FormDecript();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FormIOS newMDIChild = new FormIOS();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            FormAbTar newMDIChild = new FormAbTar();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            Form4 newMDIChild = new Form4();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            Form1 newMDIChild = new Form1();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            toolStripButton7.Enabled = false;

            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string folder = @TextboxPath.Text + "\\coletas";
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            ProcessStartInfo processStartInfoDados = new ProcessStartInfo("powershell.exe");
            processStartInfoDados.RedirectStandardInput = true;
            processStartInfoDados.RedirectStandardOutput = true;
            processStartInfoDados.UseShellExecute = false;
            processStartInfoDados.CreateNoWindow = true;
            Process processDados = Process.Start(processStartInfoDados);
            if (processDados != null)
            {
                processDados.StandardInput.WriteLine(fullPath + "\\adb.exe shell content query --uri content://sms/inbox --projection address:date:read:status:type:body > " + @folder + "\\sms.csv");
                processDados.StandardInput.Close();
                processDados.StandardOutput.ReadToEnd();
                System.Diagnostics.Process.Start("explorer.exe", @folder);
            }

            toolStripButton7.Enabled = true;
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            Form3 newMDIChild = new Form3();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FormAPK newMDIChild = new FormAPK();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin\jadx-1.2.0\";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            System.Diagnostics.Process.Start(fullPathBin + "\\jadx-gui-1.2.0-no-jre-win.exe");
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin\";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            System.Diagnostics.Process.Start(fullPathBin + "\\WhatsAppViewer.exe");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
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
            startInfo3.Arguments = " devices";
            process3.StartInfo = startInfo3;
            process3.Start();
            process3.StandardOutput.ReadToEnd();
            process3.Close();

            //string pathBin2 = @"bin\Html-avilla";
            //string fullPathBin2;
            //fullPathBin2 = Path.GetFullPath(pathBin2);

            //webBrowser1.Navigate(@fullPathBin2 + "\\Avilla Forensics 3.htm");
        }
           
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            FormRaspagemInstagram newMDIChild = new FormRaspagemInstagram();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            toolStripButton15.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathWhats = @"bin";
            string fullPathWhats;
            fullPathWhats = Path.GetFullPath(pathWhats);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            Process processWhats3 = new Process();
            ProcessStartInfo startInfoWhats3 = new ProcessStartInfo();
            startInfoWhats3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats3.CreateNoWindow = true;
            startInfoWhats3.UseShellExecute = false;
            startInfoWhats3.RedirectStandardOutput = true;
            startInfoWhats3.FileName = fullPath + "\\adb.exe";
            startInfoWhats3.Arguments = " shell cmd package uninstall com.alias.connector";
            processWhats3.StartInfo = startInfoWhats3;
            processWhats3.Start();
            processWhats3.StandardOutput.ReadToEnd();
            processWhats3.Close();

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

            Process processWhats2 = new Process();
            ProcessStartInfo startInfoWhats2 = new ProcessStartInfo();
            startInfoWhats2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats2.CreateNoWindow = true;
            startInfoWhats2.UseShellExecute = false;
            startInfoWhats2.RedirectStandardOutput = true;
            startInfoWhats2.FileName = fullPath + "\\adb.exe";
            startInfoWhats2.Arguments = " install -r -g " + fullPathWhats + "\\com.alias.connector.apk";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.WRITE_EXTERNAL_STORAGE";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.READ_CALL_LOG";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.READ_SMS";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.READ_CONTACTS";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.READ_EXTERNAL_STORAGE";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.READ_PHONE_STATE";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.alias.connector android.permission.READ_PHONE_NUMBERS";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell monkey -p com.alias.connector -c android.intent.category.LAUNCHER 1";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            Thread.Sleep(8000);

            ProcessStartInfo processStartInfoDados = new ProcessStartInfo("powershell.exe");
            processStartInfoDados.RedirectStandardInput = true;
            processStartInfoDados.RedirectStandardOutput = true;
            processStartInfoDados.UseShellExecute = false;
            processStartInfoDados.CreateNoWindow = true;
            Process processDados = Process.Start(processStartInfoDados);
            if (processDados != null)
            {
                processDados.StandardInput.WriteLine(fullPath + "\\adb.exe pull /sdcard/Download/alias/ " + fullPathColetas);
                processDados.StandardInput.Close();
                processDados.StandardOutput.ReadToEnd();
            }

            Process processWhats16 = new Process();
            ProcessStartInfo startInfoWhats16 = new ProcessStartInfo();
            startInfoWhats16.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats16.CreateNoWindow = true;
            startInfoWhats16.UseShellExecute = false;
            startInfoWhats16.RedirectStandardOutput = true;
            startInfoWhats16.FileName = fullPath + "\\adb.exe";
            startInfoWhats16.Arguments = " shell am force-stop com.alias.connector";
            processWhats16.StartInfo = startInfoWhats16;
            processWhats16.Start();
            processWhats16.StandardOutput.ReadToEnd();
            processWhats16.Close();

            System.Diagnostics.Process.Start("explorer.exe", fullPathColetas);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripButton15.Enabled = true;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            toolStripButton13.Enabled = false;
            backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            string pathWhats = @"bin";
            string fullPathWhats;
            fullPathWhats = Path.GetFullPath(pathWhats);

            string pathColetas = @"coletas";
            string fullPathColetas;
            fullPathColetas = Path.GetFullPath(pathColetas);

            Process processWhats3 = new Process();
            ProcessStartInfo startInfoWhats3 = new ProcessStartInfo();
            startInfoWhats3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats3.CreateNoWindow = true;
            startInfoWhats3.UseShellExecute = false;
            startInfoWhats3.RedirectStandardOutput = true;
            startInfoWhats3.FileName = fullPath + "\\adb.exe";
            startInfoWhats3.Arguments = " shell cmd package uninstall com.viaforensics.android.aflogical_ose";
            processWhats3.StartInfo = startInfoWhats3;
            processWhats3.Start();
            processWhats3.StandardOutput.ReadToEnd();
            processWhats3.Close();

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

            Process processWhats2 = new Process();
            ProcessStartInfo startInfoWhats2 = new ProcessStartInfo();
            startInfoWhats2.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats2.CreateNoWindow = true;
            startInfoWhats2.UseShellExecute = false;
            startInfoWhats2.RedirectStandardOutput = true;
            startInfoWhats2.FileName = fullPath + "\\adb.exe";
            startInfoWhats2.Arguments = " install -r -g " + fullPathWhats + "\\AFLogicalOSE152OSE.apk";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.WRITE_EXTERNAL_STORAGE";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.READ_CALL_LOG";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.READ_SMS";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.READ_CONTACTS";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.READ_EXTERNAL_STORAGE";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.READ_PHONE_STATE";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            startInfoWhats2.Arguments = " shell pm grant com.viaforensics.android.aflogical_ose android.permission.READ_PHONE_NUMBERS";
            processWhats2.StartInfo = startInfoWhats2;
            processWhats2.Start();
            processWhats2.StandardOutput.ReadToEnd();
            processWhats2.Close();

            Process processWhats20 = new Process();
            ProcessStartInfo startInfoWhats20 = new ProcessStartInfo();
            startInfoWhats20.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats20.CreateNoWindow = true;
            startInfoWhats20.UseShellExecute = false;
            startInfoWhats20.RedirectStandardOutput = true;
            startInfoWhats20.FileName = fullPath + "\\adb.exe";
            startInfoWhats20.Arguments = " shell am start -n com.viaforensics.android.aflogical_ose/com.viaforensics.android.ExtractAllData";
            processWhats20.StartInfo = startInfoWhats20;
            processWhats20.Start();
            processWhats20.StandardOutput.ReadToEnd();
            processWhats20.Close();

            Thread.Sleep(2000);

            ProcessStartInfo processStartInfoDados = new ProcessStartInfo("powershell.exe");
            processStartInfoDados.RedirectStandardInput = true;
            processStartInfoDados.RedirectStandardOutput = true;
            processStartInfoDados.UseShellExecute = false;
            processStartInfoDados.CreateNoWindow = true;
            Process processDados = Process.Start(processStartInfoDados);
            if (processDados != null)
            {
                processDados.StandardInput.WriteLine(fullPath + "\\adb.exe pull /sdcard/forensics/ " + fullPathColetas);
                processDados.StandardInput.Close();
                processDados.StandardOutput.ReadToEnd();
            }

            //com.viaforensics.android.aflogical_ose

            Process processWhats16 = new Process();
            ProcessStartInfo startInfoWhats16 = new ProcessStartInfo();
            startInfoWhats16.WindowStyle = ProcessWindowStyle.Hidden;
            startInfoWhats16.CreateNoWindow = true;
            startInfoWhats16.UseShellExecute = false;
            startInfoWhats16.RedirectStandardOutput = true;
            startInfoWhats16.FileName = fullPath + "\\adb.exe";
            startInfoWhats16.Arguments = " shell am force-stop com.viaforensics.android.aflogical_ose";
            processWhats16.StartInfo = startInfoWhats16;
            processWhats16.Start();
            processWhats16.StandardOutput.ReadToEnd();
            processWhats16.Close();

            System.Diagnostics.Process.Start("explorer.exe", fullPathColetas);
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripButton13.Enabled = true;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            Hash newMDIChild = new Hash();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            DeviceExplorer newMDIChild = new DeviceExplorer();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton23_Click(object sender, EventArgs e)
        {
            FormMidias newMDIChild = new FormMidias();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton24_Click(object sender, EventArgs e)
        {
            FormColetasWhats newMDIChild = new FormColetasWhats();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            WhatsParser newMDIChild = new WhatsParser();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
            WhatsParserAntigocs newMDIChild = new WhatsParserAntigocs();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            FormTrash newMDIChild = new FormTrash();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            FormOpus newMDIChild = new FormOpus();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin\Avilla-Records-Localizations_1_0_0_0";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            System.Diagnostics.Process.Start(fullPathBin + "\\Avilla-Records-Localizations.exe");
        }

        private void toolStripButton33_Click(object sender, EventArgs e)
        {
            FormCopyAll newMDIChild = new FormCopyAll();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            FormUnlock newMDIChild = new FormUnlock();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton36_Click(object sender, EventArgs e)
        {
            FormOCR newMDIChild = new FormOCR();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void toolStripButton37_Click(object sender, EventArgs e)
        {
            FormProcess newMDIChild = new FormProcess();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string folder = @TextboxPath.Text;
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            }

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\PathAcquisition.txt");
            EscreverTXT4.WriteLine($"{@TextboxPath.Text}");
            EscreverTXT4.Close();

            toolStripStatusLabel9.Text = "Acquisition Path: " + TextboxPath.Text;

            panel1.Visible = false;
            //webBrowser1.Visible = false;

            toolStrip.Enabled = true;
            toolStrip1.Enabled = true;
            toolStrip2.Enabled = true;      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pathBin = @"acquisitions\";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            TextboxPath.Text = fullPathBin + textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolder = new FolderBrowserDialog();
            backupfolder.Description = "Choose destination folder";
            if (backupfolder.ShowDialog() == DialogResult.OK)
            {
                TextboxPath.Text = backupfolder.SelectedPath;
                toolStripStatusLabel9.Text = "Acquisition Path: " + backupfolder.SelectedPath;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://academiadeforensedigital.com.br/treinamentos/treinamento-de-avilla-forensics/");
        }

        private void toolStripButton38_Click(object sender, EventArgs e)
        {
            FormSpecialDump newMDIChild = new FormSpecialDump();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPED = new FolderBrowserDialog();
            backupfolderIPED.Description = "Choose existing case";
            if (backupfolderIPED.ShowDialog() == DialogResult.OK)
            {
                string pathTEMP = @"temp";
                string fullPathTEMP;
                fullPathTEMP = Path.GetFullPath(pathTEMP);

                StreamWriter EscreverTXT4 = new StreamWriter(@fullPathTEMP + "\\PathAcquisition.txt");
                EscreverTXT4.WriteLine($"{@backupfolderIPED.SelectedPath}");
                EscreverTXT4.Close();

                TextboxPath.Text = backupfolderIPED.SelectedPath;
                toolStripStatusLabel9.Text = "Acquisition Path: " + backupfolderIPED.SelectedPath;

                panel1.Visible = false;
                //webBrowser1.Visible = false;

                toolStrip.Enabled = true;
                toolStrip1.Enabled = true;
                toolStrip2.Enabled = true;
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton42_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Avilla-File-System-Forensics.exe");
        }

        private void LabelModel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", TextboxPath.Text);
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathADB = @"adb";
            string fullPath;
            fullPath = Path.GetFullPath(pathADB);

            //Modelo
            Process process3 = new Process();
            ProcessStartInfo startInfo3 = new ProcessStartInfo();
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo3.CreateNoWindow = true;
            startInfo3.UseShellExecute = false;
            startInfo3.RedirectStandardOutput = true;
            startInfo3.FileName = fullPath + "\\adb.exe";
            startInfo3.Arguments = " shell getprop ro.product.model";
            process3.StartInfo = startInfo3;
            process3.Start();
            LabelModel.Text = "Model: " + process3.StandardOutput.ReadToEnd();
            process3.Close();

            //Versão Android
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
            ToolVersion.Text = "  Version Release: " + process4.StandardOutput.ReadToEnd();
            process4.Close();

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
            ToolBuildVersion.Text = "  Build Version: " + process2.StandardOutput.ReadToEnd();
            process2.Close();

            //Versão SDK Fabrica
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
            ToolVendorBuildVersion.Text = "  Vendor Build Version: " + process1.StandardOutput.ReadToEnd();
            process1.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.ucapem.group/site/repositorio/avilla-forensic/");
        }
    }
}
