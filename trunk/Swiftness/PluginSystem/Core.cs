using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Swiftness.Plugin;

namespace Swiftness.PluginSystem
{
    static class Core
    {
        private static List<Plugin> pluginlist = new List<Plugin>();

        /// <summary>
        /// Refresh the whole pluginlist
        /// </summary>
        public static void RefreshPluginlist()
        {
            #region Refresh current plugins

            foreach (Plugin plugin in pluginlist)
            {
                // Refresh all plugins that are not loaded
                if (!plugin.Loaded)
                {
                    plugin.UpdateInfo();
                }
            }

            #endregion

            #region Scan for new Plugins
            DirectoryInfo dir = new DirectoryInfo("./Plugins/");
            FileInfo[] files = dir.GetFiles("*.dll", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in files)
            {
                // Skip already existing plugins
                if (pluginExists(file.Name))
                    continue;

                // Create Plugin
                Plugin plugin = new Plugin(file.FullName);

                pluginlist.Add(plugin);

            }
            #endregion
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
