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

        frmTest test;

        public PluginInfo pluginInfo
        {
            get
            {
                PluginInfo info = new PluginInfo();
                info.Author = pAuthor;
                info.Desc = pDesc;
                info.Name = pName;
                info.URL = pURL;
                info.Version = pVersion;
                
                return info;
            }
        }

        public frmPlugin Form
        {
            get { return test; }
        }

        public void Initalize(PluginParams param)
        {
            test = new frmTest();
        }

        public void Shutdown(PluginParams param)
        {
            throw new NotImplementedException();
        }

    }
}
