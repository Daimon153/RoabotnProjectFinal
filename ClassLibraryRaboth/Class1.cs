using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryRaboth
{
    public class LoginChecker
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
    }
}
