using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using Prosimo.UnitOperations;
using Prosimo.UnitOperations.ProcessStreams;
using Prosimo.UnitSystems;

namespace ProsimoUI.ProcessStreamsUI {
   /// <summary>
   /// Summary description for ProcessStreamControl.
   /// </summary>
   [Serializable]
   public class ProcessStreamControl : ProcessStreamBaseControl {
      private const int CLASS_PERSISTENCE_VERSION = 1;

      public ProcessStream ProcessStream {
         get { return (ProcessStream)this.Solvable; }
         set { this.Solvable = value; }
      }

      public ProcessStreamControl() {
      }

      public ProcessStreamControl(Flowsheet flowsheet, Point location, ProcessStream processStream)
         : this(flowsheet, location, processStream, StreamOrientation.Right) {

         //InitializeComponent();

         //this.Size = new System.Drawing.Size(UI.STREAM_CTRL_W, UI.STREAM_CTRL_H);
         //UI.SetStatusColor(this, this.ProcessStream.SolveState);
         //this.Orientation = StreamOrientation.Right;
         //this.UpdateBackImage();
         //this.flowsheet.ConnectionManager.UpdateConnections(this);
      }

      public ProcessStreamControl(Flowsheet flowsheet, Point location, ProcessStream processStream, StreamOrientation orientation)
         : base(flowsheet, location, processStream, orientation) {

         InitializeComponent();

         this.Size = new System.Drawing.Size(UI.STREAM_CTRL_W, UI.STREAM_CTRL_H);
         UI.SetStatusColor(this, this.ProcessStream.SolveState);
         this.Orientation = StreamOrientation.Right;
         this.UpdateBackImage();
         this.flowsheet.ConnectionManager.UpdateConnections(this);
         this.Name = "Process Stream: " + processStream.Name;
      }


      private void InitializeComponent() {
         // 
         // ProcessStreamControl
         // 
         //this.Name = "ProcessStreamControl";
         this.Size = new System.Drawing.Size(72, 32);
      }

      //protected override void DoThePaint()
      //{
      //   this.DrawSelection();
      //   this.UpdateNameControlLocation();
      //}

      public override void Edit() {
         if (this.editor == null) {
            this.editor = new ProcessStreamBaseEditor(this);
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
         if (this.Orientation.Equals(StreamOrientation.Down)) {
            if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_NOT_SOLVED_DOWN_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_WITH_WARNING_DOWN_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_DOWN_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVE_FAILED_DOWN_IMG;
            }
         }
         else if (this.Orientation.Equals(StreamOrientation.Left)) {
            if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_NOT_SOLVED_LEFT_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_WITH_WARNING_LEFT_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_LEFT_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVE_FAILED_LEFT_IMG;
            }
         }
         else if (this.Orientation.Equals(StreamOrientation.Right)) {
            if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_NOT_SOLVED_RIGHT_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_WITH_WARNING_RIGHT_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_RIGHT_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVE_FAILED_RIGHT_IMG;
            }
         }
         else if (this.Orientation.Equals(StreamOrientation.Up)) {
            if (this.solvable.SolveState.Equals(SolveState.NotSolved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_NOT_SOLVED_UP_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolvedWithWarning)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_WITH_WARNING_UP_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.Solved)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVED_UP_IMG;
            }
            else if (this.solvable.SolveState.Equals(SolveState.SolveFailed)) {
               this.BackgroundImage = UI.IMAGES.PROCESS_CTRL_SOLVE_FAILED_UP_IMG;
            }
         }
      }

      public override string ToPrintToolTip() {
         return this.ToPrint();
      }

      public override string ToPrint() {
         UnitSystem us = UnitSystemService.GetInstance().CurrentUnitSystem;
         string nfs = this.flowsheet.ApplicationPrefs.NumericFormatString;
         StringBuilder sb = new StringBuilder();

         sb.Append("Process Stream: ");
         sb.Append(this.ProcessStream.Name);
         sb.Append("\r\n");
         sb.Append(UI.UNDERLINE);
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.MassFlowRate, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.MassFlowRate, us, nfs));
         if (this.ProcessStream.MassFlowRate.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.VolumeFlowRate, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.VolumeFlowRate, us, nfs));
         if (this.ProcessStream.VolumeFlowRate.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.Pressure, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.Pressure, us, nfs));
         if (this.ProcessStream.Pressure.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.Temperature, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.Temperature, us, nfs));
         if (this.ProcessStream.Temperature.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.SpecificEnthalpy, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.SpecificEnthalpy, us, nfs));
         if (this.ProcessStream.SpecificEnthalpy.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.SpecificHeat, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.SpecificHeat, us, nfs));
         if (this.ProcessStream.SpecificHeat.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         sb.Append(GetVariableName(this.ProcessStream.Density, us));
         sb.Append(" = ");
         sb.Append(GetVariableValue(this.ProcessStream.Density, us, nfs));
         if (this.ProcessStream.Density.IsSpecified)
            sb.Append(" * ");
         sb.Append("\r\n");

         return sb.ToString();
      }

      protected ProcessStreamControl(SerializationInfo info, StreamingContext context)
         : base(info, context) {
      }

      //public override void SetObjectData(SerializationInfo info, StreamingContext context) {
      //   base.SetObjectData(info, context);
      public override void SetObjectData() {
         base.SetObjectData();
         int persistedClassVersion = (int)info.GetValue("ClassPersistenceVersionProcessStreamControl", typeof(int));
      }

      [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
      public override void GetObjectData(SerializationInfo info, StreamingContext context) {
         base.GetObjectData(info, context);
         info.AddValue("ClassPersistenceVersionProcessStreamControl", ProcessStreamControl.CLASS_PERSISTENCE_VERSION, typeof(int));
      }
   }
}
