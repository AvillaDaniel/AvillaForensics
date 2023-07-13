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
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Analisador_Arquivos_DEIC_SBC
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label5.Text = "";
            label6.Text = "";
        }

        public class contador //Variável Pública
        {
            public static int ContMiniaturas = 0;
            public static int ContPagMiniaturas = 1;
            public static int ContPagTotal = 0;
        }

        public class GerarKML //Variável Pública
        {
            public static string PathCaminho = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog backupfolder = new FolderBrowserDialog();
            backupfolder.Description = "Choose source folder";
            if (backupfolder.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = backupfolder.SelectedPath;
                button3.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com.br/maps/place/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            contador.ContMiniaturas = 0;
            contador.ContPagMiniaturas = 1;
            contador.ContPagTotal = 0;
            listBox1.Items.Clear();
            listView1.Items.Clear(); 
            imageList1.Images.Clear();
            textBox1.Text = "";
            label1.Text = "";
            label5.Text = "";
            label6.Text = "";
            TXTMeta.Text = "";
            Txthash256.Text = "";
            Txthashmd5.Text = "";
            button8.Enabled = true;
            button10.Enabled = true;
            webBrowser2.Navigate("about:blank");

            DirectoryInfo Dir = new DirectoryInfo(@textBox2.Text);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*."+ comboBox1.Text, SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                listBox1.Items.Add(File.FullName);
            }
            int quantidade = listBox1.Items.Count;
            label1.Text = Convert.ToString(quantidade) + " files ." + comboBox1.Text;
            contador.ContPagTotal = quantidade / 100;

            if (checkBoxMiniaturas.Checked)
            {
                //Carregar Miniaturas
                int contar = 0;

                if (quantidade > 100)
                {
                    button4.Enabled = true;
                    while (contar < 100)
                    {
                        try
                        {
                            imageList1.Images.Add(Image.FromFile(listBox1.Items[contar].ToString()));
                            listView1.Items.Add(listBox1.Items[contar].ToString(), contar);
                            contar++;
                        }
                        catch
                        {
                            imageList1.Images.Add(Image.FromFile(fullPathBin + "\\erro.jpg"));
                            listView1.Items.Add(listBox1.Items[contar].ToString(), contar);
                            contar++;
                        }
                    }
                }
                else
                {
                    button4.Enabled = false;
                    contador.ContPagTotal = 1;

                    while (contar < quantidade)
                    {
                        try
                        {
                            imageList1.Images.Add(Image.FromFile(listBox1.Items[contar].ToString()));
                            listView1.Items.Add(listBox1.Items[contar].ToString(), contar);
                            contar++;
                        }
                        catch
                        {
                            imageList1.Images.Add(Image.FromFile(fullPathBin + "\\erro.jpg"));
                            listView1.Items.Add(listBox1.Items[contar].ToString(), contar);
                            contar++;
                        }
                    }
                }
                label6.Text = "Page " + Convert.ToString(contador.ContPagMiniaturas) + " in " + contador.ContPagTotal;
                label5.Text = Convert.ToString(listView1.Items.Count) + " Loaded Thumbnails";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXTMeta.Text = "";
            TxtGEO.Text = "";
            webBrowser1.Navigate("https://www.google.com.br/maps/place/");

            String navegar = listBox1.Text;
            textBox1.Text = navegar;
            webBrowser2.Navigate(navegar);
            Txthashmd5.Text = BytesToString(GetHashMD5(textBox1.Text));
            Txthash256.Text = BytesToString(GetHashSha256(textBox1.Text));

            string pathBin = @"bin\";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            if (checkBoxMeta.Checked)
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPathBin + "\\exiftool.exe";
                startInfo3.Arguments = " \"" + textBox1.Text + "\"";
                process3.StartInfo = startInfo3;
                process3.Start();
                TXTMeta.Text = process3.StandardOutput.ReadToEnd();
                process3.Close();
            }

            if (checkBoxGEO.Checked)
            {
                string pathFind = @"find";
                string fullPathFind;
                fullPathFind = Path.GetFullPath(pathFind);

                StreamWriter EscreverTXT1 = new StreamWriter(@fullPathFind + "\\GEOLOC.TXT");
                EscreverTXT1.WriteLine($" ");
                EscreverTXT1.Close();

                StreamWriter EscreverTXT3 = new StreamWriter(@fullPathFind + "\\GEO.bat");
                EscreverTXT3.WriteLine($" ");
                EscreverTXT3.Close();

                StreamWriter EscreverTXT2 = new StreamWriter(@fullPathFind + "\\GEO.bat");
                EscreverTXT2.WriteLine($"{fullPathBin}\\exiftool.exe \"{textBox1.Text}\" | {fullPathBin}\\grep.exe \"GPS Position\" > {fullPathFind}\\GEOLOC.txt");
                EscreverTXT2.Close();

                Process process4 = new Process();
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.RedirectStandardOutput = true;
                startInfo4.FileName = @fullPathFind + "\\GEO.bat";
                process4.StartInfo = startInfo4;
                process4.Start();
                process4.StandardOutput.ReadToEnd();
                process4.Close();

                System.IO.StreamReader file = new System.IO.StreamReader(@fullPathFind + "\\GEOLOC.txt");
                TxtGEO.Text = file.ReadLine();
                file.Close();

                try
                {
                    String str = TxtGEO.Text;
                    StringBuilder sb = new StringBuilder(str);
                    TxtGEO.Text = sb.Replace("deg", " ° ").ToString();
                    TxtGEO.Text = sb.Replace(',', '+').ToString();
                    TxtGEO.Text = sb.Replace(" ", "").ToString();

                    string[] dadosGeo = TxtGEO.Text.Split(':');
                    TxtGEO.Text = dadosGeo[1];

                    //GPS Position
                    webBrowser1.Navigate("https://www.google.com.br/maps/place/" + TxtGEO.Text);
                }
                catch
                {

                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXTMeta.Text = "";
            TxtGEO.Text = "";
            webBrowser1.Navigate("https://www.google.com.br/maps/place/");

            String navegar = listView1.Items[listView1.FocusedItem.Index].Text;
            textBox1.Text = navegar;
            webBrowser2.Navigate(navegar);
            Txthashmd5.Text = BytesToString(GetHashMD5(textBox1.Text));
            Txthash256.Text = BytesToString(GetHashSha256(textBox1.Text));

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            if (checkBoxMeta.Checked)
            {
                Process process3 = new Process();
                ProcessStartInfo startInfo3 = new ProcessStartInfo();
                startInfo3.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo3.CreateNoWindow = true;
                startInfo3.UseShellExecute = false;
                startInfo3.RedirectStandardOutput = true;
                startInfo3.FileName = fullPathBin + "\\exiftool.exe";
                startInfo3.Arguments = " \"" + textBox1.Text + "\"";
                process3.StartInfo = startInfo3;
                process3.Start();
                TXTMeta.Text = process3.StandardOutput.ReadToEnd();
                process3.Close();
            }

            if (checkBoxGEO.Checked)
            {
                string pathFind = @"find";
                string fullPathFind;
                fullPathFind = Path.GetFullPath(pathFind);

                StreamWriter EscreverTXT1 = new StreamWriter(@fullPathFind + "\\GEOLOC.TXT");
                EscreverTXT1.WriteLine($" ");
                EscreverTXT1.Close();

                StreamWriter EscreverTXT3 = new StreamWriter(@fullPathFind + "\\GEO.bat");
                EscreverTXT3.WriteLine($" ");
                EscreverTXT3.Close();

                StreamWriter EscreverTXT2 = new StreamWriter(@fullPathFind + "\\GEO.bat");
                EscreverTXT2.WriteLine($"{fullPathBin}\\exiftool.exe \"{textBox1.Text}\" | {fullPathBin}\\grep.exe \"GPS Position\" > {fullPathFind}\\GEOLOC.txt");
                EscreverTXT2.Close();

                Process process4 = new Process();
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.RedirectStandardOutput = true;
                startInfo4.FileName = @fullPathFind + "\\GEO.bat";
                process4.StartInfo = startInfo4;
                process4.Start();
                process4.StandardOutput.ReadToEnd();
                process4.Close();

                System.IO.StreamReader file = new System.IO.StreamReader(@fullPathFind + "\\GEOLOC.txt");
                TxtGEO.Text = file.ReadLine();
                file.Close();

                try
                {
                    String str = TxtGEO.Text;
                    StringBuilder sb = new StringBuilder(str);
                    TxtGEO.Text = sb.Replace("deg", " ° ").ToString();
                    TxtGEO.Text = sb.Replace(',', '+').ToString();
                    TxtGEO.Text = sb.Replace(" ", "").ToString();

                    string[] dadosGeo = TxtGEO.Text.Split(':');
                    TxtGEO.Text = dadosGeo[1];

                    //GPS Position
                    webBrowser1.Navigate("https://www.google.com.br/maps/place/" + TxtGEO.Text);
                }
                catch
                {

                }
            }
        }

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

        private void button4_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            contador.ContPagMiniaturas = contador.ContPagMiniaturas + 1;
            label6.Text = "Página " + Convert.ToString(contador.ContPagMiniaturas) + " de " + contador.ContPagTotal;

            listView1.Items.Clear();
            imageList1.Images.Clear();
            label5.Text = "";
            button5.Enabled = true;

            contador.ContMiniaturas = contador.ContMiniaturas + 100;

            int contar = contador.ContMiniaturas;
            int contar2 = 0;

            while (contar < contador.ContMiniaturas + 100)
            {
                try
                {
                    imageList1.Images.Add(Image.FromFile(listBox1.Items[contar].ToString()));
                    listView1.Items.Add(listBox1.Items[contar].ToString(), contar2);
                    contar++;
                    contar2++;
                }
                catch
                {
                    imageList1.Images.Add(Image.FromFile(fullPathBin + "\\erro.jpg"));
                    listView1.Items.Add(listBox1.Items[contar].ToString(), contar2);
                    contar++;
                    contar2++;
                }

            }
            label5.Text = Convert.ToString(listView1.Items.Count) + " Loaded Thumbnails";

            if (contador.ContPagTotal == contador.ContPagMiniaturas)
            {
                button4.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            //string FILEIMG = "file:";
            //string FILEIMGBarra = "///";

            string GEO = "";

            string GEO1 = "";
            decimal GEO1C = 0;
            string GEO1Cartesiano = "";

            string GEOh1 = "";
            decimal GEOh1C = 0;

            string GEOm1 = "";
            decimal GEOm1C = 0;

            string GEOs1 = "";
            decimal GEOs1C = 0;

            string GEO2 = "";
            decimal GEO2C = 0;
            string GEO2Cartesiano = "";

            string GEOh2 = "";
            decimal GEOh2C = 0;

            string GEOm2 = "";
            decimal GEOm2C = 0;

            string GEOs2 = "";
            decimal GEOs2C = 0;

            int i = 0;

            StreamWriter EscreverTXT1 = new StreamWriter(GerarKML.PathCaminho + "\\geo.kml");
            EscreverTXT1.WriteLine($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            EscreverTXT1.WriteLine($"<kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\" xmlns:kml=\"http://www.opengis.net/kml/2.2\" xmlns:atom=\"http://www.w3.org/2005/Atom\">");
            EscreverTXT1.WriteLine($"<Document>");
            EscreverTXT1.WriteLine($"	<name>KML</name>");
            EscreverTXT1.WriteLine($"	<description>teste</description>");
            EscreverTXT1.WriteLine($"	<gx:CascadingStyle kml:id=\"__managed_style_219E1D031B2130BFE25C\">");
            EscreverTXT1.WriteLine($"		<Style>");
            EscreverTXT1.WriteLine($"			<IconStyle>");
            EscreverTXT1.WriteLine($"				<scale>1.2</scale>");
            EscreverTXT1.WriteLine($"				<Icon>");
            EscreverTXT1.WriteLine($"					<href>https://earth.google.com/earth/rpc/cc/icon?color=1976d2&amp;id=2000&amp;scale=4</href>");
            EscreverTXT1.WriteLine($"				</Icon>");
            EscreverTXT1.WriteLine($"				<hotSpot x=\"64\" y=\"128\" xunits=\"pixels\" yunits=\"insetPixels\"/>");
            EscreverTXT1.WriteLine($"			</IconStyle>");
            EscreverTXT1.WriteLine($"			<LabelStyle>");
            EscreverTXT1.WriteLine($"			</LabelStyle>");
            EscreverTXT1.WriteLine($"			<LineStyle>");
            EscreverTXT1.WriteLine($"				<color>ff2dc0fb</color>");
            EscreverTXT1.WriteLine($"				<width>4.8</width>");
            EscreverTXT1.WriteLine($"			</LineStyle>");
            EscreverTXT1.WriteLine($"			<PolyStyle>");
            EscreverTXT1.WriteLine($"				<color>40ffffff</color>");
            EscreverTXT1.WriteLine($"			</PolyStyle>");
            EscreverTXT1.WriteLine($"			<BalloonStyle>");
            EscreverTXT1.WriteLine($"				<displayMode>hide</displayMode>");
            EscreverTXT1.WriteLine($"			</BalloonStyle>");
            EscreverTXT1.WriteLine($"		</Style>");
            EscreverTXT1.WriteLine($"	</gx:CascadingStyle>");
            EscreverTXT1.WriteLine($"	<gx:CascadingStyle kml:id=\"__managed_style_12770A89432130BFE25C\">");
            EscreverTXT1.WriteLine($"		<Style>");
            EscreverTXT1.WriteLine($"			<IconStyle>");
            EscreverTXT1.WriteLine($"				<Icon>");
            EscreverTXT1.WriteLine($"					<href>https://earth.google.com/earth/rpc/cc/icon?color=1976d2&amp;id=2000&amp;scale=4</href>");
            EscreverTXT1.WriteLine($"				</Icon>");
            EscreverTXT1.WriteLine($"				<hotSpot x=\"64\" y=\"128\" xunits=\"pixels\" yunits=\"insetPixels\"/>");
            EscreverTXT1.WriteLine($"			</IconStyle>");
            EscreverTXT1.WriteLine($"			<LabelStyle>");
            EscreverTXT1.WriteLine($"			</LabelStyle>");
            EscreverTXT1.WriteLine($"			<LineStyle>");
            EscreverTXT1.WriteLine($"				<color>ff2dc0fb</color>");
            EscreverTXT1.WriteLine($"				<width>3.2</width>");
            EscreverTXT1.WriteLine($"			</LineStyle>");
            EscreverTXT1.WriteLine($"			<PolyStyle>");
            EscreverTXT1.WriteLine($"				<color>40ffffff</color>");
            EscreverTXT1.WriteLine($"			</PolyStyle>");
            EscreverTXT1.WriteLine($"			<BalloonStyle>");
            EscreverTXT1.WriteLine($"				<displayMode>hide</displayMode>");
            EscreverTXT1.WriteLine($"			</BalloonStyle>");
            EscreverTXT1.WriteLine($"		</Style>");
            EscreverTXT1.WriteLine($"	</gx:CascadingStyle>");
            EscreverTXT1.WriteLine($"	<StyleMap id=\"__managed_style_0A83665B4B2130BFE25C\">");
            EscreverTXT1.WriteLine($"		<Pair>");
            EscreverTXT1.WriteLine($"			<key>normal</key>");
            EscreverTXT1.WriteLine($"			<styleUrl>#__managed_style_12770A89432130BFE25C</styleUrl>");
            EscreverTXT1.WriteLine($"		</Pair>");
            EscreverTXT1.WriteLine($"		<Pair>");
            EscreverTXT1.WriteLine($"			<key>highlight</key>");
            EscreverTXT1.WriteLine($"			<styleUrl>#__managed_style_219E1D031B2130BFE25C</styleUrl>");
            EscreverTXT1.WriteLine($"		</Pair>");
            EscreverTXT1.WriteLine($"	</StyleMap>");
            foreach (string Items in listBox1.Items)
            {

                StreamWriter EscreverTXT4 = new StreamWriter(@fullPathFind + "\\GEOLOC.TXT");
                EscreverTXT4.WriteLine($" ");
                EscreverTXT4.Close();

                StreamWriter EscreverTXT3 = new StreamWriter(@fullPathFind + "\\GEO.bat");
                EscreverTXT3.WriteLine($" ");
                EscreverTXT3.Close();

                StreamWriter EscreverTXT2 = new StreamWriter(@fullPathFind + "\\GEO.bat");
                EscreverTXT2.WriteLine($"{fullPathBin}\\exiftool.exe \"{Items}\" | {fullPathBin}\\grep.exe \"GPS Position\" > {fullPathFind}\\GEOLOC.txt");
                EscreverTXT2.Close();

                Process process4 = new Process();
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.RedirectStandardOutput = true;
                startInfo4.FileName = @fullPathFind + "\\GEO.bat";
                process4.StartInfo = startInfo4;
                process4.Start();
                process4.StandardOutput.ReadToEnd();
                process4.Close();

                System.IO.StreamReader file = new System.IO.StreamReader(@fullPathFind + "\\GEOLOC.txt");
                GEO = file.ReadLine();
                file.Close();

                try
                {
                    String str = GEO;
                    StringBuilder sb = new StringBuilder(str);
                    GEO = sb.Replace("deg", " ° ").ToString();
                    GEO = sb.Replace(',', '+').ToString();
                    GEO = sb.Replace(" ", "").ToString();

                    string[] dadosGeo = GEO.Split(':');
                    GEO = dadosGeo[1];

                    //Inicio conversão DMS para Coordenada : EX: 23°41'56.98"S+46°33'8.02"W                    
                    string[] dadosGeo2 = GEO.Split('+');
                    GEO1 = dadosGeo2[0]; //23°41'56.98"S
                    GEO2 = dadosGeo2[1]; //46°33'8.02"W

                    //INICIO GEO1: 23°41'56.98"S 
                    string[] dadosGeo3 = GEO1.Split('°');
                    GEOh1 = dadosGeo3[0]; //23
                    //dadosGeo3[1] = 41'56.98"S 

                    string[] dadosGeo4 = dadosGeo3[1].Split('\'');
                    GEOm1 = dadosGeo4[0]; //41
                    //dadosGeo4[1] = 56.98"S

                    string[] dadosGeo5 = dadosGeo4[1].Split('\"');
                    GEOs1 = dadosGeo5[0].Replace(".", ","); //56.98
                    //dadosGeo5[1] = S
                    if (dadosGeo5[1] == "S")
                    {
                        GEO1Cartesiano = "-";
                    }
                    else
                    {
                        GEO1Cartesiano = "";
                    }
                    //FIM GEO1

                    //INICIO GEO2: 46°33'8.02"W
                    string[] dadosGeo6 = GEO2.Split('°');
                    GEOh2 = dadosGeo6[0]; //46
                    //dadosGeo6[1] = 33'8.02"W

                    string[] dadosGeo7 = dadosGeo6[1].Split('\'');
                    GEOm2 = dadosGeo7[0]; //33
                    //dadosGeo7[1] = 8.02"W

                    string[] dadosGeo8 = dadosGeo7[1].Split('\"');
                    GEOs2 = dadosGeo8[0].Replace(".", ","); //8.02
                    //dadosGeo8[1] = W
                    if (dadosGeo8[1] == "W")
                    {
                        GEO2Cartesiano = "-";
                    }
                    else
                    {
                        GEO2Cartesiano = "";
                    }
                    //FIM GEO2

                    GEOh1C = Convert.ToDecimal(GEOh1);
                    GEOm1C = Convert.ToDecimal(GEOm1) / 60;
                    GEOs1C = Convert.ToDecimal(GEOs1) / 3600;

                    GEOh2C = Convert.ToDecimal(GEOh2);
                    GEOm2C = Convert.ToDecimal(GEOm2) / 60;
                    GEOs2C = Convert.ToDecimal(GEOs2) / 3600;

                    GEO1C = GEOh1C + (GEOm1C + GEOs1C);
                    GEO2C = GEOh2C + (GEOm2C + GEOs2C);

                    GEO1 = GEO1C.ToString().Replace(",", ".");
                    GEO2 = GEO2C.ToString().Replace(",", ".");

                    ////FIM conversão DMS para Coordenada : EX: 23°41'56.98"S+46°33'8.02"W                  

                }
                catch
                {

                }

                if (GEO1 != "" & GEO1 != "0.00")
                {
                    if (GEO2 != "" & GEO2 != "0.00")
                    {
                        String strP = Items;
                        String ItemsP;
                        StringBuilder sbP = new StringBuilder(strP);
                        ItemsP = sbP.Replace(@textBox2.Text, ".").ToString();

                        //Inicio Point
                        EscreverTXT1.WriteLine($"	<Placemark id=\"05FE04E26E2130BFE25B{i++}\">");
                        EscreverTXT1.WriteLine($"		<name>{ItemsP}</name>");
                        EscreverTXT1.WriteLine($"		<description><![CDATA[<img style=\"max-width:500px;\" src=\"{ItemsP}\">]]></description>");
                        EscreverTXT1.WriteLine($"		<styleUrl>#__managed_style_0A83665B4B2130BFE25C</styleUrl>");
                        EscreverTXT1.WriteLine($"		<Point>");
                        EscreverTXT1.WriteLine($"			<coordinates>{GEO2Cartesiano}{GEO2},{GEO1Cartesiano}{GEO1}</coordinates>");
                        EscreverTXT1.WriteLine($"		</Point>");
                        EscreverTXT1.WriteLine($"	</Placemark>");
                        //Fim Point
                    }
                }
            }
            EscreverTXT1.WriteLine($"</Document>");
            EscreverTXT1.WriteLine($"</kml>");
            EscreverTXT1.Close();            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();
            panelProcesso.Visible = false;
            MessageBox.Show(".KML file generated in: " + GerarKML.PathCaminho + "\\geo.kml", "Generated file");
            tabControl1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            contador.ContPagMiniaturas = contador.ContPagMiniaturas - 1;
            label6.Text = "Página " + Convert.ToString(contador.ContPagMiniaturas) + " de " + contador.ContPagTotal;

            listView1.Items.Clear();
            imageList1.Images.Clear();
            label5.Text = "";

            button4.Enabled = true;

            contador.ContMiniaturas = contador.ContMiniaturas - 100;

            int contar = contador.ContMiniaturas;
            int contar2 = 0;

            while (contar < contador.ContMiniaturas + 100)
            {
                try
                {
                    imageList1.Images.Add(Image.FromFile(listBox1.Items[contar].ToString()));
                    listView1.Items.Add(listBox1.Items[contar].ToString(), contar2);
                    contar++;
                    contar2++;
                }
                catch
                {
                    imageList1.Images.Add(Image.FromFile(fullPathBin + "\\erro.jpg"));
                    listView1.Items.Add(listBox1.Items[contar].ToString(), contar2);
                    contar++;
                    contar2++;
                }

            }
            label5.Text = Convert.ToString(listView1.Items.Count) + " Loaded Thumbnails";

            if (contador.ContPagMiniaturas == 1)
            {
                button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Width = 1000;
            webBrowser2.Width = 870;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://earth.google.com/web/search/" + TxtGEO.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GerarKML.PathCaminho = textBox2.Text;
            tabControl1.Enabled = false;
            panelProcesso.Visible = true;
            timer1.Start();
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 100)
            {
                progressBar1.Value = 0;
            }
            progressBar1.Value += 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //string line;

            //System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Coletas-DEIC-2\Poco\Coleta\jpg.txt");

            //while ((line = file.ReadLine()) != null)
            //{
            //    listBox1.Items.Add(line);
            //}
            //file.Close();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            string pathBin = @"bin";
            string fullPathBin;
            fullPathBin = Path.GetFullPath(pathBin);

            string GEO = "";

            string GEO1 = "";
            decimal GEO1C = 0;
            string GEO1Cartesiano = "";

            string GEOh1 = "";
            decimal GEOh1C = 0;

            string GEOm1 = "";
            decimal GEOm1C = 0;

            string GEOs1 = "";
            decimal GEOs1C = 0;

            string GEO2 = "";
            decimal GEO2C = 0;
            string GEO2Cartesiano = "";

            string GEOh2 = "";
            decimal GEOh2C = 0;

            string GEOm2 = "";
            decimal GEOm2C = 0;

            string GEOs2 = "";
            decimal GEOs2C = 0;

            StreamWriter EscreverTXT1 = new StreamWriter(GerarKML.PathCaminho + "\\geoIMG.html");
            EscreverTXT1.WriteLine($"<html lang=\"pt-BR\">");
            EscreverTXT1.WriteLine($"	<head>");
            EscreverTXT1.WriteLine($"		<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<script src=\"https://code.jquery.com/jquery-3.2.1.min.js\"></script>");
            EscreverTXT1.WriteLine($"		<link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65\" crossorigin=\"anonymous\">");
            EscreverTXT1.WriteLine($"		<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4\" crossorigin=\"anonymous\"></script>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<link rel=\"stylesheet\" href=\"https://unpkg.com/leaflet@1.9.3/dist/leaflet.css\" integrity=\"sha256-kLaT2GOSpHechhsozzB+flnD+zUyjE2LlfWPgU04xyI=\" crossorigin=\"\" />");
            EscreverTXT1.WriteLine($"		<script src=\"https://unpkg.com/leaflet@1.9.3/dist/leaflet.js\" integrity=\"sha256-WBkoXOwTeyKclOHuWtc+i2uENFpDZ9YPdf5Hf+D7ewM=\" crossorigin=\"\"></script>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<script src=\"http://jieter.github.io/Leaflet-semicircle/Semicircle.js\"></script>");
            EscreverTXT1.WriteLine($"		<script src=\"https://dgoguerra.github.io/bootstrap-menu/dist/BootstrapMenu.min.js\"></script>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<link href='https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.css' rel='stylesheet' />");
            EscreverTXT1.WriteLine($"		<script src='https://cdn.jsdelivr.net/npm/fullcalendar@5.11.3/main.min.js'></script>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<style>");
            EscreverTXT1.WriteLine($"			.Originada {{");
            EscreverTXT1.WriteLine($"				color: #7FFF00 !important;");
            EscreverTXT1.WriteLine($"			}}");
            EscreverTXT1.WriteLine($"			.Recebida {{");
            EscreverTXT1.WriteLine($"				color: #DC143C !important;");
            EscreverTXT1.WriteLine($"			}}");
            EscreverTXT1.WriteLine($"			* {{");
            EscreverTXT1.WriteLine($"				margin: 0px;");
            EscreverTXT1.WriteLine($"				padding: 0px;");
            EscreverTXT1.WriteLine($"			}}");
            EscreverTXT1.WriteLine($"		</style>");
            EscreverTXT1.WriteLine($"	</head>");
            EscreverTXT1.WriteLine($"    <body>");
            EscreverTXT1.WriteLine($"		<div class=\"m-0\">");
            EscreverTXT1.WriteLine($"			<div class=\"tab-content\" id=\"mapa\">");
            EscreverTXT1.WriteLine($"				<div id=\"map\" class=\"vh-100 w-100\"></div>");
            EscreverTXT1.WriteLine($"			</div>	");
            EscreverTXT1.WriteLine($"		</div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"		<script type=\"text/javascript\" src=\"http://leaflet.github.io/Leaflet.heat/dist/leaflet-heat.js\"></script>");
            EscreverTXT1.WriteLine($"		<script type=\"text/javascript\">");
            EscreverTXT1.WriteLine($"			markers = [");
            EscreverTXT1.WriteLine($"");

            StreamWriter EscreverTXT5 = new StreamWriter(@fullPathFind + "\\GEOLOG.TXT"); //Guarda as coordenadas

            foreach (string Items in listBox1.Items)
            {

                StreamWriter EscreverTXT4 = new StreamWriter(@fullPathFind + "\\GEOLOCJPG.TXT");
                EscreverTXT4.WriteLine($" ");
                EscreverTXT4.Close();

                StreamWriter EscreverTXT3 = new StreamWriter(@fullPathFind + "\\GEOJPG.bat");
                EscreverTXT3.WriteLine($" ");
                EscreverTXT3.Close();

                StreamWriter EscreverTXT2 = new StreamWriter(@fullPathFind + "\\GEOJPG.bat");
                EscreverTXT2.WriteLine($"{fullPathBin}\\exiftool.exe \"{Items}\" | {fullPathBin}\\grep.exe \"GPS Position\" > {fullPathFind}\\GEOLOCJPG.txt");
                EscreverTXT2.Close();

                Process process4 = new Process();
                ProcessStartInfo startInfo4 = new ProcessStartInfo();
                startInfo4.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo4.CreateNoWindow = true;
                startInfo4.UseShellExecute = false;
                startInfo4.RedirectStandardOutput = true;
                startInfo4.FileName = @fullPathFind + "\\GEOJPG.bat";
                process4.StartInfo = startInfo4;
                process4.Start();
                process4.StandardOutput.ReadToEnd();
                process4.Close();

                System.IO.StreamReader file = new System.IO.StreamReader(@fullPathFind + "\\GEOLOCJPG.txt");
                GEO = file.ReadLine();
                file.Close();

                try
                {
                    String str = GEO;
                    StringBuilder sb = new StringBuilder(str);
                    GEO = sb.Replace("deg", " ° ").ToString();
                    GEO = sb.Replace(',', '+').ToString();
                    GEO = sb.Replace(" ", "").ToString();

                    string[] dadosGeo = GEO.Split(':');
                    GEO = dadosGeo[1];

                    //Inicio conversão DMS para Coordenada : EX: 23°41'56.98"S+46°33'8.02"W                    
                    string[] dadosGeo2 = GEO.Split('+');
                    GEO1 = dadosGeo2[0]; //23°41'56.98"S
                    GEO2 = dadosGeo2[1]; //46°33'8.02"W

                    //INICIO GEO1: 23°41'56.98"S 
                    string[] dadosGeo3 = GEO1.Split('°');
                    GEOh1 = dadosGeo3[0]; //23
                    //dadosGeo3[1] = 41'56.98"S 

                    string[] dadosGeo4 = dadosGeo3[1].Split('\'');
                    GEOm1 = dadosGeo4[0]; //41
                    //dadosGeo4[1] = 56.98"S

                    string[] dadosGeo5 = dadosGeo4[1].Split('\"');
                    GEOs1 = dadosGeo5[0].Replace(".", ","); //56.98
                    //dadosGeo5[1] = S
                    if (dadosGeo5[1] == "S")
                    {
                        GEO1Cartesiano = "-";
                    }
                    else
                    {
                        GEO1Cartesiano = "";
                    }
                    //FIM GEO1

                    //INICIO GEO2: 46°33'8.02"W
                    string[] dadosGeo6 = GEO2.Split('°');
                    GEOh2 = dadosGeo6[0]; //46
                    //dadosGeo6[1] = 33'8.02"W

                    string[] dadosGeo7 = dadosGeo6[1].Split('\'');
                    GEOm2 = dadosGeo7[0]; //33
                    //dadosGeo7[1] = 8.02"W

                    string[] dadosGeo8 = dadosGeo7[1].Split('\"');
                    GEOs2 = dadosGeo8[0].Replace(".", ","); //8.02
                    //dadosGeo8[1] = W
                    if (dadosGeo8[1] == "W")
                    {
                        GEO2Cartesiano = "-";
                    }
                    else
                    {
                        GEO2Cartesiano = "";
                    }
                    //FIM GEO2

                    GEOh1C = Convert.ToDecimal(GEOh1);
                    GEOm1C = Convert.ToDecimal(GEOm1) / 60;
                    GEOs1C = Convert.ToDecimal(GEOs1) / 3600;

                    GEOh2C = Convert.ToDecimal(GEOh2);
                    GEOm2C = Convert.ToDecimal(GEOm2) / 60;
                    GEOs2C = Convert.ToDecimal(GEOs2) / 3600;

                    GEO1C = GEOh1C + (GEOm1C + GEOs1C);
                    GEO2C = GEOh2C + (GEOm2C + GEOs2C);

                    GEO1 = GEO1C.ToString().Replace(",", ".");
                    GEO2 = GEO2C.ToString().Replace(",", ".");

                    ////FIM conversão DMS para Coordenada : EX: 23°41'56.98"S+46°33'8.02"W                  

                }
                catch
                {

                }

                if (GEO1 != "" & GEO1 != "0.00")
                {
                    if (GEO2 != "" & GEO2 != "0.00")
                    {
                        String strP = Items;
                        String ItemsP;
                        StringBuilder sbP = new StringBuilder(strP);
                        ItemsP = sbP.Replace(@textBox2.Text, ".\\").ToString();

                        //Inicio Point
                        EscreverTXT1.WriteLine($"			{{'data': '0', 'hora': '0', 'posicao_alvo': '{GEO1Cartesiano}{GEO1} {GEO2Cartesiano}{GEO2}', 'latitude': '{GEO1Cartesiano}{GEO1}', 'longitude': '{GEO2Cartesiano}{GEO2}', 'label': '<img style=\"max-width:80px;\" src=\"{ItemsP}\"> <a href =\"{ItemsP}\" target=\"_blank\">{ItemsP}</a>'}},");
                        //Fim Point   
                        EscreverTXT5.WriteLine($"{GEO1Cartesiano}{GEO1},{GEO2Cartesiano}{GEO2}");
                    }
                }
            }

            EscreverTXT5.Close(); //Fecha o txt que guarda as coodernadas

            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			]");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			const map = L.map('map').setView([markers[0].latitude, markers[0].longitude], 8);");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			const tiles = L.tileLayer('https://tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{");
            EscreverTXT1.WriteLine($"				maxZoom: 19,");
            EscreverTXT1.WriteLine($"				attribution: '&copy; <a href=\"http://www.openstreetmap.org/copyright\">OpenStreetMap</a>'");
            EscreverTXT1.WriteLine($"			}}).addTo(map);");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			googleStreets = L.tileLayer('http://{{s}}.google.com/vt/lyrs=m&x={{x}}&y={{y}}&z={{z}}',{{");
            EscreverTXT1.WriteLine($"				maxZoom: 20,");
            EscreverTXT1.WriteLine($"				subdomains:['mt0','mt1','mt2','mt3']");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			googleSat = L.tileLayer('http://{{s}}.google.com/vt/lyrs=s&x={{x}}&y={{y}}&z={{z}}',{{");
            EscreverTXT1.WriteLine($"				maxZoom: 20,");
            EscreverTXT1.WriteLine($"				subdomains:['mt0','mt1','mt2','mt3']");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			const baseLayers = {{");
            EscreverTXT1.WriteLine($"				'Padrão': tiles,");
            EscreverTXT1.WriteLine($"				'Google': googleStreets,");
            EscreverTXT1.WriteLine($"				'Satelite': googleSat");
            EscreverTXT1.WriteLine($"			}};");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			const alvo = L.layerGroup();");
            EscreverTXT1.WriteLine($"			const interlocutor = L.layerGroup();");
            EscreverTXT1.WriteLine($"			const meuspontos = L.layerGroup();");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			var heat = L.heatLayer([");
            EscreverTXT1.WriteLine($"");

            string line;
            System.IO.StreamReader file2 = new System.IO.StreamReader(@fullPathFind + "\\GEOLOG.TXT");
            while ((line = file2.ReadLine()) != null)
            {
                //Inicio Point
                EscreverTXT1.WriteLine($"			[{line}, 0.5],");
                //Fim Point
            }
            file2.Close();

            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			],{{radius: 100}}).addTo(map);");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			const overlays = {{");
            EscreverTXT1.WriteLine($"				'Alvo': alvo,");
            EscreverTXT1.WriteLine($"				'Interlocutor': interlocutor,");
            EscreverTXT1.WriteLine($"				'Meus pontos': meuspontos,");
            EscreverTXT1.WriteLine($"				'Heatmap': heat");
            EscreverTXT1.WriteLine($"			}};");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			var greenIcon = new L.Icon({{iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-green.png'}}),");
            EscreverTXT1.WriteLine($"				redIcon = new L.Icon({{iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-red.png'}}),");
            EscreverTXT1.WriteLine($"				orangeIcon = new L.Icon({{iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-orange.png'}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			const layerControl = L.control.layers(baseLayers, overlays).addTo(map);");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			for (var i in markers) {{");
            EscreverTXT1.WriteLine($"				var latlng = L.latLng({{ lat: markers[i].latitude, lng: markers[i].longitude }});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				m = L.marker(latlng).addTo(map).bindPopup('Ordem: ' + markers[i].label + '<br>Data: ' + markers[i].data + '<br>Hora: ' + markers[i].hora + '<br>Prosicao: ' + markers[i].posicao_alvo + '<br>Azimute: ' + markers[i].azimute).bindTooltip(markers[i].label, {{permanent: true}});");
            EscreverTXT1.WriteLine($"				sc = L.semiCircle([markers[i].latitude, markers[i].longitude], {{radius: 5000}})");
            EscreverTXT1.WriteLine($"					.setDirection(parseInt(markers[i].azimute), 120)");
            EscreverTXT1.WriteLine($"					.addTo(map);");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				if(markers[i].posicao == 'alvo') {{");
            EscreverTXT1.WriteLine($"					m.addTo(alvo);");
            EscreverTXT1.WriteLine($"					sc.addTo(alvo);");
            EscreverTXT1.WriteLine($"				}} else {{");
            EscreverTXT1.WriteLine($"					m.addTo(interlocutor).setIcon(greenIcon);");
            EscreverTXT1.WriteLine($"					sc.addTo(interlocutor);");
            EscreverTXT1.WriteLine($"				}}");
            EscreverTXT1.WriteLine($"			}}");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			$('.tab-content').hide();");
            EscreverTXT1.WriteLine($"			$('#mapa').show();");
            EscreverTXT1.WriteLine($"			$('.tab-btn').click(function () {{");
            EscreverTXT1.WriteLine($"				$('.tab-content').hide();");
            EscreverTXT1.WriteLine($"				$($(this).attr('tabcontent')).show();");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			$('#addPontoDeInteresse').click(function() {{");
            EscreverTXT1.WriteLine($"				figureIcon.options.iconUrl = 'https://icons.getbootstrap.com/assets/icons/' + $(\"input[name='radio']:checked\").val() + '.svg';");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				m = L.marker([$('#latitude').val(), $('#longitude').val()], {{draggable:'true'}})");
            EscreverTXT1.WriteLine($"						.addTo(map)");
            EscreverTXT1.WriteLine($"						.setIcon(figureIcon)");
            EscreverTXT1.WriteLine($"						.addTo(meuspontos)");
            EscreverTXT1.WriteLine($"						.bindTooltip($('#titulo').val(), {{permanent: true}})");
            EscreverTXT1.WriteLine($"				m.on('dragend', function(event){{");
            EscreverTXT1.WriteLine($"					var marker = event.target;");
            EscreverTXT1.WriteLine($"					var position = marker.getLatLng();");
            EscreverTXT1.WriteLine($"					marker.setLatLng(new L.LatLng(position.lat, position.lng));");
            EscreverTXT1.WriteLine($"				}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				var timestamp = new Date().getTime();");
            EscreverTXT1.WriteLine($"				m._id = timestamp;");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				$('#id').val(m._id);");
            EscreverTXT1.WriteLine($"				$('.btn-group-vertical').append(");
            EscreverTXT1.WriteLine($"					\"<button class='btn btn-outline-secondary bg-white' data-bs-toggle='modal' data-bs-target='#modalPOI' onclick='fillModal(this);' data-id='\" + timestamp + \"' data-latitude='\" + $('#latitude').val() + \"' data-longitude='\" + $('#longitude').val() + \"'>\" + $('#titulo').val() + \"</button>\"");
            EscreverTXT1.WriteLine($"				);");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				clearModal();");
            EscreverTXT1.WriteLine($"				$('#closeModal').trigger('click');");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			function clearModal() {{");
            EscreverTXT1.WriteLine($"				$('#titulo, #latitude, #longitude').val(\"\");");
            EscreverTXT1.WriteLine($"				$('#removerPontoDeInteresse').hide();");
            EscreverTXT1.WriteLine($"			}}");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			function fillModal(m) {{");
            EscreverTXT1.WriteLine($"				$('#id').val($(m).data('id'));");
            EscreverTXT1.WriteLine($"				$('#titulo').val($(m).html());");
            EscreverTXT1.WriteLine($"				$('#latitude').val($(m).data('latitude'));");
            EscreverTXT1.WriteLine($"				$('#longitude').val($(m).data('longitude'));");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"				$('#removerPontoDeInteresse').show();");
            EscreverTXT1.WriteLine($"			}}");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			$('#removerPontoDeInteresse').click(function() {{");
            EscreverTXT1.WriteLine($"				id = $('#id').val();");
            EscreverTXT1.WriteLine($"				map.eachLayer(function(layer) {{");
            EscreverTXT1.WriteLine($"					if(layer._id == id) {{");
            EscreverTXT1.WriteLine($"						map.removeLayer(layer);");
            EscreverTXT1.WriteLine($"						$('button[data-id=\"' + id + '\"]').remove();");
            EscreverTXT1.WriteLine($"					}}");
            EscreverTXT1.WriteLine($"				}});");
            EscreverTXT1.WriteLine($"				$('#closeModal').trigger('click');");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			map.on('dblclick', function(e) {{");
            EscreverTXT1.WriteLine($"				$('#btnModalPOI').trigger('click');");
            EscreverTXT1.WriteLine($"				$('#latitude').val(e.latlng.lat);");
            EscreverTXT1.WriteLine($"				$('#longitude').val(e.latlng.lng);");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			map.on('dblclick', function(e) {{");
            EscreverTXT1.WriteLine($"				$('#btnModalPOI').trigger('click');");
            EscreverTXT1.WriteLine($"				$('#latitude').val(e.latlng.lat);");
            EscreverTXT1.WriteLine($"				$('#longitude').val(e.latlng.lng);");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"			var calendarEl = document.getElementById('calendar');");
            EscreverTXT1.WriteLine($"			var calendar = new FullCalendar.Calendar(calendarEl, {{");
            EscreverTXT1.WriteLine($"				initialView: 'dayGridMonth',");
            EscreverTXT1.WriteLine($"				initialDate: '2022-12-07',");
            EscreverTXT1.WriteLine($"				headerToolbar: {{");
            EscreverTXT1.WriteLine($"					left: 'prev,next today',");
            EscreverTXT1.WriteLine($"					center: 'title',");
            EscreverTXT1.WriteLine($"					right: 'dayGridMonth,timeGridWeek,timeGridDay'");
            EscreverTXT1.WriteLine($"				}},");
            EscreverTXT1.WriteLine($"			}});");
            EscreverTXT1.WriteLine($"			calendar.render();");
            EscreverTXT1.WriteLine($"		</script>");
            EscreverTXT1.WriteLine($"	</body>");
            EscreverTXT1.WriteLine($"</html>");
            EscreverTXT1.Close();     
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GerarKML.PathCaminho = textBox2.Text;
            tabControl1.Enabled = false;
            panelProcesso.Visible = true;
            timer1.Start();
            backgroundWorker2.RunWorkerAsync();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer1.Stop();
            panelProcesso.Visible = false;
            MessageBox.Show(".HTML file generated in: " + GerarKML.PathCaminho + "\\geoIMG.html", "Generated file");
            tabControl1.Enabled = true;

            System.Diagnostics.Process.Start(GerarKML.PathCaminho + "\\geoIMG.html");
        }
    }
     
}
