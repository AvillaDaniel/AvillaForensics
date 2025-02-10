using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormIPED : Form
    {
        private const string PathAcquisitionFileName = "PathAcquisition.txt";
        private const string IpedExecutable = "iped.exe";
        private const string IpedDirectory = @"IPED-4.1.3_and_plugins\iped-4.1.3";
        private readonly string[] fileFilters = { "*.tar", "*.zip", "*.dd", "*.ufdr" };

        public FormIPED()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButtonArquivo.Checked)
            {
                OpenFileDialogWithInitialDirectory();
            }
            else
            {
                SelectSourceFolder();
            }
        }

        private void OpenFileDialogWithInitialDirectory()
        {
            string initialDirectory = GetInitialDirectory();
            if (string.IsNullOrEmpty(initialDirectory))
            {
                MessageBox.Show("Could not retrieve the initial directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select file";
                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.Filter = $"Files ({string.Join(", ", fileFilters)})|{string.Join(";", fileFilters)}|All files (*.*)|*.*";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.ReadOnlyChecked = true;
                openFileDialog.ShowReadOnly = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    UpdateSelectedFile(openFileDialog.FileName);
                }
            }
        }

        private string GetInitialDirectory()
        {
            string fullPathTEMP = Path.GetFullPath("temp");
            string filePath = Path.Combine(fullPathTEMP, PathAcquisitionFileName);

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    return reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the initial directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void UpdateSelectedFile(string fileName)
        {
            textBox3.Text = fileName;
            textBox1.Text += $"\r
>> Origin:  {fileName}";
            button4.Enabled = true;
        }

        private void SelectSourceFolder()
        {
            using (var folderBrowserDialog = new FolderBrowserDialog { Description = "Choose source folder" })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    UpdateSelectedFolder(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void UpdateSelectedFolder(string folderPath)
        {
            textBox3.Text = folderPath;
            textBox1.Text += $"\r
>> Origin: {folderPath}";
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog { Description = "Choose destination folder" })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    ipedtextbox.Text = folderBrowserDialog.SelectedPath;
                    textBox1.Text += $"\r
>> Destiny: {ipedtextbox.Text}";
                    webBrowser1.Navigate(folderBrowserDialog.SelectedPath);
                    button3.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This process may take some time, please wait", "Attention!");
            textBox1.Text += "\r
>> IPED indexing started.";
            button3.Text = "Wait...";
            SetControlsEnabled(false);

            backgroundWorker3.RunWorkerAsync();
            pictureBox2.Visible = true;
        }

        private void SetControlsEnabled(bool isEnabled)
        {
            button3.Enabled = isEnabled;
            button4.Enabled = isEnabled;
            button10.Enabled = isEnabled;
            panel3.Enabled = isEnabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectSourceFolder();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                StartIpedProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during IPED execution: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartIpedProcess()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(textBox2.Text, IpedExecutable),
                Arguments = $" -d \"{textBox3.Text}\" -o \"{ipedtextbox.Text}\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            using (var process = new Process { StartInfo = startInfo })
            {
                process.Start();
                process.StandardOutput.ReadToEnd();
            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox2.Visible = false;
            SetControlsEnabled(true);

            textBox1.Text += "\r
>> Generated Indexer.";
            button3.Text = "Generate";

            textBox3.Clear();
            ipedtextbox.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://www.java.com/pt-BR/download/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl("https://github.com/sepinf-inc/IPED");
        }

        private void OpenUrl(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void FormIPED_Load(object sender, EventArgs e)
        {
            string fullPath = Path.GetFullPath(IpedDirectory);
            textBox2.Text = fullPath;
        }
    }
}
