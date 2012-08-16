using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace CommunityBot.PluginSystem
{
    static class PluginLoader
    {
        public static void LoadPlugins()
        {
            string[] files = Directory.GetFiles("./Plugins/", "*.dll", SearchOption.TopDirectoryOnly);
            
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                
            }

        }
    }
}
