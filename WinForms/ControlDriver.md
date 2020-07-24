# ControlDriver

TestAssistantPro を使ってWinFormsのテストプロジェクトを作成すると以下のパッケージがインストールされ<br>
それぞれに定義されているコントロールドライバとキャプチャジェネレータが使えるようになります。<br>
コントロールドライバの種類はそれぞれのリンクを参照してください。<br>

+ [Ong.Frinedly.FormsStandardControls](https://github.com/ShinichiIshizuka/Ong.Friendly.FormsStandardControls)
+ [Codeer.Friendly.Windows.NativeStandardControls](https://github.com/Codeer-Software/Friendly.Windows.NativeStandardControls)

また、WinFormsのサードパーティ製のコントロールで<br>
GrapeCity社のC1FlexGridとSpreadに対するドライバもOSSで公開しています。<br>
+ [Friendly.C1.Win](https://github.com/Codeer-Software/Friendly.C1.Win)
+ [Friendly.FarPoint](https://github.com/Codeer-Software/Friendly.FarPoint)

しかし、世の中には大量の3rdパーティ製のコントロールがあり、さらには各プロジェクト固有のコントロールも存在します。<br>
TestAssistantProはそのような場合でもそれぞれに対するControlDriverとCaptureGeneratorを実装することで対応することが可能です<br>

## AnalyzeWindow から ControlDriver と CaptureGenerator を作成する
ここではサンプルとしてBlockControlのControlDriverとCaptureGeneratorを作ってみます。<br>
BlockControlはこんなのです。
ドラッグで移動させることができます。
★図<br>
まずは AnalyzeWindow を使ってテンプレートを作成します。<br>
作らいたいコントロールをツリーで選んで右クリックから Create Control Driver を実行してください。<br>
★図<br>

ダイアログからControlDriverを選択しDriverプロジェクトの任意のフォルダにドロップします。<br>
次にCaptureGeneratorを選択しDriver.InTargetの任意のフォルダにドロップします。<br>
★図<br>

作成されたコードを見ると
属性がついてて継承しています。
これらの意味は・・・

### ControlDriver 実装
これは [BlockControl]() と [Frinedly]()の知識があれば簡単に実装できます。<br>
BlockCotrolはプロダクトのコードなのでその開発チームなら知っているはずです。<br>
この実装は基本は開発チームに行ってもらうのが費用対効果が良いでしょう。<br>
BlockControlDriverの公開APIの仕様は自由に決定してかまいません。<br>
Ong.Friendly.FormsStandardControlの設計に合すならば<br>
変更を及ぼす操作はメソッドでつくりEmulateプレフィックスを付けます。<br>
今回はこのようにします。<br>

★コード<br>

### キャプチャジェネレータの実装
先ほどのドライバは手動でFriendlyを使ったテストを書く時にも作成するものですが
キャプチャジェネレータはTestAssistantProを使うときだけ出てくるユーティリティクラスです。
これを作っておくと対象のコントロールが操作されたときにドライバを使ったコードが生成されます。
キャプチャジェネレータはキャプチャ時に対象プロセス内部で生成され動作します。
実装方法は対象のコントロールのイベントを受けて、そこで期待されるコードを作成します。

実装方法を紹介します。
まずはBlockControlが定義されているアセンブリを参照します。
そして以下のような実装をします。

ソースコードはDriverCreatorAdaptorに入れるとキャプチャウィンドウに表示されます。

ルールとして・・・


### 使ってみる
ウィンドウドライバを作成します。
するとPickupChildrenでコントロールドライバが割り当たります。

次はキャプチャしてみます。


### デバッグする
上手く動かない場合はデバッグして問題を見つけます。
対象プロセス内で動いているので対象プロセスをデバッグする必要があります。
Attachにブレイクポイントを貼って
Shiftキーを押しながらCaptureを実行してみてください。

キャプチャでBlockControlを見つけるとキャプやジェネレータが生成されAttachコードが呼び出されます。

### 参照せずにイベント接続する

//コントロールドライバで説明
ControlDriverAttribute
RequiredDllsAttribute
Sentence
CommaType
TokenAsyncType
TokenName
TokenSeparator
CaptureSettingAttribute <-高度
UserControlDriverGetterAttribute

