using System;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

using Prosimo.UnitOperations;
using ProsimoUI;
using ProsimoUI.UnitOperationsUI;
using ProsimoUI.UnitOperationsUI.TwoStream;
using Prosimo.UnitOperations.ProcessStreams;
using Prosimo.UnitSystems;

namespace ProsimoUI.ProcessStreamsUI {
   /// <summary>
   /// Summary description for GasStreamControl.
   /// </summary>
   [Serializable]
   public class GasStreamControl : ProcessStreamBaseControl {
      private const int CLASS_PERSISTENCE_VERSION = 1;

      internal protected override string SolvableTypeName
      {
         get { return "Gas Stream"; }
      }

      public DryingGasStream GasStream {
         get { return (DryingGasStream)this.solvable; }
         set { this.solvable = value; }
      }

      public GasStreamControl() {
      }

      public GasStreamControl(Flowsheet flowsheet, Point location, DryingGasStream gasStream)
         : base(flowsheet, location, gasStream) {

         InitializeComponent();
      }

      public GasStreamControl(Flowsheet flowsheet, Point location, DryingGasStream gasStream, StreamOrientation orientation)
         : base(flowsheet, location, gasStream, orientation) {

         InitializeComponent();
         this.Name = "Gas Stream: " + gasStream.Name;
      }


      //private void Init() {
      //   this.Size = new System.Drawing.Size(UI.STREAM_CTRL_W, UI.STREAM_CTRL_H);
      //   UI.SetStatusColor(this, this.GasStream.SolveState);
      //   this.Orientation = StreamOrientation.Right;
      //   this.UpdateBackImage();
      //   this.flowsheet.ConnectionManager.UpdateConnections(this);
      //}

      private void InitializeComponent() {
         // 
         // GasStreamControl
         // 
         this.BackColor = System.Drawing.Color.Gainsboro;
         this.Name = "Gas Stream: ";
         //this.Size = new System.Drawing.Size(144, 128);
      }

      //protected override void DoThePaint()
      //{
      //   this.DrawSelection();
      //   this.UpdateNameControlLocation();
      //}

      public override void Edit() {
         if (this.editor == null) {
            this.editor = new GasStreamEditor(this);
            //this.editor = new ProcessStreamBaseEditor(this);
            this.editor.Owner = (Form)this.flowsheet.Parent;
            this.editor.Show();
         }
         else {
            if (this.editor.WindowState.Equals(FormWindowState.Minimized))
               this.editor.WindowState = FormWindowState.Normal;
            this.editor.Activate();
         }
      }

      protected override void UpdateBackImage() {
         if(this.solvable.SolveState.Equals(SolveState.NotSolved))
         {
            this.BackgroundImage = UI.IMAGES.GAS_CTRL_NOT_SOLVED_RIGHT_IMG;
         }
         else if(this.solvable.SolveState.Equals(SolveState.SolvedWithWarning))
         {
            this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_WITH_WARNING_RIGHT_IMG;
         }
         else if(this.solvable.SolveState.Equals(SolveState.Solved))
         {
            this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_RIGHT_IMG;
         }
         else if(this.solvable.SolveState.Equals(SolveState.SolveFailed))
         {
            this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVE_FAILED_RIGHT_IMG;
         }

         UpdateBackImageOrientation();
      }

      protected GasStreamControl(SerializationInfo info, StreamingContext context)
         : base(info, context) {

         InitializeComponent();
      }

      //public override void SetObjectData(SerializationInfo info, StreamingContext context) {
      //   base.SetObjectData(info, context);
      public override void SetObjectData() {
         base.SetObjectData();
         int persistedClassVersion = info.GetInt32("ClassPersistenceVersionGasStreamControl");
      }

      [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
      public override void GetObjectData(SerializationInfo info, StreamingContext context) {
         base.GetObjectData(info, context);
         info.AddValue("ClassPersistenceVersionGasStreamControl", GasStreamControl.CLASS_PERSISTENCE_VERSION, typeof(int));
      }
   }
}
//public override string ToPrintToolTip() {
//   UnitSystem us = UnitSystemService.GetInstance().CurrentUnitSystem;
//   string nfs = this.flowsheet.ApplicationPrefs.NumericFormatString;
//   StringBuilder sb = new StringBuilder();

//   sb.Append("Drying Gas Stream: ");
//   sb.Append(this.GasStream.Name);
//   sb.Append("\r\n");
//   sb.Append(UI.UNDERLINE);
//   sb.Append("\r\n");

//   sb.Append(GetVariableName(this.GasStream.MassFlowRate, us));
//   sb.Append(" = ");
//   sb.Append(GetVariableValue(this.GasStream.MassFlowRate, us, nfs));
//   if (this.GasStream.MassFlowRate.IsSpecified)
//      sb.Append(" * ");
//   sb.Append("\r\n");

//   sb.Append(GetVariableName(this.GasStream.VolumeFlowRate, us));
//   sb.Append(" = ");
//   sb.Append(GetVariableValue(this.GasStream.VolumeFlowRate, us, nfs));
//   if (this.GasStream.VolumeFlowRate.IsSpecified)
//      sb.Append(" * ");
//   sb.Append("\r\n");

//   sb.Append(GetVariableName(this.GasStream.Pressure, us));
//   sb.Append(" = ");
//   sb.Append(GetVariableValue(this.GasStream.Pressure, us, nfs));
//   if (this.GasStream.Pressure.IsSpecified)
//      sb.Append(" * ");
//   sb.Append("\r\n");

//   sb.Append(GetVariableName(this.GasStream.Temperature, us));
//   sb.Append(" = ");
//   sb.Append(GetVariableValue(this.GasStream.Temperature, us, nfs));
//   if (this.GasStream.Temperature.IsSpecified)
//      sb.Append(" * ");
//   sb.Append("\r\n");

//   sb.Append(GetVariableName(this.GasStream.Humidity, us));
//   sb.Append(" = ");
//   sb.Append(GetVariableValue(this.GasStream.Humidity, us, nfs));
//   if (this.GasStream.Humidity.IsSpecified)
//      sb.Append(" * ");
//   sb.Append("\r\n");

//   sb.Append(GetVariableName(this.GasStream.RelativeHumidity, us));
//   sb.Append(" = ");
//   sb.Append(GetVariableValue(this.GasStream.RelativeHumidity, us, nfs));
//   if (this.GasStream.RelativeHumidity.IsSpecified)
//      sb.Append(" * ");
//   sb.Append("\r\n");

//   return sb.ToString();
//}

//public override string ToPrint() {
//   //UnitSystem us = UnitSystemService.GetInstance().CurrentUnitSystem;
//   //string nfs = this.flowsheet.ApplicationPrefs.NumericFormatString;
//   //StringBuilder sb = new StringBuilder();

//   //sb.Append("Drying Gas Stream: ");
//   //sb.Append(this.GasStream.Name);
//   //sb.Append("\r\n");
//   //sb.Append(UI.UNDERLINE);
//   //sb.Append("\r\n");

//   //sb.Append(ToPrintVarList());

//   //return sb.ToString();
//   return ToPrintVarList("Drying Gas Stream: ");
//}

   //sb.Append(GetVariableName(this.GasStream.MassFlowRate, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.MassFlowRate, us, nfs));
   //if (this.GasStream.MassFlowRate.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.MassFlowRateDryBase, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.MassFlowRateDryBase, us, nfs));
   //if (this.GasStream.MassFlowRateDryBase.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.VolumeFlowRate, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.VolumeFlowRate, us, nfs));
   //if (this.GasStream.VolumeFlowRate.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.Pressure, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.Pressure, us, nfs));
   //if (this.GasStream.Pressure.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.Temperature, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.Temperature, us, nfs));
   //if (this.GasStream.Temperature.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.WetBulbTemperature, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.WetBulbTemperature, us, nfs));
   //if (this.GasStream.WetBulbTemperature.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.DewPoint, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.DewPoint, us, nfs));
   //if (this.GasStream.DewPoint.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.Humidity, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.Humidity, us, nfs));
   //if (this.GasStream.Humidity.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.RelativeHumidity, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.RelativeHumidity, us, nfs));
   //if (this.GasStream.RelativeHumidity.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.SpecificEnthalpy, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.SpecificEnthalpy, us, nfs));
   //if (this.GasStream.SpecificEnthalpy.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.SpecificHeatDryBase, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.SpecificHeatDryBase, us, nfs));
   //if (this.GasStream.SpecificHeatDryBase.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

   //sb.Append(GetVariableName(this.GasStream.Density, us));
   //sb.Append(" = ");
   //sb.Append(GetVariableValue(this.GasStream.Density, us, nfs));
   //if (this.GasStream.Density.IsSpecified)
   //   sb.Append(" * ");
   //sb.Append("\r\n");

//if (this.Orientation.Equals(StreamOrientation.Down)) {
//   if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_NOT_SOLVED_DOWN_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_WITH_WARNING_DOWN_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_DOWN_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVE_FAILED_DOWN_IMG;
//   }
//}
//else if (this.Orientation.Equals(StreamOrientation.Left)) {
//   if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_NOT_SOLVED_LEFT_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_WITH_WARNING_LEFT_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_LEFT_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVE_FAILED_LEFT_IMG;
//   }
//}
//else if (this.Orientation.Equals(StreamOrientation.Right)) {
//   if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_NOT_SOLVED_RIGHT_IMG;
//      //this.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_WITH_WARNING_RIGHT_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_RIGHT_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVE_FAILED_RIGHT_IMG;
//   }
//}
//else if (this.Orientation.Equals(StreamOrientation.Up)) {
//   if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_NOT_SOLVED_UP_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_WITH_WARNING_UP_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVED_UP_IMG;
//   }
//   else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
//      this.BackgroundImage = UI.IMAGES.GAS_CTRL_SOLVE_FAILED_UP_IMG;
//   }
//}
