using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.IO.Compression;

namespace f
{
    public partial class Y : UserControl
    {
        #region ctor && Load
        Font m_FontForExample = null;
        Font m_FontForPartSpeech = null;
        Font m_FontForServiceNode = null;

        public Y()
        {
            InitializeComponent();

            m_FontForExample = this.tv1.Font;
            //m_FontForSpeechPart = new Font(this.tv1.Font, FontStyle.Underline);
            m_FontForPartSpeech = new Font(this.tv1.Font.Name, this.tv1.Font.Size - 1, FontStyle.Underline);
            m_FontForServiceNode = new Font(this.tv1.Font.Name, this.tv1.Font.Size, FontStyle.Italic);

            this.txWord.Text = "";
            this.txSelectedCard.Text = "";
            ShowIndex();
            #region Lucida Sans Unicode
            //string fontName = "Lucida Sans Unicode";
            //Font fnt = new Font(fontName, 11);
            //if (fnt.Name != fontName)
            //    MessageBox.Show("Font " + fontName + " not found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else
            //{
            //    this.txPhonetic.Font = fnt;
            //    this.txWord.Font = fnt;
            //} 
            #endregion
            this.tv1.Nodes.Clear();
            this.tv1.BeforeCheck += new TreeViewCancelEventHandler(tv1_BeforeCheck);
            this.tv1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv1_BeforeExpand);
            this.tv1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterCheck);
            this.tv1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterExpand);
            this.tv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterSelect);
            this.tv1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterExpand);
            this.tv1.AddToVocabulary += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AddToVocabulary);
            this.tv1.Remove += new System.Windows.Forms.TreeViewEventHandler(this.tv1_Remove);
            this.tv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tv1_KeyDown);
            AssignHelp(this.Controls);

            this.miAutohistoryforcards.Click += new System.EventHandler(this.miAutohistoryforcards_Click);
            this.menuForTree.Opening += new System.ComponentModel.CancelEventHandler(this.menuForTree_Opening);
            this.miAutohistoryforcards.Checked = CF.GetValue(autohistoryForCards, bool.FalseString) == bool.TrueString;
        }

        #region ForHistory
        internal const string autohistoryForCards = "autohistoryForCards";

        private void menuForTree_Opening(object sender, CancelEventArgs e)
        {
            if (!miAutohistoryforcards.Checked)
            {
                if (miAutohistoryforcards.Image != null)
                    miAutohistoryforcards.Image = null;
            }
            else
            {
                if (miAutohistoryforcards.Image == null)
                    this.miAutohistoryforcards.Image = global::f.Properties.Resources.CheckBox;
            }
        }

        private void miAutohistoryforcards_Click(object sender, EventArgs e)
        {
            CF.SetValue(autohistoryForCards, this.miAutohistoryforcards.Checked.ToString());
        }
        #endregion

        void AssignHelp(Control.ControlCollection collection)
        {
            foreach (Control control in collection)
            {
                control.KeyDown += new KeyEventHandler(ShowHelp);
                AssignHelp(control.Controls);
            }
        }

        private void Y_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.txWord;
        }
        #endregion

        #region Checks
        private void tv1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is Card)
            {
                e.Node.Checked = true;
            }
        }

        private void tv1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            try
            {
                this.tv1.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterCheck);
                // с низлежащими все просто назначаем и всё
                AssignDeep(e.Node);
                AssignUpward(e.Node); // для правильности перед этой строкой AssignUpward выполним предыдущую с методом AssignDeep
            }
            finally
            {
                this.tv1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterCheck);
            }
        }

        void tv1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            //if( e.Node.Nodes.Count > 0 )
            //    e.Cancel = e.Node.Nodes[0].Text == sProcessingCaption;
            e.Cancel = !(e.Node.Tag is Card || IsHaveInnerCard(e.Node));
        }

        bool IsHaveInnerCard(TreeNode node)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.Tag is Card || IsHaveInnerCard(tn))
                    return true;
            }
            return false;
        }

        void AssignUpward(TreeNode node)
        {
            if (node.Parent == null) return;
            if (node.Parent.Tag is Card) return;
            if (node.Checked)
            {
                node.Parent.Checked = true;
            }
            else
            {
                if (node.Parent.Checked && !HaveChecked(node.Parent, node)) // excluded передаём т.к. если внутри есть отмеченный гипоним то наверно надо это дело исключить
                    node.Parent.Checked = false;
            }
            AssignUpward(node.Parent);
        }

        void AssignDeep(TreeNode treeNode)
        {
            if (treeNode.Tag is Card) return;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.Checked = treeNode.Checked;
                AssignDeep(tn);
            }
        }

        bool HaveChecked(TreeNode treeNode, TreeNode excluded)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (excluded == tn) continue;
                if (tn.Checked || HaveChecked(tn, null))
                    return true;
            }
            return false;
        }

        private void tv1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Text == sFindInWordsMore || e.Node.Text == sFindInExamples || e.Node.Tag is List<Card>)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.tv1.BeginUpdate();
                    e.Node.Nodes.Clear();
                    // поиск в примерах
                    if (e.Node.Text == sFindInExamples && e.Node.Parent != null && e.Node.Parent.Tag is Word)
                    {
                        List<string> list = D.GetExamples(((Word)e.Node.Parent.Tag).Text);
                        foreach (string example in list)
                        {
                            e.Node.Nodes.Add(new RichTreeNode(example, m_FontForExample));
                        }
                    }
                    // поиск в других словах
                    else if (e.Node.Text == sFindInWordsMore && e.Node.Parent != null && e.Node.Parent.Tag is Word)
                    {
                        string findedPartWord = ((Word)e.Node.Parent.Tag).Text;
                        foreach (string word in D.Index.Keys)
                        {
                            if (word.IndexOf(findedPartWord) != -1 && word != findedPartWord)
                            {
                                TreeNode tnWord = new TreeNode(word.ToString());
                                e.Node.Nodes.Add(tnWord);
                                FillNode(new Word(word), tnWord);
                            }
                        }
                    }
                    else
                    { // здесь заполняются отложенные узлы
                        ArrayList removed = new ArrayList();
                        foreach (Card delayedCard in (List<Card>)e.Node.Tag) // здесь не учитывается индекс частоты использования слов
                        {
                            //TODO:                        if (htOwners.Contains(w.ID)) continue; // т.е. этот узел уже был
                            delayedCard.DelayedFill();
                            this.AddCardToWordNode(e.Node, delayedCard, 0);
                        }
                        e.Node.Tag = null;
                    }
                }
                finally
                {
                    this.tv1.EndUpdate();
                    this.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        List<string> m_Words = new List<string> { };
        List<string> Words
        {
            get
            {
                m_Words.Clear();
                // при перетаксивании нам могут попасть строки не только с "\r\n" но и просто '\n'
                foreach (string text in this.txWord.Text.Split('\r', '\n'))
                {
                    string word = Word.GetLetters(text).ToLower();
                    if (!string.IsNullOrEmpty(word) && m_Words.IndexOf(word) == -1)
                        m_Words.Insert(0, word);
                }
                return m_Words;
            }
        }

        #region Show in dictionary
        string previousWord = "";
        private void txWord_TextChanged(object sender, EventArgs e)
        {
            List<string> wordsList = this.Words;

            //if( this.IsHandleCreated )
            //    base.BeginInvoke(new MethodInvoker(UpdateTree)); Words должен быть потоконезависимым
            UpdateTree();

            if (wordsList.Count > 0)
            {
                string firstWord = wordsList[wordsList.Count - 1];
                #region выделяем группу
                string maxCoincidedGroupText = "";
                object itemGroupToSelect = null;

                int[] maxIndexs = new int[] { -1, -1, -1, -1 };
                for (int i = 0; i < this.listItemGroups.Items.Count; ++i)
                {
                    //                    foreach (List<IndexItem> list in this.listItemGroups.Items)
                    foreach (string groupName in this.listItemGroups.Items[i].ToString().Split(';'))
                    {
                        string _groupName = groupName.Trim();

                        int charInd = 0;
                        string _newCoincidedText = "";
                        foreach (char c in firstWord)
                        {
                            if (_groupName.Length > charInd)
                            {
                                if (c == _groupName[charInd])
                                    _newCoincidedText += c;
                                else
                                    break;
                                ++charInd;
                            }
                            else
                                break;
                        }
                        if (_newCoincidedText.Length > maxCoincidedGroupText.Length)
                        {
                            maxCoincidedGroupText = _newCoincidedText;
                            itemGroupToSelect = this.listItemGroups.Items[i];
                        }
                    }
                }

                if (itemGroupToSelect != null && this.listItemGroups.SelectedItem != itemGroupToSelect)
                {
                    try
                    {
                        this.listItemGroups.BeginUpdate();
                        this.listItemGroups.SelectedItem = itemGroupToSelect;
                        this.listItemGroups.MarkedItemIndex = this.listItemGroups.SelectedIndex;
                        this.listItemGroups.MarkedText = maxCoincidedGroupText;
                        this.listItemGroups.ScrollSelectedToCenter();
                    }
                    finally
                    {
                        this.listItemGroups.EndUpdate();
                    }
                }
                else if (itemGroupToSelect == null)
                {
                    this.listItemGroups.MarkedItemIndex = -1;
                    this.listItemGroups.MarkedText = "";
                }
                #endregion
                #region выделяем слово
                string maxCoincidedText = "";
                IndexItem itemToSelect = null;
                foreach (IndexItem indexItem in this.listWords.Items)
                {
                    int charInd = 0;
                    string _newCoincidedText = "";
                    foreach (char c in firstWord)
                    {
                        if (indexItem.Word.Length > charInd)
                        {
                            if (c == indexItem.Word[charInd])
                                _newCoincidedText += c;
                            else
                                break;
                            ++charInd;
                        }
                        else
                            break;
                    }
                    if (_newCoincidedText.Length > maxCoincidedText.Length)
                    {
                        maxCoincidedText = _newCoincidedText;
                        itemToSelect = indexItem;
                    }
                }

                if (itemToSelect != null && this.listWords.SelectedItem != itemToSelect)
                {
                    try
                    {
                        this.listWords.BeginUpdate();
                        this.listWords.SelectedItem = itemToSelect;
                        this.listWords.MarkedItemIndex = this.listWords.SelectedIndex;
                        this.listWords.MarkedText = maxCoincidedText;
                        this.listWords.ScrollSelectedToCenter();
                    }
                    finally
                    {
                        this.listWords.EndUpdate();
                    }
                }
                else if (itemToSelect == null)
                {
                    this.listWords.MarkedText = "";
                    this.listWords.MarkedItemIndex = -1;
                }
                else if (this.listWords.SelectedItem == itemToSelect)
                {// выделенный текст изменился а выбранный пункт остался
                    this.listWords.MarkedText = maxCoincidedText;
                }
                #endregion
            }
            else
            {
                this.listItemGroups.MarkedText = "";
                this.listItemGroups.MarkedItemIndex = -1;
                this.listWords.MarkedText = "";
                this.listWords.MarkedItemIndex = -1;
            }

            #region PlayWord
            foreach (TreeNode tn in this.tv1.Nodes)
            {
                Word wr = tn.Tag as Word;
                if (wr != null && wr.IsDubbing)
                {
                    if (previousWord != wr.Text) // тобы не играть по 10 раз слово
                    {
                        wr.PlayWord();
                        previousWord = wr.Text;
                    }
                    break;
                }
            }
            #endregion

            txSelectedCard_TextChanged(this.txWord, EventArgs.Empty);
        }

        void UpdateTree()
        {
            #region узнаем что удалить а что добавить
            List<string> wordsList = this.Words;
            List<string> oldWordsList = new List<string> { };
            // найдем старые узлы которые не присутствуют в списке со словами
            List<TreeNode> toDelete = new List<TreeNode> { };
            foreach (TreeNode tn in tv1.Nodes)  // перебираем существующие слово-узлы
            {
                string word = ((Word)tn.Tag).InitText;
                if (wordsList.IndexOf(word) == -1)
                    toDelete.Add(tn);
                else
                    oldWordsList.Add(word);
            }
            List<Word> newWordsList = new List<Word> { };
            foreach (string wordText in wordsList)
            {
                //TODO: нужен тот порядок слов в котором находятся слова в окне ввода

                if (oldWordsList.IndexOf(wordText) == -1)
                {
                    Word word = new Word(wordText);
                    if (!word.IsEmpty)
                        newWordsList.Add(word);
                }
            }
            #endregion
            if (newWordsList.Count > 0 || toDelete.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tv1.BeginUpdate();
                    //    this.tv1.IsClearCanvas = true;
                    // старые старые узлы 
                    foreach (TreeNode tn in toDelete)
                        tv1.Nodes.Remove(tn);

                    foreach (Word word in newWordsList)
                    {
                        TreeNode tnWord = new TreeNode(word.ToString());
                        this.tv1.Nodes.Insert(0, tnWord);
                        FillNode(word, tnWord);
                    }

                    // для красоты
                    if (tv1.SelectedNode == null && tv1.Nodes.Count > 0 && tv1.Nodes[0].Nodes.Count > 0 && tv1.Nodes[0].Nodes[0].Nodes.Count > 0)
                    {
                        tv1.SelectedNode = tv1.Nodes[0].Nodes[0].Nodes[0]; // TODO: имеет смысл выбирать узел который придется раскрывать
                        //    tv1.SelectedNode.Expand();
                    }
                    if (tv1.SelectedNode == null)
                        this.txSelectedCard.Text = "";
                }
                finally
                {
                    //this.tv1.EndUpdate();
                    //this.tv1.BeginUpdate();

                    this.tv1.EndUpdate(); // полностью очистим canvas
                    //                    this.tv1.IsClearCanvas = false;
                    this.tv1.Refresh(); // чтобы текст не прорисовывался поверх другого текста

                    this.Cursor = Cursors.Default;
                }
            }
        }

        internal static readonly string sFindInWordsMore = "find in words ...";
        internal static readonly string sFindInExamples = "find in examples ...";
        //        string delayedTreeNodeCaption = "-> ...";
        //        string delayedTreeNodeHint = "-> ... (more definitions) ... ";
        string sProcessingCaption = "please wait";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        void FillNode(Word word, TreeNode tnRootWord)
        {
            if (word.IsEmpty) return;
            tnRootWord.Tag = word;

            if (!word.IsEmpty)
            {
                #region noun verb advreb adjective
                if (word.Nouns.Count > 0)
                {
                    RichTreeNode tn = new RichTreeNode("noun", m_FontForPartSpeech);
                    tnRootWord.Nodes.Add(tn);
                    foreach (Card card in word.Nouns)
                        AddCardToWordNode(tn, card, word.Nouns.IndexOf(card) + 1);
                    tn.Expand();
                }
                if (word.Verbs.Count > 0)
                {
                    RichTreeNode tn = new RichTreeNode("verb", m_FontForPartSpeech);
                    tnRootWord.Nodes.Add(tn);
                    foreach (Card card in word.Verbs)
                        AddCardToWordNode(tn, card, word.Verbs.IndexOf(card) + 1);
                    tn.Expand();
                }
                if (word.Adverbs.Count > 0)
                {
                    RichTreeNode tn = new RichTreeNode("advreb", m_FontForPartSpeech);
                    tnRootWord.Nodes.Add(tn);
                    foreach (Card card in word.Adverbs)
                        AddCardToWordNode(tn, card, word.Adverbs.IndexOf(card) + 1);
                    tn.Expand();
                }
                if (word.Adjectives.Count > 0)
                {
                    RichTreeNode tn = new RichTreeNode("adjective", m_FontForPartSpeech);
                    tnRootWord.Nodes.Add(tn);
                    foreach (Card card in word.Adjectives)
                        AddCardToWordNode(tn, card, word.Adjectives.IndexOf(card) + 1);
                    tn.Expand();
                }
                #endregion
                TreeNode tnFindInExamples = tnRootWord.Nodes.Add(sFindInExamples);
                tnFindInExamples.Nodes.Add(sProcessingCaption); // обязательно надо ProcessingCaption, иначе незаполненный узел будет помечатся для тренажера
                tnFindInExamples = tnRootWord.Nodes.Add(sFindInWordsMore);
                tnFindInExamples.Nodes.Add(sProcessingCaption);

                tnRootWord.Expand();
            }
        }

        private void AddCardToWordNode(TreeNode tnRootWord, Card card, int partSpeechCounter)
        {
            string cardCaption;
            if (partSpeechCounter > 0) // значит это самые верхние узлы
            {
                String _partSpeechCounterString = GetFineLength((partSpeechCounter++).ToString() + ")", 5);
                if (card.CountOfUsage > 0) // && показывать кол-во употреблений
                {
                    string usage = GetFineLength(card.CountOfUsage.ToString(), 4); // usage.Length == 6
                    cardCaption = string.Format("{0}-{2} {1}", _partSpeechCounterString, card.Synonyms, usage);
                }
                else cardCaption = string.Format("{0} {2} {1}", _partSpeechCounterString, card.Synonyms, "      ");// "      ".length = 6
            }
            else // это вложенные узлы
                cardCaption = string.Format("{0}   {1} ", PartSpeechUtil.GetReadableName(card.PartSpeech), card.Synonyms);

            RichTreeNode partSpeechNode = new RichTreeNode(cardCaption, this.tv1.Font);
            tnRootWord.Nodes.Add(partSpeechNode);
            partSpeechNode.ToolTipText = card.ToolTipText;
            partSpeechNode.ToolTipStore = card.ToolTipText;
            partSpeechNode.Tag = card;
            // Meanings
            foreach (string mean in card.Meanings)
                partSpeechNode.Nodes.Add(mean);
            // Examples
            if (card.Examples.Length > 0)
            {
                foreach (string ex in card.Examples)
                {
                    partSpeechNode.Nodes.Add(new RichTreeNode(ex, m_FontForExample));
                    //if (card.Examples.Length == 1)
                    //{
                    //    partSpeechNode.Nodes.Add(new RichTreeNode("example: " + card.Examples[0]));
                    //    //                    partSpeechNode.Nodes.Add(new RichTreeNode(card.Examples[0]));
                    //}
                    //else
                    //{
                    //    TreeNode examples = partSpeechNode.Nodes.Add("examples:");
                    //        examples.Nodes.Add(new RichTreeNode(ex));
                    //    examples.ExpandAll();
                    //}
                }
            }

            // delayNodes - antonym, see also .....  
            Dictionary<string, RichTreeNode> delayNodes = new Dictionary<string, RichTreeNode> { };
            foreach (Card delayCard in card.Childs.Keys)
            {
                string delayNodeName = card.Childs[delayCard];
                RichTreeNode delayNode = null;
                delayNodes.TryGetValue(delayNodeName, out delayNode);
                if (delayNode == null) // если не нашли в коллекции то создадим
                {
                    delayNode = new RichTreeNode(delayNodeName, m_FontForServiceNode);
                    partSpeechNode.Nodes.Add(delayNode);
                    delayNodes.Add(delayNodeName, delayNode);
                }
                delayNode.Tag = new List<Card> { };
                ((List<Card>)delayNode.Tag).Add(delayCard);
                delayNode.Nodes.Add(this.sProcessingCaption); // обязательно надо ProcessingCaption, иначе незаполненный узел будет помечатся для тренажера
            }
        }

        public static string GetFineLength(string val, int length)
        {
            for (int i = val.Length; i < length; ++i)
            {
                val += ' ';
            }
            return val;
        }
        #endregion

        #region Debug
        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in tv1.Nodes)
                ShowTag(tn);
        }

        void ShowTag(TreeNode node)
        {
            foreach (TreeNode tn in node.Nodes)
            {
                if (tn.Tag != null)
                    tn.Text = tn.Tag.ToString();
                ShowTag(tn);
            }
        }
        #endregion

        #region MenuItem s


        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   M.PasteText(this.txWord, Clipboard.GetText());
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   M.CutText(this.txWord);
        }

        //ArrayList toLearn = new ArrayList();

        //void GetLearned(TreeNodeCollection collection)
        //{
        //    foreach(TreeNode tn in collection )
        //    {
        //        if (tn.Checked)
        //            toLearn.Add(tn);
        //        GetLearned(tn.Nodes);
        //    }
        //}

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string buffer = null;
            if (this.tv1.Focused)
            {
                if (tv1.SelectedNode != null)
                    buffer = tv1.SelectedNode.Text;
                else
                    buffer = tv1.ToString();
            }
            else if (this.txWord.Focused)
            {
                buffer = this.txWord.Text;
            }

            if (!string.IsNullOrEmpty(buffer))
                Clipboard.SetText(buffer);
        }
        #endregion

        #region tv1_KeyDown & tv1_MouseHover
        private void tv1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46 && this.tv1.SelectedNode != null && this.tv1.SelectedNode.Tag is Word)
            {
                this.tv1_Remove(this.tv1, new TreeViewEventArgs(this.tv1.SelectedNode));
            }
            else if (e.KeyValue == 45) // стрелка вправо
            {
                if (this.tv1.SelectedNode == null) return;
                this.tv1.SelectedNode.Checked = !this.tv1.SelectedNode.Checked;
                e.SuppressKeyPress = true;
            }
            //       base.OnKeyDown(e);
        }

        private void ShowHelp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                HH.ShowHelp(this, f.Properties.Resources.Help_dict); //sender as Control
            }
        }

        private void txWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 107) // + 
            {
                IndexItem indexItem = this.listWords.SelectedItem as IndexItem;
                if (indexItem != null)
                {
                    this.txWord.Text = indexItem.Word;
                    this.txWord.SelectAll();
                    e.SuppressKeyPress = true;
                }
            }
            else if (e.Control && e.KeyValue == 65) // Ctrl + A
            {
                this.txWord.SelectAll();
            }
            else if (txWord.SelectedText.Length == 0)
            {
                #region переключение фокуса на список слов
                if (e.KeyValue == 38)
                {
                    string subText = txWord.Text.Substring(0, txWord.SelectionStart);
                    if (subText.Split('\n').Length == 1)
                    {
                        int step = e.KeyValue == 38 ? 1 : 1; // this.listWords.
                        if (this.listWords.SelectedIndex - 1 > -1)
                            this.listWords.SelectedIndex = this.listWords.SelectedIndex - 1;
                        base.BeginInvoke(new MethodInvoker(ListWordsFocus));
                    }
                }
                else if (e.KeyValue == 40)
                {
                    string subText = txWord.Text.Substring(txWord.SelectionStart);
                    if (subText.Split('\n').Length == 1)
                    {
                        if (this.listWords.Items.Count > this.listWords.SelectedIndex + 1)
                            this.listWords.SelectedIndex = this.listWords.SelectedIndex + 1;
                        base.BeginInvoke(new MethodInvoker(ListWordsFocus));
                    }
                }
                else if (e.KeyValue == 33 || e.KeyValue == 34) // PageUp == 33
                {
                    this.listWords.PageScroll(e.KeyValue == 33);
                }
                #endregion
            }

        }

        void ListWordsFocus()
        {
            this.listWords.Focus();
        }
        #endregion

        private void tv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Card card = e.Node.Tag as Card;
            TreeNode tn = e.Node;
            while (card == null && tn.Parent != null)
            {
                tn = tn.Parent;
                card = tn.Tag as Card;
            }
            if (card != null) //TODO: '\r', '\n'
                this.txSelectedCard.Text = card.ToolTipText.Trim('\r', '\n');

            //if (!string.IsNullOrEmpty(e.Node.ToolTipText))
            //{
            //    string text = e.Node.ToolTipText;
            //    int iEndTextMeaning = text.IndexOf(Card.MeaningDelimiter);
            //    if (iEndTextMeaning != -1)
            //    {
            //        // начинаем с 1 т.к. пропускаем /n
            //        this.toolTip1.ToolTipTitle = text.Substring(1, iEndTextMeaning-1);
            //        text = text.Substring(iEndTextMeaning + 2);
            //    }
            //    else
            //    {
            //        this.toolTip1.ToolTipTitle = "";
            //    }
            //    this.toolTip1.Show(text, this.tv1, e.Node.Bounds.X + 33, e.Node.Bounds.Y + e.Node.Bounds.Height);
            //}
            //else
            //    this.toolTip1.Hide(this.tv1);
        }

        #region IndexItem & listWords & listItemGroups
        private void listWords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                listWords_DoubleClick(listWords, EventArgs.Empty);
                this.tv1.Focus();
            }
        }

        private void listWords_DoubleClick(object sender, EventArgs e)
        {
            if (listWords.SelectedItem == null) return;
            string increment = ((IndexItem)listWords.SelectedItem).Word + " ";
            AddWordToEnterLine(increment);
        }

        private void listWords_Enter(object sender, EventArgs e)
        {
            if (listWords.SelectedIndex == -1 && listWords.Items.Count > 0)
                listWords.SelectedIndex = 0;
        }

        IndexItemList<IndexItem> priorList;

        private void listItemGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexItemList<IndexItem> list = ((IndexItemList<IndexItem>)this.listItemGroups.SelectedItem);
            if (priorList == list) return;
            priorList = list;
            try
            {
                this.listWords.BeginUpdate();
                this.listWords.Items.Clear();
                IndexItem[] items = new IndexItem[list.Count];
                list.CopyTo(items);
                this.listWords.Items.AddRange(items);
            }
            finally
            {
                this.listWords.EndUpdate();
                this.listItemGroups.Refresh();
            }
        }

        void ShowIndex()
        {
            try
            {
                this.listItemGroups.BeginUpdate();
                this.listItemGroups.Items.Clear();
                IndexItemList<IndexItem>[] groups = new IndexItemList<IndexItem>[D.SearchIndex.Count];
                D.SearchIndex.Values.CopyTo(groups, 0);
                this.listItemGroups.Items.AddRange(groups);
            }
            finally
            {
                this.listItemGroups.EndUpdate();
            }
        }
        #endregion

        #region splitters & resize
        private void pnInWrapperDict_Resize(object sender, EventArgs e)
        {
            //      panelForSelectedCard.Height = (int)(pnInWrapperDict.Width * 0.1);
        }

        private void paListWords_Resize(object sender, EventArgs e)
        {
            listWords.Width = (int)(paListWords.Width * 0.5);
        }

        private void panelCollector_Resize(object sender, EventArgs e)
        {
            paListWords.Width = (int)(panelCollector.Width * 0.5);
        }

        private void Y_Resize(object sender, EventArgs e)
        {
            panelCollector.Height = (int)(this.Height * 0.15);
            splitter1.Refresh();
            splitter2.Refresh();
            splitter3.Refresh();
        }

        private void splitter1_Paint(object sender, PaintEventArgs e)
        {
            Splitter sp = (Splitter)sender;
            Pen pen = new Pen(Brushes.Gray);
            pen.Width = 1; // ширина сплитера 11
            if (splitter4 == sp)
                pen.DashStyle = DashStyle.Dot;
            Point p1 = new Point(5, 0);
            Point p2 = new Point(5, sp.Height);
            e.Graphics.DrawLine(pen, p1, p2);
            pen.Dispose();
        }

        private void splitter2_Paint(object sender, PaintEventArgs e)
        {
            Splitter sp = (Splitter)sender;
            Pen pen = new Pen(Brushes.Gray);
            pen.Width = 8; // ширина сплитера 7
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 8);
            e.Graphics.DrawLine(pen, p1, p2);
            p1 = new Point(sp.Width, 0);
            p2 = new Point(sp.Width, 8);
            e.Graphics.DrawLine(pen, p1, p2);
            pen.Dispose();
        }

        private void splitter3_Paint(object sender, PaintEventArgs e)
        {
            Splitter sp = (Splitter)sender;
            Pen pen = new Pen(Brushes.Gray);
            pen.Width = 1; // ширина сплитера 7
            pen.DashStyle = DashStyle.Dot;
            Point p1 = new Point(0, splitter3.Height / 2);
            Point p2 = new Point(sp.Width, splitter3.Height / 2);
            e.Graphics.DrawLine(pen, p1, p2);
            pen.Dispose();
        }
        #endregion

        private void tv1_Remove(object sender, TreeViewEventArgs e)
        {
            List<string> wrds = this.Words;
            if (e.Node.Tag is Word && wrds.Contains(((Word)e.Node.Tag).Text))
            {
                wrds.Remove(((Word)e.Node.Tag).Text);
                try
                {
                    this.txWord.TextChanged -= new System.EventHandler(this.txWord_TextChanged);
                    string newLine = "";
                    this.txWord.Text = "";
                    foreach (string word in wrds)
                    {
                        this.txWord.Text += newLine + word;
                        newLine = "\r\n";
                    }
                }
                finally
                {
                    this.txWord.TextChanged += new System.EventHandler(this.txWord_TextChanged);
                }
            }

            if (e.Node.Parent != null)
                e.Node.Parent.Nodes.Remove(e.Node);
            else
                tv1.Nodes.Remove(e.Node);
            if (tv1.Nodes.Count == 0)
            {
                this.txWord.Focus();
                this.txSelectedCard.Text = "";
            }
        }

        private void txSelectedCard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string selectedText = Word.GetLetters(this.txSelectedCard.SelectedText);
            if (!string.IsNullOrEmpty(selectedText))
            {
                AddWordToEnterLine(selectedText);
            }
        }

        private void AddWordToEnterLine(string increment)
        {
            if (!string.IsNullOrEmpty(this.txWord.Text))
                increment += "\r\n";
            this.txWord.Text = increment + this.txWord.Text; // а если это слово есть то надо стересть а операцию инкремента вунести в метод? или просто не показать двойные слова?
            this.txWord.SelectionStart = increment.Length;
        }

        private void tv1_AddToVocabulary(object sender, TreeViewEventArgs e)
        {

        }

        private void contextMenuForTextBox_Opening(object sender, CancelEventArgs e)
        {
            pasteToolStripMenuItem.Visible =
                cutToolStripMenuItem.Visible = this.menuForTextBox.SourceControl == this.txWord;
            if (this.ActiveControl is TextBox)
            {
                this.copyToolStripMenuItem.Enabled =
                this.pasteToolStripMenuItem.Enabled =
                this.cutToolStripMenuItem.Enabled = !string.IsNullOrEmpty(((TextBox)this.ActiveControl).SelectedText);
            }
        }

        private void txSelectedCard_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Lines.Length > 3) // TODO: размер может поменятся
            {
                ((TextBox)sender).ScrollBars = ScrollBars.Vertical;
            }
            else
                ((TextBox)sender).ScrollBars = ScrollBars.None;

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        bool m_VisibleIndexBar = true;
        public bool VisibleIndexBar
        {
            get
            {
                return m_VisibleIndexBar;
            }
            set
            {
                this.splitter1.Visible =
                this.paListWords.Visible =
                m_VisibleIndexBar = value;
                if (m_VisibleIndexBar)
                    this.paWrapperTextWord.Padding = new Padding(0, 5, 5, 5);
                else
                    this.paWrapperTextWord.Padding = new Padding(5);
            }
        }
    }
}