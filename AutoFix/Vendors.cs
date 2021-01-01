using System;
using System.Collections.Generic;

namespace AutoFixer
{
    class Vendors
    {

        static Dictionary<String, String> vendors = new Dictionary<String, String>()
        {
            {"017A", "Apacer" },
            {"059B", "Crucial"},
            {"04CD", "G.Skill"},
            {"0198", "HyperX" },
            {"029E", "Corsair"},
            {"04CB", "A-DATA" },
            {"00CE", "Samsung"}
        };


        /// <summary>
        /// Grab the vendor name from the vendor dicitonary.
        /// </summary>
        /// <param name="vendornumber">Which vendor number the hardware got</param>
        /// <returns>The name of the manufacturer if found or else just return the input</returns>
        public static String GetVendor(String vendornumber)
        {
            vendornumber = vendornumber.ToUpper();
            return vendors.ContainsKey(vendornumber) ? vendors[vendornumber] : vendornumber;
        }

    }
}
