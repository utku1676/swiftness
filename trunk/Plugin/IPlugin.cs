
namespace cpg.Swiftness.Plugin
{
    public interface IPlugin
    {
        PluginInfo pluginInfo
        {
            get;
        }

        void Initalize(PluginParams param);
        void Shutdown(PluginParams param);

    }
}
