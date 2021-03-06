using System;
using System.Collections;

namespace Prosimo.UnitSystems
{
   public enum PlaneAngleUnitType {Degree = 0, Radian, Min, Sec};

   /// <summary>
	/// Summary description for Class2.
	/// </summary>
   public class PlaneAngleUnit {
      private static Hashtable coeffTable = new Hashtable();
      private static Hashtable unitStringTable = new Hashtable();

      static PlaneAngleUnit() {
         coeffTable.Add(PlaneAngleUnitType.Radian, 1.0);         unitStringTable.Add(PlaneAngleUnitType.Radian, "rad");
         coeffTable.Add(PlaneAngleUnitType.Degree, 1.745329e-2); unitStringTable.Add(PlaneAngleUnitType.Degree, "�");
         coeffTable.Add(PlaneAngleUnitType.Min, 2.908882e-4);    unitStringTable.Add(PlaneAngleUnitType.Min, "min");
         coeffTable.Add(PlaneAngleUnitType.Sec, 4.848137e-6);    unitStringTable.Add(PlaneAngleUnitType.Sec, "sec");
      }

      public static double ConvertToSIValue(PlaneAngleUnitType unitType, double toBeConvertedValue) {
         double convertionCoeff = (double) coeffTable[unitType];
         return convertionCoeff * toBeConvertedValue;
      }
      
      public static double ConvertFromSIValue(PlaneAngleUnitType unitType, double radValue) {
         double convertionCoeff = (double) coeffTable[unitType];
         return radValue/convertionCoeff;
      }
      
      public static string GetUnitAsString(PlaneAngleUnitType unitType) {
         return unitStringTable[unitType] as String;
      }
   
      public static PlaneAngleUnitType GetUnitAsEnum(string unitString) {
         IDictionaryEnumerator myEnumerator = unitStringTable.GetEnumerator();
         String name;
         PlaneAngleUnitType type = PlaneAngleUnitType.Radian;
         while (myEnumerator.MoveNext()) {
            name = myEnumerator.Value as String;
            if (name.Equals(unitString)) {
               type = (PlaneAngleUnitType) myEnumerator.Key;
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
