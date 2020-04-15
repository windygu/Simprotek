using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Prosimo.Materials;
using ProsimoUI.MaterialsUI;

namespace ProsimoUI {
   /// <summary>
   /// Summary description for NewProcessSettingsForm.
   /// </summary>
   public class DefaultFlowsheetSettingsForm : System.Windows.Forms.Form {
      private FlowsheetSettings newFlowsheetSettings;
      private MainForm mainForm;

      private System.Windows.Forms.Panel panel;
      private System.Windows.Forms.GroupBox groupBoxSelectDryingMaterial;
      private ProsimoUI.MaterialsUI.DryingMaterialsControl dryingMaterialsControl;
      private System.Windows.Forms.TextBox textBoxDryingMaterial;
      private System.Windows.Forms.Label labelDryingMaterial;
      private System.Windows.Forms.TextBox textBoxDryingGas;
      private System.Windows.Forms.Label labelDryingGas;
      private System.Windows.Forms.Button buttonSetDryingMaterial;
      private GroupBox groupBoxSelected;
      private TextBox textBoxMoisture;
      private Label labelMoisture;
      private Button buttonOK;
      private Button buttonDetails;
      private Button buttonCancel;
      //private IContainer components;

      public DefaultFlowsheetSettingsForm() {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
      }

      public DefaultFlowsheetSettingsForm(MainForm mainForm, FlowsheetSettings newProcessSettings)
      {
          //
          // Required for Windows Form Designer support
          //
          InitializeComponent();

          this.mainForm = mainForm;
          this.newFlowsheetSettings = newProcessSettings;

          //this.dryingGasesControl.ListViewGases.MultiSelect = false;
          this.dryingMaterialsControl.ListViewMaterials.MultiSelect = false;

          //this.dryingGasesControl.SelectDryingGas(this.newProcessSettings.DryingGasName);
          this.dryingMaterialsControl.SelectDryingMaterial(this.newFlowsheetSettings.DryingMaterialName);

          string materialName = this.newFlowsheetSettings.DryingMaterialName;
          DryingMaterialCatalog catalog = DryingMaterialCatalog.Instance;
          if (!catalog.IsInCatalog(materialName)) {
             materialName = "Generic Drying Material";
          }
          string moistureName = DryingMaterialCatalog.Instance.GetDryingMaterial(materialName).Moisture.ToString();
          string gasName = DryingGasCatalog.Instance.GetDryingGasForMoisture(moistureName).ToString();
          this.textBoxMoisture.Text = moistureName;
          this.textBoxDryingGas.Text = gasName;
          //this.textBoxDryingGas.Text = this.newProcessSettings.DryingGasName;
          this.textBoxDryingMaterial.Text = materialName;
          this.ResizeEnd += new EventHandler(NewProcessSettingsForm_ResizeEnd);
      }

      void NewProcessSettingsForm_ResizeEnd(object sender, EventArgs e) {
         if (this.mainForm.Flowsheet != null) {
            this.mainForm.Flowsheet.ConnectionManager.DrawConnections();
         }
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing) {
         //if (disposing) {
         //   if (components != null) {
         //      components.Dispose();
         //   }
         //}
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultFlowsheetSettingsForm));
         this.panel = new System.Windows.Forms.Panel();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.groupBoxSelected = new System.Windows.Forms.GroupBox();
         this.textBoxMoisture = new System.Windows.Forms.TextBox();
         this.labelMoisture = new System.Windows.Forms.Label();
         this.textBoxDryingMaterial = new System.Windows.Forms.TextBox();
         this.labelDryingGas = new System.Windows.Forms.Label();
         this.textBoxDryingGas = new System.Windows.Forms.TextBox();
         this.labelDryingMaterial = new System.Windows.Forms.Label();
         this.groupBoxSelectDryingMaterial = new System.Windows.Forms.GroupBox();
         this.buttonDetails = new System.Windows.Forms.Button();
         this.buttonSetDryingMaterial = new System.Windows.Forms.Button();
         this.dryingMaterialsControl = new ProsimoUI.MaterialsUI.DryingMaterialsControl();
         this.panel.SuspendLayout();
         this.groupBoxSelected.SuspendLayout();
         this.groupBoxSelectDryingMaterial.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel
         // 
         this.panel.Controls.Add(this.buttonCancel);
         this.panel.Controls.Add(this.buttonOK);
         this.panel.Controls.Add(this.groupBoxSelected);
         this.panel.Controls.Add(this.groupBoxSelectDryingMaterial);
         this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel.Location = new System.Drawing.Point(0, 0);
         this.panel.Margin = new System.Windows.Forms.Padding(5);
         this.panel.Name = "panel";
         this.panel.Padding = new System.Windows.Forms.Padding(3);
         this.panel.Size = new System.Drawing.Size(494, 571);
         this.panel.TabIndex = 0;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Location = new System.Drawing.Point(387, 539);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 6;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
         // 
         // buttonOK
         // 
         this.buttonOK.Location = new System.Drawing.Point(279, 539);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // groupBoxSelected
         // 
         this.groupBoxSelected.Controls.Add(this.textBoxMoisture);
         this.groupBoxSelected.Controls.Add(this.labelMoisture);
         this.groupBoxSelected.Controls.Add(this.textBoxDryingMaterial);
         this.groupBoxSelected.Controls.Add(this.labelDryingGas);
         this.groupBoxSelected.Controls.Add(this.textBoxDryingGas);
         this.groupBoxSelected.Controls.Add(this.labelDryingMaterial);
         this.groupBoxSelected.Location = new System.Drawing.Point(16, 442);
         this.groupBoxSelected.Name = "groupBoxSelected";
         this.groupBoxSelected.Size = new System.Drawing.Size(462, 91);
         this.groupBoxSelected.TabIndex = 5;
         this.groupBoxSelected.TabStop = false;
         this.groupBoxSelected.Text = "Default Flowsheet Settings";
         // 
         // textBoxMoisture
         // 
         this.textBoxMoisture.BackColor = System.Drawing.SystemColors.Control;
         this.textBoxMoisture.Location = new System.Drawing.Point(322, 25);
         this.textBoxMoisture.Name = "textBoxMoisture";
         this.textBoxMoisture.ReadOnly = true;
         this.textBoxMoisture.Size = new System.Drawing.Size(100, 20);
         this.textBoxMoisture.TabIndex = 18;
         // 
         // labelMoisture
         // 
         this.labelMoisture.Location = new System.Drawing.Point(260, 26);
         this.labelMoisture.Name = "labelMoisture";
         this.labelMoisture.Size = new System.Drawing.Size(56, 19);
         this.labelMoisture.TabIndex = 17;
         this.labelMoisture.Text = "Moisture:";
         this.labelMoisture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBoxDryingMaterial
         // 
         this.textBoxDryingMaterial.BackColor = System.Drawing.SystemColors.Control;
         this.textBoxDryingMaterial.Location = new System.Drawing.Point(103, 57);
         this.textBoxDryingMaterial.Name = "textBoxDryingMaterial";
         this.textBoxDryingMaterial.ReadOnly = true;
         this.textBoxDryingMaterial.Size = new System.Drawing.Size(319, 20);
         this.textBoxDryingMaterial.TabIndex = 16;
         // 
         // labelDryingGas
         // 
         this.labelDryingGas.Location = new System.Drawing.Point(15, 27);
         this.labelDryingGas.Name = "labelDryingGas";
         this.labelDryingGas.Size = new System.Drawing.Size(84, 16);
         this.labelDryingGas.TabIndex = 13;
         this.labelDryingGas.Text = "Drying Gas:";
         this.labelDryingGas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBoxDryingGas
         // 
         this.textBoxDryingGas.BackColor = System.Drawing.SystemColors.Control;
         this.textBoxDryingGas.Location = new System.Drawing.Point(103, 25);
         this.textBoxDryingGas.Name = "textBoxDryingGas";
         this.textBoxDryingGas.ReadOnly = true;
         this.textBoxDryingGas.Size = new System.Drawing.Size(100, 20);
         this.textBoxDryingGas.TabIndex = 14;
         // 
         // labelDryingMaterial
         // 
         this.labelDryingMaterial.Location = new System.Drawing.Point(15, 57);
         this.labelDryingMaterial.Name = "labelDryingMaterial";
         this.labelDryingMaterial.Size = new System.Drawing.Size(84, 16);
         this.labelDryingMaterial.TabIndex = 15;
         this.labelDryingMaterial.Text = "Drying Material:";
         this.labelDryingMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // groupBoxSelectDryingMaterial
         // 
         this.groupBoxSelectDryingMaterial.Controls.Add(this.buttonDetails);
         this.groupBoxSelectDryingMaterial.Controls.Add(this.buttonSetDryingMaterial);
         this.groupBoxSelectDryingMaterial.Controls.Add(this.dryingMaterialsControl);
         this.groupBoxSelectDryingMaterial.Location = new System.Drawing.Point(14, 12);
         this.groupBoxSelectDryingMaterial.Name = "groupBoxSelectDryingMaterial";
         this.groupBoxSelectDryingMaterial.Size = new System.Drawing.Size(464, 424);
         this.groupBoxSelectDryingMaterial.TabIndex = 4;
         this.groupBoxSelectDryingMaterial.TabStop = false;
         this.groupBoxSelectDryingMaterial.Text = "Select a Drying Material for Default Flowsheet";
         // 
         // buttonDetails
         // 
         this.buttonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonDetails.Location = new System.Drawing.Point(130, 389);
         this.buttonDetails.Name = "buttonDetails";
         this.buttonDetails.Size = new System.Drawing.Size(75, 23);
         this.buttonDetails.TabIndex = 11;
         this.buttonDetails.Text = "View Details";
         this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
         // 
         // buttonSetDryingMaterial
         // 
         this.buttonSetDryingMaterial.Location = new System.Drawing.Point(265, 389);
         this.buttonSetDryingMaterial.Name = "buttonSetDryingMaterial";
         this.buttonSetDryingMaterial.Size = new System.Drawing.Size(75, 23);
         this.buttonSetDryingMaterial.TabIndex = 2;
         this.buttonSetDryingMaterial.Text = "Set";
         this.buttonSetDryingMaterial.Click += new System.EventHandler(this.buttonSetDryingMaterial_Click);
         // 
         // dryingMaterialsControl
         // 
         this.dryingMaterialsControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
         this.dryingMaterialsControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.dryingMaterialsControl.Location = new System.Drawing.Point(2, 34);
         this.dryingMaterialsControl.Name = "dryingMaterialsControl";
         this.dryingMaterialsControl.Size = new System.Drawing.Size(456, 349);
         this.dryingMaterialsControl.TabIndex = 0;
         // 
         // DefaultFlowsheetSettingsForm
         // 
         this.ClientSize = new System.Drawing.Size(494, 571);
         this.Controls.Add(this.panel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DefaultFlowsheetSettingsForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Set Material for Default Flowsheet";
         this.panel.ResumeLayout(false);
         this.groupBoxSelected.ResumeLayout(false);
         this.groupBoxSelected.PerformLayout();
         this.groupBoxSelectDryingMaterial.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private void menuItemClose_Click(object sender, System.EventArgs e) {
         this.Close();
      }

      //private void buttonSetDryingGas_Click(object sender, System.EventArgs e) {
      //   if (this.dryingGasesControl.GetSelectedDryingGas() != null) {
      //      this.newProcessSettings.DryingGasName = this.dryingGasesControl.GetSelectedDryingGas().Name;
      //   }
      //}

      private void buttonSetDryingMaterial_Click(object sender, System.EventArgs e) {
         DryingMaterial selectedDryingMaterial = this.dryingMaterialsControl.GetSelectedDryingMaterial();
         if (selectedDryingMaterial != null) {
            this.textBoxDryingMaterial.Text = selectedDryingMaterial.Name;
            //this.textBoxMoisture.Text = selectedDryingMaterial.Moisture.Name;
            this.textBoxMoisture.Text = selectedDryingMaterial.Moisture.ToString();
            this.textBoxDryingGas.Text = DryingGasCatalog.Instance.GetDryingGasForMoisture(selectedDryingMaterial.Moisture).ToString();
         }
      }

      private void buttonOK_Click(object sender, EventArgs e) {
         this.newFlowsheetSettings.DryingMaterialName = this.dryingMaterialsControl.GetSelectedDryingMaterial().Name;
         this.newFlowsheetSettings.DryingGasName = this.textBoxDryingGas.Text;
         this.Close();
      }

      private void buttonCancel_Click(object sender, EventArgs e) {
         string message = "Your selected new flowsheet settings will be lost. Do you really want to Cancel?";
         DialogResult dr = MessageBox.Show(this, message, "Cancel Selection", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         if (dr == DialogResult.Yes) {
            this.Close();
         }
      }

      private void buttonDetails_Click(object sender, EventArgs e) {
         DMDetailsForm form = new DMDetailsForm(this.dryingMaterialsControl.GetSelectedDryingMaterial(), this.mainForm.ApplicationPrefs);
         form.ShowDialog();
      }
   }
}
