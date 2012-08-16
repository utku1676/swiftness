using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using cpg.Swiftness.Plugin;

namespace cpg.Swiftness.PluginSystem
{
    static class Core
    {
        private static List<Plugin> pluginlist = new List<Plugin>();

        /// <summary>
        /// Refresh the whole pluginlist
        /// </summary>
        public static void RefreshPluginlist()
        {
            DirectoryInfo dir = new DirectoryInfo("./Plugins/");
            FileInfo[] files = dir.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                if (pluginExists(file.Name))
                    continue;



                FileVersionInfo version = FileVersionInfo.GetVersionInfo(file.FullName);

                Plugin plugin = new Plugin();

                plugin.Name = version.FileDescription;
                plugin.Version = version.ProductVersion;
                plugin.Desc = version.Comments;
                plugin.Author = version.CompanyName;
                plugin.URL = version.LegalTrademarks;

                plugin.loaded = false;
                plugin.enabled = false;

                plugin.FileName = file.Name;

                pluginlist.Add(plugin);

            }
        }


        private static IPlugin LoadPlugin(string pFileName)
        {
            //Loads an assembly given its file name or path.
            Assembly assembly = Assembly.LoadFrom(pFileName);

            // Search for IPlugin-Class
            foreach (Type type in assembly.GetTypes())
            {
                // Check only public & non-abstract classes
                if (type.IsPublic && !type.IsAbstract) 
                {
                    // Sucht die Schnittstelle mit dem angegebenen Namen. 
                    Type typeInterface = type.GetInterface("cpg.Swiftness.Plugin.IPlugin", true);

                    Console.WriteLine("{0} : {1} : {2} : {3}", type.Name, type.IsPublic, type.IsAbstract, typeInterface.ToString());

                    //Make sure the interface we want to use actually exists
                    if (typeInterface != null)
                    {
                        try
                        {
                            object activedInstance = Activator.CreateInstance(type);

                            if (activedInstance != null)
                            {
                                interfaceinstances.Add(type.Name, activedInstance);
                            }
                        }
                        catch (Exception exception)
                        {
                            System.Diagnostics.Debug.WriteLine(exception);
                        }
                    }

                    typeInterface = null;
                }
            }

            assembly = null;

            return interfaceinstances;
        }

        #region Properties
        public static Plugin[] Plugins
        {
            get
            {
                return pluginlist.ToArray();
            }
        }
        #endregion


        /// <summary>
        /// Returns the Plugin that matches the given filename
        /// </summary>
        /// <param name="fileName">The filename of the plugin</param>
        /// <returns></returns>
        private static Plugin getPluginByFilename(string fileName)
        {
            foreach (Plugin plugin in pluginlist)
            {
                if (plugin.FileName == fileName)
                {
                    return plugin;
                }
            }

            throw new Exception("Plugin was not found");
        }

        /// <summary>
        /// Checks is a plugin exists (by filename)
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool pluginExists(string fileName)
        {
            foreach (Plugin plugin in pluginlist)
            {
                if (plugin.FileName == fileName)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
