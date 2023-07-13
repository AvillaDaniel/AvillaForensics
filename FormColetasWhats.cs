//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormColetasWhats : Form
    {
        public FormColetasWhats()
        {
            InitializeComponent();
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=" + caminho.caminhoDB + ";Version=3;New=True;Compress=True;");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch
            {

            }
            return sqlite_conn;
        }

        public class caminho //Variável Pública
        {
            public static string caminhoDB = "";
            public static string caminhoIMG = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            label5.Text = "";

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);  

            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM wa_contacts";            

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            
            string myreaderJID = "";
            string myreaderNAME = "";
            string myreaderSTATUS = "";
            string myreaderNUMBER = "";

            int contar = 0;

            while (sqlite_datareader.Read())
            {

                myreaderJID = sqlite_datareader.GetString(1);                   
                    
                try
                {
                    myreaderNAME = sqlite_datareader.GetString(7);
                }
                catch
                {
                    myreaderNAME = " ";
                }

                try
                {
                    myreaderNUMBER = sqlite_datareader.GetString(5);
                }
                catch
                {
                    myreaderNUMBER = " ";
                }

                try
                {
                    myreaderSTATUS = sqlite_datareader.GetString(3);
                }
                catch
                {
                    myreaderSTATUS = " ";
                }

                try 
                {
                    imageList1.Images.Add(Image.FromFile(caminho.caminhoIMG + "\\" + myreaderJID + ".j"));
                }
                catch
                {
                    imageList1.Images.Add(Image.FromFile(fullPathBin + "\\erro2.png"));
                }                                      
                    
                listView1.Items.Add(myreaderJID + " | " + myreaderNAME + " | " + myreaderNUMBER + " | " + myreaderSTATUS, contar);
                contar++;

            }
            sqlite_conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd2.Multiselect = true;
            this.ofd2.Title = "Select file";
            ofd2.InitialDirectory = @"C:\";
            ofd2.Filter = "Files (*.db)|*.db";
            ofd2.CheckFileExists = true;
            ofd2.CheckPathExists = true;
            ofd2.FilterIndex = 2;
            ofd2.RestoreDirectory = true;
            ofd2.ReadOnlyChecked = true;
            ofd2.ShowReadOnly = true;

            DialogResult drIPED = this.ofd2.ShowDialog();

            if (drIPED == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = ofd2.FileName;
                caminho.caminhoDB = ofd2.FileName;
                button1.Enabled = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(caminho.caminhoIMG + "\\" + listBoxLINK.Text + ".j");
            label5.Visible = true;
            label5.Text = listView1.Items[listView1.FocusedItem.Index].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolderIPEDArquivo = new FolderBrowserDialog();
            backupfolderIPEDArquivo.Description = "Choose source folder";
            if (backupfolderIPEDArquivo.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = backupfolderIPEDArquivo.SelectedPath;
                caminho.caminhoIMG = backupfolderIPEDArquivo.SelectedPath;
                button10.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
