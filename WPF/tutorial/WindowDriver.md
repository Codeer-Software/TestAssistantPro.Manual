# アプリケーションを解析してWindowDriverおよびUserControlDriverを作成する

[テストソリューションを新規作成する](./Sln.md)で作成したソリューションにTestAssistantProを利用してアプリケーションのドライバを作ります。

ドライバ(WindowDriver/UserControlDriver/ControlDriver)が理解できていない場合は先に
[Driver/Scenarioパターン](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)
を参照してください。

各機能の詳細な内容は次を参照してください。

- [AnalyzeWindowによるアプリケーションの解析](../feature/AnalyzeWindow.md)
- [AnalyzeWindowで生成されるコード](../feature/GeneratedCode.md)
- [Attach方法ごとのコード](../feature/Attach.md)

## 事前準備
WpfDockApp.exeを起動してください。ドライバの作成は操作対象のアプリケーションを解析しながら行います。

## 次の手順
[AnalzeWindowの表示](WindowDriver1.md)