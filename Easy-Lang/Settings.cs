using System.Windows.Forms;

namespace f.Properties {
    
    
    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() 
        {
            //this.SettingChanging += new System.Configuration.SettingChangingEventHandler(Settings_SettingChanging);
        }

        //void Settings_SettingChanging(object sender, System.Configuration.SettingChangingEventArgs e)
        //{
        //    if (e.SettingName == "Default_Font")
        //    {
        //        foreach (Form frm in Application.OpenForms)
        //        {
        //            if (frm is CommonForm)
        //                ((CommonForm)frm).AssingFont(frm, (System.Drawing.Font)e.NewValue);
        //        }
        //    }
        //}
    }
}
