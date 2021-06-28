using System;
using System.Drawing;
using Codeer.TestAssistant.GeneratorToolKit;
using WinFormsApp;

namespace Driver.InTarget
{
    [CaptureCodeGenerator("Driver.Controls.BlockControlDriver")]
    public class BlockControlDriverGenerator : CaptureCodeGeneratorBase
    {
        BlockControl _control;

        protected override void Attach()
        {
            _control = (BlockControl)ControlObject;
            _control.SelectChanged += SelectChanged;
            _control.BlockMoved += BlockMoved;
        }

        protected override void Detach()
        {
            _control.SelectChanged -= SelectChanged;
            _control.BlockMoved -= BlockMoved;
        }

        void SelectChanged(object sender, EventArgs e)
        {
            if (!_control.Focused) return;
            AddSentence(new TokenName(), ".EmulateChangeSelectedIndex(" + _control.SelectedIndex, new TokenAsync(CommaType.Before), ");");
        }

        void BlockMoved(object sender, BlockMoveEventArgs e)
        {
            if (!_control.Focused) return;
            AddUsingNamespace(typeof(Point).Namespace);
            AddSentence(new TokenName(), ".EmulateMoveBlock(" + _control.SelectedIndex, $", new Point({e.MoveLocation.X}, {e.MoveLocation.Y})", new TokenAsync(CommaType.Before), ");");
        }
    }
}

