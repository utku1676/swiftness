using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Swiftness.Forms
{
    public partial class frmLog : MDIChild
    {
        public frmLog(Form parent)
            : base(parent)
        {
            InitializeComponent();
            Log.Setup(this);
        }

        public frmLog(Form parent, bool nohide)
            : base(parent, nohide)
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
