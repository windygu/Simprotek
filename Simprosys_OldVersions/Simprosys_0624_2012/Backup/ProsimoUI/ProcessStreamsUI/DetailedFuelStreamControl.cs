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
   public class DetailedFuelStreamControl : ProcessStreamBaseControl {
      private const int CLASS_PERSISTENCE_VERSION = 1;

      public WaterStream WaterStream {
         get { return (WaterStream)this.Solvable; }
         set { this.Solvable = value; }
      }

      public DetailedFuelStreamControl() {
      }

      public DetailedFuelStreamControl(Flowsheet flowsheet, Point location, DetailedFuelStream detailedFuelStream)
         : this(flowsheet, location, detailedFuelStream, StreamOrientation.Right) {

         //InitializeComponent();

         //this.Size = new System.Drawing.Size(UI.STREAM_CTRL_W, UI.STREAM_CTRL_H);
         //UI.SetStatusColor(this, this.WaterStream.SolveState);
         //this.Orientation = StreamOrientation.Right;
         //this.UpdateBackImage();
         //this.flowsheet.ConnectionManager.UpdateConnections(this);
      }

      public DetailedFuelStreamControl(Flowsheet flowsheet, Point location, DetailedFuelStream detailedFuelStream, StreamOrientation orientation)
         : base(flowsheet, location, detailedFuelStream, orientation) {

         InitializeComponent();

         this.Size = new System.Drawing.Size(UI.STREAM_CTRL_W, UI.STREAM_CTRL_H);
         UI.SetStatusColor(this, this.WaterStream.SolveState);
         //this.Orientation = StreamOrientation.Right;
         this.UpdateBackImage();
         this.flowsheet.ConnectionManager.UpdateConnections(this);
         this.Name = "Fuel Stream: " + detailedFuelStream.Name;
      }


      private void InitializeComponent() {
         // 
         // ProcessStreamControl
         // 
         //this.Name = "WaterStreamControl";
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

         sb.Append("Detailed Fuel Stream: ");
         sb.Append(this.WaterStream.Name);
         sb.Append("\r\n");
         sb.Append(UI.UNDERLINE);
         sb.Append("\r\n");

         sb.Append(ToPrintVarList());
         
         return sb.ToString();
      }

      protected DetailedFuelStreamControl(SerializationInfo info, StreamingContext context)
         : base(info, context) {
      }

      //public override void SetObjectData(SerializationInfo info, StreamingContext context) {
      //   base.SetObjectData(info, context);
      public override void SetObjectData() {
         base.SetObjectData();
         int persistedClassVersion = (int)info.GetValue("ClassPersistenceVersionDetailedFuelStreamControl", typeof(int));
      }

      [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
      public override void GetObjectData(SerializationInfo info, StreamingContext context) {
         base.GetObjectData(info, context);
         info.AddValue("ClassPersistenceVersionDetailedFuelStreamControl", CLASS_PERSISTENCE_VERSION, typeof(int));
      }
   }
}
