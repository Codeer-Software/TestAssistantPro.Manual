# テストソリューションの新規作成

テストソリューションの新規作成について説明します。<br>
TestAssistantPro を使うことで WinForms のアプリの自動テストに最適なソリューションを作成することができます。
ウィザードに従うと以下のプロジェクトが作成され、それぞれに必要な最新の Nuget パッケージがインストールされます。

* Driver
    * Codeer.Friendly
    * Codeer.Friendly.Windows
    * Codeer.Friendly.Windows.Grasp
    * Codeer.Friendly.Windows.KeyMouse
    * Codeer.Friendly.Windows.NativeStandardControls
    * Codeer.TestAssistant.GeneratorToolKit
    * Ong.Friendly.FormsStandardControls
* Driver.InTarget
    * Codeer.TestAssistant.GeneratorToolkit
* Scenario
  * Codeer.Friendly
  * Codeer.Friendly.Windows
  * Codeer.Friendly.Windows.Grasp
  * Codeer.Friendly.Windows.KeyMouse
  * Codeer.Friendly.Windows.NativeStandardControls
  * Codeer.TestAssistant.GeneratorToolKit
  * Ong.Friendly.FormsStandardControls
  * NUnit

ここで作るのは基本構成です。
作業が進みボリュームが大きくなってきた場合、必要に応じてそれぞれの役割を持つ dll を複数個に分割していくことも可能です。
TestAssistantPro はこの構成以外でも Driver の作成やシナリオの作成を行うことができます。
それらは WinForms用のものであれば Ong.Friendly.FormsStandardControls がインストールされているプロジェクトで使うことが可能です。
テストフレームワークも NUnit が入りますが、これも NUnit である必要はありません。プロジェクトに適したものを採用してください。

# 手順
## テンプレート選択
検索ウィンドウに Test と入力して検索してください。
（表示されない場合はスクロールで下を見てください）
TestAssistantPro WinForms Test Project を選択して Next ボタンを押します。

![Sln1.png](Img/Sln1.png)

## プロジェクト情報入力
任意でパスと名称を入力します。

![Sln2.png](Img/Sln2.png)

## .netのバージョン入力
.Netのバージョンを入力します。Applicationはテスト対象のプロジェクト以下のバージョンにしてください。
Testの方はApplicationのバージョン以上を指定してください。

![Sln3.png](Img/Sln3.png)

## 作成されたソリューション

![Sln4.png](Img/Sln4.png)

## ProcessControllerの調整
Driver/TestController.cs の targetPath を書き換えます。
これでNunitでテスト実行した場合に対象プロセスが起動するようになります。
TestControllerフォルダ以下には対象アプリケーションを管理するコードが入っています。
あくまでテンプレートですので、プロジェクトにあわせて書き換えてください。
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
            //target path
            var targetPath = @"C:\GitHub\TestAssistantPro.Manual\WinForms\WinFormsApp\bin\Debug\WinFormsApp.exe";
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