using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProsimoUI
{
	/// <summary>
	/// Summary description for NewSystemPreferencesForm.
	/// </summary>
	public class NewSystemPreferencesForm : System.Windows.Forms.Form
	{
      private NewSystemPreferences newSysPrefs;

      private System.Windows.Forms.Panel panel;
      private System.Windows.Forms.MainMenu mainMenu;
      private System.Windows.Forms.MenuItem menuItemClose;
      private System.Windows.Forms.GroupBox groupBoxSelectDryingMaterial;
      private System.Windows.Forms.GroupBox groupBoxSelectDryingGas;
      private ProsimoUI.MaterialsUI.DryingGasesControl dryingGasesControl;
      private ProsimoUI.MaterialsUI.DryingMaterialsControl dryingMaterialsControl;
      private System.Windows.Forms.TextBox textBoxDryingMaterial;
      private System.Windows.Forms.Label labelDryingMaterial;
      private System.Windows.Forms.TextBox textBoxDryingGas;
      private System.Windows.Forms.Label labelDryingGas;
      private System.Windows.Forms.Button buttonSetDryingGas;
      private System.Windows.Forms.Button buttonSetDryingMaterial;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NewSystemPreferencesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

      public NewSystemPreferencesForm(NewSystemPreferences newSysPrefs)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         this.newSysPrefs = newSysPrefs;

         this.dryingGasesControl.ListViewGases.MultiSelect = false;
         this.dryingMaterialsControl.ListViewMaterials.MultiSelect = false;

         this.dryingGasesControl.SelectDryingGas(this.newSysPrefs.DryingGasName);
         this.dryingMaterialsControl.SelectDryingMaterial(this.newSysPrefs.DryingMaterialName);

         this.textBoxDryingGas.Text = this.newSysPrefs.DryingGasName;
         this.textBoxDryingMaterial.Text = this.newSysPrefs.DryingMaterialName;
      }

      /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
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
         this.panel = new System.Windows.Forms.Panel();
         this.textBoxDryingMaterial = new System.Windows.Forms.TextBox();
         this.labelDryingMaterial = new System.Windows.Forms.Label();
         this.textBoxDryingGas = new System.Windows.Forms.TextBox();
         this.labelDryingGas = new System.Windows.Forms.Label();
         this.groupBoxSelectDryingGas = new System.Windows.Forms.GroupBox();
         this.buttonSetDryingGas = new System.Windows.Forms.Button();
         this.dryingGasesControl = new ProsimoUI.MaterialsUI.DryingGasesControl();
         this.groupBoxSelectDryingMaterial = new System.Windows.Forms.GroupBox();
         this.buttonSetDryingMaterial = new System.Windows.Forms.Button();
         this.dryingMaterialsControl = new ProsimoUI.MaterialsUI.DryingMaterialsControl();
         this.mainMenu = new System.Windows.Forms.MainMenu();
         this.menuItemClose = new System.Windows.Forms.MenuItem();
         this.panel.SuspendLayout();
         this.groupBoxSelectDryingGas.SuspendLayout();
         this.groupBoxSelectDryingMaterial.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel
         // 
         this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.panel.Controls.Add(this.textBoxDryingMaterial);
         this.panel.Controls.Add(this.labelDryingMaterial);
         this.panel.Controls.Add(this.textBoxDryingGas);
         this.panel.Controls.Add(this.labelDryingGas);
         this.panel.Controls.Add(this.groupBoxSelectDryingGas);
         this.panel.Controls.Add(this.groupBoxSelectDryingMaterial);
         this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel.Location = new System.Drawing.Point(0, 0);
         this.panel.Name = "panel";
         this.panel.Size = new System.Drawing.Size(602, 319);
         this.panel.TabIndex = 0;
         // 
         // textBoxDryingMaterial
         // 
         this.textBoxDryingMaterial.BackColor = System.Drawing.Color.White;
         this.textBoxDryingMaterial.Location = new System.Drawing.Point(96, 44);
         this.textBoxDryingMaterial.Name = "textBoxDryingMaterial";
         this.textBoxDryingMaterial.ReadOnly = true;
         this.textBoxDryingMaterial.TabIndex = 16;
         this.textBoxDryingMaterial.Text = "";
         // 
         // labelDryingMaterial
         // 
         this.labelDryingMaterial.Location = new System.Drawing.Point(8, 48);
         this.labelDryingMaterial.Name = "labelDryingMaterial";
         this.labelDryingMaterial.Size = new System.Drawing.Size(84, 16);
         this.labelDryingMaterial.TabIndex = 15;
         this.labelDryingMaterial.Text = "Drying Material:";
         this.labelDryingMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBoxDryingGas
         // 
         this.textBoxDryingGas.BackColor = System.Drawing.Color.White;
         this.textBoxDryingGas.Location = new System.Drawing.Point(96, 16);
         this.textBoxDryingGas.Name = "textBoxDryingGas";
         this.textBoxDryingGas.ReadOnly = true;
         this.textBoxDryingGas.TabIndex = 14;
         this.textBoxDryingGas.Text = "";
         // 
         // labelDryingGas
         // 
         this.labelDryingGas.Location = new System.Drawing.Point(8, 20);
         this.labelDryingGas.Name = "labelDryingGas";
         this.labelDryingGas.Size = new System.Drawing.Size(84, 16);
         this.labelDryingGas.TabIndex = 13;
         this.labelDryingGas.Text = "Drying Gas:";
         this.labelDryingGas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // groupBoxSelectDryingGas
         // 
         this.groupBoxSelectDryingGas.Controls.Add(this.buttonSetDryingGas);
         this.groupBoxSelectDryingGas.Controls.Add(this.dryingGasesControl);
         this.groupBoxSelectDryingGas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.groupBoxSelectDryingGas.Location = new System.Drawing.Point(4, 108);
         this.groupBoxSelectDryingGas.Name = "groupBoxSelectDryingGas";
         this.groupBoxSelectDryingGas.Size = new System.Drawing.Size(256, 196);
         this.groupBoxSelectDryingGas.TabIndex = 5;
         this.groupBoxSelectDryingGas.TabStop = false;
         this.groupBoxSelectDryingGas.Text = "Select Drying Gas";
         // 
         // buttonSetDryingGas
         // 
         this.buttonSetDryingGas.Location = new System.Drawing.Point(92, 168);
         this.buttonSetDryingGas.Name = "buttonSetDryingGas";
         this.buttonSetDryingGas.TabIndex = 1;
         this.buttonSetDryingGas.Text = "Set";
         this.buttonSetDryingGas.Click += new System.EventHandler(this.buttonSetDryingGas_Click);
         // 
         // dryingGasesControl
         // 
         this.dryingGasesControl.Location = new System.Drawing.Point(4, 20);
         this.dryingGasesControl.Name = "dryingGasesControl";
         this.dryingGasesControl.Size = new System.Drawing.Size(248, 144);
         this.dryingGasesControl.TabIndex = 0;
         // 
         // groupBoxSelectDryingMaterial
         // 
         this.groupBoxSelectDryingMaterial.Controls.Add(this.buttonSetDryingMaterial);
         this.groupBoxSelectDryingMaterial.Controls.Add(this.dryingMaterialsControl);
         this.groupBoxSelectDryingMaterial.Location = new System.Drawing.Point(264, 12);
         this.groupBoxSelectDryingMaterial.Name = "groupBoxSelectDryingMaterial";
         this.groupBoxSelectDryingMaterial.Size = new System.Drawing.Size(332, 292);
         this.groupBoxSelectDryingMaterial.TabIndex = 4;
         this.groupBoxSelectDryingMaterial.TabStop = false;
         this.groupBoxSelectDryingMaterial.Text = "Select Drying Material";
         // 
         // buttonSetDryingMaterial
         // 
         this.buttonSetDryingMaterial.Location = new System.Drawing.Point(128, 264);
         this.buttonSetDryingMaterial.Name = "buttonSetDryingMaterial";
         this.buttonSetDryingMaterial.TabIndex = 2;
         this.buttonSetDryingMaterial.Text = "Set";
         this.buttonSetDryingMaterial.Click += new System.EventHandler(this.buttonSetDryingMaterial_Click);
         // 
         // dryingMaterialsControl
         // 
         this.dryingMaterialsControl.Location = new System.Drawing.Point(4, 20);
         this.dryingMaterialsControl.Name = "dryingMaterialsControl";
         this.dryingMaterialsControl.Size = new System.Drawing.Size(324, 240);
         this.dryingMaterialsControl.TabIndex = 0;
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
         // NewSystemPreferencesForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(602, 319);
         this.Controls.Add(this.panel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.Menu = this.mainMenu;
         this.MinimizeBox = false;
         this.Name = "NewSystemPreferencesForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "New System Preferences";
         this.panel.ResumeLayout(false);
         this.groupBoxSelectDryingGas.ResumeLayout(false);
         this.groupBoxSelectDryingMaterial.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

      private void menuItemClose_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      private void buttonSetDryingGas_Click(object sender, System.EventArgs e)
      {
         if (this.dryingGasesControl.GetSelectedDryingGas() != null)
         {
            this.newSysPrefs.DryingGasName = this.dryingGasesControl.GetSelectedDryingGas().Name;
            this.textBoxDryingGas.Text = this.newSysPrefs.DryingGasName;
         }
      }

      private void buttonSetDryingMaterial_Click(object sender, System.EventArgs e)
      {
         if (this.dryingMaterialsControl.GetSelectedDryingMaterial() != null)
         {
            this.newSysPrefs.DryingMaterialName = this.dryingMaterialsControl.GetSelectedDryingMaterial().Name;
            this.textBoxDryingMaterial.Text = this.newSysPrefs.DryingMaterialName;
         }
      }
   }
}
