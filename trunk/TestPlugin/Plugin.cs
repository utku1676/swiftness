using System;
using cpg.Swiftness.Plugin;

namespace cpg.Swiftness.Plugins.TestPlugin
{
    public class TestPlugin : MarshalByRefObject, IPlugin
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

        public void Initalize(PluginParams param)
        {
            //throw new NotImplementedException();
        }

        public void Shutdown(PluginParams param)
        {
            throw new NotImplementedException();
        }

    }
}
