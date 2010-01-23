using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class ParseTools
    {
        public static void SStripPhoneNumber(this String cIn ,  ref string cPhoneNumber)
        {
            cPhoneNumber = cPhoneNumber.Replace("--", "");          

        }    

    }
}
