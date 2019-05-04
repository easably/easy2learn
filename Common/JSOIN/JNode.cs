using System;
using System.Collections.Generic;
using System.Text;

// http://james.newtonking.com/projects/json-net.aspx

namespace f
{
    public class JNode
    {
        public static JNode Parse(string value)
        {
            value.Trim();
            if (string.IsNullOrEmpty(value) || !value.StartsWith("["))
                return null;

            JNode current = null;  
            string currentText = "";
            foreach (char c in value)
            {
                if (c.Equals('['))
                {
                    // first cycle
                    if (current == null)
                    {
                        current = new JNode("", null);
                        continue;
                    }
                    current.Text = currentText;
                    JNode node = new JNode("", current);
                    current = node;
                    currentText = "";
                }
                else if (c.Equals(']'))
                {
                    current.Text = currentText;
                    if (current.Parent == null) continue; // end of all cycles
                    current = current.Parent;
                    currentText = current.Text;
                }
                else
                {
                    currentText += c;
                }
            }
            return current;
        }

        public static JNode Parse2(string value)
        {
            JNode current = null;
            value.Trim();
            if (string.IsNullOrEmpty(value) || !(value.StartsWith("[") || value.StartsWith("{")))
                return current;
            string currentText = "";
            foreach (char c in value)
            {
                if (c.Equals('[') || c.Equals('{'))
                {
                    // first cycle
                    if (current == null)
                    {
                        current = new JNode("", null);
                        continue;
                    }
                    current.Text = currentText;
                    JNode node = new JNode("", current);
                    current = node;
                    currentText = "";
                }
                else if (c.Equals(']') || c.Equals('}'))
                {
                    current.Text = currentText;
                    if (current.Parent == null) continue; // end of all cycles
                    current = current.Parent;
                    currentText = current.Text;
                }
                else
                {
                    currentText += c;
                }
            }
            return current;
        }

        public JNode(string text, JNode parent)
           // : this(text, null, null, null, null)
        {
            _parent = parent;
            this.Text = text;
            if (parent != null)
                parent.ChildNodes.Add(this);
        }

        List<JNode> _childNodes = null;
        public List<JNode> ChildNodes
        {
            get
            {
                if (this._childNodes == null)
                    this._childNodes = new List<JNode>();
                return this._childNodes;
            }
        }

        public bool HasChild { get { return _childNodes != null && _childNodes.Count > 0; } }

        JNode _parent;
        public JNode Parent { get { return _parent; } }

        string m_Text = "";
        public string Text
        {
            set {
                if (!m_Text.Equals(value))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        m_Values = value.Split(',');
                        #region corrected JSOIN
                        m_ValuesExt2 = new List<string>();
                        string previous = "";
                        foreach (string s in m_Values)
                        {       
                            previous += s;
                            if ((previous.StartsWith("\"") && previous.EndsWith("\"")) || 
                                (!previous.StartsWith("\"") && !previous.EndsWith("\"")))
                            {
                                m_ValuesExt2.Add(previous);
                                previous = "";
                            }

                            // \"duration\":3000,
                            else if (previous.StartsWith("\"") && !previous.EndsWith("\"") && previous.Contains("\":"))
                            {
                                m_ValuesExt2.Add(s);
                                previous = "";
                            }
                        }
                        // "\"Now it may seem kind of strange that such a thing can actually be patented,sdsdds\",\"duration\":3000,\"startOfParagraph\":false,23000"

                        #endregion
                        //m_ValuesExt = value.Trim('"').Split(new string[] { "\",\"" }, StringSplitOptions.None);
                    }
                    m_Text = value;
                }
            }
            get {
                return m_Text;
            }
        }

        public string[] m_Values = new string[] { };
        public string[] Values { 
            get {
                return m_Values; 
            } 
        }

        //public string[] m_ValuesExt = new string[] { };
        //public string[] ValuesExt
        //{
        //    get
        //    {
        //        return m_ValuesExt;
        //    }
        //}

        public List<string> m_ValuesExt2 = null;
        public List<string> ValuesExt2
        {
            get
            {
                if (m_ValuesExt2 == null) 
                    m_ValuesExt2 = new List<string>();
                return m_ValuesExt2;
            }
        }

        public override string ToString()
        { 
            string result = "";
            foreach(string s in this.Values)
                result += s + Environment.NewLine;
            if (this.HasChild)
                result += string.Format("({0}) {1}", this.ChildNodes.Count, this.Text);
            return result;
        }

        public string ToString(string tab)
        { 
            string result = "";
            result += this.Text + Environment.NewLine;
            foreach (JNode node in this.ChildNodes)
            {
                result += Environment.NewLine + tab + node.ToString(tab + tab);
            }
            return result;
        }        
    }
}
