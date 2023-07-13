
namespace Avilla_Forensics
{
    partial class FormAbTar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbTar));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSenha = new System.Windows.Forms.Panel();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtSenha = new System.Windows.Forms.TextBox();
            this.radioButtonSSenha = new System.Windows.Forms.RadioButton();
            this.radioButtonSenha = new System.Windows.Forms.RadioButton();
            this.Txtdestino = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.Txtorigem = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxPATH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panelSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panelSenha);
            this.panel2.Controls.Add(this.radioButtonSSenha);
            this.panel2.Controls.Add(this.radioButtonSenha);
            this.panel2.Controls.Add(this.Txtdestino);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.Txtorigem);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(353, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 202);
            this.panel2.TabIndex = 6;
            // 
            // panelSenha
            // 
            this.panelSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSenha.BackColor = System.Drawing.Color.White;
            this.panelSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSenha.Controls.Add(this.button20);
            this.panelSenha.Controls.Add(this.button19);
            this.panelSenha.Controls.Add(this.label15);
            this.panelSenha.Controls.Add(this.TxtSenha);
            this.panelSenha.Location = new System.Drawing.Point(6, 12);
            this.panelSenha.Name = "panelSenha";
            this.panelSenha.Size = new System.Drawing.Size(1069, 177);
            this.panelSenha.TabIndex = 23;
            this.panelSenha.Visible = false;
            this.panelSenha.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSenha_Paint);
            // 
            // button20
            // 
            this.button20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button20.BackColor = System.Drawing.Color.RoyalBlue;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.ForeColor = System.Drawing.Color.White;
            this.button20.Location = new System.Drawing.Point(893, 54);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(77, 36);
            this.button20.TabIndex = 3;
            this.button20.Text = "Cancel";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button19.BackColor = System.Drawing.Color.RoyalBlue;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.ForeColor = System.Drawing.Color.White;
            this.button19.Location = new System.Drawing.Point(976, 54);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(77, 36);
            this.button19.TabIndex = 2;
            this.button19.Text = "OK";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(266, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "Enter the password set in Backup:";
            // 
            // TxtSenha
            // 
            this.TxtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSenha.Location = new System.Drawing.Point(9, 63);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(878, 22);
            this.TxtSenha.TabIndex = 0;
            // 
            // radioButtonSSenha
            // 
            this.radioButtonSSenha.AutoSize = true;
            this.radioButtonSSenha.Checked = true;
            this.radioButtonSSenha.Location = new System.Drawing.Point(21, 151);
            this.radioButtonSSenha.Name = "radioButtonSSenha";
            this.radioButtonSSenha.Size = new System.Drawing.Size(188, 21);
            this.radioButtonSSenha.TabIndex = 18;
            this.radioButtonSSenha.TabStop = true;
            this.radioButtonSSenha.Text = "Backup without password";
            this.radioButtonSSenha.UseVisualStyleBackColor = true;
            // 
            // radioButtonSenha
            // 
            this.radioButtonSenha.AutoSize = true;
            this.radioButtonSenha.Location = new System.Drawing.Point(230, 151);
            this.radioButtonSenha.Name = "radioButtonSenha";
            this.radioButtonSenha.Size = new System.Drawing.Size(168, 21);
            this.radioButtonSenha.TabIndex = 17;
            this.radioButtonSenha.Text = "Backup with password";
            this.radioButtonSenha.UseVisualStyleBackColor = true;
            // 
            // Txtdestino
            // 
            this.Txtdestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtdestino.Enabled = false;
            this.Txtdestino.Location = new System.Drawing.Point(21, 80);
            this.Txtdestino.Margin = new System.Windows.Forms.Padding(4);
            this.Txtdestino.Name = "Txtdestino";
            this.Txtdestino.Size = new System.Drawing.Size(893, 22);
            this.Txtdestino.TabIndex = 11;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.RoyalBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(933, 41);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(135, 31);
            this.button7.TabIndex = 12;
            this.button7.Text = "Select";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Txtorigem
            // 
            this.Txtorigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtorigem.Enabled = false;
            this.Txtorigem.Location = new System.Drawing.Point(21, 43);
            this.Txtorigem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txtorigem.Name = "Txtorigem";
            this.Txtorigem.Size = new System.Drawing.Size(893, 22);
            this.Txtorigem.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.RoyalBlue;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(933, 80);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(106, 39);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(146, 154);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 30;
            this.pictureBox5.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(44, 343);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(263, 18);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.java.com/pt-BR/download/";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(66, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Requirement: Install Java";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(353, 501);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1082, 202);
            this.webBrowser1.TabIndex = 25;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(353, 216);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1084, 281);
            this.textBox1.TabIndex = 24;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // ofd1
            // 
            this.ofd1.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd1_FileOk);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBoxPATH);
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Location = new System.Drawing.Point(-10, -10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 776);
            this.panel3.TabIndex = 26;
            // 
            // textBoxPATH
            // 
            this.textBoxPATH.Location = new System.Drawing.Point(37, 411);
            this.textBoxPATH.Name = "textBoxPATH";
            this.textBoxPATH.Size = new System.Drawing.Size(263, 22);
            this.textBoxPATH.TabIndex = 32;
            this.textBoxPATH.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(83, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(172, 50);
            this.label14.TabIndex = 20;
            this.label14.Text = "Convert Backup \r\n   .AB to .TAR:";
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1265, 566);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 123);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 53;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // FormAbTar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1443, 715);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Name = "FormAbTar";
            this.Text = "Convert Backup .AB to .TAR:";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAbTar_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelSenha.ResumeLayout(false);
            this.panelSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonSSenha;
        private System.Windows.Forms.RadioButton radioButtonSenha;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txtdestino;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox Txtorigem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelSenha;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtSenha;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxPATH;
    }
}