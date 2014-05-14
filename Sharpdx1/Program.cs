using System;
using System.Collections.Generic;

namespace Sharpdx1
{
    /// <summary>
    /// Simple Sharpdx1 application using SharpDX.Toolkit.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
#if NETFX_CORE
        [MTAThread]
#else
        [STAThread]
#endif
        static void Main()
        {
            using (var program = new Sharpdx1())
                program.Run();

        }
    }
}