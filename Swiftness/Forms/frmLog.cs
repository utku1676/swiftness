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
    public partial class frmLog : MDIchild
    {
        public frmLog()
        {
            InitializeComponent();
        }

        public frmLog(Form parent) 
            : base(parent)
        {
            InitializeComponent();
            Log.Setup(this);
        }

        public void WriteLog(string message)
        {
            richTextBox1.AppendText(message);
        }
    }
}
