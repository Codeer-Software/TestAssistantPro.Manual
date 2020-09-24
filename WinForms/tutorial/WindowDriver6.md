## Documentのドライバの作成
Document は TreeView の AcceptedもしくはSendedから開くことができます。これは同じクラスで表示するデータが異なっているだけです。一般的にドキュメントは同じタイプのものが複数存在します。
Attach方法は VariableWindowText を利用し、 WindowsAppFriend にAttachするように設定します。
Attachのオプションの詳細は [Attach方法ごとのコード](../feature/Attach.md)を参照してください。

![WindowDriver.Document.png](../Img/WindowDriver.Document.png)

```cs
using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;
using Codeer.Friendly.Windows.Grasp;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Linq;

namespace Driver.Windows
{
    [UserControlDriver(TypeFullName = "WinFormsApp.OrderDocumentForm")]
    public class OrderDocumentFormDriver
    {
        public WindowControl Core { get; }
        public FormsButton _searchButton => Core.Dynamic()._searchButton;
        public FormsTextBox _searchTextBox => Core.Dynamic()._searchTextBox;
        public FormsDataGridView _grid => Core.Dynamic()._grid;

        public OrderDocumentFormDriver(WindowControl core)
        {
            Core = core;
        }

        public OrderDocumentFormDriver(AppVar core)
        {
            Core = new WindowControl(core);
        }
    }

    public static class OrderDocumentFormDriverExtensions
    {
        [UserControlDriverIdentify(CustomMethod = "TryGet")]
        public static OrderDocumentFormDriver AttachOrderDocumentForm(this WindowsAppFriend app, string text)
            => app.GetTopLevelWindows().SelectMany(e=>e.GetFromTypeFullName("WinFormsApp.OrderDocumentForm")).Where(e=>(string)e.Dynamic().Text == text).FirstOrDefault()?.Dynamic();

        public static void TryGet(this WindowsAppFriend parent, out string[] texts)
            => texts = parent.GetTopLevelWindows().SelectMany(e => e.GetFromTypeFullName("WinFormsApp.OrderDocumentForm")).Select(e => (string)e.Dynamic().Text).ToArray();

    }
}
```

## 次の手順

ここまで画面キャプチャを行うためのドライバの作成が完了しました。
次は標準ではキャプチャに対応していないコントロールに対応するためのControlDriverを作成します。

[ControlDriverとCaptureCodeGeneratorを作成する](ControlDriver.md)