# ControlDriverのコード

ControlDriver はその名の通り、Button や TextBox など Control に対応するドライバです。
多くの物は複数のアプリケーション間で再利用できます。

TestAssistantPro を使って WPF のテストプロジェクトを作成すると次のパッケージがインストールされ、含まれるControlDriverを利用できます。

+ [RM.Frinedly.WPFStandardControls](https://github.com/Roommetro/Friendly.WPFStandardControls/)
+ [Codeer.Friendly.Windows.NativeStandardControls](https://github.com/Codeer-Software/Friendly.Windows.NativeStandardControls)

詳細はそれぞれのリンクを参照してください。

また、WPFのサードパーティ製のコントロールでInfragistics社のXamControlsに対するドライバもOSSで公開しています。
+ [Friendly.XamControls](https://github.com/Codeer-Software/Friendly.XamControls)

## カスタムControllDriver
アプリケーションによっては固有のコントロールや上述した以外の3rdパティーのコントロールを利用することがあります。
TestAssistantPro はそのような場合でもそれぞれに対する ControlDriver を実装することで対応できます。
ControlDriverはFriendlyの基本機能を使うことで簡単に実装できます。実装方法の詳細は[こちら](https://github.com/Codeer-Software/Friendly/blob/master/TestAutomationDesign.jp.md#controldriver)を参照してください。

TestAssistantPro で AnalyzeWindow に認識させるためには ControlDriverAttribute 属性を付加します。

```cs
//対応するコントロールを指定することでTestAssistantProでCheckBoxを選択したときにこのクラスが割り当たります
[ControlDriver(TypeFullName = "System.Windows.Controls.ComboBox")]
public class WPFComboBox : WPFSelectorCore<ComboBox>
{

```

同一のコントロールに対して複数の ControlDriver を割り当てることも可能です。その場合 Priority を指定すると高い方が優先的に選択されます。

```cs
[ControlDriver(TypeFullName = "System.Windows.Controls.ComboBox", Priority = 1)]
public class WPFComboBoxEx : WPFComboBox
{

```
