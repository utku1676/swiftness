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
        Plugin.PluginInfo _info;

        //public ctrlPlugin()
        //{
        //    InitializeComponent();
        //}

        public delegate void EnablePlugin();
        public delegate void DisablePlugin();
        public delegate void LoadPlugin();
        public delegate void UnloadPlugin();

        private EnablePlugin _enablefunc;
        private DisablePlugin _disablefunc;
        private LoadPlugin _loadfunc;
        private UnloadPlugin _unloadfunc;


        public ctrlPlugin(Plugin.PluginInfo info, EnablePlugin enablefunc, DisablePlugin disablefunc, LoadPlugin loadfunc, UnloadPlugin unloadfunc)
        {
            InitializeComponent();

            _info = info;

            gb_plugin.Text = _info.Name + " " + _info.Version.ToString();
            lbl_author.Text = _info.Author;
            lbl_desc.Text = _info.Desc;
            lbl_link.Text = _info.URL;

            _enablefunc = enablefunc;
            _disablefunc = disablefunc;
            _loadfunc = loadfunc;
            _unloadfunc = unloadfunc;

        }

        #region Properties
        public string PluginName
        {
            get { return _info.Name; }
        }

        public Version PluginVersion
        {
            get { return _info.Version; }
        }

        public string PluginAuthor
        {
            get { return _info.Author; }
        }

        public string PluginPage
        {
            get { return _info.URL; }            
        }

        public string PluginDescription
        {
            get { return _info.Desc; }
        }
        #endregion

        private void lbl_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(_info.URL);
            }
            catch { }
        }

        private void btn_endisable_Click(object sender, EventArgs e)
        {
            _enablefunc();
        }

        private void btn_loadunload_Click(object sender, EventArgs e)
        {

        }
    }
}
