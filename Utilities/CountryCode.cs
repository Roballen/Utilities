using System.Collections.Generic;

namespace Utilities
{
    public class CountryCode
    {
        internal static Dictionary<string, string> dCountryCodes = new Dictionary<string, string>();

        /// <summary>
        /// loads the values in the dictionary
        /// </summary>
        public static void LoadDictionary()
        {
            if (dCountryCodes.Count < 1)
            {
                dCountryCodes.Add("AR", "Argentina");
                dCountryCodes.Add("AT", "Austria");
                dCountryCodes.Add("AU", "Australia");
                dCountryCodes.Add("AZ", "Azerbaijan");
                dCountryCodes.Add("BE", "Belgium");
                dCountryCodes.Add("BG", "Bulgaria (Rep.)");
                dCountryCodes.Add("BR", "Brazil");
                dCountryCodes.Add("BY", "Belarus");
                dCountryCodes.Add("CA", "Canada");
                dCountryCodes.Add("CH", "Switzerland");
                dCountryCodes.Add("CL", "Chile");
                dCountryCodes.Add("CV", "Cape Verde");
                dCountryCodes.Add("CZ", "Czech Rep.");
                dCountryCodes.Add("DE", "Germany");
                dCountryCodes.Add("DK", "Denmark");
                dCountryCodes.Add("EE", "Estonia");
                dCountryCodes.Add("ES", "Spain");
                dCountryCodes.Add("FI", "Finland");
                dCountryCodes.Add("FR", "France");
                dCountryCodes.Add("GB", "Great Britain");
                dCountryCodes.Add("HR", "Croatia");
                dCountryCodes.Add("HU", "Hungary");
                dCountryCodes.Add("ID", "Indonesia");
                dCountryCodes.Add("IE", "Ireland");
                dCountryCodes.Add("IL", "Israel");
                dCountryCodes.Add("IN", "India");
                dCountryCodes.Add("IR", "Iran");
                dCountryCodes.Add("IS", "Iceland");
                dCountryCodes.Add("IT", "Italy");
                dCountryCodes.Add("JP", "Japan");
                dCountryCodes.Add("KH", "Cambodia");
                dCountryCodes.Add("LK", "Sri Lanka");
                dCountryCodes.Add("LT", "Lithuania");
                dCountryCodes.Add("LV", "Latvia");
                dCountryCodes.Add("MA", "Morocco");
                dCountryCodes.Add("MD", "Moldova");
                dCountryCodes.Add("MK", "The former Yugoslav");
                dCountryCodes.Add("MV", "Maldives");
                dCountryCodes.Add("MX", "Mexico");
                dCountryCodes.Add("MY", "Malaysia");
                dCountryCodes.Add("MZ", "Mozambique");
                dCountryCodes.Add("NL", "Netherlands");
                dCountryCodes.Add("NO", "Norway");
                dCountryCodes.Add("NZ", "New Zealand");
                dCountryCodes.Add("PE", "Peru");
                dCountryCodes.Add("PK", "Pakistan");
                dCountryCodes.Add("PL", "Poland");
                dCountryCodes.Add("PT", "Portugal");
                dCountryCodes.Add("RO", "Romania");
                dCountryCodes.Add("RU", "Russian Federation");
                dCountryCodes.Add("SE", "Sweden");
                dCountryCodes.Add("SG", "Singapore");
                dCountryCodes.Add("SI", "Slovenia");
                dCountryCodes.Add("SK", "Slovakia");
                dCountryCodes.Add("SN", "Senegal");
                dCountryCodes.Add("SZ", "Swaziland");
                dCountryCodes.Add("TJ", "Tajikistan");
                dCountryCodes.Add("TN", "Tunisia");
                dCountryCodes.Add("TR", "Turkey");
                dCountryCodes.Add("UA", "Ukraine");
                dCountryCodes.Add("US", "United States of America");
                dCountryCodes.Add("UY", "Uruguay");
                dCountryCodes.Add("VE", "Venezuela");
                dCountryCodes.Add("ZA", "South Africa");
            }
        }
 
        /// <summary>
        /// gets the country code when passed the name of the country
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCountryCode(string name)
        {
            LoadDictionary();

            foreach (KeyValuePair<string, string> pair in dCountryCodes)
            {
                if (name.ToLower() == pair.Value.ToLower())
                    return pair.Key;
            }

            return null;
        }

        /// <summary>
        /// gets the country name when passed the country code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetCountryName(string code)
        {
            LoadDictionary();

            foreach (KeyValuePair<string, string> pair in dCountryCodes)
            {
                if (code.ToLower() == pair.Key.ToLower())
                    return pair.Value;
            }
            return null;
        }

        public static Dictionary<string, string> CountryCodes()
        {
            return dCountryCodes;
        }
    }
}
