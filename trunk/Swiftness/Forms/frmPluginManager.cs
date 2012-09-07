using System;
using System.Windows.Forms;
using Swiftness.Controls;

namespace Swiftness.Forms
{
    public partial class frmPluginManager : MDIChild
    {
        public frmPluginManager(Form myparent) : base (myparent)
        {
            InitializeComponent();
        }

        private void btn_UpdatePluginList_Click(object sender, EventArgs e)
        {
            flp_plugincontainer.Controls.Clear();

            PluginSystem.Core.RefreshPluginlist();

            foreach (PluginSystem.Plugin plugin in PluginSystem.Core.Plugins)
            {
                flp_plugincontainer.Controls.Add(plugin.Control);
            }
        }
    }
}
