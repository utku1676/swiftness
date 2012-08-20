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

                // Create Plugin
                Plugin plugin = new Plugin(file.FullName);



                pluginlist.Add(plugin);

            }
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
