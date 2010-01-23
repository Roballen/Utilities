using System;

namespace Utilities
{
    public class StateCodes
    {
        // IMPORTANT: These MUST be in alphabetical order by code.
        internal static string[,] aStateData = {
                                                {"AA", "America"},
                                                {"AE", "Europe"},
                                                {"AK", "Alaska"},
                                                {"AL", "Alabama"},
                                                {"AP", "Pacific"},
                                                {"AR", "Arkansas"},
                                                {"AS", "American Samoa"},
                                                {"AZ", "Arizona"},
                                                {"CA", "California"},
                                                {"CO", "Colorado"},
                                                {"CT", "Connecticut"},
                                                {"DC", "Washington DC"},
                                                {"DE", "Delaware"},
                                                {"FL", "Florida"},
                                                {"GA", "Georgia"},
                                                {"GU", "Guam"},
                                                {"HI", "Hawaii"},
                                                {"IA", "Iowa"},
                                                {"ID", "Idaho"},
                                                {"IL", "Illinois"},
                                                {"IN", "Indiana"},
                                                {"KS", "Kansas"},
                                                {"KY", "Kentucky"},
                                                {"LA", "Lousiana"},
                                                {"MA", "Massachusetts"},
                                                {"MD", "Maryland"},
                                                {"ME", "Maine"},
                                                {"MH", "Marshall Islands"}, //rob
                                                {"MI", "Michigan"},
                                                {"MN", "Minnesota"},
                                                {"MO", "Missouri"},
                                                {"MP", "Northern Mariana Islands"}, //rob
                                                {"MS", "Mississippi"},
                                                {"MT", "Montana"},
                                                {"NC", "North Carolina"},
                                                {"ND", "North Dakota"},
                                                {"NE", "Nebraska"},
                                                {"NH", "New Hampshire"},
                                                {"NJ", "New Jersey"},
                                                {"NM", "New Mexico"},
                                                {"NV", "Nevada"},
                                                {"NY", "New York"},
                                                {"OH", "Ohio"},
                                                {"OK", "Oklahoma"},
                                                {"OR", "Oregon"},
                                                {"PA", "Pennsylvania"},
                                                {"PR", "Puerto Rico"},
                                                {"PT", "Pacific Trust"},
                                                {"RI", "Rhode Island"},
                                                {"SC", "South Carolina"},
                                                {"SD", "South Dakota"},
                                                {"TN", "Tennessee"},
                                                {"TX", "Texas"},
                                                {"UT", "Utah"},
                                                {"VA", "Virginia"},
                                                {"VI", "Virgin Islands"},
                                                {"VT", "Vermont"},
                                                {"WA", "Washington"},
                                                {"WI", "Wisconsin"},
                                                {"WV", "West Virginia"},
                                                {"WY", "Wyoming"}
                                            };

        /// <summary>
        /// Returns the state code for a state of specified name. For instance,
        /// GetCode("Colorado") would return "CO". Case does not matter for name.
        /// null is returned if a code for the given name cannot be found.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetCode(string name)
        {
            if (name != null)
                if (aStateData != null)
                    for (int i = 0; i < aStateData.GetLength(0); i++)
                        if (String.Compare(aStateData[i, 1], name, true) == 0)
                            return aStateData[i, 0];

            return null;
        }

        /// <summary>
        /// Returns the state name for a state of specified code. For instance,
        /// GetName("CO") would return "Colorado". Case does not matter for code.
        /// null is returned if a name for the given name cannot be found.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetName(string code)
        {
            if (code != null)
            {
                int index = indexOf(code);

                if (aStateData != null)
                    if ((index < aStateData.GetLength(0)) && (String.Compare(aStateData[index, 0], code, true) == 0))
                        return aStateData[index, 1];
            }
             
            return null;
        }

        /// <summary>
        /// Returns the index in aStateData where code should be (whether or not it is
        /// actually there).
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static int indexOf(string code)
        {
            string midValue;
            int low = 0;
            int high = aStateData.GetLength(0);
            int mid = (low + high)/2;

            while (low < high)
            {
                midValue = aStateData[mid, 0];

                if (midValue.ToLower().CompareTo(code.ToLower()) < 0)
                    low = mid + 1;
                else
                    high = mid;

                mid = (low + high)/2;
            }
            return low;
        }
    }
}