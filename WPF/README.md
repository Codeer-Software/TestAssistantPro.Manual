# TestAssistantProを利用してWPFアプリケーションのテストを構築する

## 前提知識
TestAssistantProを使ってFriendlyでの`Driver/Scenarioパターン`に沿ったテストを実装します。
そのためFriendlyと`Driver/Scenarioパターン`の知識が必要となります。
特に`Driver/Scenarioパターン`の理解は必須です。
Friendlyと`Driver/Scenarioパターン`は次のリンクを参照してください。

+ [Friendly](https://github.com/Codeer-Software/Friendly/blob/master/README.jp.md)
+ [Driver/Scenarioパターン](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)

## 目次
初めてTestAssistantProを使う場合はチュートリアルから読んでください。チュートリアル中に各機能の詳細説明へのリンクを入れているので効率良く使用方法を学習できます。

- チュートリアル

	- [テストソリューションを新規作成する](tutorial/Sln.md)
		- [ウィザードを利用してプロジェクトを追加する](tutorial/Sln1.md)
		- [テスト対象アプリケーションのパスを指定する](tutorial/Sln2.md)
		- [テストを実行して動作を確認する](tutorial/Sln3.md)
	- [アプリケーションを解析してWindowDriverおよびUserControlDriverを作成する](tutorial/WindowDriver.md)
		- [AnalzeWindowの表示](tutorial/WindowDriver1.md)
		- [Simple Dialogのドライバの作成](tutorial/WindowDriver2.md)
		- [Multi UserControl Dialogのドライバの作成](tutorial/WindowDriver3.md)
		- [MainWindowのドライバの作成](tutorial/WindowDriver4.md)
		- [TreeUserControlとOutputUserControl のドライバの作成](tutorial/WindowDriver5.md)
		- [Documentのドライバの作成](tutorial/WindowDriver6.md)
	- [カスタマイズされたItemsControlに対応する](tutorial/ItemsControlDriver.md)
		- [シンプルなListBoxItemのドライバ作成る](tutorial/ItemsControlDriver1.md)
		- [複数種類のアイテムへの対応(DataTemplateSelector)](tutorial/ItemsControlDriver2.md)
		- [ItemsControlWindowのドライバ作成](tutorial/ItemsControlDriver3.md)
		- [キャプチャ](tutorial/ItemsControlDriver4.md)
	- [ControlDriverとCaptureCodeGeneratorを作成する](tutorial/ControlDriver.md)
		- [ControlDriverとCaptureCodeGeneratorのコードテンプレートを生成する](tutorial/ControlDriver1.md)
		- [ControlDriverの実装](tutorial/ControlDriver2.md)
		- [CaptureCodeGeneratorの実装](tutorial/ControlDriver3.md)
		- [ControlDriverとCaptureCodeGeneratorの利用](tutorial/ControlDriver4.md)
		- [ドキュメントの閉じるに反応するようにする](tutorial/ControlDriver5.md)
	- [アプリケーションの操作を記録してシナリオを作成する](tutorial/Scenario.md)

- 機能
  - [AnalyzeWindowの使い方](feature/AnalyzeWindow.md)
  - [画面操作のキャプチャと再生](feature/CaptureAndExecute.md)
  - [WindowDriver/UserControlDriverのコード](feature/GeneratedCode.md)
  - [Attach方法ごとのコード](feature/Attach.md)
  - [ControlDriverのコード](feature/ControlDriver.md)
  - [CaptureCodeGeneratorのコード](feature/CaptureCodeGenerator.md)
  - [AnalyzeWindowをカスタマイズする](feature/CustomizeAnalyzeWindow.md)
  - [Captureウィンドウをカスタマイズする](feature/CustomizeCaptureWindow.md)
 
## 利用するサンプルアプリケーション
### ダウンロード
サンプルアプリケーションは[こちら](https://github.com/Codeer-Software/TestAssistantPro.Manual/releases/download/ver0.2/WpfDockApp.zip)からダウンロードできます。ダウンロード後には「ブロックの解除」を行ってください。ソースコードは[こちら](WpfDockApp)にあります。

### 内容
サンプルには WPF でよくあるドッキングウィンドウタイプのアプリケーションを用意しました。
Friendly を使って自動テストを作成しようとするときに多くの場合最初に表示されるメインウィンドウでつまずきます。
ドッキングウィンドウはドライバ作成にコツが必要で前提知識なしに作成するのは困難です。
そのほか、シンプルなダイアログ、ネイティブのダイアログ、プロジェクト固有のコントロールもあり
一般的な WPF のアプリケーションの操作方法が一通り学べるようにしています。

![DemoApp1.png](Img/DemoApp1.png)
![DemoApp2.png](Img/DemoApp2.png)
![DemoApp3.png](Img/DemoApp3.png)
![DemoApp4.png](Img/DemoApp4.png)
