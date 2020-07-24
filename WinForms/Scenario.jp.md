## シナリオ作成

ここではシナリオの作成方法を説明します。
シナリオ作成時に使われる機能はCaptureとExecuteです。

Caputer
★図
操作によってプロジェクトに含まれるWindowDriverを使ってコードを作成します。

Execute
関数単位で処理を実行します。
この時 _appには現在TestAssistantProでアタッチしているアプリケーションが割り当てられます。

## 演習
コードを作成する前に生成されているProcessControllerを調整しましょう。

TestAssisntaProのシナリオ作成の特徴は少しづつ進めて行くことで質の高いコードを効率的に作成できることです。

まずはドキュメントを開くシナリオを作ってみます。
関数を作り、そこで右クリックからCaptureを実行します。

void OpenDocument()
{

}

ツリー上でドキュメントを選択して右クリックメニューから Open Document を実行します。
Captureウィンドウ上に次のようにコードが出ているのでGenerateボタンを押します。
先ほどのOpenDocument関数にコードが出ているので、
一度対象プロジェクトのドキュメントを閉じてから
OpenDocument上で右クリックからExecuteを実行します。
そうするとOpenDocumentのみが実行されます。

今度はドキュメント上で検索をしてみます。
最後にAssertも書いてみます。
このAssert処理はここにあって、カスタマイズの方法はこちらを参照お願いします


これもまた同様にSearch関数のみ実行してみます。
実行前に一度ドキュメントを閉じて開きなおしてください。

期待通りの動作をすると今度は一つのテスト関数から呼び出だすようにして纏めて実行してみます。
折角なのでNUnitから実行します。

長いシナリオを一度にキャプチャするのは大変です。
このように短い操作コードを作って確認しながら少しづつ進めることで結果的には高い効率で作業を進めることができます。
また短いコードであれば再利用可能となることが多いです。

またもう一つ重要なのは
当然ですが、これらのコードは手動でも書くことができるということです。
もちろん手動で書いたコードでもExecuteで実行可能で、後述のデバッグ機能も使えます。

### デバッグ
Ctrlキーを押しながらExecuteを実行するとテストプロセスをデバッグできます。
(これはDebugメニューと同じ動作になります)
Shiftキーを押しながらExcecuteを実行すると対象プロセスをデバッグできます。
Dllインジェクションで対象プロセスにロードさせる処理を作っている時に便利です。
Ctrl+Shiftを押しながらExecuteを実行すると両方を同時にデバッグできます。




### Asyncに関して



### キーマウス




テストフレームワークにはNunitをお勧めしていますが、他のテストフレームワークでも問題ありません。
本来はテストシナリオを作成する前にはテスト設計が必須となりますが、ここではその説明は省略して
TestAssistantProの使い方の説明に注力します。

## プロセス実行待ちに関して

## アプリのライフサイクルに関して


## 複数のアプリを操作する場合
WindowsAppFriendを複数持つ場合は、AppInfoAttributeでアプリの名前を指定できます。これによってCapture時に変数を使い分けることができます。ただし複数同時にキャプチャすることはできないので、一つづつキャプチャして処理を作成してください。

using System.Diagnostics;
using Codeer.Friendly.Windows;
using Driver;
using NUnit.Framework;
using Codeer.TestAssistant.GeneratorToolKit;

namespace Scenario
{
    [TestFixture]
    public class Test
    {
        [AppInfo(Name = "WinFormsApp")]
        WindowsAppFriend _winFormsApp;

        [AppInfo(Name = "WpfApp")]
        WindowsAppFriend _wpfApp;