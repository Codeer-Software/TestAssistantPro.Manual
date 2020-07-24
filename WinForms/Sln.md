# テストソリューションの新規作成

テストソリューションの新規作成について説明します。<br>
TestAssistantProを使うことでWinFormsのアプリの自動テストに最適なソリューションを作成することができます。<br>
ウィザードに従うと以下のプロジェクトを作成し、それぞれに必要な最新のNugetパッケージをインストールします。<br>

* Driver
    * Codeer.Friendly
    * Codeer.Friendly.Windows
    * Codeer.Friendly.Windows.Grasp
    * Codeer.Friendly.Windows.KeyMouse
    * Codeer.Friendly.Windows.NativeStandardControls
    * Codeer.TestAssistant.GeneratorToolKit
    * Ong.Friendly.FormsStandardControls
* Driver.InTarget
    * Codeer.TestAssistant.GeneratorToolkit
* Scenario
  * Codeer.Friendly
  * Codeer.Friendly.Windows
  * Codeer.Friendly.Windows.Grasp
  * Codeer.Friendly.Windows.KeyMouse
  * Codeer.Friendly.Windows.NativeStandardControls
  * Codeer.TestAssistant.GeneratorToolKit
  * Ong.Friendly.FormsStandardControls
  * NUnit

ここで作るのは基本構成です。<br>
作業が進みボリュームが大きくなってきた場合、必要に応じてそれぞれの役割を持つdllを複数個に分割していくことも可能です。<br>
TestAssistantProはこの構成以外でもDriverの作成やシナリオの作成を行うことができます。<br>
それらはOng.Friendly.FormsStandardControlsがインストールされているプロジェクトで使うことが可能です。<br>
テストフレームワークもNUnitが入りますが、これもNUnitである必要はありません。プロジェクトに適したものを採用してください。<br>

# 手順
## テンプレート選択
検索ウィンドウに Test と入力して検索してください。<br>
（表示されない場合はスクロールで下を見てください）<br>
TestAssistantPro WinForms Test Project を選択して Nextボタンを押します。<br>
![Sln1.png](Img/Sln1.png)

## プロジェクト情報入力
任意でパスと名称を入力します。<Br>
![Sln2.png](Img/Sln2.png)

## .netのバージョン入力
.Netのバージョンを入力します。Applicationはテスト対象のプロジェクト以下のバージョンにしてください。<br>
Testの方はApplicationのバージョン以上を指定してください。<br>
![Sln3.png](Img/Sln3.png)

## 作成されたソリューション
![Sln4.png](Img/Sln4.png)

## ProcessControllerの調整
コードを作成する前に生成されているProcessControllerを調整しましょう。
TODO
