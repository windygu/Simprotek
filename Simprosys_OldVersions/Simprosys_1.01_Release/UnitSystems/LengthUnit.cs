using System;
using System.Collections;

namespace Prosimo.UnitSystems
{
   public enum LengthUnitType {Meter = 0, Micrometer, Millimeter, Centimeter, Decimeter, 
      Kilometer, Inch, Foot, Yard, Chain, Furlong, Mile, Fathom, 
      Nauticalmile};
   
   /// <summary>
	/// Summary description for Class2.
	/// </summary>
   public class LengthUnit {
      private static Hashtable coeffTable = new Hashtable();
      private static Hashtable unitStringTable = new Hashtable();

      static LengthUnit() {
         coeffTable.Add(LengthUnitType.Meter, 1.0);           unitStringTable.Add(LengthUnitType.Meter, "m");
         coeffTable.Add(LengthUnitType.Micrometer, 1.0e-6);   unitStringTable.Add(LengthUnitType.Micrometer, "�m");
         coeffTable.Add(LengthUnitType.Millimeter, 1.0e-3);   unitStringTable.Add(LengthUnitType.Millimeter, "mm");
         coeffTable.Add(LengthUnitType.Centimeter, 0.01);     unitStringTable.Add(LengthUnitType.Centimeter, "cm");
         coeffTable.Add(LengthUnitType.Decimeter, 0.1);       unitStringTable.Add(LengthUnitType.Decimeter, "dm");
         coeffTable.Add(LengthUnitType.Kilometer, 1000.0);    unitStringTable.Add(LengthUnitType.Kilometer, "km");
         coeffTable.Add(LengthUnitType.Inch, 0.0254);         unitStringTable.Add(LengthUnitType.Inch, "in");
         coeffTable.Add(LengthUnitType.Foot, 0.3048);         unitStringTable.Add(LengthUnitType.Foot, "ft");
         coeffTable.Add(LengthUnitType.Yard, 0.9144);         unitStringTable.Add(LengthUnitType.Yard, "yd");
         coeffTable.Add(LengthUnitType.Chain, 20.1168);       unitStringTable.Add(LengthUnitType.Chain, "chain");
         coeffTable.Add(LengthUnitType.Furlong, 201.168);     unitStringTable.Add(LengthUnitType.Furlong, "furlong");
         coeffTable.Add(LengthUnitType.Mile, 1609.344);       unitStringTable.Add(LengthUnitType.Mile, "mi");
         coeffTable.Add(LengthUnitType.Fathom, 1.8288);       unitStringTable.Add(LengthUnitType.Fathom, "fathom");
         coeffTable.Add(LengthUnitType.Nauticalmile, 1852.0); unitStringTable.Add(LengthUnitType.Nauticalmile, "nauticalmile");
      }

      public static double ConvertToSIValue(LengthUnitType unitType, double toBeConvertedValue) {
         double convertionCoeff = (double) coeffTable[unitType];
         return convertionCoeff * toBeConvertedValue;
      }
      
      public static double ConvertFromSIValue(LengthUnitType unitType, double meterValue) {
         double convertionCoeff = (double) coeffTable[unitType];
         return meterValue/convertionCoeff;
      }
      
      public static string GetUnitAsString(LengthUnitType unitType) {
         return unitStringTable[unitType] as String;
      }
      
      public static LengthUnitType GetUnitAsEnum(string unitString) {
         IDictionaryEnumerator myEnumerator = unitStringTable.GetEnumerator();
         String name;
         LengthUnitType type = LengthUnitType.Meter;
         while (myEnumerator.MoveNext()) {
            name = myEnumerator.Value as String;
            if (name.Equals(unitString)) {
               type = (LengthUnitType) myEnumerator.Key;
               break;
            }
         }
         return type;
      }

      public static ICollection GetUnitsAsStrings() {
         return unitStringTable.Values;
      }
   }
}
