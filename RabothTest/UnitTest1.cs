using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryRaboth;
namespace RabothTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void CheckLogin()
        {
            //Arrange
            string login = "Baltos";
            string password = "ASqw12$$";
            bool expected = true;
            //act
            bool actual = LoginChecker.LoginAuth(login,password);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
