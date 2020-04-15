using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProsimoUI.Help
{
   /// <summary>
   /// Summary description for TheTutorialForm.
   /// </summary>
   public class TheTutorialForm : System.Windows.Forms.Form
   {
      public const string TUTORIAL_FILE = "Tutorial.htm";
      public const string HELP_DIRECTORY = "..\\help\\";

      private System.Windows.Forms.MainMenu mainMenu;
      private System.Windows.Forms.MenuItem menuItemClose;
      private Panel panel;
      private WebBrowser webBrowser;
      private IContainer components;

      public TheTutorialForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         string exePathName = Application.StartupPath + Path.DirectorySeparatorChar;
         string link = exePathName + TheTutorialForm.HELP_DIRECTORY + TheTutorialForm.TUTORIAL_FILE;
         this.webBrowser.Navigate(link);
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
         this.menuItemClose = new System.Windows.Forms.MenuItem();
         this.panel = new System.Windows.Forms.Panel();
         this.webBrowser = new System.Windows.Forms.WebBrowser();
         this.panel.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainMenu
         // 
         this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemClose});
         // 
         // menuItemClose
         // 
         this.menuItemClose.Index = 0;
         this.menuItemClose.Text = "Close";
         this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
         // 
         // panel
         // 
         this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.panel.Controls.Add(this.webBrowser);
         this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel.Location = new System.Drawing.Point(0, 0);
         this.panel.Name = "panel";
         this.panel.Size = new System.Drawing.Size(700, 606);
         this.panel.TabIndex = 0;
         // 
         // webBrowser
         // 
         this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.webBrowser.Location = new System.Drawing.Point(0, 0);
         this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.webBrowser.Name = "webBrowser";
         this.webBrowser.Size = new System.Drawing.Size(696, 602);
         this.webBrowser.TabIndex = 0;
         // 
         // TheTutorialForm
         // 
         this.ClientSize = new System.Drawing.Size(700, 606);
         this.Controls.Add(this.panel);
         this.Menu = this.mainMenu;
         this.Name = "TheTutorialForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Simprosys - Tutorial";
         this.panel.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private void menuItemClose_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }
   }
}