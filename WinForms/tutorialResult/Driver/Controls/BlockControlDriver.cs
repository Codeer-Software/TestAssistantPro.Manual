using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Drawing;

namespace Driver.Controls
{
    //実装するにはBlockControlのAPIを知っている必要がある
    [ControlDriver(TypeFullName = "WinFormsApp.BlockControl", Priority = 2)]
    public class BlockControlDriver : FormsControlBase
    {
        public BlockControlDriver(AppVar appVar)
            : base(appVar) { }

        //選択インデックス
        public int SelectedIndex => this.Dynamic().SelectedIndex;

        //選択変更
        public void EmulateChangeSelectedIndex(int index) => this.Dynamic().SelectedIndex = index;

        //移動
        public void EmulateMoveBlock(int index, Point location) => this.Dynamic().MoveBlock(index, location);
    }
}
