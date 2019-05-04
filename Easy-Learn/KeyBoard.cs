using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class KeyBoard : UserControl
    {
        public KeyBoard()
        {
            InitializeComponent();
            InitButtons();
            SetStyle();

            this.TabStop =
            this.panel1.TabStop =
            this.panel2.TabStop =
            this.panel3.TabStop = false;
            //foreach (Button bt in buttons) 
            //    bt.TabStop = false;
            //btHelp.TabStop = false;
        }

        public ScoreData ScoreData;
        bool alreadyHaveErrorForCurrentSymbol = false;

        #region redirect KeyDown event
        protected override void OnKeyDown(KeyEventArgs e)
        {
           // base.OnKeyDown(e);
        }

        void btHelp_KeyDown(object sender, KeyEventArgs e)
        {
           // this.OnKeyDown(e);
        }

        void bt_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO: не приходит события с нажатия Enter
            // throw new NotImplementedException();
        }
        #endregion
        
        #region InitButtons
        string[] groups = new string[] {
            "qwsd",  "rtfg",  "klp",                      
                    "hvb",
            "zxc",          "jnm",
            // vowel
            "aey", "uio",
        };
        Button[] buttons;
        Dictionary<char[], Button[]> symbolGroups = new Dictionary<char[], Button[]>();

        public void InitButtons()
        {
            buttons = new Button[] { 
                btQ, btW, btE,
                btR, btT, btY,
                btU, btI, btO, btP,
                // second line
                btA, btS, btD,
                btF, btG, btH,
                btJ, btK, btL,
                // third line
                btZ, btX, btC,                
                btV, btB, btN, btM,
            };

            // 
            this.btHelp.KeyDown += new KeyEventHandler(btHelp_KeyDown);
            foreach (Button bt in buttons)
                bt.KeyDown += new KeyEventHandler(btHelp_KeyDown);

            foreach (string strLow in groups)
            {
                string str = strLow.ToUpper();
                char[] chars = new char[str.Length];
                Button[] bttns = new Button[str.Length];
                int i = 0;
                foreach (char c in str)
                {
                    foreach (Button bt in buttons)
                    {
                        if (bt.Text[0] == c)
                            bttns[i] = bt;
                    }
                    chars[i++] = c;
                }
                symbolGroups.Add(chars, bttns);
            }
        }
        #endregion

        void SetStyle()
        {
            if (!Windows7.Windows7Taskbar.Windows7OrGreater)
            { // for xp and other
                foreach (Button bt in buttons)
                    AssignStyle(bt);
                AssignStyle(btHelp);
            }
        }

        bool isPopupStyle = !Windows7.Windows7Taskbar.Windows7OrGreater;

        private void AssignStyle(Button bt)
        {
            bt.KeyDown += new KeyEventHandler(bt_KeyDown);
//            bt.FlatStyle = FlatStyle.System; // Popup;
            bt.FlatStyle = FlatStyle.Popup;
            bt.ForeColor = standartColor;
            // bt.Font = new Font("Times New Roman", 13);
            //bt.UseVisualStyleBackColor = false;
        }

        #region YesLetter & State
        private char m_YesLetter = ' ';
        /// <summary>
        /// Здесь происходит смена текущей буквы
        /// </summary>
        public char YesLetter
        {
            get { return m_YesLetter; }
            set
            {
                if (freezeCounter != 0) return;
                if (m_YesLetter != value)
                {
                    m_YesLetter = char.ToUpper(value);
                    // пройдемся по группам кнопок и состояние для текущей буквы
                    foreach (KeyValuePair<char[], Button[]> pair in symbolGroups)
                        EstablishState(pair.Value, Array.IndexOf(pair.Key, m_YesLetter) > -1);
                }
                alreadyHaveErrorForCurrentSymbol = false;
            }
        }

        Color disableColor = Color.DarkGray;
        Color standartColor = Color.Black; // SystemColors.ControlDarkDark;
        const float bigSize = 13F;
        const float smallSize = 6F;

        public void EstablishState(Button[] btns, bool isGroupForYesChar)
        {
            foreach (Button bt in btns)
            {
                 bt.Enabled = isGroupForYesChar;
                 bt.Font = new Font(bt.Name, (isGroupForYesChar ? bigSize : smallSize));
                 //bt.Font = new Font(bt.Name, (isGroupForYesChar ? 13F : 6F), (isGroupForYesChar ? FontStyle.Bold : FontStyle.Regular));
                bt.ForeColor = standartColor;
                // bt.ForeColor = isGroupForYesChar ? Color.Black : disableColor;
                //if (bt.Font.Strikeout)
                //    bt.Font = new Font(bt.Font, FontStyle.Regular);

                //                bt.Font = new Font(bt.Font, (val ? FontStyle.Bold : FontStyle.Regular));
            }
        } 
        #endregion

        public event EventHandler PressYesLetter;

        private void bt9_Click(object sender, EventArgs e)
        {
            string answerVariant = ((Button)sender).Text;
            if (answerVariant[0] == YesLetter )
            {
                this.ScoreData.CurPasses += 1;
                PressYesLetter.Invoke(this, EventArgs.Empty);
            }
            else if (sender == this.btHelp)
            {
                this.ScoreData.CurHints += 1;
                PressYesLetter.Invoke(this, EventArgs.Empty);
            }
            else DoActionOnWrongSymbol(answerVariant);
        }

        public void DoActionOnWrongSymbol(string symbol)
        {
            if(!string.IsNullOrEmpty(symbol))
            {
                foreach (Button bt in buttons)
                { 
                    if(bt.Text == symbol)
                    {
                        bt.ForeColor = Color.Red;
                        //bt.BackColor = Color.Red;
                        //if( !bt.Enabled ) // if button is not actual
                        bt.Font = new Font(bt.Font.FontFamily, bigSize, FontStyle.Strikeout);
                        if (bt.Enabled) // т.е. символ в списке из которых можно угадывать
                        {
                            if (!alreadyHaveErrorForCurrentSymbol)
                                this.ScoreData.CurErrors += 1;
                            alreadyHaveErrorForCurrentSymbol = true;
                        }
                        break;
                    }
                }                    
            }
        }

        int freezeCounter = 0;

        internal void Freeze()
        {
            freezeCounter++;
        }

        internal void UnFreeze()
        {
            freezeCounter--;
        }
    }
}
    #region YesLetterQWERTYUIOP
    //char[] c1 = new char[] { 'Q', 'W', 'S', 'D' };
    //char[] c3 = new char[] { 'Z', 'X', 'C' };

    //char[] c4 = new char[] { 'R', 'T', 'P' };
    //char[] c5 = new char[] { 'F', 'G', 'H' };
    //char[] c6 = new char[] { 'V', 'B', 'N', 'M' };

    //char[] c7 = new char[] { 'E', 'Y', 'A', 'U', 'I', 'O'};        
    //char[] c8 = new char[] { 'J', 'K', 'L' };



    //char[] c1 = new char[] { 'A', 'D', 'G', 'J', 'M', 'P', 'T', 'W' };
    //char[] c2 = new char[] { 'B', 'E', 'H', 'K', 'N', 'Q', 'U', 'X' };
    //char[] c3 = new char[] { 'C', 'F', 'I', 'L', 'O', 'R', 'V', 'Y' };
    //char[] c4 = new char[] { 'C', 'F', 'I', 'L', 'O', 'S', 'V', 'Z' };

    #endregion
