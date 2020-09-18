# テストソリューションを新規作成する

TestAssistantProではWPFアプリケーションの自動テストに最適なVisual Studioソリューションを作成するためのテンプレートウィザードが提供されています。
ウィザードに従ってプロジェクトを作成すると自動的に次の3つのプロジェクトが作成されます。


プロジェクト       | 説明
----------------|---------------
Driver          | テスト対象アプリケーションのプロセスの制御や操作を行う処理が定義されています。画面やコントロールの操作をカプセル化するためのコードはここに記述します。
Driver.InTarget | テスト対象アプリケーションのプロセス内に埋め込むコードを記述します。外部からの操作で実現が難しい処理はここに記述してください。
Scenario        | 実際のテストを実行するテストコードを記述します。テストシナリオに沿ってテストコードを記述してください。


<!--
* Driver
    * Codeer.Friendly
    * Codeer.Friendly.Dynamic
    * Codeer.Friendly.Windows
    * Codeer.Friendly.Windows.Grasp
    * Codeer.TestAssistant.GeneratorToolKit
    * RM.Friendly.WPFStandardControls
* Driver.InTarget
    * Codeer.TestAssistant.GeneratorToolkit
* Scenario
  * Codeer.Friendly
  * Codeer.Friendly.Windows
  * Codeer.Friendly.Windows.Grasp
  * Codeer.Friendly.Windows.KeyMouse
  * Codeer.Friendly.Windows.NativeStandardControls
  * Codeer.TestAssistant.GeneratorToolKit
  * RM.Friendly.WPFStandardControls
  * NUnit
-->

これらの3つのプロジェクトは基本構成です。作業を進めることでボリュームが大きくなってきた場合、それぞれの役割を持つプロジェクトを複数に分割していくことも可能です。

> TestAssistantProはこの構成以外でもドライバーの作成やシナリオの作成を行うことができます。
> RM.Friendly.WPFStandardControlsがインストールされているプロジェクトで使うことが可能です。

<!--
TODO: いったんコメントアウト。自動生成されるコードがNUnitに依存しすぎている場合、別のフレームワークを採用することは非現実的なので記述から外す
> テストフレームワークもNUnitが入りますが、これもNUnitである必要はありません。プロジェクトに適したものを採用してください。
-->
