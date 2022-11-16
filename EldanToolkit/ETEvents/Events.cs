using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldanToolkit.ETEvents
{
    public static class Events
    {
        public static event EventHandler? eProjectLoaded;
        public static void ProjectLoaded()
        {
            eProjectLoaded?.Invoke(null, EventArgs.Empty);
        }
    }
}
