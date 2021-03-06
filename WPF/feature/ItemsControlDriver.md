# ItemsControlのControlDriver

## ControlDriver
WPFでのItemsControlのControlDriverを作るときはいくつかの手法があり、判断ポイントがあります。

+ ItemDriverを作るか
+ ItemDriverをどのようにつくるか
	+ ControlDriverで作る
	+ UserControlDriverで作る
+ ItemDriverへのAttach/As
	+ Attach
	+ As

### ItemDriverを作るか
Itemを独立した存在として操作する必要があるかで判断します。
シンプルなものだとItemsContorlのAPIだけで問題ない場合があります。
例えばコンボボックスもそれぞれのItemを操作するものも作れますが、一般的には必要ないのでWPFComboBoxではItemの操作までは行っていません。

### ItemDriverをContorlDriverとして作る
Itemを一つのコントロールとしてとらえてそれに対する操作を与える方法です。この場合Itemへの操作のコードをTestAssistantProで生成するならCaptureGenratorもこのクラスに対して作成します。

### ItemDriverをUserControlDriverとして作る
ItemをUserControlとしてとらえる方法です。
こちらの方がツールのサポートを多く使えるので最初は作りやすいと思います。
WPFListBox<T>、WPFListView<T>WPFTreeView<T>はItemをUserControlDriverとして定義できるようにしています。
<br>
サンプルはこちらを参照してください。

[DateTemplateでカスタマイズしたListBoxItemのドライバ作成る](../tutorial/ItemsControlDriver1.md)

### ItemDriverへのAttach/As
Itemが様々な形態を持つ場合、一つのUserContorlにそのすべてを定義するのが難しければAttachでItemDriverから操作対象のコントロールを取得したり、Asで変形させたりして目的の操作を行います。
<br>
サンプルはこちらを参照してください。

[複数種類のアイテムへの対応(DataTemplateSelector)](../tutorial/ItemsControlDriver2.md)
[DataGrid のカスタマイズ](../tutorial/ItemsControlDriver4.md)

## CaptureGeneratorのサポート
ItemDriverを作るときにはそれをキャプチャするための仕組みとしてItemDriverGetterAttributeを用意しています。
現在アクティブになっているアイテムをキャプチャ対象にします。
これはItemは多い場合があるので必要な物のみキャプチャ対象にしています。
注意点としてアクティブになった後にキャプチャ対象になるので一度選択してから操作してもらう必要があります。
<br>
サンプルはこちらを参照してください。

[ItemsControlのControlDriverを作る](../tutorial/ControlDriver4.md)

### ItemDriverGetterAttribute
ItemDriverGetterAttributeをアイテムを取得するメソッドに設定します。
キャプチャ中にはActiveItemKeyPropertyで指定されたプロパティが呼び出されます。
それを使ってアイテムが取得されキャプチャ対象になります。

![ItemDriverGetterAttribute.png](../Img/ItemDriverGetterAttribute.png)

ActiveItemKeyPropertyにはint,string,int[],string[],IItemKeyを使うことができます。
例えばActiveItemKeyPropertyのCurrentCellはWPFDataGridCellになっています。
WPFDataGridCellはIItemKeyを実装しています。
```cs
public WPFDataGridCell CurrentCell { get; }

[ItemDriverGetter(ActiveItemKeyProperty = "CurrentCell")]
public WPFDataGridCell GetCell(int itemIndex, int col)
```

実際にWPFDataGridのGetCellを呼び出すときにはGetArguments()で取得したオブジェクトが使われ、生成されるコードにはGetArgumentsCode()が使われます。

```cs
public class WPFDataGridCell : IItemKey
{
    //実際の引数
    public object[] GetArguments()
        => new object[] { 
                (int)App.Type<WPFDataGridCell>().GetItemIndex(this),
                (int)App.Type<WPFDataGridCell>().GetColumnIndex(this) 
            };

    //生成されるコード
    public string GetArgumentsCode()
        => $"{(int)App.Type<WPFDataGridCell>().GetItemIndex(this)}, {(int)App.Type<WPFDataGridCell>().GetColumnIndex(this)}";
}