using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpg.Swiftness.Plugin
{
    [Serializable]
    public struct PluginInfo
    {
        public string Name;
        public string Author;
        public Version Version;
        public string URL;
        public string Desc;
    }

    [Serializable]
    public struct PluginParams
    {
        
    }
}
