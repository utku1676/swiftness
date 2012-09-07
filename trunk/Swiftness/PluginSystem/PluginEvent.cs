using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swiftness.PluginSystem
{
        public delegate void PluginEventHandler(object sender, PluginEventArgs args);

        public class PluginEventArgs : EventArgs
        {
            private bool _enabled;
            private bool _loaded;

            public PluginEventArgs(bool loaded, bool enabled)
            {
                _enabled = enabled;
                _loaded = loaded;
            }

            public bool Loaded
            { get { return _loaded; } }

            public bool Enabled
            { get {return _enabled; } }

        }
}
