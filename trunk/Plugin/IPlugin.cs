using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpg.Swiftness.Plugin
{
    public interface IPlugin
    {
        PluginInfo pluginInfo
        {
            get;
        }

        void Intialize();
        void Shutdown();

    }
}
