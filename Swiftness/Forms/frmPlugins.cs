using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using cpg.Swiftness.Controls;

namespace cpg.Swiftness.Forms
{
    public partial class frmPlugins : MDIchild
    {
        public frmPlugins()
        {
            InitializeComponent();
        }

        public frmPlugins(Form parent) 
            : base(parent)
        {
            InitializeComponent();
        }

        private void btn_UpdatePluginList_Click(object sender, EventArgs e)
        {
            PluginSystem.Core.RefreshPluginlist();

            flp_plugincontainer.Controls.Clear();

            foreach (PluginSystem.Plugin plugin in PluginSystem.Core.Plugins)
            {
                ctrlPlugin cplugin = new ctrlPlugin();

                cplugin.PluginName = plugin.Name;
                cplugin.PluginVersion = plugin.Version;
                cplugin.PluginDescription = plugin.Desc;
                cplugin.PluginAuthor = plugin.Author;
                cplugin.PluginPage = plugin.URL;

                flp_plugincontainer.Controls.Add(cplugin);
            }
            
        }

    }
}
