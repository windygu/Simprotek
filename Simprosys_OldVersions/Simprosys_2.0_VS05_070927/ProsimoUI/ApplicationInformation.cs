using System;
using System.Collections.Generic;
using System.Text;

namespace ProsimoUI
{
   class ApplicationInformation
   {
      public const string COMPANY = "Simprotek Corporation (www.simprotek.com)";
      public const string PRODUCT= "Simprosys";
      public const string COPYRIGHT = "Copyright � Simprotek Corporation 2006";
      private const string VERSION = "1.0.1.1";

      public static Version ProductVersion {
         get {
            return new Version(VERSION);
         }
      }

      public static string ProductVersionString {
         get {
            Version v = new Version(VERSION);
            return v.Major + "." + v.Minor + v.Build;
         }
      }
   }
}
