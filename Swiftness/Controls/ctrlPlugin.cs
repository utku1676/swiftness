using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace cpg.Swiftness.Controls
{
    public partial class ctrlPlugin : UserControl
    {
        private string pName = "";
        private string pVersion = "";
        private string pURL = "";

        public ctrlPlugin()
        {
            InitializeComponent();
        }

        public string PluginName
        {
            get { return pName; }
            set 
            {
                pName = value;
                gb_plugin.Text = pName + " " + pVersion;
            }

        }

        public string PluginVersion
        {
            get { return pVersion; }
            set
            {
                pVersion = value;
                gb_plugin.Text = pName + " " + pVersion;
            }
        }

        public string PluginAuthor
        {
            get { return lbl_author.Text; }
            set { lbl_author.Text = value;}
        }

        public string PluginPage
        {
            get { return pURL; }
            set { pURL = value; }
        }

        public string PluginDescription
        {
            get { return lbl_desc.Text; }
            set { lbl_desc.Text = value; }
        }

        private void lbl_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(pURL);
            }
            catch { }
        }
    }
}
