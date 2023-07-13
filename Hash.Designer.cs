
namespace Avilla_Forensics
{
    partial class Hash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hash));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioMD5 = new System.Windows.Forms.RadioButton();
            this.radioSHA512 = new System.Windows.Forms.RadioButton();
            this.radioSHA384 = new System.Windows.Forms.RadioButton();
            this.radioSHA256 = new System.Windows.Forms.RadioButton();
            this.radioSHA1 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(352, 207);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1104, 297);
            this.webBrowser1.TabIndex = 36;
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.Enabled = false;
            this.txtDestino.Location = new System.Drawing.Point(166, 93);
            this.txtDestino.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(914, 22);
            this.txtDestino.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.RoyalBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(18, 88);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 32);
            this.button4.TabIndex = 9;
            this.button4.Text = "Save to:";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtOrigem
            // 
            this.txtOrigem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigem.Enabled = false;
            this.txtOrigem.Location = new System.Drawing.Point(166, 56);
            this.txtOrigem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(914, 22);
            this.txtOrigem.TabIndex = 10;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.RoyalBlue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(18, 51);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(132, 32);
            this.button10.TabIndex = 11;
            this.button10.Text = "Origin folder";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.RoyalBlue;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(948, 128);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 32);
            this.button3.TabIndex = 7;
            this.button3.Text = "Calculate";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(103, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(150, 141);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 35;
            this.pictureBox5.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.radioMD5);
            this.panel3.Controls.Add(this.radioSHA512);
            this.panel3.Controls.Add(this.radioSHA384);
            this.panel3.Controls.Add(this.radioSHA256);
            this.panel3.Controls.Add(this.radioSHA1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button10);
            this.panel3.Controls.Add(this.txtOrigem);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.txtDestino);
            this.panel3.Location = new System.Drawing.Point(352, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1104, 191);
            this.panel3.TabIndex = 35;
            // 
            // radioMD5
            // 
            this.radioMD5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioMD5.AutoSize = true;
            this.radioMD5.Location = new System.Drawing.Point(867, 136);
            this.radioMD5.Name = "radioMD5";
            this.radioMD5.Size = new System.Drawing.Size(58, 21);
            this.radioMD5.TabIndex = 40;
            this.radioMD5.Text = "MD5";
            this.radioMD5.UseVisualStyleBackColor = true;
            this.radioMD5.CheckedChanged += new System.EventHandler(this.radioMD5_CheckedChanged);
            // 
            // radioSHA512
            // 
            this.radioSHA512.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSHA512.AutoSize = true;
            this.radioSHA512.Location = new System.Drawing.Point(780, 136);
            this.radioSHA512.Name = "radioSHA512";
            this.radioSHA512.Size = new System.Drawing.Size(81, 21);
            this.radioSHA512.TabIndex = 39;
            this.radioSHA512.Text = "SHA512";
            this.radioSHA512.UseVisualStyleBackColor = true;
            this.radioSHA512.CheckedChanged += new System.EventHandler(this.radioSHA512_CheckedChanged);
            // 
            // radioSHA384
            // 
            this.radioSHA384.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSHA384.AutoSize = true;
            this.radioSHA384.Location = new System.Drawing.Point(683, 136);
            this.radioSHA384.Name = "radioSHA384";
            this.radioSHA384.Size = new System.Drawing.Size(81, 21);
            this.radioSHA384.TabIndex = 38;
            this.radioSHA384.Text = "SHA384";
            this.radioSHA384.UseVisualStyleBackColor = true;
            this.radioSHA384.CheckedChanged += new System.EventHandler(this.radioSHA384_CheckedChanged);
            // 
            // radioSHA256
            // 
            this.radioSHA256.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSHA256.AutoSize = true;
            this.radioSHA256.Checked = true;
            this.radioSHA256.Location = new System.Drawing.Point(585, 136);
            this.radioSHA256.Name = "radioSHA256";
            this.radioSHA256.Size = new System.Drawing.Size(81, 21);
            this.radioSHA256.TabIndex = 37;
            this.radioSHA256.TabStop = true;
            this.radioSHA256.Text = "SHA256";
            this.radioSHA256.UseVisualStyleBackColor = true;
            this.radioSHA256.CheckedChanged += new System.EventHandler(this.radioSHA256_CheckedChanged);
            // 
            // radioSHA1
            // 
            this.radioSHA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioSHA1.AutoSize = true;
            this.radioSHA1.Location = new System.Drawing.Point(503, 135);
            this.radioSHA1.Name = "radioSHA1";
            this.radioSHA1.Size = new System.Drawing.Size(65, 21);
            this.radioSHA1.TabIndex = 36;
            this.radioSHA1.Text = "SHA1";
            this.radioSHA1.UseVisualStyleBackColor = true;
            this.radioSHA1.CheckedChanged += new System.EventHandler(this.radioSHA1_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Brown;
            this.label9.Location = new System.Drawing.Point(58, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(201, 153);
            this.label9.TabIndex = 41;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser2.Location = new System.Drawing.Point(352, 510);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1104, 206);
            this.webBrowser2.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Location = new System.Drawing.Point(-9, -11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 782);
            this.panel1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(58, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 170);
            this.label1.TabIndex = 42;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(87, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 25);
            this.label14.TabIndex = 20;
            this.label14.Text = "Hash Calculator";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1290, 576);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 123);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 57;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // Hash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1468, 728);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel3);
            this.Name = "Hash";
            this.Text = "Hash Calculator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Hash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.RadioButton radioSHA1;
        private System.Windows.Forms.RadioButton radioSHA512;
        private System.Windows.Forms.RadioButton radioSHA384;
        private System.Windows.Forms.RadioButton radioSHA256;
        private System.Windows.Forms.RadioButton radioMD5;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}