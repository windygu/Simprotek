using System;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Prosimo.UnitOperations;
using Prosimo.UnitOperations.GasSolidSeparation;
using ProsimoUI.UnitOperationsUI;
using ProsimoUI.UnitOperationsUI.TwoStream;

namespace ProsimoUI.GlobalEditor
{
   /// <summary>
   /// Summary description for ElectrostaticPrecipitatorsEditor.
   /// </summary>
   public class ElectrostaticPrecipitatorsEditor : UnitOpsEditor
   {
      private const string TITLE = "Electrostatic Precipitators:";

      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ElectrostaticPrecipitatorsEditor() : base()
      {
         // This call is required by the Windows.Forms Form Designer.
         InitializeComponent();
      }

      public ElectrostaticPrecipitatorsEditor(Flowsheet flowsheet) : base(flowsheet)
      {
         // This call is required by the Windows.Forms Form Designer.
         InitializeComponent();
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

      #region Component Designer generated code
      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         components = new System.ComponentModel.Container();
      }
      #endregion

      protected override string GetTitle()
      {
         return ElectrostaticPrecipitatorsEditor.TITLE;
      }

      protected override Type GetUnitOpType() {
         return typeof(ElectrostaticPrecipitator);
      }

      protected override UserControl GetNewUnitOpLabelsControl(Solvable solvable)
      {
         return new ProcessVarLabelsControl(solvable.VarList);
      }

      protected override IList GetShowableInEditorUnitOpControls()
      {
         return this.flowsheet.UnitOpManager.GetShowableInEditorUnitOpControls<ElectrostaticPrecipitator>();
      }

      protected override UserControl GetNewUnitOpValuesControl(UnitOpControl unitOpCtrl)
      {
         return new ProcessVarValuesControl(unitOpCtrl);
      }
   }
}
