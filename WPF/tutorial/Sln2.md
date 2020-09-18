## テスト対象アプリケーションのパスを指定する

テスト対象アプリケーションをテストするために、テスト対象アプリケーションの実行ファイルのパスを指定します。
「Driver」プロジェクトのTestController/ProcessController.csファイルを開いて、targetPath変数にパスを設定してください。

### サンプルアプリケーションの準備
サンプルアプリケーションは[こちら](https://github.com/Codeer-Software/TestAssistantPro.Manual/releases/download/ver0.2/WpfDockApp.zip)からダウンロードできます。ダウンロード後には「ブロックの解除」を行ってください。ソースコードは[こちら](WpfDockApp)にあります。

```cs
using Codeer.Friendly.Windows;
using System.Diagnostics;
using System.IO;

namespace Driver.TestController
{
    public static class ProcessController
    {
        public static WindowsAppFriend Start()
        {
            //※ここを書き換えます。
            var targetPath = @"C:\GitHub\TestAssistantPro.Manual\WPF\WpfDockApp\bin\Debug\WpfDockApp.exe";
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
```
