using System;
using Swiftness.Plugin;
using System.Runtime.Serialization;

namespace Swiftness.Plugins.TestPlugin
{
    public class TestPlugin : MarshalByRefObject, IPlugin
    {
        string pName = "Test Plugin";
        string pAuthor = "florian0";
        string pURL = "http://cp-g.de";
        string pDesc = "florian0's demoplugin";
        Version pVersion = new Version(1, 0);

        frmTest test;

        #region IPlugin Member

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
            test.Dispose();
        }

        public bool OnServerToClient()
        {
            throw new NotImplementedException();
        }

        public bool OnClientToServer()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
