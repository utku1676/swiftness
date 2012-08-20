using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cpg.Swiftness.Plugin;

namespace cpg.Swiftness.Plugins.TestPlugin
{
    public partial class frmTest : frmPlugin
    {
        public frmTest()
        {
            InitializeComponent();
        }

        public frmTest(Form parent)
            : base(parent)
        { }
    }
}
