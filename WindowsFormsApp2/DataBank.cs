using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class DataBank
    {
        public static string Login = "";
        public static string[] Users_List;
        public static List<string> Block_Users = new List<string>();
        public static string path = "D:\\Дима\\ИНФ. БЕЗОПАСНОСТЬ И ЗАЩИТА ИНФОРМАЦИИ\\WindowsFormsApp2 (2)\\WindowsFormsApp2\\WindowsFormsApp2\\Users.txt";
        public static string BlockUsersPath = "D:\\Дима\\ИНФ. БЕЗОПАСНОСТЬ И ЗАЩИТА ИНФОРМАЦИИ\\WindowsFormsApp2 (2)\\WindowsFormsApp2\\WindowsFormsApp2\\blockUsers.txt";
        public static bool password_restrictions = false;
        public static string password_restrictionsPath = "D:\\Дима\\ИНФ. БЕЗОПАСНОСТЬ И ЗАЩИТА ИНФОРМАЦИИ\\WindowsFormsApp2 (2)\\WindowsFormsApp2\\WindowsFormsApp2\\password_restrictions.txt";


        public static bool PasswordCheck(string password)
        {
            if (password.Length <= 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public static int errcount = 3;

    }
}
