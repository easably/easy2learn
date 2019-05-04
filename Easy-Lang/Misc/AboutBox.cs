using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace f
{
    partial class X : Form
    {
        public X()
        {
            InitializeComponent();
            this.linkLabelSite.Text = Utils.Root;

#if !PRO
            this.btGetEasyLearn.Visible = 
            this.boxInitial.Visible = 
            this.boxDemo.Visible = true;
            this.boxProLabel.Visible = false;

            this.boxDemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxInitial.Cursor = System.Windows.Forms.Cursors.Hand;

            this.boxDemo.Click += new EventHandler(btGetEasyLearn_Click);
            this.boxInitial.Click += new EventHandler(btGetEasyLearn_Click);
            this.btGetEasyLearn.Click += new EventHandler(btGetEasyLearn_Click);
#else
            this.btGetEasyLearn.Visible =
            this.boxInitial.Visible =
            this.boxDemo.Visible = false;
            this.boxProLabel.Visible = true;
#endif


            if (!Windows7.Windows7Taskbar.Windows7OrGreater)
            {
                this.btGetEasyLearn.FlatStyle = 
                this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            }
        }

        void btGetEasyLearn_Click(object sender, EventArgs e)
        {
            SentenceListWithVideo.ShowLearnWordsArticle();
        }

        private void X_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void X_Load(object sender, EventArgs e)
        {
            // TranscriptionWriter.AboutForm, TranscriptionWriter, Version=0.9.0.0, Culture=neutral, PublicKeyToken=null
            string ver = Application.ProductVersion; //  this.GetType().AssemblyQualifiedName.Split(',')[2];
            // Version=0.9.0.0
            // ver = ver.Replace("Version=", "v ");
            
            ver = ver.Split('.')[0] + "." + ver.Split('.')[1];
            lbMain.Text = string.Format("\"{0}\" {1}", T.AppName, ver);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Runner.OpenURL("easy4learn.net");
            //    Runner.OpenURL(string.Format("http://easy4learn.com/{0}/", Utils.GetLocaleForUI()));
        }

        private void linkLabelMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.Support();
        }
    }
}
    /*
     *    Princeton University (lexical database) and ReciteWord
     * 
     * 
   Валентине Голубевой, организатор и руководитель Клуба "I CAN", ст. преподователь МГЛУ
   Михаилу Еронину, организатор и руководитель центра практической психологии и психоанализа
     * 
     * Мои реалии: Валентина Голубева, ст. преподаватель Минского
    государственного лингвистического университета, переводчик,
    организатор и руководитель Клуба для англоговорящих "I CAN".

    Если по-английски, то это будет:

    Valentina Holubeva, Senior Instructor at Minsk State Linguistic University, 
        interpreter and translator, organiser and mediator of I CAN English Speaking Club.
    Michael Eronin, organiser and mediator psychology center
     * 
    Аббревиатуры для нашего универа: МГЛУ и MSLU.

     * 
     * 
     *             this.btRecommend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btRecommend.EndColor = System.Drawing.Color.Silver;
            this.btRecommend.EndOffset = 0;
            this.btRecommend.FillDirection = Gl.FillDirection.TopToBottom;
            this.btRecommend.Font = new System.Drawing.Font("Arial", 8F);
            this.btRecommend.Location = new System.Drawing.Point(276, 448);
            this.btRecommend.Name = "btRecommend";
            this.btRecommend.Size = new System.Drawing.Size(138, 23);
            this.btRecommend.StartColor = System.Drawing.Color.White;
            this.btRecommend.StartOffset = 0;
            this.btRecommend.TabIndex = 1;
            this.btRecommend.Text = "Testimonial to friends";
            this.btRecommend.Click += new System.EventHandler(this.btRecommend_Click);
            this.btRecommend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.X_KeyDown);

     */