using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public class EnterLine : TextBox
    {
        public EnterLine()
            : base()
        {
            this.AllowDrop = true;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            string text = null;
            // TreeNode node = null;
            //if (Array.IndexOf(drgevent.Data.GetFormats(), "System.Windows.Forms.TreeNode") != -1)
            //    node = drgevent.Data.GetData("System.Windows.Forms.TreeNode") as TreeNode;
            //if (Array.IndexOf(drgevent.Data.GetFormats(), "RichTreeNode") != -1)
            //    node = drgevent.Data.GetData("RichTreeNode") as TreeNode;            
            //if (node != null)
            //{
            //    text = node.Text;
            //}
            //else 
            if (Array.IndexOf(drgevent.Data.GetFormats(), "Text") != -1)
            {
                text = drgevent.Data.GetData("Text") as string;
            }

            string words = "";
            string delimiter = "";
            foreach (string word in text.Split(';', ',', '.', '?', '!'))
            {
                words += delimiter + word.Trim();
                delimiter = "\r\n";
            }

            if (!string.IsNullOrEmpty(words))
            {
                if (this.SelectionLength == 0)
                    this.Text = words + "\r\n" + this.Text;
                else
                {
                    this.SelectedText = words;
                }
            }
            base.OnDragDrop(drgevent);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if ((Array.IndexOf(drgevent.Data.GetFormats(), "System.Windows.Forms.TreeNode") != -1) ||
                (Array.IndexOf(drgevent.Data.GetFormats(), "RichTreeNode") != -1) ||
                (Array.IndexOf(drgevent.Data.GetFormats(), "Text") != -1))
                drgevent.Effect = DragDropEffects.Copy;
            base.OnDragEnter(drgevent);
        }
    }
}