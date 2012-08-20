using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cpg.Swiftness.Forms
{
    public partial class MDIchild : Form
    {
        public MDIchild()
        {
            InitializeComponent();
        }

        public MDIchild(Form parent)
        {
            this.MdiParent = parent;
        }

        private void MDIchild_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if MidForm is closed
            if (e.CloseReason == CloseReason.MdiFormClosing)
                return;

            // If not, just hide the dialog to be able to show it later
            e.Cancel = true;
            this.Hide();
        }

    }
}
