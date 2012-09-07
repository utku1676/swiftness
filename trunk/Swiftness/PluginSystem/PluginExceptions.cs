using System;

namespace Swiftness.PluginSystem
{
    class PluginLoaderException : Exception
    {
        public PluginLoaderException() : base()
        { }

        public PluginLoaderException(string message) : base(message)
        { }

        public PluginLoaderException(string message, Exception innerException) : base(message,innerException)
        { }
    }

    class PluginException : Exception
    {
        public PluginException() : base()
        { }

        public PluginException(string message) : base(message)
        { }

        public PluginException(string message, Exception innerException) : base(message,innerException)
        { }
    }
}
