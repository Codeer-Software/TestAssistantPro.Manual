# WinForms

Friendly を使って Driver/Scenario パターンに沿ってテストを実装します。<br>
Friendly と Driver/Scenario パターンはこちらを参照お願いします。<br>
+ [Friendly](https://github.com/Codeer-Software/Friendly/blob/master/README.jp.md)
+ [Driver/Scenarioパターン](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)

解説は[こちらのサンプル](WinFormsApp)を操作する例を使いながらおこないます。
[WinFormsAppフォルダ](WinFormsApp)以下にソースコードがあるので最初にダウンロード/ビルドをお願いします。
ダウンロード後には「ブロックの解除」をお願いします。

# 目次
+ [テストソリューションの新規作成](Sln.md)
+ [WindwoDriver](WindowDriver.md)
+ [ControlDriver](ControlDriver.md)
+ [シナリオ](Scenario.md)
+ [カスタマイズ](Customize.md)

# サンプルの説明
サンプルには WinForms のアプリでよくあるドッキングウィンドウタイプのアプリを用意しました。
Friendly を使って自動テストを作成しようとするときに多くの場合最初に表示されるメインウィンドウで躓きます。
ドッキングウィンドウはドライバ作成にコツが必要で前提知識なしに作成するのは困難です。
その他、シンプルなダイアログ、ネイティブのダイアログ、プロジェクト固有のコントロールもあり
一般的な WinForms のアプリの操作方法が一通り学べるようにしています。

![MainFrame.png](Img/MainFrame.png)

![SampleDialogs.png](Img/SampleDialogs.png)

![NativeWindows.png](Img/NativeWindows.png)
