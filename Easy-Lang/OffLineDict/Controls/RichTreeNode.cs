using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class RichTreeNode : TreeNode
    {
        public RichTreeNode(string text, Font font)
        {
            this.Text = Card.ClearHtml(text);
            if (this.Text.Length != text.Length)
                this.m_HTMLText = text;
            m_Font = font;
        }

        string m_ToolTipStore;

        public string ToolTipStore
        {
            get { return m_ToolTipStore; }
            set { m_ToolTipStore = value; } 
        }

        string m_HTMLText = "";
        public string HTMLText { 
            get { return this.m_HTMLText; } 
//            set { this.m_HTMLText = value; } 
        }

        Font m_Font = null;
        public Font Font
        {
            get { return this.m_Font; }
        }
    }
}