using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace f
{
    public class ComboBoxWithHistory : ComboBox
    {
        public ComboBoxWithHistory()
        { 
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            base.OnMouseWheel(e);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            string text = this.Items[e.Index].ToString();
            HistoryItem hi = this.Items[e.Index] as HistoryItem;
            if ( hi != null && hi.DictionaryProvider != null )
                    text = string.Format("{0} - ( {1} )", hi.Word, hi.DictionaryProvider.Title);

            e.DrawBackground();
            Brush br = e.State == DrawItemState.Selected ? Brushes.White : Brushes.Black;
            e.Graphics.DrawString(text, e.Font, br, e.Bounds, StringFormat.GenericDefault);
        }
    }
}
