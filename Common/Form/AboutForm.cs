/*
Copyright (C) 2008-2011 ForceMem (Siarhei Fedarenko)
GNU General Public License version 3 (GPLv3)
 * 
 
 * 
 * 
 Программа => DictionaryBlend
 * 
(It does not include data from a dictionary.)

The program has no data of dictionaries. 
Part of the data available merely for viewing in the browser of program.
Data are not copied or modified.
The program performs only a part of the work to carry out search services on the Internet.
The program essentially works as a browser
which performs only a preview content for web pages.
 
 *
 * 
 * 
Программа не имеет данных из словарей. (Программа не содержит данных из словарей.)
Часть данных просто предоставляются для просмотра в браузере программы. 
Данные не копируются и не модифицируются.
Программа выполняет всего лишь часть работы, которую выполняют поисковые сервисы в интернете.
Программа по сути является браузером, 
который выполняет только функцию предварительного просмотра содержания интернет страниц.

 * 
 * 
 * 
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace f
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            tbDictionaryBlendAddition.Visible = Application.ProductName.Equals("DictionaryBlend");

            this.Text = string.Format("About {0}", Application.ProductName);
            this.lbMain.Text = string.Format("{0} v {1}", Application.ProductName, Application.ProductVersion);

            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.linkHomePage.LinkClicked += new LinkLabelLinkClickedEventHandler(goToUrlInLink);
        }

        private void goToUrlInLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender is LinkLabel)
            {
                Runner.OpenURL(Utils.GetLocalizedPrefix() + "forcemem.com");
            }
        } 

        private void AboutForm_Load(object sender, EventArgs e)
        {
            btOK.Enabled = !cbIAgree.Visible;

            if (CF.AdvertLinkWasShown || Utils.IsWitheasy4learn)
            {
                this.cbGoToHomePage.Visible = false;
            }
            else
                this.cbGoToHomePage.Visible = true;
        }

        private void X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
                e.SuppressKeyPress = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.SendFeedback();
        }

        private void AboutForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.cbGoToHomePage.Visible && this.cbGoToHomePage.Checked)
                GoToProducerPage();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            GoToProducerPage();
        }

        void GoToProducerPage()
        {
            Runner.OpenURL(Utils.GetLocalizedPrefix() + "forcemem.com/easy-lang/index.htm");
            CF.AdvertLinkWasShown = true;
        }

        private void cbIAgree_CheckedChanged(object sender, EventArgs e)
        {
            btOK.Enabled = cbIAgree.Checked;
        }
    }
}