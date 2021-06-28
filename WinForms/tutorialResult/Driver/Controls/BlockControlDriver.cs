using Codeer.Friendly;
using Codeer.Friendly.Dynamic;
using Codeer.TestAssistant.GeneratorToolKit;
using Ong.Friendly.FormsStandardControls;
using System.Drawing;

namespace Driver.Controls
{
    //��������ɂ�BlockControl��API��m���Ă���K�v������
    [ControlDriver(TypeFullName = "WinFormsApp.BlockControl", Priority = 2)]
    public class BlockControlDriver : FormsControlBase
    {
        public BlockControlDriver(AppVar appVar)
            : base(appVar) { }

        //�I���C���f�b�N�X
        public int SelectedIndex => this.Dynamic().SelectedIndex;

        //�I��ύX
        public void EmulateChangeSelectedIndex(int index) => this.Dynamic().SelectedIndex = index;

        //�ړ�
        public void EmulateMoveBlock(int index, Point location) => this.Dynamic().MoveBlock(index, location);
    }
}
