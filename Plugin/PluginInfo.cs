using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpg.Swiftness.Plugin
{
    [Serializable]
    public struct PluginInfo
    {
        public string PluginName;
        public string PluginAuthor;
        public Version PluginVersion;
        public string PluginURL;
        public string PluginDesc;
    }

    [Serializable]
    public struct PluginParams
    {
        public System.Windows.Forms.Form mdiParent;
    }
}
