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
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormMidias : Form
    {
        public FormMidias()
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
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string pathFind = @"bin\whatsapp-media-decrypt";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT message_url,mime_type,hex(media_key),file_path FROM message_media";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            StreamWriter EscreverTXT = new StreamWriter(@fullPathFind + "\\Executar_Script_Midias.bat");

            string myreaderL = ""; //message_url
            string myreaderT = ""; //mime_type
            string myreaderK = ""; //hex(media_key)
            string myreaderP = ""; //file_path

            int contar = 0;

            while (sqlite_datareader.Read())
            {
                try
                {
                    myreaderL = sqlite_datareader.GetString(0);
                }
                catch 
                {
                    myreaderL = "none";
                }

                try
                {
                    myreaderT = sqlite_datareader.GetString(1);
                    string[] TYPESEPARA = myreaderT.Split(';');
                    myreaderT = TYPESEPARA[0];
                }
                catch 
                {
                    myreaderT = "none";
                }

                try 
                {
                    myreaderK = sqlite_datareader.GetString(2);
                }
                catch 
                {
                    myreaderK = "none";
                }
                    
                try 
                {
                    myreaderP = sqlite_datareader.GetString(3);
                }
                catch 
                {
                    myreaderP = "null";
                }

                /////////////////////////////////////////////////////////////////   

                try 
                {
                    string FilePath = myreaderP;

                    string TEXTOmod = FilePath;
                    String str = TEXTOmod;
                    StringBuilder sb = new StringBuilder(str);
                    TEXTOmod = sb.Replace("/", "\\").ToString(); //Barra invertida     

                    var inicioPalavra = TEXTOmod.LastIndexOf('\\'); //Pega o index
                    var palavra = TEXTOmod.Substring(inicioPalavra); //Obtem a string a partir do Index (IMG-20230706-WA0160.jpg)

                    string TEXTOmod2 = TEXTOmod; //Remove o nome da midia do path total
                    String str2 = TEXTOmod2;
                    StringBuilder sb2 = new StringBuilder(str2);
                    TEXTOmod2 = sb2.Replace(palavra, "").ToString();

                    string folder = @fullPathFind + "\\" + TEXTOmod2;
                    if (!Directory.Exists(@folder))
                    {
                        Directory.CreateDirectory(@folder);
                    }

                    EscreverTXT.WriteLine($"curl -o \"{@fullPathFind}\\{TEXTOmod2}{palavra}\" \"{myreaderL}\" --silent --fail");
                    EscreverTXT.WriteLine($"python decrypt.py -m {myreaderT} -j \"{myreaderK}\" \"{@fullPathFind}\\{TEXTOmod2}{palavra}\"");

                }
                catch 
                {          

                    EscreverTXT.WriteLine($"curl -o File-{contar}.enc \"{myreaderL}\" --silent --fail");
                    EscreverTXT.WriteLine($"python decrypt.py -m {myreaderT} -j \"{myreaderK}\" File-{contar}.enc");

                    contar++;
                }
                
                ///////////////////////////////////////////////////////////////////////////////

            }

            sqlite_conn.Close();
            EscreverTXT.Close();

            //"image": "jpg",
            //"video": "mp4",
            //"audio": "ogg",
            //"document": "bin",

            //"image": b"WhatsApp Image Keys",
            //"video": b"WhatsApp Video Keys",
            //"audio": b"WhatsApp Audio Keys",
            //"document": b"WhatsApp Document Keys",
            //"image/webp": b"WhatsApp Image Keys",
            //"image/jpeg": b"WhatsApp Image Keys",
            //"image/png": b"WhatsApp Image Keys",
            //"video/mp4": b"WhatsApp Video Keys",
            //"audio/aac": b"WhatsApp Audio Keys",
            //"audio/ogg": b"WhatsApp Audio Keys",
            //"audio/wav": b"WhatsApp Audio Keys",
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxLINK.Items.Clear();

            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT message_url,mime_type,hex(media_key) FROM message_media";

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            string myreaderL = "";
            string myreaderT = "";
            string myreaderK = "";

            while (sqlite_datareader.Read())
            {
                try
                {
                    myreaderL = sqlite_datareader.GetString(0);
                    myreaderT = sqlite_datareader.GetString(1);
                    myreaderK = sqlite_datareader.GetString(2);

                    string[] TYPESEPARA = myreaderT.Split(';');
                    myreaderT = TYPESEPARA[0];

                    listBoxLINK.Items.Add(myreaderL + "            " + myreaderT + "            " + myreaderK);
                }
                catch
                {

                }
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
                button2.Enabled = true;
            }
        }

        private void FormMidias_Load(object sender, EventArgs e)
        {
            string pathFind = @"bin\whatsapp-media-decrypt";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            webBrowser1.Navigate(@fullPathFind);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.python.org/");
        }
    }
}
