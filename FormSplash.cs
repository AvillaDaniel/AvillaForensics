//                GNU GENERAL PUBLIC LICENSE
//                  Version 3, 29 June 2007 
//Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
//Everyone is permitted to copy and distribute verbatim copies 
//of this license document, but changing it is not allowed.

using System;
using System.Windows.Forms;

namespace Avilla_Forensics
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MDIParent1 mDIParent1 = new MDIParent1();
            timer1.Stop();
            mDIParent1.Show();
            this.Hide();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
