using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ProsimoUI.Help
{
	/// <summary>
	/// Summary description for SplashForm.
	/// </summary>
	public class SplashForm : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Label labelStatus;
      private System.Windows.Forms.Label labelProductName;
      private System.Windows.Forms.Label labelCompanyName;
      private System.Windows.Forms.Label labelLogoTech;
      private System.Windows.Forms.Label labelAppico;
      private System.Windows.Forms.Label labelCopyright2;
      private System.Windows.Forms.Label labelCopyright1;
      private System.Windows.Forms.Label labelAlphaBeta;
      private System.Windows.Forms.Label labelFullProductName;
      private System.Windows.Forms.Label labelVersion;
      private System.Windows.Forms.Label labelBuild;
      private System.Windows.Forms.Label labelLogoAmsco;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SplashForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

         this.Cursor = Cursors.AppStarting;
         this.labelCompanyName.Text = Application.CompanyName;         this.labelProductName.Text = Application.ProductName;         Version v = new Version(Application.ProductVersion);         this.labelVersion.Text = String.Format(this.labelVersion.Text, v.Major, v.Minor);         this.labelBuild.Text = String.Format(this.labelBuild.Text, v.Build);         this.labelAlphaBeta.Text = UI.GetReleaseType();      }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
         this.Cursor = Cursors.Default;
         if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SplashForm));
         this.labelVersion = new System.Windows.Forms.Label();
         this.labelStatus = new System.Windows.Forms.Label();
         this.labelProductName = new System.Windows.Forms.Label();
         this.labelCompanyName = new System.Windows.Forms.Label();
         this.labelCopyright2 = new System.Windows.Forms.Label();
         this.labelLogoTech = new System.Windows.Forms.Label();
         this.labelLogoAmsco = new System.Windows.Forms.Label();
         this.labelAppico = new System.Windows.Forms.Label();
         this.labelCopyright1 = new System.Windows.Forms.Label();
         this.labelAlphaBeta = new System.Windows.Forms.Label();
         this.labelFullProductName = new System.Windows.Forms.Label();
         this.labelBuild = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // labelVersion
         // 
         this.labelVersion.BackColor = System.Drawing.Color.Transparent;
         this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelVersion.ForeColor = System.Drawing.Color.Red;
         this.labelVersion.Location = new System.Drawing.Point(24, 168);
         this.labelVersion.Name = "labelVersion";
         this.labelVersion.Size = new System.Drawing.Size(156, 20);
         this.labelVersion.TabIndex = 0;
         this.labelVersion.Text = "Version {0}.{1}";
         this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // labelStatus
         // 
         this.labelStatus.BackColor = System.Drawing.Color.DarkGray;
         this.labelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelStatus.ForeColor = System.Drawing.Color.White;
         this.labelStatus.Location = new System.Drawing.Point(0, 280);
         this.labelStatus.Name = "labelStatus";
         this.labelStatus.Size = new System.Drawing.Size(360, 20);
         this.labelStatus.TabIndex = 1;
         this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // labelProductName
         // 
         this.labelProductName.BackColor = System.Drawing.Color.Transparent;
         this.labelProductName.Font = new System.Drawing.Font("Comic Sans MS", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelProductName.ForeColor = System.Drawing.Color.Red;
         this.labelProductName.Location = new System.Drawing.Point(48, 100);
         this.labelProductName.Name = "labelProductName";
         this.labelProductName.Size = new System.Drawing.Size(268, 64);
         this.labelProductName.TabIndex = 2;
         this.labelProductName.Text = "{0}";
         this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // labelCompanyName
         // 
         this.labelCompanyName.BackColor = System.Drawing.Color.Transparent;
         this.labelCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelCompanyName.ForeColor = System.Drawing.Color.Yellow;
         this.labelCompanyName.Location = new System.Drawing.Point(116, 224);
         this.labelCompanyName.Name = "labelCompanyName";
         this.labelCompanyName.Size = new System.Drawing.Size(140, 20);
         this.labelCompanyName.TabIndex = 3;
         this.labelCompanyName.Text = "{0}";
         this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // labelCopyright2
         // 
         this.labelCopyright2.BackColor = System.Drawing.Color.Transparent;
         this.labelCopyright2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelCopyright2.ForeColor = System.Drawing.Color.Yellow;
         this.labelCopyright2.Location = new System.Drawing.Point(260, 224);
         this.labelCopyright2.Name = "labelCopyright2";
         this.labelCopyright2.Size = new System.Drawing.Size(64, 20);
         this.labelCopyright2.TabIndex = 4;
         this.labelCopyright2.Text = "2005-2006";
         this.labelCopyright2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // labelLogoTech
         // 
         this.labelLogoTech.BackColor = System.Drawing.Color.Transparent;
         this.labelLogoTech.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelLogoTech.ForeColor = System.Drawing.Color.DodgerBlue;
         this.labelLogoTech.Location = new System.Drawing.Point(288, 8);
         this.labelLogoTech.Name = "labelLogoTech";
         this.labelLogoTech.Size = new System.Drawing.Size(68, 24);
         this.labelLogoTech.TabIndex = 6;
         this.labelLogoTech.Text = "TECH";
         this.labelLogoTech.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // labelLogoAmsco
         // 
         this.labelLogoAmsco.BackColor = System.Drawing.Color.Transparent;
         this.labelLogoAmsco.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelLogoAmsco.ForeColor = System.Drawing.Color.DarkBlue;
         this.labelLogoAmsco.Location = new System.Drawing.Point(192, 8);
         this.labelLogoAmsco.Name = "labelLogoAmsco";
         this.labelLogoAmsco.Size = new System.Drawing.Size(100, 24);
         this.labelLogoAmsco.TabIndex = 7;
         this.labelLogoAmsco.Text = "AMSCO";
         this.labelLogoAmsco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // labelAppico
         // 
         this.labelAppico.BackColor = System.Drawing.Color.Transparent;
         this.labelAppico.Image = ((System.Drawing.Image)(resources.GetObject("labelAppico.Image")));
         this.labelAppico.Location = new System.Drawing.Point(8, 4);
         this.labelAppico.Name = "labelAppico";
         this.labelAppico.Size = new System.Drawing.Size(32, 32);
         this.labelAppico.TabIndex = 8;
         // 
         // labelCopyright1
         // 
         this.labelCopyright1.BackColor = System.Drawing.Color.Transparent;
         this.labelCopyright1.ForeColor = System.Drawing.Color.Yellow;
         this.labelCopyright1.Location = new System.Drawing.Point(36, 224);
         this.labelCopyright1.Name = "labelCopyright1";
         this.labelCopyright1.Size = new System.Drawing.Size(76, 20);
         this.labelCopyright1.TabIndex = 9;
         this.labelCopyright1.Text = "Copyright (c)";
         this.labelCopyright1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // labelAlphaBeta
         // 
         this.labelAlphaBeta.BackColor = System.Drawing.Color.Transparent;
         this.labelAlphaBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelAlphaBeta.ForeColor = System.Drawing.Color.Red;
         this.labelAlphaBeta.Location = new System.Drawing.Point(76, 52);
         this.labelAlphaBeta.Name = "labelAlphaBeta";
         this.labelAlphaBeta.Size = new System.Drawing.Size(200, 40);
         this.labelAlphaBeta.TabIndex = 16;
         this.labelAlphaBeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // labelFullProductName
         // 
         this.labelFullProductName.BackColor = System.Drawing.Color.Transparent;
         this.labelFullProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelFullProductName.ForeColor = System.Drawing.Color.Lime;
         this.labelFullProductName.Location = new System.Drawing.Point(4, 200);
         this.labelFullProductName.Name = "labelFullProductName";
         this.labelFullProductName.Size = new System.Drawing.Size(352, 20);
         this.labelFullProductName.TabIndex = 23;
         this.labelFullProductName.Text = "Process Simulation and Optimization";
         this.labelFullProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // labelBuild
         // 
         this.labelBuild.BackColor = System.Drawing.Color.Transparent;
         this.labelBuild.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.labelBuild.ForeColor = System.Drawing.Color.Red;
         this.labelBuild.Location = new System.Drawing.Point(188, 168);
         this.labelBuild.Name = "labelBuild";
         this.labelBuild.Size = new System.Drawing.Size(156, 20);
         this.labelBuild.TabIndex = 24;
         this.labelBuild.Text = "Build {0}";
         this.labelBuild.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // SplashForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.BackColor = System.Drawing.SystemColors.Control;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.ClientSize = new System.Drawing.Size(360, 300);
         this.Controls.Add(this.labelBuild);
         this.Controls.Add(this.labelFullProductName);
         this.Controls.Add(this.labelAlphaBeta);
         this.Controls.Add(this.labelCopyright1);
         this.Controls.Add(this.labelAppico);
         this.Controls.Add(this.labelLogoAmsco);
         this.Controls.Add(this.labelLogoTech);
         this.Controls.Add(this.labelCopyright2);
         this.Controls.Add(this.labelCompanyName);
         this.Controls.Add(this.labelProductName);
         this.Controls.Add(this.labelStatus);
         this.Controls.Add(this.labelVersion);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "SplashForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "ProSimO";
         this.ResumeLayout(false);

      }
		#endregion

      public void DisplayMessage(string message)
      {
         this.labelStatus.Text = message;
      }

      public void KillMe(object o, EventArgs e)
      {
         this.Close();
      }
	}
}
