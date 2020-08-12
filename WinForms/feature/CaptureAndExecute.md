# 画面操作のキャプチャと再生

TestAssistantProには、対になるCaptureとExecuteという機能があります。
<!--TODO ExecuteというよりはReplay?-->

- Capture機能は、アプリケーションの操作をプログラムコードとして記録します。
- Execute機能は、記録したプログラムコードを実行して対象アプリケーション上で操作を再現します。

## Capture

アプリケーションの操作をプログラムコードとして記録します。
Captureでプログラムコードを生成するためには、WindowDriverおよびUserControlDriverが作成されている必要があります。詳細な内容は[AnalyzeWindowの使い方](./AnalyzeWindow.md)を参照してください。

Capture機能を実行するには、プログラムコードを記録したいメソッドを右クリックして、[Capture]を選択してください。Captureウィンドウが表示され、画面操作の記録が開始されます。

![Captureコンテキストメニュー](../Img/CaptureAndExecute.CaptureContextMenu.png)

この状態で画面操作を行うことで、Captureウィンドウにプログラムコードが追加されていきます。標準の状態では、ControlDriverおよびCaptureCodeGeneratorを利用して、追加するプログラムコードが生成されます。

画面下部にある[Key Mouse Capture Mode]をオンにするとキーボードおよびマウスの操作をキャプチャし、その内容に従ったプログラムコードが生成されます。

![Captureウィンドウ](../Img/CaptureAndExecute.CaptureWindow.png)

最後に、[Captureウィンドウ]の[Generate]ボタンをクリックすることで選択したメソッドに生成されたコードが追加されます。

![生成されたコード](../Img/CaptureAndExecute.GeneratedCode.png)

## Execute

記録したプログラムコードを実行して対象アプリケーション上で操作を再現します。

実行したいメソッドを右クリックして、[Execute]を選択してください。プログラムコードが実行され、操作が再生されます。

![Executeコンテキストメニュー](../Img/CaptureAndExecute.ExecuteContextMenu.png)

操作を正しく再生するためにはアプリケーションが操作を実行できる状態になっている必要があります。たとえば、ダイアログの操作を記録したプログラムコードを再生する場合は、ダイアログが表示されている状態から実行する必要があることに注意してください。