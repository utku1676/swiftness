
namespace cpg.Swiftness.Plugin
{
    public interface IPlugin
    {
        PluginInfo pluginInfo
        {
            get;
        }

        frmPlugin Form
        {
            get;
        }

        void Initalize(PluginParams param);
        void Shutdown(PluginParams param);
    }
}
