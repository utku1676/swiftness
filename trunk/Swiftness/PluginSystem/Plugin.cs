using System;
using System.Security.Policy;
using System.Reflection;
using System.IO;
using Swiftness.Plugin;
using System.Runtime.InteropServices;


namespace Swiftness.PluginSystem
{
    class Plugin
    {
        #region Imports
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        #endregion

        #region Constants
        const int GWL_STYLE = (-16);
        const int WS_CAPTION = 0xC00000;
        const int WS_THICKFRAME = 0x40000;
        const int WS_MAXIMIZE = 0x1000000;
        const int WS_MINIMIZE = 0x20000000;
        const int WS_SYSMENU = 0x80000;


        const short SWP_NOMOVE = 0x2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0x4;
        const int SWP_SHOWWINDOW = 0x0040;

        #endregion

        #region Privates
        AppDomain _appDomain;       // AppDomain holding the plugin-assembly
        IPlugin _instance;          // Instance of the plugin-interface
        PluginInfo _pluginInfo;     // Holds information about the plugin (Name, Version, Author, etc)
        FileInfo _fileInfo;         // FileInfo of the Plugin-File
        Forms.MDIChild _child;      // MDIChild of the Plugin
        Controls.ctrlPlugin _ctrl;  // Control for the Plugin manager

        bool _loaded = false;
        bool _enabled = false;
        bool _autoEnable = false;
        bool _update = false;
        #endregion

        #region Construct
        public Plugin(string assemblyPath)
        {
            _Constructor(assemblyPath, false);
        }

        public Plugin(string assemblyPath, bool autoEnable)
        {
            _Constructor(assemblyPath, autoEnable);
        }

        private void _Constructor(string assemblyPath, bool autoEnable)
        {
            _fileInfo = new FileInfo(assemblyPath);
            _autoEnable = autoEnable;

            _update = true;
            Load();
            _update = false;

            _ctrl = new Controls.ctrlPlugin(_pluginInfo, Enable, Disable, Load, Unload);

            PluginStateChanged += new PluginEventHandler(_ctrl.PluginStateChangedHandler);

            if (_autoEnable)
                Enable();
            else
                Unload();

        }
        #endregion

        #region Events

        public event PluginEventHandler PluginStateChanged;

        private void OnPluginStateChanged(PluginEventArgs args)
        {
            PluginStateChanged(this, args);
        }

        #endregion

        #region Properties
        public PluginInfo PluginInfo
        { get { return _pluginInfo; } }

        public string Name
        {
            get
            {
                return _pluginInfo.Name;
            }
        }

        public Version Version
        {
            get
            {
                return _pluginInfo.Version;
            }
        }

        public string Description
        {
            get
            {
                return _pluginInfo.Desc;
            }
        }

        public string Author
        {
            get
            {
                return _pluginInfo.Author;
            }
        }

        public string URL
        {
            get
            {
                return _pluginInfo.URL;
            }
        }

        public string FileName
        {
            get
            {
                return _fileInfo.Name;
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
        }

        public bool Loaded
        {
            get { return _loaded; }
        }

        #endregion

        /// <summary>
        /// Load the plugin
        /// </summary>
        public void Load()
        {
            // Check if plugin is already loaded
            if (_loaded)
                throw new PluginLoaderException("Load Plugin failed: This plugin is already loaded");

            //try
            //{
            // Create AppDomainSetup-Helper
            System.AppDomainSetup appDomainSetup = new System.AppDomainSetup();

            // Setup initializer
            appDomainSetup.AppDomainInitializer = new AppDomainInitializer(InitializerFunc);

            // Set parameters for initializer
            appDomainSetup.AppDomainInitializerArguments = new string[] { _fileInfo.FullName };

            // Security-Stuff
            Evidence adevidence = System.AppDomain.CurrentDomain.Evidence;

            // Create AppDomain
            _appDomain = System.AppDomain.CreateDomain(_fileInfo.Name, adevidence, appDomainSetup);

            // Setup ExceptionHandler
            _appDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            // Get ClassName (set by AppDomainInitializer in Func: "InitializerFunc")
            string PluginType = (string)_appDomain.GetData("PluginName");

            // Create instance of Plugin-Interface
            //_instance = (IPlugin)_appDomain.CreateInstanceFromAndUnwrap(_fileInfo.FullName, PluginType);
            _instance = (IPlugin)_appDomain.CreateInstanceFromAndUnwrap(_fileInfo.FullName, PluginType, false, BindingFlags.Default, null, null, null, null, null);

            // Get PluginInfo
            _pluginInfo = _instance.pluginInfo;
            //}
            //catch (Exception ex)
            //{
            //    throw new PluginLoaderException("Failed to load plugin", ex);
            //}

            _loaded = true;
            if (!_update) 
                OnPluginStateChanged(new PluginEventArgs(_loaded, _enabled));
        }

        /// <summary>
        /// Unload the plugin
        /// </summary>
        public void Unload()
        {
            // Disable Plugin before unloading it
            if (_enabled)
                Disable();

            try
            {
                // Unload whole AppDomain
                AppDomain.Unload(_appDomain);
            }
            catch (Exception ex)
            {
                throw new PluginLoaderException("Failed to unload plugin", ex);
            }

            // Unload success ...
            _loaded = false;
            if (!_update)
                OnPluginStateChanged(new PluginEventArgs(_loaded, _enabled));

        }

        /// <summary>
        /// Enable the plugin (Register Eventhandlers, etc)
        /// </summary>
        public void Enable()
        {
            if (!_loaded)
                throw new PluginLoaderException("Enable plugin failed: Plugin not loaded");

            if (_enabled)
                throw new PluginLoaderException("Enable plugin failed: Plugin already enabled");

            PluginParams param = new PluginParams();
            
            // Initialze Plugin
            _instance.Initalize(param);

            // Remove border of Pluginform
            int lStyle = GetWindowLong(_instance.Form.Handle, GWL_STYLE);
            lStyle &= ~(WS_CAPTION | WS_THICKFRAME | WS_MINIMIZE | WS_MAXIMIZE | WS_SYSMENU);
            SetWindowLong(_instance.Form.Handle, GWL_STYLE, lStyle);

            // Create MDIChild
            _child = new Swiftness.Forms.MDIChild(Program.mainForm);
            _child.Name = _instance.Form.Name;

            // Resize MDIChild
            _child.Height = _instance.Form.Height + 40;
            _child.Width = _instance.Form.Width + 20;

            // Show MDIChild
            _child.Show();

            // Show Pluginform
            _instance.Form.Show();

            // Parent Pluginform to MDIChild
            SetParent(_instance.Form.Handle, _child.Handle);

            // Move Pluginform to fit into the MDIChild
            SetWindowPos(_instance.Form.Handle, 0, 0, 0, 0, 0, SWP_NOZORDER | SWP_SHOWWINDOW | SWP_NOSIZE);

            _enabled = true;

            if (!_update)
                OnPluginStateChanged(new PluginEventArgs(_loaded, _enabled));
        }

        /// <summary>
        /// Disable the plugin (Unregister Eventhandlers, etc)
        /// </summary>
        public void Disable()
        {
            if (!_loaded)
                throw new PluginLoaderException("Disable plugin failed: Plugin not loaded");

            if (!_enabled)
                throw new PluginLoaderException("Disable plugin failed: Plugin not enabled");

            // Dispose the MDIChild
            _child.Close();
            _child.Dispose();

            // Call Shutdown
            PluginParams param = new PluginParams();
            _instance.Shutdown(param);

            // Plugin is now disabled
            _enabled = false;
            if (!_update)
                OnPluginStateChanged(new PluginEventArgs(_loaded, _enabled));
        }

        /// <summary>
        /// Update the plugin-information (Author, Version, ...)
        /// </summary>
        public void UpdateInfo()
        {
            // Update only if plugin is not loaded and not enabled)
            if (!_loaded && !_enabled)
            {
                _update = true;
                Load();
                UpdateControl();
                Unload();
                _update = false;
            }
        }

        /// <summary>
        /// Returns the Control for this Plugin
        /// </summary>
        public Controls.ctrlPlugin Control
        {
            get
            {
                return _ctrl;
            }
        }

        private static void InitializerFunc(string[] args)
        {
            // Get instance of actual appdomain (Your new AppDomain)
            AppDomain mydom = AppDomain.CurrentDomain;

            // Load Assembly from File
            Assembly asm = Assembly.LoadFrom(args[0]);

            // Check all types in the assembly for the implementation of IPlugin
            foreach (Type type in asm.GetTypes())
            {
                Type typeInterface = type.GetInterface(typeof(IPlugin).ToString(), true);

                // Check if communication-interface
                if (typeInterface != null)
                {
                    // Save name of class
                    mydom.SetData("PluginName", type.FullName);
                    return;
                }
            }
        }

        private void UpdateControl()
        {
            _ctrl.PluginInfo = _pluginInfo;
        }

        private static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
        }
    }
}
