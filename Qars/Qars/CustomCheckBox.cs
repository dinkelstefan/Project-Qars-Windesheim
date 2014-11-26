//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Windows.Forms.VisualStyles;

//namespace Qars
//{
//    public class CustomCheckBox : Control
//    {
//        private Rectangle textRectangleValue = new Rectangle();
//        private bool clicked = false;
//        private CheckBoxState state = CheckBoxState.UncheckedNormal;

//        public CustomCheckBox(int x, int y)
//            : base()
//        {
//            this.Location = new Point(x, y);
//            this.Size = new Size(14, 14);
//        }

//        // Draw the check box in the current state. 
//        protected override void OnPaint(PaintEventArgs e)
//        {
//            base.OnPaint(e);

//            CheckBoxRenderer.DrawCheckBox(e.Graphics,
//                ClientRectangle.Location, new Rectangle(), "",
//                this.Font, TextFormatFlags.HorizontalCenter,
//                clicked, state);
//        }

//        // Draw the check box in the checked or unchecked state, alternately. 
//        protected override void OnMouseDown(MouseEventArgs e)
//        {
//            base.OnMouseDown(e);

//            if (!clicked)
//            {
//                clicked = true;
//                state = CheckBoxState.CheckedPressed;
//                Invalidate();
//            }
//            else
//            {
//                clicked = false;
//                state = CheckBoxState.UncheckedNormal;
//                Invalidate();
//            }
//        }

//        // Draw the check box in the hot state.  
//        protected override void OnMouseHover(EventArgs e)
//        {
//            base.OnMouseHover(e);
//            state = clicked ? CheckBoxState.CheckedHot :
//                CheckBoxState.UncheckedHot;
//            Invalidate();
//        }

//        // Draw the check box in the hot state.  
//        protected override void OnMouseUp(MouseEventArgs e)
//        {
//            base.OnMouseUp(e);
//            this.OnMouseHover(e);
//        }

//        // Draw the check box in the unpressed state. 
//        protected override void OnMouseLeave(EventArgs e)
//        {
//            base.OnMouseLeave(e);
//            state = clicked ? CheckBoxState.CheckedNormal :
//                CheckBoxState.UncheckedNormal;
//            Invalidate();
//        }
//    }
//}
