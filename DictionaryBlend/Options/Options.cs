using System;
using System.Windows.Forms;
using System.IO;

namespace f
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            this.listDict.CheckOnClick = true;

            this.cbGenerateArticlesWithJScript.Checked = GlobalOptions.GenerateArticlesWithJScript;
           
            foreach (Type type in GlobalOptions.AllDictionaries)
            {
                DictionaryProviderViewForList view = new DictionaryProviderViewForList(type);
                int i = this.listDict.Items.Add(new DictionaryProviderViewForList(type));

                if (Array.IndexOf(GlobalOptions.WorkedDictionaries, type) != -1)
                        this.listDict.SetItemCheckState(i, CheckState.Checked);

                //if (!GlobalOptions.IsContainsConfig) // первый запуск отмечаем все
                //    this.listDict.SetItemCheckState(i, CheckState.Checked);

                if (view.Code.Equals(DictionaryProvider.RequiredDictionary))
                    this.listDict.SetItemCheckState(i, CheckState.Indeterminate);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
          //  this.Close();
        }

        private void listDict_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            DictionaryProviderViewForList provider = (DictionaryProviderViewForList)this.listDict.Items[e.Index];

            if (provider.Code.Equals(DictionaryProvider.RequiredDictionary))
                e.NewValue = CheckState.Indeterminate;
            if (provider.Code.Equals(typeof(Idiomcenter).FullName))
                e.NewValue = CheckState.Unchecked;
        }

        private void Options_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                GlobalOptions.GenerateArticlesWithJScript = this.cbGenerateArticlesWithJScript.Checked;

                string store = "";
                foreach (int i in this.listDict.CheckedIndices)
                {
                    store += ((DictionaryProviderViewForList)this.listDict.Items[i]).Code + ";";
                }
                GlobalOptions.AvailableDictionaries = store;
                GlobalOptions.InitDictionaries();
                CF.Config.Save();
            }
        }
    }
}
