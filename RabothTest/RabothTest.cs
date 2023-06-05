using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryRaboth;
namespace RabothTest
{
    [TestClass]
    public class RabothTest
    {
        
        [TestMethod]
        public void CheckLoginFalse()
        {
            //Arrange
            string login = "Baltos";
            string password = "ASqw12$$";
            bool expected = true;
            //act
            bool actual = RabothChecker.LoginAuth(login,password);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckLoginTrue()
        {
            //Arrange
            string login = "Baltika";
            string password = "2Wadf";
            bool expected = true;
            //act
            bool actual = RabothChecker.LoginAuth(login, password);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckWorkerAllFalse()
        {
            //Arrange
            string FirstName = "Жора";
            string LastName = "Жованна";
            string SurName = "Жора";
            string Num = "+79325874589";
            string INN = "4855898742";
            string email = "vais232@mail.ru";
            string Snils = null;
            string Adress = "Ул.Пушкина 8, 45";
            string specialnost = "Кондитер";
            string PasportSeries = "6517";
            string PasportNumber = "628794";
            string Department = null;


            bool expected = true;
            //act
            bool actual = RabothChecker.WorkerChecker(FirstName, LastName, SurName, Num, INN, email, Snils, Adress, specialnost, PasportSeries
                , PasportNumber, Department);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckWorkerFIOFalse()
        {
            //Arrange
            string FirstName = null;
            string LastName = null;
            string SurName = null;
            string Num = "+79325874589";
            string INN = "4855898742";
            string email = "vais232@mail.ru";
            string Snils = "58428451";
            string Adress = "Ул.Пушкина 8, 45";
            string specialnost = "Кондитер";
            string PasportSeries = "6517";
            string PasportNumber = "628794";
            string Department = "Отдел кулинарии";


            bool expected = true;
            //act
            bool actual = RabothChecker.FioChecker(FirstName, LastName, SurName, Num, INN, email, Snils, Adress, specialnost, PasportSeries
                , PasportNumber, Department);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CheckWorkerAllTrue()
        {
            //Arrange
            string FirstName = "Жора";
            string LastName = "Жованна";
            string SurName = "Жора";
            string Num = "+79325874589";
            string INN = "4855898742";
            string email = "vais232@mail.ru";
            string Snils = "58428451";
            string Adress = "Ул.Пушкина 8, 45";
            string specialnost = "Кондитер";
            string PasportSeries = "6517";
            string PasportNumber = "628794";
            string Department = "Отдел кулинарии";


            bool expected = true;
            //act
            bool actual = RabothChecker.WorkerChecker(FirstName, LastName, SurName, Num, INN, email, Snils, Adress, specialnost, PasportSeries
                , PasportNumber, Department);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TaskCheckerFalse()
        {
            //Arrange
            string TaskName = null;
            string Opis = "Необходимо разгрузить грузовик с солью";
           


            bool expected = true;
            //act
            bool actual = RabothChecker.TaskChecker(TaskName, Opis);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TaskCheckerTrue()
        {
            //Arrange
            string TaskName = "Разгрузка";
            string Opis = "Необходимо разгрузить грузовик с солью";



            bool expected = true;
            //act
            bool actual = RabothChecker.TaskChecker(TaskName, Opis);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
