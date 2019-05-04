using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace f
{
    public partial class RichContainer : UserControl
    {
        public RichContainer()
        {
            InitializeComponent();
        }

        int m_Height = 0;

        bool m_IsOn = true;
        public bool IsOn
        {
            get { return m_IsOn; }
            set
            {
                m_IsOn = value;
                this.pictureBoxMinus.Visible =
                this.richTextBox.Visible = m_IsOn; // for CanFocus
                this.pictureBoxPlus.Visible = !m_IsOn;
                if (m_IsOn)
                {
                    this.Height += this.m_Height;
                }
                else
                {
                    this.m_Height = richTextBox.Height; // запоминаем состояние
                    this.Height -= richTextBox.Height;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.IsOn = !this.IsOn;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.IsOn = !this.IsOn;
        }

        private void pictureBoxSwitcher_Click(object sender, EventArgs e)
        {
            this.IsOn = !this.IsOn;
        }

        private void richTextBox_DoubleClick(object sender, EventArgs e)
        {
            base.OnDoubleClick(e);
        }

        private void RichContainer_BackColorChanged(object sender, EventArgs e)
        {
            this.richTextBox.BackColor = this.BackColor;
        }

        public string ToggleTitle
        {
            get
            {
                return this.linkLabel1.Text;
            }
            set
            {
                this.linkLabel1.Text = value;
            }

        }

        public string RichText
        {
            get
            {
                return this.richTextBox.Text;
            }
            set
            {
                this.richTextBox.Text = value;
            }
        }

        public int OptimalHeight
        {
            get
            {
                return 14 * this.richTextBox.Lines.Length + 10 + this.togglePanel.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }
    }
}