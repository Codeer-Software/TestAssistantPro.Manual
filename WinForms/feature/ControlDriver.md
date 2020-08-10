# ControlDriver

ControlDriver はその名の通り、Button や TextBox など Control に対応するドライバです。
多くの物は複数のアプリケーション間で再利用できます。

TestAssistantPro を使って WinForms のテストプロジェクトを作成すると次のパッケージがインストールされ、含まれるControlDriverを利用できます。

+ [Ong.Frinedly.FormsStandardControls](https://github.com/ShinichiIshizuka/Ong.Friendly.FormsStandardControls)
+ [Codeer.Friendly.Windows.NativeStandardControls](https://github.com/Codeer-Software/Friendly.Windows.NativeStandardControls)

詳細はそれぞれのリンクを参照してください。

また、WinFormsのサードパーティ製のコントロールでGrapeCity社のC1FlexGridとSpreadに対するドライバもOSSで公開しています。
+ [Friendly.C1.Win](https://github.com/Codeer-Software/Friendly.C1.Win)
+ [Friendly.FarPoint](https://github.com/Codeer-Software/Friendly.FarPoint)

## カスタムControllDriver
アプリケーションによっては固有のコントロールや上述した以外の3rdパティーのコントロールを利用することがあります。
TestAssistantPro はそのような場合でもそれぞれに対する ControlDriver を実装することで対応できます。
ControlDriverはFriendlyの基本機能を使うことで簡単に実装できます。実装方法の詳細は[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md#controldriver)を参照してください。

TestAssistantPro で AnalyzeWindow に認識させるためには ControlDriverAttribute 属性を付加します。

```cs
//対応するコントロールを指定することでTestAssistantProでCheckBoxを選択したときにこのクラスが割り当たります
[ControlDriver(TypeFullName = "System.Windows.Forms.CheckBox")]
public class FormsCheckBox : FormsControlBase
{

```

同一のコントロールに対して複数の ControlDriver を割り当てることも可能です。その場合 Priority を指定すると高い方が優先的に選択されます。

```cs
[ControlDriver(TypeFullName = "System.Windows.Forms.CheckBox", Priority = 1)]
public class FormsCheckBoxEx : FormsCheckBox
{

```
