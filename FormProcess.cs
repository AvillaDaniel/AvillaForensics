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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormProcess : Form
    {
        public FormProcess()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderImagens = new FolderBrowserDialog();
            FolderImagens.Description = "Choose source directory";
            if (FolderImagens.ShowDialog() == DialogResult.OK)
            {
                TxtDiretorio.Text = FolderImagens.SelectedPath;
                webBrowser1.Navigate(TxtDiretorio.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            pictureBox2.Visible = true;

            string folder = @TxtDiretorio.Text + "\\Process";
            //Se o diretório não existir..
            if (!Directory.Exists(folder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(folder);
            } 

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroundWorkerJPG_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathTemp = @"temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            string pathTempP = TxtDiretorio.Text + "\\Process";
            string fullPathTempP;
            fullPathTempP = Path.GetFullPath(pathTempP);

            StreamWriter EscreverTXT1 = new StreamWriter(@TxtDiretorio.Text + "\\Avilla-Report.htm");
            EscreverTXT1.WriteLine($"<!doctype html>");
            EscreverTXT1.WriteLine($"<html lang=\"pt-BR\">");
            EscreverTXT1.WriteLine($"    <head> ");
            EscreverTXT1.WriteLine($"		<meta charset=\"utf-8\">");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"        <title>Avilla Process - {textBoxTitle.Text}</title>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"        <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We\" crossorigin=\"anonymous\">");
            EscreverTXT1.WriteLine($"        <link href=\"https://getbootstrap.com/docs/5.1/examples/sidebars/sidebars.css\" rel=\"stylesheet\">");
            EscreverTXT1.WriteLine($"        <script src=\"https://kit.fontawesome.com/1cca76fcc8.js\" crossorigin=\"anonymous\"></script>");
            EscreverTXT1.WriteLine($"    </head>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"    <body>");
            EscreverTXT1.WriteLine($"        <main>");
            EscreverTXT1.WriteLine($"            <div class=\"row\" style=\"width:100% !important; overflow: auto;\">");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                <div class=\"d-flex flex-column flex-shrink-0 p-3 text-white bg-dark col\" style=\"width: 280px; height: 100vh; position: fixed; overflow-y: auto\">");
            EscreverTXT1.WriteLine($"                    <div class=\"mb-3 mb-md-0 me-md-auto text-white text-decoration-none align-items-center col-12\" align=\"center\">");
            EscreverTXT1.WriteLine($"                        <img src=\".\\Process\\logo.png\" height=100 class=\"d-none-logo\"><br>");
            EscreverTXT1.WriteLine($"                        <div class=\"fs-4\">");
            EscreverTXT1.WriteLine($"                            <br><small>{textBoxTitle.Text}</small>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"                    </div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"					<hr>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                   <ul class=\"nav nav-pills flex-column mb-auto\">");
            EscreverTXT1.WriteLine($"");  
            EscreverTXT1.WriteLine($"						<li class=\"nav-item\">");
            EscreverTXT1.WriteLine($"                            <a href=\"#\" class=\"nav-link active\" id=\"summary-tab\" data-bs-toggle=\"tab\" data-bs-target=\"#summary\" role=\"tab\" aria-controls=\"summary\" aria-selected=\"true\">");
            EscreverTXT1.WriteLine($"                                <i class=\"fas fa-home\"></i>");
            EscreverTXT1.WriteLine($"                                Summary");
            EscreverTXT1.WriteLine($"                            </a>");
            EscreverTXT1.WriteLine($"                        </li>  ");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <li>");
            EscreverTXT1.WriteLine($"                           <a href=\"#\" class=\"nav-link\" id=\"imagens-jpg-tab\" data-bs-toggle=\"tab\" data-bs-target=\"#imagens-jpg\" role=\"tab\" aria-controls=\"imagens-jpg\" aria-selected=\"true\">");
            EscreverTXT1.WriteLine($"                                <i class=\"fas fa-images\"></i>");
            EscreverTXT1.WriteLine($"                                Images.jpg");
            EscreverTXT1.WriteLine($"                            </a>");
            EscreverTXT1.WriteLine($"                        </li>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <li>");
            EscreverTXT1.WriteLine($"                           <a href=\"#\" class=\"nav-link\" id=\"videos-mp4-tab\" data-bs-toggle=\"tab\" data-bs-target=\"#videos-mp4\" role=\"tab\" aria-controls=\"videos-mp4\" aria-selected=\"true\">");
            EscreverTXT1.WriteLine($"                                <i class=\"fas fa-file-video\"></i>");
            EscreverTXT1.WriteLine($"                                Videos.mp4");
            EscreverTXT1.WriteLine($"                            </a>");
            EscreverTXT1.WriteLine($"                        </li>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <li>");
            EscreverTXT1.WriteLine($"                           <a href=\"#\" class=\"nav-link\" id=\"audios-opus-tab\" data-bs-toggle=\"tab\" data-bs-target=\"#audios-opus\" role=\"tab\" aria-controls=\"audios-opus\" aria-selected=\"true\">");
            EscreverTXT1.WriteLine($"                                <i class=\"fas fa-file-audio\"></i>");
            EscreverTXT1.WriteLine($"                                Audios.opus");
            EscreverTXT1.WriteLine($"                            </a>");
            EscreverTXT1.WriteLine($"                        </li>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <li>");
            EscreverTXT1.WriteLine($"                            <a href=\"#\" class=\"nav-link\" id=\"documentos-pdf-tab\" data-bs-toggle=\"tab\" data-bs-target=\"#documentos-pdf\" role=\"tab\" aria-controls=\"documentos-pdf\" aria-selected=\"true\">");
            EscreverTXT1.WriteLine($"                                <i class=\"fas fa-file-pdf\"></i>");
            EscreverTXT1.WriteLine($"                                Documents.pdf");
            EscreverTXT1.WriteLine($"                            </a>");
            EscreverTXT1.WriteLine($"                        </li>	");
            EscreverTXT1.WriteLine($"");


            ///////////  Lista formatos //////////////////////////////////////////////////
            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(" dir /b " + "\"" + fullPathTempP + "\" > " + fullPathTemp + "\\List-Formats.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            string line2;
            System.IO.StreamReader file2 = new System.IO.StreamReader(fullPathTemp + "\\List-Formats.txt");

            while ((line2 = file2.ReadLine()) != null)
            {
                try 
                {
                    if (line2 == ".jpg") { continue; }
                    if (line2 == ".mp4") { continue; }
                    if (line2 == ".opus") { continue; }
                    if (line2 == ".pdf") { continue; }

                    String str = line2;
                    String lineL;
                    StringBuilder sb = new StringBuilder(str);
                    lineL = sb.Replace(".", "doc-").ToString();

                    EscreverTXT1.WriteLine($"                        <li>");
                    EscreverTXT1.WriteLine($"                           <a href=\"#\" class=\"nav-link\" id=\"{lineL}-tab\" data-bs-toggle=\"tab\" data-bs-target=\"#{lineL}\" role=\"tab\" aria-controls=\"{lineL}\" aria-selected=\"true\">");
                    EscreverTXT1.WriteLine($"                                <i class=\"fas fa-file\"></i>");
                    EscreverTXT1.WriteLine($"                                {line2}");
                    EscreverTXT1.WriteLine($"                            </a>");
                    EscreverTXT1.WriteLine($"                        </li>");
                    EscreverTXT1.WriteLine($"");

                }
                catch { }
            }
            file2.Close();
            ////////////////////////////////////////////////////////////////////////////////
        
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                    </ul>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                    <hr>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                    <div class=\"col-12 ml-2 text-white\" align=\"center\">");
            EscreverTXT1.WriteLine($"                        <small>{DateTime.Now.ToString("dd-MM-yyyy")}</small>");
            EscreverTXT1.WriteLine($"                    </div>");
            EscreverTXT1.WriteLine($"                </div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                <div class=\"tab-content col-lg-10 row\" style=\"margin-left: 280px;\">");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"					<div class=\"tab-pane active p-3\" id=\"summary\" role=\"tabpanel\" aria-labelledby=\"summary-tab\">");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <div class=\"col\">");
            EscreverTXT1.WriteLine($"                                <h1>Summary</h1>");
            EscreverTXT1.WriteLine($"                                <hr>");
            EscreverTXT1.WriteLine($"                            </div>	");
            EscreverTXT1.WriteLine($"                        </div> ");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"						<img src=\".\\Process\\logo.png\" height=150 class=\"d-none-logo\"><br>");
            EscreverTXT1.WriteLine($"						<hr>");
            EscreverTXT1.WriteLine($"						<h4>Case Name: {textBoxCASE.Text}</h4>");
            EscreverTXT1.WriteLine($"						<hr>");
            EscreverTXT1.WriteLine($"						<h4>Computer Expert: {textBoxEXPERT.Text}</h4>");
            EscreverTXT1.WriteLine($"						<hr>");
            EscreverTXT1.WriteLine($"						<h4>Device Owner: {textBoxOWNER.Text}</h4>");
            EscreverTXT1.WriteLine($"						<hr>");
            EscreverTXT1.WriteLine($"						<h4>Device Model: {textBoxMODEL.Text}</h4>");
            EscreverTXT1.WriteLine($"						<hr>");
            EscreverTXT1.WriteLine($"						<h4>Serial Number: {textBoxSN.Text}</h4>");
            EscreverTXT1.WriteLine($"						<hr>");
            EscreverTXT1.WriteLine($"						<h4>System Version: {textBoxVERSION.Text}</h4>");
            EscreverTXT1.WriteLine($"						<hr>			");
            EscreverTXT1.WriteLine($"						<h4>Comments: {textBoxCOMMENTS.Text}</h4>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                    </div>	");
            EscreverTXT1.WriteLine($"");            

            //////////////// JPG ////////////////////////////////////////////////////////////////////

            EscreverTXT1.WriteLine($"                    <div class=\"tab-pane p-3\" id=\"imagens-jpg\" role=\"tabpanel\" aria-labelledby=\"imagens-jpg-tab\">");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <div class=\"col\">");
            EscreverTXT1.WriteLine($"                                <h1>Imagens</h1>");
            EscreverTXT1.WriteLine($"                                <hr>");
            EscreverTXT1.WriteLine($"                            </div>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <table class='table'><thead><tr><th width='50%'>Imagem - JPG </th><th width='25%'><th width='25%'>Hash MD5</th></tr></thead>");
            EscreverTXT1.WriteLine($"								<tbody><tr><td>");
            EscreverTXT1.WriteLine($"");

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTempP + "\\.jpg");

            while ((line = file.ReadLine()) != null)
            {
                try 
                {
                    StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process-JPG.txt");
                    EscreverTXT.WriteLine($"{line}");
                    EscreverTXT.Close();
                    webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process-JPG.txt");

                    String str = line;
                    String lineP;
                    StringBuilder sb = new StringBuilder(str);
                    lineP = sb.Replace(@TxtDiretorio.Text, ".").ToString();

                    EscreverTXT1.WriteLine($"                              <a href='{lineP}' target='_blank'><img src='{lineP}' height=\"150\">{lineP}</a></td><td></td><td>{BytesToString(GetHashMD5(line))}</td></tr><tr><td>");
                }
                catch { }
            }
            file.Close();

            EscreverTXT1.WriteLine($"								</tbody>");
            EscreverTXT1.WriteLine($"							</table>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"                    </div>");
            EscreverTXT1.WriteLine($"");
            /////////////////////////////////////////////////////////////////////////////////////////

            //////////////// MP4 ////////////////////////////////////////////////////////////////////
            
            EscreverTXT1.WriteLine($"                    <div class=\"tab-pane p-3\" id=\"videos-mp4\" role=\"tabpanel\" aria-labelledby=\"videos-mp4-tab\">");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <div class=\"col\">");
            EscreverTXT1.WriteLine($"                                <h1>Videos</h1>");
            EscreverTXT1.WriteLine($"                                <hr>");
            EscreverTXT1.WriteLine($"                            </div>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <table class='table'><thead><tr><th width='50%'>Video - MP4</th><th width='25%'><th width='25%'>Hash MD5</th></tr></thead>");
            EscreverTXT1.WriteLine($"								<tbody><tr><td>	");
            EscreverTXT1.WriteLine($"");

            string lineMP4;
            System.IO.StreamReader fileMP4 = new System.IO.StreamReader(fullPathTempP + "\\.mp4");

            while ((lineMP4 = fileMP4.ReadLine()) != null)
            {
                try
                {
                    StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process-JPG.txt");
                    EscreverTXT.WriteLine($"{lineMP4}");
                    EscreverTXT.Close();
                    webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process-JPG.txt");

                    String str = lineMP4;
                    String lineP;
                    StringBuilder sb = new StringBuilder(str);
                    lineP = sb.Replace(@TxtDiretorio.Text, ".").ToString();

                    EscreverTXT1.WriteLine($"									<video width ='320' height='240' controls><source src='{lineP}' type='video/mp4'></video><br><a href ='{lineP}' target='_blank'>{lineP}</a></td><td>{lineP}</td><td>{BytesToString(GetHashMD5(lineMP4))}</td></tr><tr><td>");
                    //EscreverTXT1.WriteLine($"                              <a href='{lineP}' target='_blank'><img src='{lineP}' height=\"150\"></a></td><td></td><td>{BytesToString(GetHashMD5(lineMP4))}</td></tr><tr><td>");
                }
                catch { }
            }
            fileMP4.Close();

            EscreverTXT1.WriteLine($"								</tbody>");
            EscreverTXT1.WriteLine($"							</table>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"                    </div>");
            EscreverTXT1.WriteLine($"");

            /////////////////////////////////////////////////////////////////////////////////////////

            //////////////// AUDIOS ////////////////////////////////////////////////////////////////////

            EscreverTXT1.WriteLine($"                    <div class=\"tab-pane p-3\" id=\"audios-opus\" role=\"tabpanel\" aria-labelledby=\"audios-opus-tab\">");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <div class=\"col\">");
            EscreverTXT1.WriteLine($"                                <h1>Audios</h1>");
            EscreverTXT1.WriteLine($"                                <hr>");
            EscreverTXT1.WriteLine($"                            </div>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <table class='table'><thead><tr><th width='50%'>Audio - OPUS</th><th width='25%'><th width='25%'>Hash MD5</th></tr></thead>");
            EscreverTXT1.WriteLine($"								<tbody><tr><td>	");
            EscreverTXT1.WriteLine($"");

            string lineOPUS;
            System.IO.StreamReader fileOPUS = new System.IO.StreamReader(fullPathTempP + "\\.opus");

            while ((lineOPUS = fileOPUS.ReadLine()) != null)
            {
                try
                {
                    StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process-JPG.txt");
                    EscreverTXT.WriteLine($"{lineOPUS}");
                    EscreverTXT.Close();
                    webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process-JPG.txt");

                    String str = lineOPUS;
                    String lineP;
                    StringBuilder sb = new StringBuilder(str);
                    lineP = sb.Replace(@TxtDiretorio.Text, ".").ToString();

                    EscreverTXT1.WriteLine($"									<audio controls><source src='{lineP}' type='audio/ogg'></audio><br><a href ='{lineP}' target='_blank'>{lineP}</a></td><td></td><td>{BytesToString(GetHashMD5(lineOPUS))}</td></tr><tr><td>");   
                }
                catch { }
            }
            fileOPUS.Close();

            EscreverTXT1.WriteLine($"								</tbody>");
            EscreverTXT1.WriteLine($"							</table>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"                    </div>");
            EscreverTXT1.WriteLine($"");

            /////////////////////////////////////////////////////////////////////////////////////////

            //////////////// Documentos-PDF  ///////////////////////////////////////////////////////

            EscreverTXT1.WriteLine($"                    <div class=\"tab-pane p-3\" id=\"documentos-pdf\" role=\"tabpanel\" aria-labelledby=\"documentos-pdf-tab\">");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <div class=\"col\">");
            EscreverTXT1.WriteLine($"                                <h1>DOCUMENTOS-PDF</h1>");
            EscreverTXT1.WriteLine($"                                <hr>");
            EscreverTXT1.WriteLine($"                            </div>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                        <div class=\"row\">");
            EscreverTXT1.WriteLine($"                            <table class='table'><thead><tr><th width='50%'>Audio - OPUS</th><th width='25%'><th width='25%'>Hash MD5</th></tr></thead>");
            EscreverTXT1.WriteLine($"								<tbody><tr><td>	");
            EscreverTXT1.WriteLine($"");

            string linePDF;
            System.IO.StreamReader filePDF = new System.IO.StreamReader(fullPathTempP + "\\.pdf");

            while ((linePDF = filePDF.ReadLine()) != null)
            {
                try
                {
                    StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process-JPG.txt");
                    EscreverTXT.WriteLine($"{linePDF}");
                    EscreverTXT.Close();
                    webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process-JPG.txt");

                    String str = linePDF;
                    String lineP;
                    StringBuilder sb = new StringBuilder(str);
                    lineP = sb.Replace(@TxtDiretorio.Text, ".").ToString();

                    EscreverTXT1.WriteLine($"									<a href ='{lineP}' target='_blank'>{lineP}</a></td><td></td><td>{BytesToString(GetHashMD5(linePDF))}</td></tr><tr><td>");
                }
                catch { }
            }
            filePDF.Close();

            EscreverTXT1.WriteLine($"								</tbody>");
            EscreverTXT1.WriteLine($"							</table>");
            EscreverTXT1.WriteLine($"                        </div>");
            EscreverTXT1.WriteLine($"                    </div>");
            EscreverTXT1.WriteLine($"");

            /////////////////////////////////////////////////////////////////////////////////////////

            //////////////// Documentos  ////////////////////////////////////////////////////////////
            string line3;
            System.IO.StreamReader file3 = new System.IO.StreamReader(fullPathTemp + "\\List-Formats.txt");

            while ((line3 = file3.ReadLine()) != null)
            {  
                try 
                {
                    if (line3 == ".jpg") { continue; }
                    if (line3 == ".mp4") { continue; }
                    if (line3 == ".opus") { continue; }
                    if (line3 == ".pdf") { continue; }

                    String str2 = line3;
                    String lineL;
                    StringBuilder sb2 = new StringBuilder(str2);
                    lineL = sb2.Replace(".", "doc-").ToString();

                    EscreverTXT1.WriteLine($"                    <div class=\"tab-pane p-3\" id=\"{lineL}\" role=\"tabpanel\" aria-labelledby=\"{lineL}-tab\">");
                    EscreverTXT1.WriteLine($"                        <div class=\"row\">");
                    EscreverTXT1.WriteLine($"                            <div class=\"col\">");
                    EscreverTXT1.WriteLine($"                                <h1>{line3}</h1>");
                    EscreverTXT1.WriteLine($"                                <hr>");
                    EscreverTXT1.WriteLine($"                            </div>");
                    EscreverTXT1.WriteLine($"                        </div>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"                        <div class=\"row\">");
                    EscreverTXT1.WriteLine($"                            <table class='table'><thead><tr><th width='50%'>{line3}</th><th width='25%'><th width='25%'>Hash MD5</th></tr></thead>");
                    EscreverTXT1.WriteLine($"								<tbody><tr><td>");

                    string line4;
                    System.IO.StreamReader file4 = new System.IO.StreamReader(fullPathTempP + "\\" + line3);

                    while ((line4 = file4.ReadLine()) != null)
                    {
                        try
                        {
                            StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process-JPG.txt");
                            EscreverTXT.WriteLine($"{line4}");
                            EscreverTXT.Close();
                            webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process-JPG.txt");

                            String str = line4;
                            String lineP;
                            StringBuilder sb = new StringBuilder(str);
                            lineP = sb.Replace(@TxtDiretorio.Text, ".").ToString();

                            EscreverTXT1.WriteLine($"									<a href ='{lineP}' target='_blank'>{lineP}</a></td><td></td><td>{BytesToString(GetHashMD5(line4))}</td></tr><tr><td>");
                        }
                        catch { }
                    }
                    file.Close();

                    EscreverTXT1.WriteLine($"								</tbody>");
                    EscreverTXT1.WriteLine($"							</table>");
                    EscreverTXT1.WriteLine($"                        </div>");
                    EscreverTXT1.WriteLine($"                    </div>");
                    EscreverTXT1.WriteLine($"");

                }
                catch { }  
            }
            file3.Close();
            /////////////////////////////////////////////////////////////////////////////////////////


            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"                </div>");
            EscreverTXT1.WriteLine($"            </div>");
            EscreverTXT1.WriteLine($"        </main>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"        <script src=\"https://code.jquery.com/jquery-3.6.0.min.js\"></script>");
            EscreverTXT1.WriteLine($"        <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj\" crossorigin=\"anonymous\"></script>");
            EscreverTXT1.WriteLine($"        <script src=\"https://unpkg.com/leaflet@1.6.0/dist/leaflet.js\"></script>");
            EscreverTXT1.WriteLine($"        <link href=\"https://unpkg.com/leaflet@1.6.0/dist/leaflet.css\" rel=\"stylesheet\"/>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.WriteLine($"    </body>");
            EscreverTXT1.WriteLine($"</html>");
            EscreverTXT1.WriteLine($"");
            EscreverTXT1.Close();
        }

        //######################################################################################
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
        //######################################################################################

        private void backgroundWorkerJPG_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Enabled = true;

            string pathTempP = TxtDiretorio.Text + "\\Process";
            string fullPathTempP;
            fullPathTempP = Path.GetFullPath(pathTempP);

            //Copia Logo.png
            try
            {
                File.Copy(textBoxLogo.Text, @fullPathTempP + "\\logo.png");
            }
            catch { }
            //

            MessageBox.Show("Completed Process", "Attention!");
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            string pathFind = @"find";
            string fullPathFind;
            fullPathFind = Path.GetFullPath(pathFind);

            string pathTemp = @"temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            string pathTempP = TxtDiretorio.Text + "\\Process";
            string fullPathTempP;
            fullPathTempP = Path.GetFullPath(pathTempP);

            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(" dir /s /b /a-d " + "\"" + TxtDiretorio.Text + "\" > " + fullPathFind + "\\AProcess.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(fullPathFind + "\\AProcess.txt");

            while ((line = file.ReadLine()) != null)
            {
                try
                {
                    StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process.txt");
                    EscreverTXT.WriteLine($"{line}");
                    EscreverTXT.Close();
                    webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process.txt");

                    string extensao = Path.GetExtension(line);

                    try
                    {
                        StreamWriter EscreverTXT1 = File.AppendText(fullPathTempP + "\\" + extensao);
                        EscreverTXT1.WriteLine($"{line}");
                        EscreverTXT1.Close();
                    }
                    catch
                    {
                        StreamWriter EscreverTXT1 = File.AppendText(fullPathTempP + "\\" + "noformat");
                        EscreverTXT1.WriteLine($"{line}");
                        EscreverTXT1.Close();
                    }
                }
                catch { }               
            }
            file.Close();
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            if (radioBHTML.Checked)
            {
                backgroundWorkerJPG.RunWorkerAsync();
            }
            else
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void FormProcess_Load(object sender, EventArgs e)
        {
            string pathBIN = @"bin";
            string fullPathBIN;
            fullPathBIN = Path.GetFullPath(pathBIN);

            textBoxLogo.Text = fullPathBIN + "\\logo.png";

            pictureBox1.Image = Image.FromFile(@textBoxLogo.Text);

            string pathTEMP = @"temp";
            string fullPathTEMP;
            fullPathTEMP = Path.GetFullPath(pathTEMP);

            System.IO.StreamReader file = new System.IO.StreamReader(fullPathTEMP + "\\PathAcquisition.txt");
            TxtDiretorio.Text = file.ReadLine();
            file.Close();

            webBrowser1.Navigate(TxtDiretorio.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ofd3.Multiselect = true;
            this.ofd3.Title = "Select File";
            ofd3.InitialDirectory = @"C:\";
            ofd3.Filter = "Files (*.png)|*.png";
            ofd3.CheckFileExists = true;
            ofd3.CheckPathExists = true;
            ofd3.FilterIndex = 2;
            ofd3.RestoreDirectory = true;
            ofd3.ReadOnlyChecked = true;
            ofd3.ShowReadOnly = true;

            DialogResult drIPED2 = this.ofd3.ShowDialog();

            if (drIPED2 == System.Windows.Forms.DialogResult.OK)
            {
                textBoxLogo.Text = ofd3.FileName;
                pictureBox1.Image = Image.FromFile(@ofd3.FileName);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathTemp = @"temp";
            string fullPathTemp;
            fullPathTemp = Path.GetFullPath(pathTemp);

            string pathTempP = TxtDiretorio.Text + "\\Process";
            string fullPathTempP;
            fullPathTempP = Path.GetFullPath(pathTempP);

            ///////////  Lista formatos //////////////////////////////////////////////////
            ProcessStartInfo processStartInfoAPPT = new ProcessStartInfo("cmd.exe");
            processStartInfoAPPT.RedirectStandardInput = true;
            processStartInfoAPPT.RedirectStandardOutput = true;
            processStartInfoAPPT.UseShellExecute = false;
            processStartInfoAPPT.CreateNoWindow = true;
            Process processAPPT = Process.Start(processStartInfoAPPT);
            if (processAPPT != null)
            {
                processAPPT.StandardInput.WriteLine(" dir /b " + "\"" + fullPathTempP + "\" > " + fullPathTemp + "\\List-Formats.txt");
                processAPPT.StandardInput.Close();
                processAPPT.StandardOutput.ReadToEnd();
            }

            string line2;
            System.IO.StreamReader file2 = new System.IO.StreamReader(fullPathTemp + "\\List-Formats.txt");

            while ((line2 = file2.ReadLine()) != null)
            {
                try
                {
                    StreamWriter EscreverTXT1 = new StreamWriter(@TxtDiretorio.Text + "\\" + line2 + ".htm");
                    EscreverTXT1.WriteLine($"<!doctype html>");
                    EscreverTXT1.WriteLine($"<html lang=\"pt-BR\">");
                    EscreverTXT1.WriteLine($"    <head> ");
                    EscreverTXT1.WriteLine($"		<meta charset=\"utf-8\">");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"        <title>Avilla Process - {textBoxTitle.Text}</title>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"        <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-KyZXEAg3QhqLMpG8r+8fhAXLRk2vvoC2f3B09zVXn8CA5QIVfZOJ3BCsw2P0p/We\" crossorigin=\"anonymous\">");
                    EscreverTXT1.WriteLine($"        <link href=\"https://getbootstrap.com/docs/5.1/examples/sidebars/sidebars.css\" rel=\"stylesheet\">");
                    EscreverTXT1.WriteLine($"        <script src=\"https://kit.fontawesome.com/1cca76fcc8.js\" crossorigin=\"anonymous\"></script>");
                    EscreverTXT1.WriteLine($"    </head>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"    <body>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"		<div class=\"tab-pane p-3\" id=\"{line2}\" role=\"tabpanel\" aria-labelledby=\"{line2}-tab\">");
                    EscreverTXT1.WriteLine($"			<div class=\"row\">");
                    EscreverTXT1.WriteLine($"				<div class=\"col\">");
                    EscreverTXT1.WriteLine($"					<h1>{line2}</h1>");
                    EscreverTXT1.WriteLine($"					<hr>");
                    EscreverTXT1.WriteLine($"				</div>");
                    EscreverTXT1.WriteLine($"			</div>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"			<div class=\"row\">");
                    EscreverTXT1.WriteLine($"				<table class='table'><thead><tr><th width='50%'>{line2}</th><th width='25%'><th width='25%'>Hash SHA256</th></tr></thead>");
                    EscreverTXT1.WriteLine($"					<tbody><tr><td>	");
                    EscreverTXT1.WriteLine($"");
                    ///////////////////////////////////////////////////////////////////////////////////

                    string lineDOCS;
                    System.IO.StreamReader fileDOCS = new System.IO.StreamReader(fullPathTempP + "\\" + line2);

                    while ((lineDOCS = fileDOCS.ReadLine()) != null)
                    {
                        try
                        {
                            StreamWriter EscreverTXT = new StreamWriter(fullPathTemp + "\\log-temp-Process-JPG.txt");
                            EscreverTXT.WriteLine($"{lineDOCS}");
                            EscreverTXT.Close();
                            webBrowser2.Navigate(fullPathTemp + "\\log-temp-Process-JPG.txt");

                            String str = lineDOCS;
                            String lineP;
                            StringBuilder sb = new StringBuilder(str);
                            lineP = sb.Replace(@TxtDiretorio.Text, ".").ToString();

                            if (line2 == ".mp4") 
                            {
                                EscreverTXT1.WriteLine($"									<video width ='320' height='240' controls><source src='{lineP}' type='video/mp4'></video><br><a href ='{lineP}' target='_blank'>{lineP}</a></td><td>{lineP}</td><td>{BytesToString(GetHashSha256(lineDOCS))}</td></tr><tr><td>");
                            }
                            else 
                            {
                                if (line2 == ".jpg")
                                {
                                    EscreverTXT1.WriteLine($"                              <a href='{lineP}' target='_blank'><img src='{lineP}' height=\"150\">{lineP}</a></td><td></td><td>{BytesToString(GetHashSha256(lineDOCS))}</td></tr><tr><td>");
                                }
                                else 
                                {
                                    if (line2 == ".opus")
                                    {
                                        EscreverTXT1.WriteLine($"									<audio controls><source src='{lineP}' type='audio/ogg'></audio><br><a href ='{lineP}' target='_blank'>{lineP}</a></td><td></td><td>{BytesToString(GetHashSha256(lineDOCS))}</td></tr><tr><td>");
                                    }
                                    else
                                    {
                                        EscreverTXT1.WriteLine($"									<a href ='{lineP}' target='_blank'>{lineP}</a></td><td></td><td>{BytesToString(GetHashSha256(lineDOCS))}</td></tr><tr><td>");
                                    }
                                }
                            }   
                        }
                        catch { }
                    }
                    fileDOCS.Close();

                    ////////////////////////////////////////////////////////////////////////////////////
                    EscreverTXT1.WriteLine($"					</tbody>");
                    EscreverTXT1.WriteLine($"				</table>");
                    EscreverTXT1.WriteLine($"			</div>");
                    EscreverTXT1.WriteLine($"		</div>");
                    EscreverTXT1.WriteLine($"        <script src=\"https://code.jquery.com/jquery-3.6.0.min.js\"></script>");
                    EscreverTXT1.WriteLine($"        <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.0/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-U1DAWAznBHeqEIlVSCgzq+c9gqGAJn5c/t99JyeKa9xxaYpSvHU5awsuZVVFIhvj\" crossorigin=\"anonymous\"></script>");
                    EscreverTXT1.WriteLine($"        <script src=\"https://unpkg.com/leaflet@1.6.0/dist/leaflet.js\"></script>");
                    EscreverTXT1.WriteLine($"        <link href=\"https://unpkg.com/leaflet@1.6.0/dist/leaflet.css\" rel=\"stylesheet\"/>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.WriteLine($"    </body>");
                    EscreverTXT1.WriteLine($"</html>");
                    EscreverTXT1.WriteLine($"");
                    EscreverTXT1.Close();
                }
                catch { }
            }
            file2.Close();
            ////////////////////////////////////////////////////////////////////////////////
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Enabled = true;

            StreamWriter EscreverTXT1 = new StreamWriter(@TxtDiretorio.Text + "\\case");            
            EscreverTXT1.WriteLine($"{textBoxTitle.Text}");
            EscreverTXT1.WriteLine($"{textBoxCASE.Text}");
            EscreverTXT1.WriteLine($"{textBoxEXPERT.Text}"); 
            EscreverTXT1.WriteLine($"{textBoxOWNER.Text}");
            EscreverTXT1.WriteLine($"{textBoxMODEL.Text}");
            EscreverTXT1.WriteLine($"{textBoxSN.Text}");
            EscreverTXT1.WriteLine($"{textBoxVERSION.Text}");
            EscreverTXT1.WriteLine($"{textBoxCOMMENTS.Text}");
            EscreverTXT1.Close();

            //Copia Logo.png
            try
            {
                File.Copy(textBoxLogo.Text, @TxtDiretorio.Text + "\\logo.png");
            }
            catch { }

            string pathBIN = @"bin\avilla-process";
            string fullPathBIN;
            fullPathBIN = Path.GetFullPath(pathBIN);

            //Copia Avilla-Report.exe
            try
            {
                File.Copy(fullPathBIN + "\\Avilla-Report.exe", @TxtDiretorio.Text + "\\Avilla-Report.exe");
            }
            catch { }    
     
            MessageBox.Show("Completed Process", "Attention!");
        }
    }
}
