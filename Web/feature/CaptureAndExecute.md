# 画面操作によるコードの生成と実行

TestAssistantPro には、対になる Capture と Execute という機能があります。

- Capture 機能は、アプリケーションの操作からプログラムコードを作成します。
- Execute 機能は、関数単位で処理を実行します。

## Capture

アプリケーションの操作することでプログラムコードを作成します。 Capture でプログラムコードを生成するためには、PageObject および ComponentObject が作成されている必要があります。詳細な内容は[AnalyzeWindow](AnalyzeWindow.md)を参照してください。

Capture 機能を実行するには、プログラムコードを作成したいメソッドを右クリックして、コンテキストメニューから [Capture] を選択してください。Capture ウィンドウが表示されます。

![Capture Menu](../img/captureandexecute_capture_menu.png)

この状態で画面操作を行うことで、Capture ウィンドウにプログラムコードが追加されていきます。標準の状態では、ControlDriver および CaptureCodeGenerator を利用して、追加するプログラムコードが生成されます。

![Capture Complete](../img/captureandexecute_capture_complete.png)

最後に、[Captureウィンドウ] の [Generate] ボタンをクリックすることで選択したメソッドに生成されたコードが追加されます。

![Generated Code](../img/captureandexecute_generated_code.png)

## Execute

プログラムコードを作成した関数を実行するには、実行したいテストシナリオのメソッドを右クリックして、コンテキストメニューから [Execute] を選択してください。プログラムコードが実行されます。

![Replay](../img/captureandexecute_execute_menu.png)