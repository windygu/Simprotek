using System;
using System.Collections;

namespace Prosimo.UnitSystems
{
   public enum ForceUnitType {Newton = 0, Kilonewton, Meganewton, Kgf, Gramf, Dyne, Tonnef, 
      Sthene, Ouncef, Poundf, Poundal, TonfUK, TonfUS, Kip};
   
   /// <summary>
	/// Summary description for Class2.
	/// </summary>
   public class ForceUnit : EngineeringUnit {
      public static ForceUnit Instance = new ForceUnit();

      private ForceUnit() {
         coeffTable.Add(ForceUnitType.Newton, 1.0);          unitStringTable.Add(ForceUnitType.Newton, "N");
         coeffTable.Add(ForceUnitType.Kilonewton, 1000.0);   unitStringTable.Add(ForceUnitType.Kilonewton, "kN");
         coeffTable.Add(ForceUnitType.Meganewton, 1.0e6);    unitStringTable.Add(ForceUnitType.Meganewton, "MN");
         coeffTable.Add(ForceUnitType.Kgf, 9.80665);         unitStringTable.Add(ForceUnitType.Kgf, "kgf");
         coeffTable.Add(ForceUnitType.Gramf, 9.80665e-3);    unitStringTable.Add(ForceUnitType.Gramf, "gf");
         coeffTable.Add(ForceUnitType.Dyne, 1.0e-5);         unitStringTable.Add(ForceUnitType.Dyne, "dyne");
         coeffTable.Add(ForceUnitType.Tonnef, 9.80665e3);    unitStringTable.Add(ForceUnitType.Tonnef, "tonnef");
         coeffTable.Add(ForceUnitType.Sthene, 1.0e3);        unitStringTable.Add(ForceUnitType.Sthene, "sthene");
         coeffTable.Add(ForceUnitType.Ouncef, 0.278013851);  unitStringTable.Add(ForceUnitType.Ouncef, "ozf");
         coeffTable.Add(ForceUnitType.Poundf, 4.44822162);   unitStringTable.Add(ForceUnitType.Poundf, "Ibf");
         coeffTable.Add(ForceUnitType.Poundal, 0.138254954); unitStringTable.Add(ForceUnitType.Poundal, "poundal");
         coeffTable.Add(ForceUnitType.TonfUK, 9964.01642);   unitStringTable.Add(ForceUnitType.TonfUK, "UK tonf");
         coeffTable.Add(ForceUnitType.TonfUS, 8896.44323);   unitStringTable.Add(ForceUnitType.TonfUS, "US tonf");
         coeffTable.Add(ForceUnitType.Kip, 4448.22162);      unitStringTable.Add(ForceUnitType.Kip, "kip");
      }
   }
}
