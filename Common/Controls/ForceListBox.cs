using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace f
{
    public class ForceListBox : ListBox
    {
        Brush brushLight, brushSelected, brHints, brErrors, brPasses;
        Pen penLight;
//        public static Color LightColor = System.Drawing.Color.FromArgb(233, 233, 233);
//        public static Color LightColor = System.Drawing.Color.FromArgb(192, 192, 192); // more gray 

// синий        public readonly static Color LightColor = System.Drawing.Color.FromArgb(204, 236, 251);
// зеленый ядовитовый public readonly static Color LightColor = System.Drawing.Color.FromArgb(118, 181, 0);
      public readonly static Color LightColor = Color.FromArgb(199, 231, 138);
 //       public readonly static Color LightColor = Color.FromArgb(199, 255, 138);

     //   public static Color LightColor = System.Drawing.SystemColors.Info;

        ToolTip hintToolTip;
        public ForceListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable; //OwnerDrawFixed;
            this.hintToolTip = new ToolTip();
            //            this.hintToolTip.cl
            brushLight = new SolidBrush(LightColor);
            penLight = new Pen(LightColor, 1);
            brushSelected = new SolidBrush(CF.ExternalBorder); // more light then Brushes.Gainsboro 
            brHints = new SolidBrush(ScoreProgress.ColorHints);
            brErrors = new SolidBrush(ScoreProgress.ColorErrors);
            brPasses = new SolidBrush(ScoreProgress.ColorPasses);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);

            BeginUpdate();
            base.RefreshItems();
            EndUpdate();
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = this.Font.Height;
            // debugVar = this.Name + "  " + e.ItemHeight.ToString();

            #region для многострочного текста
            //string s = Items[e.Index].ToString();
            //SizeF sf = e.Graphics.MeasureString(s, this.Font, this.Width);
            //int htex = (e.Index == 0) ? 15 : 10;
            //e.ItemHeight = (int)sf.Height + htex;
            //e.ItemWidth = this.Width; 
            #endregion
        }

        public static string SentenceTabSymbol = "#tab#";

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            #region для многострочного текста
            ///*chk if list box has any items*/
            //if(e.Index > -1)
            //{
            //    string s = Items[e.Index].ToString();                           

            //    /*Normal items*/
            //    if((e.State & DrawItemState.Focus)==0)
            //    {
            //        e.Graphics.FillRectangle(
            //            new SolidBrush(SystemColors.Window),
            //            e.Bounds);
            //        e.Graphics.DrawString(s,Font,
            //            new SolidBrush(SystemColors.WindowText),
            //            e.Bounds);              
            //        e.Graphics.DrawRectangle(
            //            new Pen(SystemColors.Highlight),e.Bounds);              
            //    }
            //    else /*Selected item, needs highlighting*/
            //    {
            //        e.Graphics.FillRectangle(
            //            new SolidBrush(SystemColors.Highlight),
            //            e.Bounds);
            //        e.Graphics.DrawString(s,Font,
            //            new SolidBrush(SystemColors.HighlightText),
            //            e.Bounds);
            //    }
            //}
            #endregion

            if (this.Items.Count == 0 || e.Index == -1) return;
            Rectangle rect = this.GetItemRectangle(e.Index);
            //  if( rect.Height == 13 )
            //      Console.WriteLine(this.Name + " draw " + rect.Height.ToString() + " (" + debugVar + ")");

            string text = this.Items[e.Index].ToString();
            Brush backRound = Brushes.White;
            #region DrawBorder
            if (this.SelectedIndex == e.Index)
            {
                if (this.Focused)
                    backRound = brushSelected;
                else backRound = Brushes.White;

                e.Graphics.FillRectangle(backRound, rect);
                ControlPaint.DrawBorder(e.Graphics, rect, Color.Gray, ButtonBorderStyle.Solid);
            }
            else
            {
                e.Graphics.FillRectangle(backRound, rect);
            } 
            #endregion

            ISentence sentence = this.Items[e.Index] as ISentence;
            IScoreUnit scoreUnit = this.Items[e.Index] as IScoreUnit;
            ScoreData scoreData = null;
            if (scoreUnit != null && scoreUnit.IsHaveScore)
                scoreData = scoreUnit.ScoreData;

            if (sentence != null)
            {
                #region WordsToLearn
		        if (sentence.WordsToLearn.Count > 0)
                {
                    string markedText = "";
                    int startText = -1;
                    // найдем ближайшее слово справа
                    foreach (string word in sentence.WordsToLearn)
                    {
                        startText = text.ToLower().IndexOf(word.ToLower());
                        if (startText == -1) continue;
                        markedText = word;

                        int markedTextLength = markedText.Length;
                        int markedWidth = TextRenderer.MeasureText(markedText, this.Font).Width - 7;
                        int yLocation = e.Bounds.Y + 1;
                        Point starForMarker = new Point(0 + 2, yLocation);
                        if (startText != 0)
                        {
                            int widthText = TextRenderer.MeasureText(text.Substring(0, startText), this.Font).Width;
                            int correction = 7;
                            if (this.Font.Size > 11) correction += (int)(this.Font.Size - 11);
                            starForMarker = new Point(widthText - correction, yLocation + 2);
                        }
                        Rectangle boldedRect = new Rectangle(starForMarker, new Size(markedWidth, rect.Height - 2 - 3));
                        e.Graphics.FillRectangle(brushLight, boldedRect);
                        Ul.DoSmoothAngle(e.Graphics, backRound, boldedRect);                    
                        
                        // Console.WriteLine(word);
                    }
                    e.Graphics.DrawLine(penLight, 0, rect.Y, 0, rect.Y + rect.Height);
                } 
	            #endregion

                #region ScoreState
                if (scoreData != null && scoreData.PrevState != ScoreState.Unknown)
                {
                    Point starForMarker = new Point(0 + 3, e.Bounds.Y + 1);
                    string textForMeasure = "100";
                    string[] parts = text.Split('-');
                    if (parts.Length > 1) textForMeasure = parts[0];
                    int markedWidth = TextRenderer.MeasureText(textForMeasure, this.Font).Width - 9;
                    Rectangle areaForSelect = new Rectangle(starForMarker, new Size(markedWidth, rect.Height - 2));

                    if (scoreData.PrevState == ScoreState.HasError)
                        e.Graphics.FillRectangle(brErrors, areaForSelect);
                    else if (scoreData.PrevState == ScoreState.Warning)
                        e.Graphics.FillRectangle(brHints, areaForSelect);
                    else if (scoreData.PrevState == ScoreState.Complete)
                        e.Graphics.FillRectangle(brPasses, areaForSelect);

                    Ul.DoSmoothAngle(e.Graphics, backRound, areaForSelect);                    
                    //e.Graphics.DrawImage(im, rect.Location);
                } 
                #endregion
            }

            #region отрисовка маркера выделяющего текст (старый (только для словаря) работающий механизм)
            if (this.MarkedItemIndex == e.Index && !string.IsNullOrEmpty(MarkedText) && text.IndexOf(this.MarkedText) != -1)
            {
                int startText = text.IndexOf(this.MarkedText);
                int markedTextLength = this.MarkedText.Length;
                int markedWidth = TextRenderer.MeasureText(this.MarkedText, this.Font).Width - 3;
                Point starForMarker = new Point(0 + 1, e.Bounds.Y + 1);
                if (startText != 0)
                {
                    starForMarker = new Point(TextRenderer.MeasureText(text.Substring(0, startText), this.Font).Width - 7, rect.Y + 1);
                }
                Rectangle boldedRect = new Rectangle(starForMarker, new Size(markedWidth, rect.Height - 2));
                e.Graphics.FillRectangle(brushLight, boldedRect);
            }
            #endregion

            Point pointStart = new Point(e.Bounds.X - 1, e.Bounds.Y-1);
            if (text.StartsWith(SentenceTabSymbol))
            {
                pointStart = new Point(e.Bounds.X + 15, e.Bounds.Y - 2);
                text = text.Replace(SentenceTabSymbol, "").TrimStart(' ');
            }
            TextRenderer.DrawText(e.Graphics, text, this.Font, pointStart, SystemColors.ControlText);
            // draw not black numbers
            string number = text.IndexOf('.') > 0 ? text.Substring(0, text.IndexOf('.') + 1) : ""; // this.Items[e.Index].ToString("#");
            if( !string.IsNullOrEmpty(number))
                TextRenderer.DrawText(e.Graphics, number, this.Font, pointStart, Color.Gray);
            //  base.OnDrawItem(e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            this.Refresh(); // RefreshItems - зависнет
            //TODO: update vrttical scrol
            base.OnSelectedIndexChanged(e);
        }

        public void PageScroll(bool isUp)
        {
            IntPtr direction = (IntPtr)Ul.SB_PAGEDOWN;
            if (isUp)
                direction = (IntPtr)Ul.SB_PAGEUP;
            Ul.SendMessage2(this.Handle, Ul.WM_VSCROLL, direction, IntPtr.Zero);
        }

        public int GetVisibleCount()
        {
            if (this.Items.Count == 0)
                return 0;
            return this.Height / this.GetItemHeight(0);
        }

        public void ScrollSelectedToCenter()
        {
            Rectangle rect = this.GetItemRectangle(this.SelectedIndex);
            int selectedOrder = (int)((rect.Y + rect.Height) / rect.Height) - 1;
            int visibleItemsCount = GetVisibleCount();
            int scrollCount = 0;
            // определим направление
            IntPtr direction = (IntPtr)Ul.SB_LINEUP;
            if (selectedOrder < visibleItemsCount / 2)
            {
                scrollCount = visibleItemsCount / 2 - selectedOrder;
            }
            else
            {
                direction = (IntPtr)Ul.SB_LINEDOWN;
                scrollCount = selectedOrder - visibleItemsCount / 2;
            }
            for (int i = 0; i < scrollCount; ++i)
            {
                Ul.SendMessage2(this.Handle, Ul.WM_VSCROLL, direction, IntPtr.Zero);
                //                Console.WriteLine(selectedOrder.ToString() + " -> " + scrollCount.ToString());
            }
        }

        bool m_ShowToolTip = false;
        public bool ShowToolTip
        {
            get { return this.m_ShowToolTip; }
            set { this.m_ShowToolTip = value; }
        }

        int prevItemsIndex = -1;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (ShowToolTip)
            {
                int i = this.IndexFromPoint(e.Location);
                if (prevItemsIndex == i) return;
                prevItemsIndex = i;
                if (i != -1 && this.Items.Count > i) // когда списка нет почему то возвращается 65535 поэтому проверим "this.Items.Count > i"
                {
                    string text = this.Items[i].ToString();
                    int widthText = TextRenderer.MeasureText(text, this.Font).Width;
                    if (widthText + 10 > this.Width)
                        this.hintToolTip.Show(text, this); // , e.Location
                    else
                        this.hintToolTip.Hide(this);
                }
                else this.hintToolTip.Hide(this);
            }
            base.OnMouseMove(e);
        }

        string m_MarkedText = null;
        public string MarkedText
        {
            get
            {
                return m_MarkedText;
            }
            set
            {
                if (m_MarkedText != value)
                {
                    m_MarkedText = value;
                    this.Refresh();
                }
            }
        }

        int m_MarkedItemIndex = -1;
        public int MarkedItemIndex
        {
            get
            {
                return m_MarkedItemIndex;
            }
            set
            {
                if (m_MarkedItemIndex != value)
                {
                    m_MarkedItemIndex = value;
                    this.Refresh();
                }
            }
        }
    }
}
