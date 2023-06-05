using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryRaboth
{
    public class RabothChecker
    {
        public static bool LoginAuth(string login, string password)
        {
           if(login == "Baltika" && password == "2Wadf")
            {
                return true;
            }
            if (login == "Pablo" && password == "dsadas")
            {
                return true;
            }
            if (login == "IvanZolo2004" && password == "2004")
            {
                return true;
            }
            return false;
        }
        public static bool WorkerChecker(string FirstName, string LastName,  string SurName, string Num, string INN, string email,
            string Snils, string Adress, string specialnost, string PasportSeries,string PasportNumber,string Department)
        {
           if(FirstName != null && LastName != null && SurName != null && Num != null && INN != null && email != null
                && Snils != null && PasportSeries != null && PasportNumber != null && Department != null)
            {
                return true;
            }
            return false;
        }
        public static bool FioChecker(string FirstName, string LastName, string SurName, string Num, string INN, string email,
           string Snils, string Adress, string specialnost, string PasportSeries, string PasportNumber, string Department)
        {
            if (FirstName != null && LastName != null && SurName != null)
            {
                return true;
            }
            return false;
        }
        public static bool TaskChecker(string TaskName, string Opis)
        {
            if (TaskName != null && Opis != null)
            {
                return true;
            }
            return false;
        }
    }
}
