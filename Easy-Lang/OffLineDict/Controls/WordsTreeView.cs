using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace f
{
    public class WordsTreeView : TreeView
    {
        Brush brushLight;

        public WordsTreeView()
            : base()
        {
            this.AllowDrop = true;
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            brushLight = new SolidBrush(Common.LightColor);
        }

        #region Drag
        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (this.SelectedNode.Text != Y.sFindInWordsMore && this.SelectedNode.Text != Y.sFindInExamples)
            {
                drgevent.Effect = DragDropEffects.All;
                string text = this.SelectedNode.Text;
                if (this.SelectedNode.Tag is Card)
                    text = ((Card)this.SelectedNode.Tag).Synonyms;
                drgevent.Data.SetData("Text", text);
                base.OnDragEnter(drgevent);
            }
            else
            {
                drgevent.Effect = DragDropEffects.None;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeNode tn = this.GetNodeAt(e.Location);
            if (tn != null && tn.Bounds.Contains(e.Location) ||
                (tn != null && tn.Tag is Word && ((Word)tn.Tag).TreeNodeBounds.Contains(e.Location)))
            {
                this.SelectedNode = tn;
                if (e.Button == MouseButtons.Left)
                    this.DoDragDrop(this.SelectedNode, DragDropEffects.Copy);
            }
            base.OnMouseDown(e);
        }
        #endregion

        #region ToolTipText
        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            if (e.Node is RichTreeNode)
                ((RichTreeNode)e.Node).ToolTipText = ((RichTreeNode)e.Node).ToolTipStore;
            base.OnAfterCollapse(e);
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            if (e.Node is RichTreeNode)
                ((RichTreeNode)e.Node).ToolTipText = "";
            base.OnAfterExpand(e);
        }
        #endregion

        internal bool IsUpdatingFromBase
        {
            get
            {
                MethodInfo mi = typeof(Control).GetMethod("IsUpdating", BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null)
                {
                    bool ret = (bool)mi.Invoke(this, new object[] { });
                    return ret;
                }
                else
                    return false;
            }
        }

        //bool m_IsClearCanvas = false;
        //public bool IsClearCanvas
        //{
        //    set
        //    {
        //        this.m_IsClearCanvas = value;
        //    }
        //    get
        //    {
        //        return this.m_IsClearCanvas;
        //    }
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    if (this.IsClearCanvas)
        //    {
        //        e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
        //        return;
        //    }
        //    else base.OnPaint(e);
        //}

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Rectangle rect = e.Bounds;
            Point textStart = new Point(rect.X - 1, rect.Y);
            rect = new Rectangle(rect.X, rect.Y, rect.Width + 1, rect.Height);
            Font fntDefault = e.Node is RichTreeNode ? ((RichTreeNode)e.Node).Font : this.Font;
            if (e.Node.Tag is Word)
            {
                textStart = new Point(rect.X - 1, rect.Y - 2);
                fntDefault = new Font(this.Font.Name, 9.75F, FontStyle.Bold); //Bold Regular
                int width = TextRenderer.MeasureText(e.Node.Text, fntDefault).Width;
                rect = new Rectangle(rect.X, rect.Y, width, rect.Height);
                if (e.Node.Tag is Word && ((Word)e.Node.Tag).TreeNodeBounds.IsEmpty && rect.X != -1) // rect.X == -1 это ложное срабатывание
                {
                    ((Word)e.Node.Tag).TreeNodeBounds = rect;
                }
            }
            //   Font fntBold = new Font(this.Font, FontStyle.Regular);

            #region уборка лишнего перерисовывания вложенных скрытых узлов с нулевой y координатой
            if (this.IsUpdatingFromBase)
                return;
            // IsUpdatingFromBase == true а нам почему то приходят такие координаты, y тоже недоделанный равен 0, хотя находится на вложенных узлах
            if (rect.X == -1) // rect.X == 0
                return;
            TreeNode tnParent = e.Node.Parent;
            while (tnParent != null)
            {
                if (!tnParent.IsExpanded)
                    return;
                tnParent = tnParent.Parent;
            }
            //if (e.Bounds.Y == 0)
            //Console.WriteLine(e.Node.Level.ToString() + " X-" + e.Bounds.X.ToString() + " Y-" + e.Bounds.Y.ToString() + e.Node.Text); 
            #endregion

            bool isSelected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            #region Get boldes index from parts
            List<int> boldes = new List<int> { };
            List<string> parts = new List<string> { };
            if (e.Node is RichTreeNode && !string.IsNullOrEmpty(((RichTreeNode)e.Node).HTMLText))
            {
                string[] partsRaw = ((RichTreeNode)e.Node).HTMLText.Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < partsRaw.Length; ++i)
                {
                    if (partsRaw[i] == "b" && partsRaw[i + 2] == "/b")
                    {
                        parts.Add(partsRaw[i + 1]);
                        boldes.Add(parts.Count - 1);
                        i = i + 2;
                    }
                    else
                        parts.Add(partsRaw[i]);
                }
            }
            #endregion

            if (boldes.Count == 0 && !isSelected)
            {
                TextRenderer.DrawText(e.Graphics, e.Node.Text, fntDefault, textStart, SystemColors.ControlText);
            }
            else
            {
                string clearText = e.Node.Text;
                if (isSelected)
                {
                    if (this.Focused)
                    {
                        e.Graphics.FillRectangle(Brushes.Gainsboro, rect);
                        ControlPaint.DrawBorder(e.Graphics, rect, Color.Gray, ButtonBorderStyle.Solid);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, rect);
                        ControlPaint.DrawBorder(e.Graphics, rect, Color.Gray, ButtonBorderStyle.Solid);
                    }
                }
                if (boldes.Count == 0)
                {
                    TextRenderer.DrawText(e.Graphics, clearText, fntDefault, textStart, SystemColors.ControlText);
                }
                else
                { // отрисовка текста с маркером
                    int _partStartX = textStart.X;
                    int _beforeLength = 0;
                    string _beforeText = "";

                    for (int i = 0; i < parts.Count; i++)
                    {
                        string _part = parts[i];
                        int widthBolded = TextRenderer.MeasureText(_part, fntDefault).Width;
                        #region отрисовка выделения цветом
                        if (boldes.IndexOf(i) != -1)
                        {
                            Point starForMarker = new Point(_partStartX + _beforeLength + 3, textStart.Y);
                            Rectangle boldedRect = new Rectangle(starForMarker, new Size(widthBolded - 3 * 2, rect.Height)); // 3 * 2 потому что с двух сторон "отрезаем" маркер
                            e.Graphics.FillRectangle(brushLight, boldedRect); // Brushes.Gainsboro
                        }
                        #endregion

                        Point starForPart = new Point(_partStartX + _beforeLength, textStart.Y);
                        TextRenderer.DrawText(e.Graphics, _part, fntDefault,
                           starForPart, Color.Black, TextFormatFlags.GlyphOverhangPadding);
                        _beforeText += _part;
                        _beforeLength = TextRenderer.MeasureText(_beforeText, fntDefault).Width - 7;
                    }

                    if (isSelected) // если мы выделяли маркером текст то повторно обведем рамку
                    {
                        ControlPaint.DrawBorder(e.Graphics, rect, Color.Gray, ButtonBorderStyle.Solid);
                    }
                    clearText = _beforeText; // для дальнейшей прорисовки
                }
            }
            if (e.Node.Tag is Word)
            {
                int xStart = rect.X + rect.Width;
                Point pointIcon = new Point(xStart + step * 3, rect.Y);
                e.Graphics.DrawImage(f.Properties.Resources.closeNode16, pointIcon);

                if (((Word)e.Node.Tag).IsDubbing)
                {
                    pointIcon = new Point(xStart + step, rect.Y - 1);
                    e.Graphics.DrawImage(f.Properties.Resources.playWord16, pointIcon);
                }

                //if (e.Node.Checked)
                //{
                //    pointIcon = new Point(xStart + step*5, rect.Y - 1);
                //    e.Graphics.DrawImage(f.Properties.Resources.AddToVocabulary, pointIcon);
                //}
            }
            base.OnDrawNode(e);
        }

        int step = 16;
        int iconWidth = 16;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            TreeNode tn = this.GetNodeAt(e.Location);
            if (tn != null && tn.Tag is Word)
            {
                int aberration = 8;
                int endBounds = ((Word)tn.Tag).TreeNodeBounds.X + ((Word)tn.Tag).TreeNodeBounds.Width;

                int iClose = e.Location.X - endBounds - step * 3;
                if (0 < iClose && iClose < iconWidth + aberration)
                {
                    OnRemoveNode(new TreeViewEventArgs(tn, TreeViewAction.Unknown));
                }

                iClose = e.Location.X - endBounds - step * 5;
                if (0 < iClose && iClose < iconWidth + aberration)
                {
                    OnAddToVocabulary(new TreeViewEventArgs(tn, TreeViewAction.Unknown));
                }


                int iSpeak = e.Location.X - endBounds - step;
                if (0 - aberration * 2 < iSpeak && iSpeak < iconWidth + aberration * 2)
                {
                    ((Word)tn.Tag).PlayWord();
                }
            }
            base.OnMouseClick(e);
        }

        public event TreeViewEventHandler Remove;

        protected void OnRemoveNode(TreeViewEventArgs e)
        {
            if (Remove != null)
            {
                Remove(this, e);
            }
        }

        public event TreeViewEventHandler AddToVocabulary;

        protected void OnAddToVocabulary(TreeViewEventArgs e)
        {
            if (AddToVocabulary != null)
            {
                AddToVocabulary(this, e);
            }
        }
    }
}