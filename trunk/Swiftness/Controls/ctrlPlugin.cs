using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Swiftness.Controls
{
    public partial class ctrlPlugin : UserControl
    {
        #region Delegates
        public delegate void EnablePlugin();
        public delegate void DisablePlugin();
        public delegate void LoadPlugin();
        public delegate void UnloadPlugin();
        #endregion

        Plugin.PluginInfo _info;

        private EnablePlugin _enablefunc;
        private DisablePlugin _disablefunc;
        private LoadPlugin _loadfunc;
        private UnloadPlugin _unloadfunc;

        private bool _enabled;
        private bool _loaded;


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

        public Plugin.PluginInfo PluginInfo
        {
            get { return _info; }
            set 
            {
                _info = value;
                gb_plugin.Text = _info.Name + " " + _info.Version.ToString();
                lbl_author.Text = _info.Author;
                lbl_desc.Text = _info.Desc;
                lbl_link.Text = _info.URL;
            }
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
            try
            {
                if (_enabled)
                    _disablefunc();
                else
                    _enablefunc();
            }
            catch (PluginSystem.PluginLoaderException plex)
            {
                MessageBox.Show(plex.Message, "PluginLoaderException");
            }
        }

        private void btn_loadunload_Click(object sender, EventArgs e)
        {
            try
            {
                if (_loaded)
                    _unloadfunc();
                else
                    _loadfunc();
            }
            catch (PluginSystem.PluginLoaderException plex)
            {
                MessageBox.Show(plex.Message, "PluginLoaderException");
            }
        }

        public void PluginStateChangedHandler(object sender, PluginSystem.PluginEventArgs args)
        {
            // Update Status
            _enabled = args.Enabled;
            _loaded = args.Loaded;

            // Update Button-Text
            btn_loadunload.Text = (_loaded) ? "Unload" : "Load";
            btn_endisable.Text = (_enabled) ? "Disable" : "Enable";

            // Update Button-Status
            btn_loadunload.Enabled = !_enabled;
            btn_endisable.Enabled = _loaded;

        }
    }
}
