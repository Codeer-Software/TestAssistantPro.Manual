# WindowDriverの作成

ここではWindowDriverの作成方法に関して説明します。
WindowDriverに関しては[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md)を参照お願いします。<br>

## AnalyzeWindow 起動
Driver/Windowsフォルダで右クリックから Analyze Window を選択してください。<br>
★図<br>
これはどこのフォルダでも可能です。ドライバを生成したときに指定のフォルダに生成されます。<br>
対象アプリを選択する画面が出ますので、対象を選択してください。<br>
★図<br>
ここで選択するとFriendlyの機能によって対象アプリにFriendly系のdllとDriver.InTarget.dllがインジェクションされます。<br>
間違ったアプリを選択するとOSの再起動が必要になる場合がありますので間違えないように選択してください。<br>
二回目以降はこれが表示されずに同一のアプリに対して Analyze Window が実行されます。<br>
途中で対象アプリを変えたい場合は Select Target を実行すると対象を変更することができます。<br>

## AnalyzeWindow の各機能の使い方
AnalyzeWindowは対象のアプリを解析してWindowDriverを作成するものです。
ツリーのルートのコントロールに対してWindowDriverを作成します。
Designerタブの設定でコードを作ります。
現在の設定で生成されるコードは Current Code タブでプレビューを見ることができます。

### Tree
コントロールを選択します。
ツリーで選択すると対象アプリの対応するコントロールが赤枠で囲まれます。
Ctrlキーを押しながら対象のアプリのコントロールにマウスを持っていくとツリーの対応するノードが選択されます。

#### Tree 操作
ダブりクリック
WindowDriverのプロパティとして登録したいコントロールをダブルクリックすると右側のグリッドに登録されます。

右クリックメニュー
Pickup Children
    指定したコントロールの子孫のコントロールでドライバが割り当たっているものを一括でピックアップしてグリッドに登録します。
    子孫をたどるときにUserControlを発見した場合はそれ以下は検索しません。
    それ以下のコントロールもグリッドに登録したい場合はそのUserControlを選択し再度Pickup Childrenを実行してください。
Create Control Driver
    コントロールドライバを作成します。
    詳細はこちらで説明します。
Show Base Class
Expand All
Close All

    ↓説明ウザいから消そう。
Display Mode 
Tree Update

※これはカスタマイズできます。詳細はこちら。

### メニュー
Display Mode 
    Control
        表示モードです。Control.Controlsを元にしたツリーを表示します。デフォルトはこちらです。
    Field
    Filter Window And UserControl

Tree Update
    Auto Update
        Treeを更新するタイミングを設定します。通常はONで使ってください。あまりにも画面の要素が頻繁に更新される場合は動作が重くなるのでチェックをOFFにしてください。
    Update Now
        Treeを更新します。
    Sync with Visual Studio

Tool
    Compile & update
    Option

### Desiner
Type   
Assigned Driver

//この辺からはコードと一緒に書いた方が良いかな
//★詳細はこちらで下にリンク飛ばす
Class Name
Create Attach Code
Extension
Method
Many Exists
Grid

### Property

### Output

# 演習
先ほどのサンプルアプリのドライバを作ります。
MainFormは少し複雑なので後に回します。
まずはシンプルなダイアログで操作に慣れていきます。

## Simple Dialog

## Multi
UserControlに関してはあれでこれで

ここではUserControlを作って親のWindowDriverのプロパティにするのと
UserControlを意識せず親のWindowDriverのプロパティに直接コントロールドライバを足す方法をやってみます。

時と場合によるので場面によって使い分けてください。

## MainWindow

## TreeとOUtput

## Document
同じタイプのが

## ネイティブのウィンドウに関して
メッセージボックス
ファイル保存/開くダイアログ
新規作成時にコードに入ってきます。
もしそれ以外のがあった場合はこちらを参考に作成お願いします。


カスタムコントロールの対応はこちら


★デバッグに関して


//WindowDriverで説明
DriverCoreIdentifyAttribute
UserControlDriverAttribute
UserControlDriverIdentifyAttribute
WindowDriverAttribute
WindowDriverIdentifyAttribute

Logger

TestAssistantMode