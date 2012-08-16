using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cpg.Swiftness.Plugin;

namespace TestPlugin
{
    public class TestPlugin : IPlugin
    {
        string pName = "Test Plugin";
        string pAuthor = "florian0";
        string pURL = "http://cp-g.de";
        string pDesc = "florian0's demoplugin";
        Version pVersion = new Version(1, 0);

        public PluginInfo pluginInfo
        {
            get 
            {
                PluginInfo info = new PluginInfo();
                info.PluginAuthor = pAuthor;
                info.PluginDesc = pDesc;
                info.PluginName = pName;
                info.PluginURL = pURL;
                info.PluginVersion = pVersion;
                
                return info;
            }
        }

        public void Intialize()
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}
