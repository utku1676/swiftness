using System;
using System.Security.Policy;
using System.Reflection;
using System.IO;
using cpg.Swiftness.Plugin;


namespace cpg.Swiftness.PluginSystem
{
    class Plugin
    {
        #region Privates
        AppDomain _appDomain;       // AppDomain holding the plugin-assembly
        IPlugin _instance;          // Instance of the plugin-interface
        PluginInfo _pluginInfo;     // Holds information about the plugin (Name, Version, Author, etc)
        frmPlugin _pluginForm;       // MdiChild-Form of the plugin
        FileInfo _fileInfo;         // FileInfo of the Plugin-File

        bool _loaded = false;
        bool _enabled = false;
        bool _autoEnable = false;
        #endregion

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

            Load();
            
            if (_autoEnable)
                Enable();

        }

        #region Properties
        public string Name
        {
            get
            {
                return _pluginInfo.PluginName;
            }
        }

        public Version Version
        {
            get
            {
                return _pluginInfo.PluginVersion;
            }
        }

        public string Description
        {
            get
            {
                return _pluginInfo.PluginDesc;
            }
        }

        public string Author
        {
            get
            {
                return _pluginInfo.PluginAuthor;
            }
        }

        public string URL
        {
            get
            {
                return _pluginInfo.PluginURL;
            }
        }

        public string FileName
        {
            get
            {
                return _fileInfo.Name;
            }
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

                // Get ClassName (set by AppDomainInitializer in Func: "InitializerFunc")
                string PluginType = (string)_appDomain.GetData("PluginName");
                string FormType = (string)_appDomain.GetData("FormName");

                // Create instance of Plugin-Interface
                //_instance = (IPlugin)_appDomain.CreateInstanceFromAndUnwrap(_fileInfo.FullName, PluginType);
                _instance = (IPlugin)_appDomain.CreateInstanceFromAndUnwrap(_fileInfo.FullName, PluginType, false, BindingFlags.Default, null, null, null, null, null);
                //_pluginForm = (frmPlugin)_appDomain.CreateInstanceFromAndUnwrap(_fileInfo.FullName, FormType, false, BindingFlags.Default, null, null, null, null, null);
                
                // Get PluginInfo
                _pluginInfo = _instance.pluginInfo;

            //}
            //catch (Exception ex)
            //{
            //    throw new PluginLoaderException("Failed to load plugin", ex);
            //}

            _loaded = true;
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
            _loaded = true;

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
            param.mdiParent = Program.mainForm;

            _instance.Initalize(param);

            _enabled = true;
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



            _enabled = false;
        }


        private static void InitializerFunc(string[] args)
        {
            // Get instance of actual appdomain (Your new AppDomain)
            AppDomain mydom = AppDomain.CurrentDomain;

            Console.WriteLine(mydom.FriendlyName);

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
                    continue;
                }

                //// Check if Form
                //if (type.BaseType == typeof(frmPlugin))
                //{
                //    // save name of class
                //    mydom.SetData("FormName", type.FullName);
                //    continue;
                //}

            }
        }

    }
}
