# ComponentObject

画面内にある一連の要素を意味のある単位で切り出して定義したものを画面コンポーネントと言い、ComponentObjcetとはそれをオブジェクト化したものを言います。
たとえば、複数の画面で利用される画面のヘッダやメニュー、また表形式の各行がそれにあたります。

![](../img/f_componentobject_headers.png)

## ComponentObject を定義する

ComponentObjectは「AnalyzeWindow」から作成します。HTML要素ツリーで切り出したい要素を選択し、コンテキストメニューより[Design Component Object]を選択してください。

![](../img/f_componentobject_design_menu.png)


「AnalyzeWindow」が選択した要素をルートとしてComponentObjectを作成する状態に更新されます。基本的な操作は通常の状態と同じで、HTMLの要素をプロパティとして追加していきます。
右ペインの上部にある設定は次のとおりです。

| 項目 | 説明 |
|-----|-----|
| Name | ComponentObject の名前を指定します。 |
| Target Element Info | チェックをつけることで要素がComponentObject側で指定されます。チェックを付けないでおくとPageObject側で指定された要素を利用します。|
| Target Element Info(Dropdown) | Non を指定すると要素名が利用されます。 Class を指定すると設定されている Class の値が利用されます。 |

![](../img/f_componentobject_header_component.png)

## ComponentObject を利用する

作成したComponentObjectは要素をプロパティとして追加したときのTypeで指定します。

![](../img/f_componentobject_use.png)