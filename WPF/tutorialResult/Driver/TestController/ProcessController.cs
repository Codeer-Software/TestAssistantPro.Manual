using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Driver.TestController
{
    public static class ProcessController
    {
        public static WindowsAppFriend Start()
        {
            var dir = typeof(ProcessController).Assembly.Location;
            Enumerable.Range(0, 5).ToList().ForEach(e => dir = Path.GetDirectoryName(dir));

            //target path
            var targetPath = Path.Combine(dir, @"WpfDockApp\bin\Debug\WpfDockApp.exe");
            var info = new ProcessStartInfo(targetPath) { WorkingDirectory = Path.GetDirectoryName(targetPath) };
            var app = new WindowsAppFriend(Process.Start(info));
            app.ResetTimeout();
            return app;
        }

        public static void Kill(this WindowsAppFriend app)
        {
            if (app == null) return;

            app.ClearTimeout();
            try
            {
                Process.GetProcessById(app.ProcessId).Kill();
            }
            catch { }
        }
    }
}
