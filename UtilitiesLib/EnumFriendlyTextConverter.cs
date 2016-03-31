/// Return Description Attribute from enum
/// Use this class to return friendly Enum name
/// By Ali Abdulhussein
/// Referance: http://stackoverflow.com/questions/2650080/how-to-get-c-sharp-enum-description-from-value
/// 03 mars 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace UtilitiesLib
{
    /// <summary>
    /// Return Friendly Enum Value from Enum Descriptiion att for agiven Enum.
    /// EnumFriendlyTextConverter.GetEnumDescription(FileTypeEnum.jpg)
    /// </summary>
    public static class EnumFriendlyTextConverter
    {
        public static string GetEnumDescription(Enum value)
        {
            //Get item info and meta data
            FieldInfo fi = value.GetType().GetField(value.ToString());
            //Extract Enum description attribute
            DescriptionAttribute[] descriptionAtt = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute),false);
            //Check if Enum item has description
            if (descriptionAtt != null && descriptionAtt.Length > 0)
                return descriptionAtt[0].Description;
            else
                return value.ToString();

        }
    }
}
