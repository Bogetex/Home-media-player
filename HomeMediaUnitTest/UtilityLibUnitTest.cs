/// Unit test class
/// Using this clas to test Utility class method
/// By Ali ABdulhussein
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilitiesLib;
using DataLib;

namespace HomeMediaUnitTest
{
    [TestClass]
    public class UtilityLibUnitTest
    {
        delegate int delegateMethod(int input);

        /// <summary>
        /// This method test the original class method GetEnumDescription
        /// Wich convert the enum vlue to friendly text, from Enum description
        /// </summary>
        [TestMethod]
        public void GetEnumDescriptionTestMethod()
        {
            //Arrange
            string actual = @".Mp4";


            //Act
            string expected = UtilitiesLib.EnumFriendlyTextConverter.GetEnumDescription(FileTypeEnum.mp4);

            //Assert
            Assert.AreEqual(actual, expected, "Fail to Get Enum description");
        }

        [TestMethod]
        public void ValidateIntegerInputTest()
        {
            ///Arrange

            ///A given value
            int actual = 1; 
            ///A return value expected from annonymouse method "Used Lamda expretion". 
            ///If not valide number return -1, and generate test error.
            int expected = -1; 
            


            ///Act
            ///Lambda expretion, Test method to test one off validation method
            delegateMethod del=(x) =>
            {
                if (UtilitiesLib.TypeValidation.ValidateIntegerInput(x))
                    return x;
                else
                    return -1;
            };


            ///Asset
            Assert.AreEqual(actual,del(expected));
        }
    }
}
