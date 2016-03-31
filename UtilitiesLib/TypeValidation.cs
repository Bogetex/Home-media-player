/// Type validation Class
/// By Ali Abdulhussein
/// 03 mars 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLib
{
    public static class TypeValidation
    {
        /// <summary>
        /// Validate string method
        /// Check if input string is valide "Not Null Or Empty space"
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool ValisateStringInput(string strIn)
        {
            if (!string.IsNullOrWhiteSpace(strIn))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Validate integer input
        /// </summary>
        /// <param name="intIn"></param>
        /// <returns></returns>
        public static bool ValidateIntegerInput(int intIn)
        {
            if (intIn >= 0)
                return true;
            else
                return false;
        }

        public static bool validateIndex(int index)
        {
            if (index > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Validate Double Input
        /// </summary>
        /// <param name="dobuleIn"></param>
        /// <returns></returns>
        public static bool ValidateDoubleInput(double dobuleIn)
        {
            if (ValidateIntegerInput((int)dobuleIn))
                return true;
            else
                return false;
        }
    }
}
