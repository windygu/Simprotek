using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Prosimo.UnitOperations;
using Prosimo.UnitSystems;
using ProsimoUI;
using Prosimo;
using ProsimoUI.ProcessStreamsUI;
using Prosimo.UnitOperations.ProcessStreams;
using Prosimo.UnitOperations.GasSolidSeparation;

namespace ProsimoUI.UnitOperationsUI
{
   /// <summary>
   /// Summary description for WetScrubberEditor.
   /// </summary>
   public class WetScrubberEditor : UnitOpEditor
   {
      public const int INDEX_BALANCE = 0;
      public const int INDEX_RATING = 1;

//      private WetScrubberRatingEditor editor;
      private bool inConstruction;

      public WetScrubberControl WetScrubberCtrl
      {
         get {return (WetScrubberControl)this.solvableCtrl;}
         set {this.solvableCtrl = value;}
      }

      private MenuItem menuItemRating;

      private System.Windows.Forms.ComboBox comboBoxCalculationType;
      private System.Windows.Forms.Label labelCalculationType;

      private System.Windows.Forms.GroupBox groupBoxGasStream;
      private System.Windows.Forms.GroupBox groupBoxLiquidStream;
      private ProsimoUI.SolvableNameTextBox textBoxGasInName;
      private ProsimoUI.SolvableNameTextBox textBoxGasOutName;
      private ProsimoUI.SolvableNameTextBox textBoxLiquidInName;
      private ProsimoUI.SolvableNameTextBox textBoxLiquidOutName;
      private System.Windows.Forms.GroupBox groupBoxWetScrubber;
      
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public WetScrubberEditor(WetScrubberControl wetScrubberCtrl) : base(wetScrubberCtrl)
      {
         //
         // Required for Windows Form Designer support
         //
         //InitializeComponent();

         this.inConstruction = true;
         WetScrubber wetScrubber = this.WetScrubberCtrl.WetScrubber;
         this.Text = "Wet Scrubber: " + wetScrubber.Name;
         this.UpdateStreamsUI();

         //this.groupBoxWetScrubber = new System.Windows.Forms.GroupBox();
         //this.groupBoxWetScrubber.Location = new System.Drawing.Point(724, 24);
         //this.groupBoxWetScrubber.Name = "groupBoxWetScrubber";
         //this.groupBoxWetScrubber.Text = "Wet Scrubber";
         //this.groupBoxWetScrubber.Size = new System.Drawing.Size(280, 180);
         //this.groupBoxWetScrubber.TabIndex = 128;
         //this.groupBoxWetScrubber.TabStop = false;
         //this.panel.Controls.Add(this.groupBoxWetScrubber);

         // TO DO: to customizs the height? or not

         //         if (wetScrubber.GasInlet is DryingGasStream)
         //         {
         //            this.groupBoxGasStream.Size = new System.Drawing.Size(360, 280);
         //            this.panel.Size = new System.Drawing.Size(1010, 309);
         //            this.ClientSize = new System.Drawing.Size(1010, 331);
         //         }
         //         else if (wetScrubber.GasInlet is DryingMaterialStream)
         //         {
         //this.groupBoxGasStream.Size = new System.Drawing.Size(360, 300);
         //this.panel.Size = new System.Drawing.Size(1010, 329);
         //this.ClientSize = new System.Drawing.Size(1010, 351);
         ////         }
         //this.groupBoxLiquidStream.Size = new System.Drawing.Size(360, 300);
         
         //WetScrubberLabelsControl wetScrubberLabelsCtrl = new WetScrubberLabelsControl(this.WetScrubberCtrl.WetScrubber);
         //this.groupBoxWetScrubber.Controls.Add(wetScrubberLabelsCtrl);
         //wetScrubberLabelsCtrl.Location = new Point(4, 12 + 20 + 2);

         //WetScrubberValuesControl wetScrubberValuesCtrl = new WetScrubberValuesControl(this.WetScrubberCtrl);
         //this.groupBoxWetScrubber.Controls.Add(wetScrubberValuesCtrl);
         //wetScrubberValuesCtrl.Location = new Point(196, 12 + 20 + 2);

         wetScrubberCtrl.WetScrubber.StreamAttached += new StreamAttachedEventHandler(WetScrubber_StreamAttached);
         wetScrubberCtrl.WetScrubber.StreamDetached += new StreamDetachedEventHandler(WetScrubber_StreamDetached);

         this.menuItemRating = new MenuItem();
         this.menuItemRating.Index = this.menuItemReport.Index + 1;
         this.menuItemRating.Text = "Rating";
         this.menuItemRating.Click += new EventHandler(menuItemRating_Click);
         this.mainMenu.MenuItems.Add(this.menuItemRating);

         this.comboBoxCalculationType = new System.Windows.Forms.ComboBox();
         this.labelCalculationType = new System.Windows.Forms.Label();
         this.labelCalculationType.BackColor = Color.DarkGray;

         // comboBoxCalculationType
         this.comboBoxCalculationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxCalculationType.Items.AddRange(new object[] {
                                                                     "Balance",
                                                                     "Rating"});
         this.comboBoxCalculationType.Location = new System.Drawing.Point(502, 8);
         this.comboBoxCalculationType.Name = "comboBoxCalculationType";
         this.comboBoxCalculationType.Size = new System.Drawing.Size(80, 21);
         this.comboBoxCalculationType.TabIndex = 7;
         this.comboBoxCalculationType.SelectedIndexChanged += new EventHandler(comboBoxCalculationType_SelectedIndexChanged);

         // labelCalculationType
         this.labelCalculationType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.labelCalculationType.Location = new System.Drawing.Point(310, 8);
         this.labelCalculationType.Name = "labelCalculationType";
         this.labelCalculationType.Size = new System.Drawing.Size(192, 20);
         this.labelCalculationType.TabIndex = 5;
         this.labelCalculationType.Text = "Calculation Type:";
         this.labelCalculationType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

         this.namePanel.Controls.Add(this.labelCalculationType);
         this.namePanel.Controls.Add(this.comboBoxCalculationType);

         this.comboBoxCalculationType.SelectedIndex = -1;
         comboBoxCalculationType.Enabled = false; // TODO: remove later
         initializeGrid(wetScrubberCtrl, columnIndex, false, "Wet Scrubber");
         this.inConstruction = false;
         this.SetCalculationType(this.WetScrubberCtrl.WetScrubber.CalculationType);
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if (this.WetScrubberCtrl.WetScrubber != null)
         {
            this.WetScrubberCtrl.WetScrubber.StreamAttached -= new StreamAttachedEventHandler(WetScrubber_StreamAttached);
            this.WetScrubberCtrl.WetScrubber.StreamDetached -= new StreamDetachedEventHandler(WetScrubber_StreamDetached);
         }
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
      //private void InitializeComponent()
      //{
      //   this.groupBoxGasStream = new System.Windows.Forms.GroupBox();
      //   this.textBoxGasOutName = new ProsimoUI.SolvableNameTextBox();
      //   this.textBoxGasInName = new ProsimoUI.SolvableNameTextBox();
      //   this.groupBoxLiquidStream = new System.Windows.Forms.GroupBox();
      //   this.textBoxLiquidOutName = new ProsimoUI.SolvableNameTextBox();
      //   this.textBoxLiquidInName = new ProsimoUI.SolvableNameTextBox();
      //   this.groupBoxGasStream.SuspendLayout();
      //   this.groupBoxLiquidStream.SuspendLayout();
      //   ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel)).BeginInit();
      //   this.panel.SuspendLayout();
      //   this.SuspendLayout();
      //   // 
      //   // groupBoxGasStream
      //   // 
      //   this.groupBoxGasStream.Controls.Add(this.textBoxGasOutName);
      //   this.groupBoxGasStream.Controls.Add(this.textBoxGasInName);
      //   this.groupBoxGasStream.Location = new System.Drawing.Point(4, 24);
      //   this.groupBoxGasStream.Name = "groupBoxGasStream";
      //   this.groupBoxGasStream.Size = new System.Drawing.Size(360, 300);
      //   this.groupBoxGasStream.TabIndex = 118;
      //   this.groupBoxGasStream.TabStop = false;
      //   this.groupBoxGasStream.Text = "Gas Inlet/Outlet";
      //   // 
      //   // textBoxGasOutName
      //   // 
      //   this.textBoxGasOutName.Location = new System.Drawing.Point(276, 12);
      //   this.textBoxGasOutName.Name = "textBoxGasOutName";
      //   this.textBoxGasOutName.Size = new System.Drawing.Size(80, 20);
      //   this.textBoxGasOutName.TabIndex = 13;
      //   this.textBoxGasOutName.Text = "";
      //   // 
      //   // textBoxGasInName
      //   // 
      //   this.textBoxGasInName.Location = new System.Drawing.Point(196, 12);
      //   this.textBoxGasInName.Name = "textBoxGasInName";
      //   this.textBoxGasInName.Size = new System.Drawing.Size(80, 20);
      //   this.textBoxGasInName.TabIndex = 12;
      //   this.textBoxGasInName.Text = "";
      //   // 
      //   // groupBoxLiquidStream
      //   // 
      //   this.groupBoxLiquidStream.Controls.Add(this.textBoxLiquidOutName);
      //   this.groupBoxLiquidStream.Controls.Add(this.textBoxLiquidInName);
      //   this.groupBoxLiquidStream.Location = new System.Drawing.Point(364, 24);
      //   this.groupBoxLiquidStream.Name = "groupBoxLiquidStream";
      //   this.groupBoxLiquidStream.Size = new System.Drawing.Size(360, 280);
      //   this.groupBoxLiquidStream.TabIndex = 119;
      //   this.groupBoxLiquidStream.TabStop = false;
      //   this.groupBoxLiquidStream.Text = "Liquid Inlet/Outlet";
      //   // 
      //   // textBoxLiquidOutName
      //   // 
      //   this.textBoxLiquidOutName.Location = new System.Drawing.Point(276, 12);
      //   this.textBoxLiquidOutName.Name = "textBoxLiquidOutName";
      //   this.textBoxLiquidOutName.Size = new System.Drawing.Size(80, 20);
      //   this.textBoxLiquidOutName.TabIndex = 11;
      //   this.textBoxLiquidOutName.Text = "";
      //   // 
      //   // textBoxLiquidInName
      //   // 
      //   this.textBoxLiquidInName.Location = new System.Drawing.Point(196, 12);
      //   this.textBoxLiquidInName.Name = "textBoxLiquidInName";
      //   this.textBoxLiquidInName.Size = new System.Drawing.Size(80, 20);
      //   this.textBoxLiquidInName.TabIndex = 10;
      //   this.textBoxLiquidInName.Text = "";
      //   // 
      //   // panel
      //   // 
      //   this.panel.Controls.Add(this.groupBoxLiquidStream);
      //   this.panel.Controls.Add(this.groupBoxGasStream);
      //   this.panel.Size = new System.Drawing.Size(1010, 329);
      //   // 
      //   // WetScrubberEditor
      //   // 
      //   this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
      //   this.ClientSize = new System.Drawing.Size(1010, 351);
      //   this.Name = "WetScrubberEditor";
      //   this.Text = "Wet Scrubber";
      //   this.groupBoxGasStream.ResumeLayout(false);
      //   this.groupBoxLiquidStream.ResumeLayout(false);
      //   ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel)).EndInit();
      //   this.panel.ResumeLayout(false);
      //   this.ResumeLayout(false);
      //}
      #endregion

      protected override void ValidatingHandler(object sender, System.ComponentModel.CancelEventArgs e)
      {
         WetScrubber wetScrubber = this.WetScrubberCtrl.WetScrubber;
         TextBox tb = (TextBox)sender;
         if (tb.Text != null)
         {
            if (tb.Text.Trim().Equals(""))
            {
               if (sender == this.textBoxName)
               {
                  e.Cancel = true;
                  string message3 = "Please specify a name!";
                  MessageBox.Show(message3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }
            }
            else
            {
               if (sender == this.textBoxName)
               {
                  ErrorMessage error = wetScrubber.SpecifyName(this.textBoxName.Text);
                  if (error != null)
                     UI.ShowError(error);
               }
            }
         }
      }

      protected override void KeyUpHandler(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         ArrayList list = new ArrayList();
         list.Add(this.textBoxName);
         list.Add(this.textBoxLiquidInName);
         list.Add(this.textBoxLiquidOutName);
         list.Add(this.textBoxGasInName);
         list.Add(this.textBoxGasOutName);

         if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
         {
            UI.NavigateKeyboard(list, sender, this, KeyboardNavigation.Down);
         }
         else if (e.KeyCode == Keys.Up)
         {
            UI.NavigateKeyboard(list, sender, this, KeyboardNavigation.Up);
         }
      }

      private void WetScrubber_StreamAttached(UnitOperation uo, ProcessStreamBase ps, int desc)
      {
         this.UpdateStreamsUI();
      }

      private void WetScrubber_StreamDetached(UnitOperation uo, ProcessStreamBase ps)
      {
         this.UpdateStreamsUI();
      }

      private void UpdateStreamsUI()
      {
         // clear the stream group-boxes and start again
         //this.groupBoxGasStream.Controls.Clear();
         //this.groupBoxLiquidStream.Controls.Clear();

         WetScrubber wetScrubber = this.WetScrubberCtrl.WetScrubber;
         bool hasGasIn = false;
         bool hasGasOut = false;
         bool hasLiquidIn = false;
         bool hasLiquidOut = false;

         ProcessStreamBase gasIn = wetScrubber.GasInlet;
         if (gasIn != null)
            hasGasIn = true;

         ProcessStreamBase gasOut = wetScrubber.GasOutlet;
         if (gasOut != null)
            hasGasOut = true;

         ProcessStreamBase liquidIn = wetScrubber.LiquidInlet;
         if (liquidIn != null)
            hasLiquidIn = true;

         ProcessStreamBase liquidOut = wetScrubber.LiquidOutlet;
         if (liquidOut != null)
            hasLiquidOut = true;

         if (hasGasIn)
         {
            
            ProcessStreamBaseControl baseCtrl = (ProcessStreamBaseControl)this.WetScrubberCtrl.Flowsheet.StreamManager.GetProcessStreamBaseControl(this.WetScrubberCtrl.WetScrubber.GasInlet.Name);
            initializeGrid(baseCtrl, columnIndex, false, "Gas Inlet/Outlet");
            columnIndex += 2;
         }

         if (hasGasOut)
         {
            ProcessStreamBaseControl baseCtrl = (ProcessStreamBaseControl)this.WetScrubberCtrl.Flowsheet.StreamManager.GetProcessStreamBaseControl(this.WetScrubberCtrl.WetScrubber.GasOutlet.Name);
            if (hasGasIn)
            {
                initializeGrid(baseCtrl, columnIndex, true, "Gas Inlet/Outlet");
                columnIndex++;
            }
            else
            {
                initializeGrid(baseCtrl, columnIndex, false, "Gas Inlet/Outlet");
                columnIndex += 2;
            }
            
            //this.textBoxGasOutName.Text = wetScrubber.GasOutlet.Name;
            //UI.SetStatusColor(this.textBoxGasOutName, wetScrubber.GasOutlet.SolveState);
         }

         if (hasLiquidIn)
         {
            ProcessStreamBaseControl baseCtrl = (ProcessStreamBaseControl)this.WetScrubberCtrl.Flowsheet.StreamManager.GetProcessStreamBaseControl(this.WetScrubberCtrl.WetScrubber.LiquidInlet.Name);
            initializeGrid(baseCtrl, columnIndex, false, "Liquid Inlet/Outlet");
            columnIndex += 2;
         }

         if (hasLiquidOut)
         {
            ProcessStreamBaseControl baseCtrl = (ProcessStreamBaseControl)this.WetScrubberCtrl.Flowsheet.StreamManager.GetProcessStreamBaseControl(this.WetScrubberCtrl.WetScrubber.LiquidOutlet.Name);
            if (hasLiquidIn)
            {
                initializeGrid(baseCtrl, columnIndex, true, "Liquid Inlet/Outlet");
                columnIndex++;

            }
            else
            {
                initializeGrid(baseCtrl, columnIndex, false, "Liquid Inlet/Outlet");
                columnIndex += 2;
            }

           //this.textBoxLiquidOutName.Text = wetScrubber.LiquidOutlet.Name;
            //UI.SetStatusColor(this.textBoxLiquidOutName, wetScrubber.LiquidOutlet.SolveState);
         }
      }

      private void comboBoxCalculationType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (!this.inConstruction)
         {
            ErrorMessage error = null;
            int idx = this.comboBoxCalculationType.SelectedIndex;
            if (idx == WetScrubberEditor.INDEX_BALANCE)
            {
               error = this.WetScrubberCtrl.WetScrubber.SpecifyCalculationType(UnitOpCalculationType.Balance);
               if (error == null)
               {
                  this.menuItemRating.Enabled = false;
               }
            }
            else if (idx == WetScrubberEditor.INDEX_RATING)
            {
               error = this.WetScrubberCtrl.WetScrubber.SpecifyCalculationType(UnitOpCalculationType.Rating);
               if (error == null)
               {
                  this.menuItemRating.Enabled = true;
               }
            }
            if (error != null)
            {
               UI.ShowError(error);
               this.SetCalculationType(this.WetScrubberCtrl.WetScrubber.CalculationType);
            }
         }
      }

      public void SetCalculationType(UnitOpCalculationType type)
      {
         if (type == UnitOpCalculationType.Balance)
            this.comboBoxCalculationType.SelectedIndex = INDEX_BALANCE;
         else if (type == UnitOpCalculationType.Rating)
            this.comboBoxCalculationType.SelectedIndex = INDEX_RATING;
      }

      private void menuItemRating_Click(object sender, EventArgs e)
      {
/*
         if (this.WetScrubberCtrl.WetScrubber.CurrentRatingModel != null)
         {
            this.comboBoxCalculationType.Enabled = false;

            if (this.editor == null)
            {
               this.editor = new WetScrubberRatingEditor(this.WetScrubberCtrl);
               this.editor.Owner = this;
               this.editor.Closed += new EventHandler(editor_Closed);
               this.editor.Show();
            }
            else
            {
               if (this.editor.WindowState.Equals(FormWindowState.Minimized))
                  this.editor.WindowState = FormWindowState.Normal;
               this.editor.Activate();
            }
         }
*/         
      }

      private void editor_Closed(object sender, EventArgs e)
      {
//         this.editor = null;
         this.comboBoxCalculationType.Enabled = true;
      }
   }
}
