# WinForms

Friendlyを使ってDriver/Scenarioパターンに沿ってテストを実装します。<br>
FriendlyとDriver/Scenarioパターンはこちらを参照お願いします。<br>
+ [Friendly](https://github.com/Codeer-Software/Friendly/blob/master/README.jp.md)
+ [Driver/Scenarioパターン](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)

解説は[こちらのサンプル](WinFormsApp)を操作する例を使いながらおこないます。<br>
[WinFormsAppフォルダ](WinFormsApp)以下にソースコードがあるので最初にダウンロード/ビルドをお願いします。<br>
ダウンロード後には「ブロックの解除」をお願いします。<br>

# 目次
+ [テストソリューションの新規作成](Sln.md)
+ [WindwoDriver](WindowDriver.md)
+ [ControlDriver](ControlDriver.md)
+ [シナリオ](Scenario.md)
+ [カスタマイズ](Customize.md)

# サンプルの説明
サンプルにはWinFormsのアプリでよくあるドッキングウィンドウタイプのアプリを用意しました。<br>
Friendlyを使って自動テストを作成しようとするときに多くの場合最初に表示されるメインウィンドウで躓きます。<br>
ドッキングウィンドウはドライバ作成にコツが必要で前提知識なしに作成するのは困難です。<br>
その他、シンプルなダイアログ、ネイティブのダイアログ、プロジェクト固有のコントロールもあり<br>
一般的なWinFormsのアプリの操作方法が一通り学べるようにしています。<br>
![MainFrame.png](Img/MainFrame.png)
![SampleDialogs.png](Img/SampleDialogs.png)
![NativeWindows.png](Img/NativeWindows.png)
