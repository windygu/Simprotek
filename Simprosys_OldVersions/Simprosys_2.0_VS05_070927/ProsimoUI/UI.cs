using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Printing;

using Prosimo.UnitOperations;
using Prosimo.UnitOperations.ProcessStreams;
using Prosimo.UnitOperations.Drying;
using Prosimo.UnitOperations.FluidTransport;
using Prosimo.UnitOperations.GasSolidSeparation;
using Prosimo.UnitOperations.HeatTransfer;
using Prosimo.UnitOperations.LiquidSolidSeparation;
using Prosimo.UnitOperations.Miscellaneous;
using Prosimo.UnitOperations.VaporLiquidSeparation;
using Prosimo.UnitSystems;
using Prosimo;
using ProsimoUI.Plots;
using Prosimo.Plots;

namespace ProsimoUI {
   public delegate void NumericFormatStringChangedEventHandler(INumericFormat iNumericFormat);
   //public delegate void ActivityChangedEventHandler(FlowsheetActivity flowsheetActivity);
   public delegate void ActivityChangedEventHandler<EventArgsType>(object sender, EventArgsType evt);
   public delegate void SaveFlowsheetEventHandler(Flowsheet flowsheet);
   public delegate void ProcessVarAddedEventHandler(ProcessVar var);
   public delegate void ProcessVarDeletedEventHandler(ArrayList vars, ArrayList idxs);
   public delegate void SnapshotTakenEventHandler(Bitmap image);
   public delegate void ToolboxAliveChangedEventHandler(bool alive);
   public delegate void ToolboxLocationChangedEventHandler(Point location);
   public delegate void ToolboxVisibleChangedEventHandler(bool visible);
   public delegate void PlotSelectedEventHandler(Plot2DGraph plotGraph);

   /// <summary>
   /// Summary description for UI.
   /// </summary>
   public class UI {
      public const string STR_ALL = "All";
      public const string FILE_EXT = "simcase";
      public const string FILE_EXT_TYPE = "SIMCASE|*.";

      public const string STR_USER_DEF_USER_DEF = "User Defined";
      public const string STR_USER_DEF_NOT_USER_DEF = "Not User Defined";

      public const string STR_YES = "Yes";
      public const string STR_NO = "No";

      public const string UNDERLINE = "--------------------------------------------------------";
      public const string UNDERLINE2 = "===============================";
      public const string NEW_SYSTEM = "New Flowsheet";
      public const string DIRTY = "*";

      public const string FIXED_POINT = "F";
      public const string SCIENTIFIC = "E";
      public const string DECIMAL = "D";

      public const string NEW_LINE = "\r\n";

      public static Color NAME_CTRL_COLOR = Color.White;

      public const int DELTA_W = 30;
      public const int DELTA_H = 30;

      public const int UNIT_OP_CTRL_W = 40;
      public const int UNIT_OP_CTRL_H = 40;

      public const int STREAM_CTRL_W = 28;
      public const int STREAM_CTRL_H = 28;

      public const int SELECTION_SIZE = 3;
      //public Color SELECTION_COLOR = Color.Gray;

      public static Color CONNECTION_COLOR_GAS = Color.DarkOrange;
      public static Color CONNECTION_COLOR_MATERIAL = Color.Blue;
      public static Color CONNECTION_COLOR_PROCESS = Color.DeepPink;
      public const int CONNECTION_WIDTH = 1;
      public const int CONNECTION_DELTA = 10;
      public const int CONNECTION_REGION_WIDTH = 2;

      public static Color SLOT_COLOR = Color.Gray;
      public const int SLOT_DELTA = 8;

      public static Color COLOR_NOT_SOLVED = Color.LightGray;
      public static Color COLOR_SOLVED_WITH_WARNING = Color.Yellow;
      public static Color COLOR_SOLVED = Color.LightGreen;
      public static Color COLOR_SOLVE_FAILED = Color.Red;

      public static int SUB_CHAR_OFFSET = -5;
      public static int SUP_CHAR_OFFSET = 5;

      public static UIForm IMAGES = new UIForm();

      private static IDictionary<Type, string> solvableNameTable;

      static UI() {
         solvableNameTable = new Dictionary<Type, string>();
         solvableNameTable.Add(typeof(LiquidDryingMaterialStream), "Liquid Material Stream");
         solvableNameTable.Add(typeof(SolidDryingMaterialStream), "Solid Material Stream");
         solvableNameTable.Add(typeof(DryingGasStream), "Gas Stream");
         solvableNameTable.Add(typeof(LiquidDryer), "Liquid Material Dryer");
         solvableNameTable.Add(typeof(SolidDryer), "Solid Material Dryer");
         solvableNameTable.Add(typeof(Cooler), "Cooler");
         solvableNameTable.Add(typeof(ElectrostaticPrecipitator), "Electrostatic Precipitator");
         solvableNameTable.Add(typeof(HeatExchanger), "Heat Exchanger");
         solvableNameTable.Add(typeof(Cyclone), "Cyclone");
         solvableNameTable.Add(typeof(Ejector), "Ejector");
         solvableNameTable.Add(typeof(WetScrubber), "Wet Scrubber");
         solvableNameTable.Add(typeof(ScrubberCondenser), "Scrubber Condenser");
         solvableNameTable.Add(typeof(Mixer), "Mixer");
         solvableNameTable.Add(typeof(Tee), "Tee");
         solvableNameTable.Add(typeof(FlashTank), "Flash Tank");
         solvableNameTable.Add(typeof(Fan), "Fan");
         solvableNameTable.Add(typeof(Compressor), "Compressor");
         solvableNameTable.Add(typeof(Valve), "Valve");
         solvableNameTable.Add(typeof(BagFilter), "Bag Filter");
         solvableNameTable.Add(typeof(AirFilter), "Air Filter");
         solvableNameTable.Add(typeof(Pump), "Pump");
         solvableNameTable.Add(typeof(Recycle), "Recycle");
         solvableNameTable.Add(typeof(Heater), "Heater");
      }
      //      public UI()
      //      {
      //      }

      public static IDictionary<Type, string> SolvableNameTable {
         get { return solvableNameTable; }
      }

      //public static string GetReleaseType() {
      //   return "Version 1.0";
      //}

      public static float GetNumericValueAsFloat(TextBox tb, System.ComponentModel.CancelEventArgs e) {
         try {
            float val = (float)Double.Parse(tb.Text);
            return val;
         }
         catch (FormatException) {
            e.Cancel = true;
            return 0f;
         }
      }

      public static double GetNumericValueAsDouble(TextBox tb, System.ComponentModel.CancelEventArgs e) {
         try {
            double val = Double.Parse(tb.Text);
            return val;
         }
         catch (FormatException) {
            e.Cancel = true;
            return 0f;
         }
      }

      public static bool HasNumericValue(TextBox tb) {
         bool isValid = false;
         if (tb.Text != null) {
            string message = "Please enter a numeric value!";
            if (tb.Text.Trim().Equals("")) {
               MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
               try {
                  double val = Double.Parse(tb.Text);
                  isValid = true;
               }
               catch (FormatException) {
                  MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }
            }
         }
         return isValid;
      }

      public static AxisVariable ConvertToAxisVariable(PlotVariable pv) {
         // Note: this also converts the values from model's default Unit System to the current Unit System
         string currentUnit = UnitSystemService.GetInstance().GetUnitAsString(pv.Variable.Type);
         double currentMin = UnitSystemService.GetInstance().ConvertFromSIValue(pv.Variable.Type, pv.Min);
         double currentMax = UnitSystemService.GetInstance().ConvertFromSIValue(pv.Variable.Type, pv.Max);
         Range currentRange = new Range((float)currentMin, (float)currentMax);
         AxisVariable av = new AxisVariable(pv.Variable.Name, currentUnit, currentRange);
         return av;
      }

      public static CurveFamily[] ConvertCurveFamilies(CurveFamilyF[] oldFamilies, PhysicalQuantity xPhysicalQuantity, PhysicalQuantity yPhysicalQuantity) {
         // Note: this also converts the values from model's default Unit System to the current Unit System
         CurveFamily[] newFamilies = new CurveFamily[oldFamilies.Length];
         int k = 0;
         foreach (CurveFamilyF curveFamily in oldFamilies) {
            CurveFamily cf = new CurveFamily();
            cf.Name = curveFamily.Name;
            PhysicalQuantity pq = curveFamily.PhysicalQuantity;
            cf.Unit = UnitSystemService.GetInstance().GetUnitAsString(pq);

            Curve[] newCurves = new Curve[curveFamily.Curves.Length];
            int j = 0;

            foreach (CurveF curve in curveFamily.Curves) {
               Curve c = new Curve();
               c.Name = curve.Name;
               c.Unit = UnitSystemService.GetInstance().GetUnitAsString(pq);
               c.Value = (float)UnitSystemService.GetInstance().ConvertFromSIValue(pq, curve.Value);

               PointF[] newData = new PointF[curve.Data.Length];
               int i = 0;
               foreach (PointF point in curve.Data) {
                  float newX = (float)UnitSystemService.GetInstance().ConvertFromSIValue(xPhysicalQuantity, point.X);
                  float newY = (float)UnitSystemService.GetInstance().ConvertFromSIValue(yPhysicalQuantity, point.Y);
                  PointF p = new PointF(newX, newY);
                  newData[i++] = p;
               }
               c.Data = newData;

               // the new curve is built, so add it to the array of curves
               newCurves[j++] = c;
            }
            cf.Curves = newCurves;

            // the new family is built, so add it to the array of families
            newFamilies[k++] = cf;
         }
         return newFamilies;
      }

      public static bool GetUserDefinedAsBool(string userDefStr) {
         bool userDefBool = false;
         if (userDefStr.Equals(UI.STR_USER_DEF_USER_DEF))
            userDefBool = true;
         else if (userDefStr.Equals(UI.STR_USER_DEF_NOT_USER_DEF))
            userDefBool = false;
         return userDefBool;
      }

      public static string GetBoolAsYesNo(bool boo) {
         if (boo)
            return UI.STR_YES;
         else
            return UI.STR_NO;
      }

      public static bool StringContainsString(string abcdStr, string bcStr, bool ignoreCase) {
         bool yes = false;
         int noOfCompar = abcdStr.Length - bcStr.Length + 1;
         if (noOfCompar > 0) {
            for (int i = 0; i < noOfCompar; i++) {
               string abStr = abcdStr.Substring(i, bcStr.Length);
               if (string.Compare(abStr, bcStr, ignoreCase) == 0) {
                  yes = true;
                  break;
               }
            }
         }
         return yes;
      }

      public static void ShowError(ErrorMessage error) {
         if (error != null) {
            MessageBox.Show(error.Message, error.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      public static Point CalculateLeftStreamLocation(Control ctrlRight, Control ctrlLeft, int maxY) {
         int x = ctrlRight.Location.X - UI.DELTA_W - ctrlLeft.Width;
         if (x < 0)
            x = 0;
         int y = ctrlRight.Location.Y + (ctrlRight.Height - ctrlLeft.Height) / 2;
         if (y < 0)
            y = 0;
         if (y > maxY - ctrlLeft.Height / 2)
            y = maxY - ctrlLeft.Height;
         return new Point(x, y);
      }

      public static Point CalculateLeftStreamLocation(Control ctrlRight, Control ctrlLeft, int k, int n) {
         int gap = ctrlLeft.Height / 2;
         int hSum = n * ctrlLeft.Height + (n - 1) * gap;
         int y1 = ctrlRight.Location.Y - (hSum - ctrlRight.Height) / 2;
         int yk = y1 + (k - 1) * (ctrlLeft.Height + gap);
         int x = ctrlRight.Location.X - UI.DELTA_W - ctrlLeft.Width;
         if (x < 0)
            x = 0;
         return new Point(x, yk);
      }

      public static Point CalculateRightStreamLocation(Control ctrlLeft, Control ctrlRight, int maxX, int maxY) {
         int x = ctrlLeft.Location.X + ctrlLeft.Width + UI.DELTA_W;
         if (x > maxX - ctrlRight.Width / 2)
            x = maxX - ctrlRight.Width;
         int y = ctrlLeft.Location.Y + (ctrlLeft.Height - ctrlRight.Height) / 2;
         if (y < 0)
            y = 0;
         if (y > maxY - ctrlRight.Height / 2)
            y = maxY - ctrlRight.Height;
         return new Point(x, y);
      }

      public static Point CalculateRightStreamLocation(Control ctrlLeft, Control ctrlRight, int k, int n, int maxX) {
         int gap = ctrlRight.Height / 2;
         int hSum = n * ctrlRight.Height + (n - 1) * gap;
         int y1 = ctrlLeft.Location.Y - (hSum - ctrlLeft.Height) / 2;
         int yk = y1 + (k - 1) * (ctrlRight.Height + gap);
         int x = ctrlLeft.Location.X + ctrlLeft.Width + UI.DELTA_W;
         if (x > maxX - ctrlRight.Width / 2)
            x = maxX - ctrlRight.Width;
         return new Point(x, yk);
      }

      public static Point CalculateUpStreamLocation(Control ctrlDown, Control ctrlUp, int maxX) {
         int x = ctrlDown.Location.X + (ctrlDown.Width - ctrlUp.Width) / 2;
         if (x < 0)
            x = 0;
         if (x > maxX - ctrlUp.Width / 2)
            x = maxX - ctrlUp.Width;
         int y = ctrlDown.Location.Y - ctrlUp.Height - UI.DELTA_H;
         if (y < 0)
            y = 0;
         return new Point(x, y);
      }

      public static Point CalculateDownStreamLocation(Control ctrlUp, Control ctrlDown, int maxX, int maxY) {
         int x = ctrlUp.Location.X + (ctrlUp.Width - ctrlDown.Width) / 2;
         if (x < 0)
            x = 0;
         if (x > maxX - ctrlDown.Width / 2)
            x = maxX - ctrlDown.Width;
         int y = ctrlUp.Location.Y + ctrlUp.Height + UI.DELTA_H;
         if (y > maxY - ctrlDown.Height / 2)
            y = maxY - ctrlDown.Height;
         return new Point(x, y);
      }

      public static void SetStatusTextAndColor(Label label, SolveState solveState) {
         //UI ui = new UI();
         string str = null;
         Color col = UI.COLOR_NOT_SOLVED;
         if (solveState.Equals(SolveState.NotSolved)) {
            str = "Not Solved";
            col = UI.COLOR_NOT_SOLVED;
         }
         else if (solveState.Equals(SolveState.SolvedWithWarning)) {
            str = "Solved with Warnings";
            col = UI.COLOR_SOLVED_WITH_WARNING;
         }
         else if (solveState.Equals(SolveState.Solved)) {
            str = "Solved";
            col = UI.COLOR_SOLVED;
         }
         else if (solveState.Equals(SolveState.SolveFailed)) {
            str = "Solve Failed";
            col = UI.COLOR_SOLVE_FAILED;
         }
         label.BackColor = col;
         label.Text = str;
      }

      public static void SetStatusTextAndIcon(StatusBarPanel statusBarPanel, SolveState solveState) {
         string str = null;
         Icon ic = UI.IMAGES.NOT_SOLVED_ICON;
         if (solveState.Equals(SolveState.NotSolved)) {
            str = "Not Solved";
            ic = UI.IMAGES.NOT_SOLVED_ICON;
         }
         else if (solveState.Equals(SolveState.SolvedWithWarning)) {
            str = "Solved with Warnings";
            ic = UI.IMAGES.SOLVED_WITH_WARNING_ICON;
         }
         else if (solveState.Equals(SolveState.Solved)) {
            str = "Solved";
            ic = UI.IMAGES.SOLVED_ICON;
         }
         else if (solveState.Equals(SolveState.SolveFailed)) {
            str = "Solve Failed";
            ic = UI.IMAGES.SOLVE_FAILED_ICON;
         }

         statusBarPanel.Text = str;
         statusBarPanel.Icon = ic;
      }

      public static void SetStatusColor(Control ctrl, SolveState solveState) {
         //UI ui = new UI();
         Color col = UI.COLOR_NOT_SOLVED;
         if (solveState.Equals(SolveState.NotSolved)) {
            col = UI.COLOR_NOT_SOLVED;
         }
         else if (solveState.Equals(SolveState.SolvedWithWarning)) {
            col = UI.COLOR_SOLVED_WITH_WARNING;
         }
         else if (solveState.Equals(SolveState.Solved)) {
            col = UI.COLOR_SOLVED;
         }
         else if (solveState.Equals(SolveState.SolveFailed)) {
            col = UI.COLOR_SOLVE_FAILED;
         }
         ctrl.BackColor = col;
      }

      public static void SetCtrlSize(Control ctrl) {
         Graphics g = ctrl.CreateGraphics();
         SizeF textSize = g.MeasureString(ctrl.Text, ctrl.Font);
         ctrl.Height = (int)textSize.Height + 1;
         ctrl.Width = (int)textSize.Width;

         g.Dispose();
      }

      public static string GetFlowsheetActivityAsString(FlowsheetActivity flowsheetActivity, Type unitOpType) {
         string activity = null;
         if (flowsheetActivity == FlowsheetActivity.AddingConnStepOne)
            activity = "Adding Connection: First Point";
         else if (flowsheetActivity == FlowsheetActivity.AddingConnStepTwo)
            activity = "Adding Connection: Second Point";
         //else if (flowsheetActivity == FlowsheetActivity.AddingCompressor)
         //   activity = "Adding Compressor";
         //else if (flowsheetActivity == FlowsheetActivity.AddingLiquidDryer)
         //   activity = "Adding Liquid Material Dryer";
         //else if (flowsheetActivity == FlowsheetActivity.AddingSolidDryer)
         //   activity = "Adding Solid Material Dryer";
         //else if (flowsheetActivity == FlowsheetActivity.AddingCooler)
         //   activity = "Adding Cooler";
         //else if (flowsheetActivity == FlowsheetActivity.AddingElectrostaticPrecipitator)
         //   activity = "Adding Electrostatic Precipitator";
         //else if (flowsheetActivity == FlowsheetActivity.AddingHeatExchanger)
         //   activity = "Adding Heat Exchanger";
         //else if (flowsheetActivity == FlowsheetActivity.AddingCyclone)
         //   activity = "Adding Cyclone";
         //else if (flowsheetActivity == FlowsheetActivity.AddingEjector)
         //   activity = "Adding Ejector";
         //else if (flowsheetActivity == FlowsheetActivity.AddingWetScrubber)
         //   activity = "Adding Wet Scrubber";
         //else if (flowsheetActivity == FlowsheetActivity.AddingScrubberCondenser)
         //   activity = "Adding Scrubber Condenser";
         //else if (flowsheetActivity == FlowsheetActivity.AddingMixer)
         //   activity = "Adding Mixer";
         //else if (flowsheetActivity == FlowsheetActivity.AddingTee)
         //   activity = "Adding Tee";
         //else if (flowsheetActivity == FlowsheetActivity.AddingFlashTank)
         //   activity = "Adding Flash Tank";
         //else if (flowsheetActivity == FlowsheetActivity.AddingFan)
         //   activity = "Adding Fan";
         //else if (flowsheetActivity == FlowsheetActivity.AddingValve)
         //   activity = "Adding Valve";
         //else if (flowsheetActivity == FlowsheetActivity.AddingBagFilter)
         //   activity = "Adding Bag Filter";
         //else if (flowsheetActivity == FlowsheetActivity.AddingAirFilter)
         //   activity = "Adding Air Filter";
         //else if (flowsheetActivity == FlowsheetActivity.AddingPump)
         //   activity = "Adding Pump";
         //else if (flowsheetActivity == FlowsheetActivity.AddingRecycle)
         //   activity = "Adding Recycle";
         //else if (flowsheetActivity == FlowsheetActivity.AddingHeater)
         //   activity = "Adding Heater";
         else if (flowsheetActivity == FlowsheetActivity.AddingSolvable)
            activity = "Adding " + solvableNameTable[unitOpType];
         //else if (flowsheetActivity == FlowsheetActivity.AddingGasStream)
         //   activity = "Adding Gas Stream";
         //else if (flowsheetActivity == FlowsheetActivity.AddingLiquidMaterialStream)
         //   activity = "Adding Liquid Material Stream";
         //else if (flowsheetActivity == FlowsheetActivity.AddingSolidMaterialStream)
         //   activity = "Adding Solid Material Stream";
         //else if (flowsheetActivity == FlowsheetActivity.AddingProcessStream)
         //   activity = "Adding Process Stream";
         else if (flowsheetActivity == FlowsheetActivity.Default)
            activity = "";
         else if (flowsheetActivity == FlowsheetActivity.DeletingConnection)
            activity = "Deleting Connection";
         else if (flowsheetActivity == FlowsheetActivity.SelectingSnapshot)
            activity = "Selecting Snapshot";
         return activity;
      }

      public static string GetVariableName(ProcessVar var, UnitSystem unitSystem) {
         string name = null;
         string unit = UnitSystemService.GetInstance().GetUnitAsString(var.Type);
         if (unit != null && !unit.Trim().Equals(""))
            name = var.VarTypeName + " (" + unit + ")";
         else
            name = var.VarTypeName;
         return name;
      }
      public static string GetUnitName(ProcessVar var, UnitSystem unitSystem) {
         string unit = UnitSystemService.GetInstance().GetUnitAsString(var.Type);
         if (unit != null && !unit.Trim().Equals(""))
            return unit;
         else
            return null;
         //return unit;
      }

      public static string GetVariableValue(ProcessVar var, UnitSystem unitSystem, string numericFormatStr) {
         string valStr = null;
         if (var is ProcessVarDouble) {
            ProcessVarDouble varDouble = (ProcessVarDouble)var;
            double val = UnitSystemService.GetInstance().ConvertFromSIValue(var.Type, varDouble.Value);
            if (varDouble.Value == Constants.NO_VALUE)
               valStr = "";
            else
               valStr = val.ToString(numericFormatStr);
         }
         else if (var is ProcessVarInt) {
            ProcessVarInt varInt = (ProcessVarInt)var;
            if (varInt.Value == Constants.NO_VALUE_INT)
               valStr = "";
            else
               valStr = varInt.Value.ToString(UI.DECIMAL);
         }
         return valStr;
      }

      public static void PageSetup(PrintDocument printDocument) {
         try {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.Document = printDocument;
            DialogResult result = pageSetupDialog.ShowDialog();
            if (result == DialogResult.OK) {
               printDocument.PrinterSettings = pageSetupDialog.PrinterSettings;
               printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
               printDocument.PrinterSettings.PrintToFile = false;
            }
         }
         catch (InvalidPrinterException) {
         }
      }

      public static void NavigateKeyboard(ArrayList list, object element, ContainerControl container, KeyboardNavigation navig) {
         for (int i = 0; i < list.Count; i++) {
            if (navig == KeyboardNavigation.Down) {
               if (i == list.Count - 1) {
                  if (element == list[i])
                     container.ActiveControl = list[0] as Control;
               }
               else {
                  if (element == list[i])
                     container.ActiveControl = list[i + 1] as Control;
               }
            }
            else if (navig == KeyboardNavigation.Up) {
               if (i == 0) {
                  if (element == list[i])
                     container.ActiveControl = list[list.Count - 1] as Control;
               }
               else {
                  if (element == list[i])
                     container.ActiveControl = list[i - 1] as Control;
               }
            }
         }
      }
   }

   public enum KeyboardNavigation {
      Undefined = 0,
      Up,
      Down
   }

   public enum FlowsheetActivity {
      Default = 0,
      //AddingGasStream,
      //AddingLiquidMaterialStream,
      //AddingSolidMaterialStream,
      //AddingProcessStream,
      //AddingSolidDryer,
      //AddingLiquidDryer,
      //AddingHeatExchanger,
      //AddingFan,
      //AddingValve,
      //AddingBagFilter,
      //AddingAirFilter,
      //AddingCompressor,
      //AddingHeater,
      //AddingCooler,
      //AddingElectrostaticPrecipitator,
      //AddingPump,
      //AddingCyclone,
      //AddingEjector,
      //AddingWetScrubber,
      //AddingScrubberCondenser,
      //AddingMixer,
      //AddingTee,
      //AddingFlashTank,
      //AddingRecycle,
      AddingSolvable,

      AddingConnStepOne,
      AddingConnStepTwo,
      DeletingConnection,
      SelectingSnapshot
   }

   public enum SlotPosition {
      Unknown = 0,
      Up,
      Down,
      Left,
      Right
   }

   public enum SlotDirection {
      Unknown = 0,
      In,
      Out
   }

   public enum StreamOrientation {
      Unknown = 0,
      Up,
      Down,
      Left,
      Right
   }

   public enum StreamType {
      Unknown,
      Gas,
      Material,
      Process
   }

   public enum PointOrientation {
      Unknown = 0,
      N,
      S,
      E,
      W
   }

   public enum RotationDirection {
      Unknown = 0,
      Clockwise,
      Counterclockwise
   }

   public interface IEditable {
      void Edit();
   }

   public interface IPrintable {
      string ToPrint();
   }

   public interface INumericFormat {
      event NumericFormatStringChangedEventHandler NumericFormatStringChanged;

      string DecimalPlaces {
         get;
         set;
      }

      NumericFormat NumericFormat {
         get;
         set;
      }

      string NumericFormatString {
         get;
      }
   }

   public enum NumericFormat {
      Undefined = 0,
      FixedPoint,
      Scientific
   }

   public enum ModifierKey {
      None = 0,
      Ctrl,
      Shift
   }

   public enum SubstancesToShow {
      Undefined = 0,
      Material,
      Gas,
      Moisture,
      All
   }

   public enum ProcessVariableListType {
      Undefined = 0,
      Specified,
      Calculated,
      All
   }

   public enum PlotGraphSize {
      Undefined = 0,
      Small,
      Medium,
      Large
   }

   public enum FlowsheetVersionStatus {
      Ok,
      NotOk,
      Upgraded
   }

   public enum AppPrefsTab {
      UnitSystems,
      NumericFormat
   }

   public class ActivityChangedEventArgs : EventArgs {
      private FlowsheetActivity flowsheetActivity;
      private Type solvableType;

      public ActivityChangedEventArgs(FlowsheetActivity flowsheetActivity, Type solvableType) {
         this.flowsheetActivity = flowsheetActivity;
         this.solvableType = solvableType;
      }

      public FlowsheetActivity FlowsheetActivity {
         get { return flowsheetActivity; }
      }

      public Type SolvableType {
         get { return solvableType; }
      }
   }
}
