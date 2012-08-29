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
            flp_plugincontainer.Controls.Clear();

            PluginSystem.Core.RefreshPluginlist();

            foreach (PluginSystem.Plugin plugin in PluginSystem.Core.Plugins)
            {
                ctrlPlugin ctrl = new ctrlPlugin(plugin.PluginInfo, plugin.Enable, plugin.Disable, plugin.Load, plugin.Unload);

                flp_plugincontainer.Controls.Add(ctrl);
            }
        }

    }
}
