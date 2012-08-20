using System;
using System.Windows.Forms;
using cpg.Swiftness.Controls;

namespace cpg.Swiftness.Forms
{
    public partial class frmPluginManager : MDIchild
    {
        public frmPluginManager()
        {
            InitializeComponent();
        }

        public frmPluginManager(Form parent) 
            : base(parent)
        {
            InitializeComponent();
        }

        private void btn_UpdatePluginList_Click(object sender, EventArgs e)
        {
            PluginSystem.Plugin plugin = new cpg.Swiftness.PluginSystem.Plugin("Plugins\\TestPlugin.dll", true);

            return;
            
        }

    }
}
