// Decompiled with JetBrains decompiler
// Type: JSInjection.СhromeView
// Assembly: libhbrd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2483B5A7-646F-40FE-9850-1556A0C4F517
// Assembly location: C:\el\easy2learn\Easy-Lang\lib\libhbrd.dll

using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace JSInjection
{
  public class СhromeView : UserControl
  {
    private Assembly assembly = (Assembly) null;
    public ArrayList JSFiles = new ArrayList();
    public ArrayList CSSFiles = new ArrayList();
    public WebView WView;
    private IContainer components;
    public ContextMenuStrip СontextMenu;
    private ToolStripMenuItem editToolStripMenuItem;
    private Timer timerForStart;
    private Label outputLabel;

    public string ManifestPrefix { set; get; }

    public СhromeView()
    {
      this.InitializeComponent();
      this.InitView();
      this.outputLabel.DoubleClick += new EventHandler(this.outputLabel_DoubleClick);
      if (!string.IsNullOrEmpty(this.ManifestPrefix) || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        return;
      this.assembly = Assembly.GetEntryAssembly();
      this.ManifestPrefix = Assembly.GetEntryAssembly().GetName().Name;
    }

    private void InitView()
    {
      this.WView = this.GetView();
      this.WView.ConsoleMessage += new ConsoleMessageEventHandler(this.wview_ConsoleMessage);
      this.Controls.Add((Control) this.WView);
      this.WView.Dock = DockStyle.Fill;
      this.timerForStart.Enabled = true;
    }

    private void wview_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
    {
      Console.WriteLine(e.Message);
    }

    private void outputLabel_DoubleClick(object sender, EventArgs e)
    {
      this.WView.ShowDevTools();
    }

    public void LoadHTML(string url)
    {
      string html = this.loadResourceText(url);
      string str = "";
      foreach (string cssFile in this.CSSFiles)
        str += this.loadResourceText(cssFile);
      if (!string.IsNullOrEmpty(str))
        html = html.Replace("<style>", "<style>" + str);
      this.WView.LoadHtml(html);
      this.LoadScripts();
    }

    private void LoadScripts()
    {
      foreach (string jsFile in this.JSFiles)
        this.WView.ExecuteScript(this.loadResourceText(jsFile));
    }

    internal string loadResourceText(string name)
    {
      string str = "";
      if (this.assembly == (Assembly) null)
        return str;
      name = name.Replace('\\', '.');
      name = this.ManifestPrefix + ".html." + name;
      Stream manifestResourceStream = this.assembly.GetManifestResourceStream(name);
      if (manifestResourceStream == null)
      {
        int num = (int) MessageBox.Show(string.Format("Status: Not founded '{0}'", (object) name), "On loading problem", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
        str = new StreamReader(manifestResourceStream).ReadToEnd();
      return str;
    }

    private WebView GetView()
    {
      return new WebView("about:plugins", new BrowserSettings());
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.timerForStart = new Timer(this.components);
      this.outputLabel = new Label();
      this.СontextMenu = new ContextMenuStrip(this.components);
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.СontextMenu.SuspendLayout();
      this.SuspendLayout();
      this.timerForStart.Interval = 500;
      this.timerForStart.Tick += new EventHandler(this.timer1_Tick);
      this.outputLabel.AutoSize = true;
      this.outputLabel.Dock = DockStyle.Bottom;
      this.outputLabel.Location = new Point(0, 137);
      this.outputLabel.Name = "outputLabel";
      this.outputLabel.Size = new Size(0, 13);
      this.outputLabel.TabIndex = 1;
      this.СontextMenu.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.editToolStripMenuItem
      });
      this.СontextMenu.Name = "contextMenuStrip1";
      this.СontextMenu.Size = new Size(95, 26);
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new Size(152, 22);
      this.editToolStripMenuItem.Text = "Edit";
      this.ContextMenuStrip = this.СontextMenu;
      this.Controls.Add((Control) this.outputLabel);
      this.Name = nameof (СhromeView);
      this.СontextMenu.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.WView.Address))
        return;
      this.timerForStart.Enabled = false;
      try
      {
        this.WView.Load(this.WView.Address);
        this.LoadScripts();
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }

    public string URL
    {
      get
      {
        return this.WView.Address;
      }
      set
      {
        this.WView.Address = value;
      }
    }
  }
}
