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
        //public static string changePass = "";
        public static string Login = "";
        public static string[] Users_List;
        public static List<string> Block_Users = new List<string>();
        //public static string path = "C:\\Users\\user.AD\\source\\repos\\PassSystem3\\WindowsFormsApp2\\Users.txt";
        //public static string BlockUsersPath = "C:\\Users\\user.AD\\source\\repos\\PassSystem3\\WindowsFormsApp2\\blockUsers.txt";
        //public static string password_restrictionsPath = "C:\\Users\\user.AD\\source\\repos\\PassSystem3\\WindowsFormsApp2\\password_restrictions.txt";

        public static string UpAlphavet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string LowAlphavet = "abcdefghijklmnopqrstuvwxyz";
        public static string numbers = "0123456789";
        public static string specSymbols = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";





        public static bool password_restrictions = false;
        public static string path = @"D:\Дима\ИНФ. БЕЗОПАСНОСТЬ И ЗАЩИТА ИНФОРМАЦИИ\BruteForce\WindowsFormsApp2\Users.txt";
        public static string BlockUsersPath = @"D:\Дима\ИНФ. БЕЗОПАСНОСТЬ И ЗАЩИТА ИНФОРМАЦИИ\BruteForce\WindowsFormsApp2\BlockUsers.txt";
        public static string password_restrictionsPath = @"D:\Дима\ИНФ. БЕЗОПАСНОСТЬ И ЗАЩИТА ИНФОРМАЦИИ\BruteForce\WindowsFormsApp2\password_restrictions.txt";

        public static bool Reverse(bool restriction)
        {
            if (restriction == true)
            {
                restriction = false;
            }
            else
            {
                restriction = true;
            }
            return restriction;
        }
        public static bool PasswordCheck(string password, string type, string len, string accessNumbers, string accessSLet, string accessBLet, string accessSymbols)
        {
            if (type == "Reg")
            {
                if (password.Length <= 8)
                {

                    return false;
                }


                bool flagUpAlphavet = false;
                bool flagLowAlphavet = false;
                bool flagnumbers = false;
                bool flagspecSymbols = false;


                //for (int i = 0; i > password.Length; i++)
                foreach (char i in password)
                {
                    //password.ToList();
                    if (UpAlphavet.Contains(i) == true)
                    {
                        flagUpAlphavet = true;

                    }
                    if (LowAlphavet.Contains(i) == true)
                    {
                        flagLowAlphavet = true;

                    }
                    if (numbers.Contains(i) == true)
                    {
                        flagnumbers = true;

                    }
                    if (specSymbols.Contains(i) == true)
                    {
                        flagspecSymbols = true;

                    }


                }

                //MessageBox.Show(flagUpAlphavet.ToString());
                //MessageBox.Show(flagLowAlphavet.ToString());
                //MessageBox.Show(flagnumbers.ToString());
                //MessageBox.Show(flagspecSymbols.ToString());


                if (flagUpAlphavet && flagLowAlphavet && flagnumbers && flagspecSymbols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //MessageBox.Show("ограничеиня при смене");

                if (password.Length <= Convert.ToInt32(len))
                {

                    return false;
                }
                
                bool flagUpAlphavet = Reverse(Convert.ToBoolean(accessBLet));
                bool flagLowAlphavet = Reverse(Convert.ToBoolean(accessSLet));
                bool flagnumbers = Reverse(Convert.ToBoolean(accessNumbers)); 
                bool flagspecSymbols = Reverse(Convert.ToBoolean(accessSymbols));

                //MessageBox.Show("начальные ограничеиня");
                //MessageBox.Show(flagnumbers.ToString());
                //MessageBox.Show(flagLowAlphavet.ToString());
                //MessageBox.Show(flagUpAlphavet.ToString());
                //MessageBox.Show(flagspecSymbols.ToString());


                //for (int i = 0; i > password.Length; i++)
                foreach (char i in password)
                {
                    //password.ToList();
                    if (UpAlphavet.Contains(i) == true)
                    {
                        flagUpAlphavet = true;

                    }
                    if (LowAlphavet.Contains(i) == true)
                    {
                        flagLowAlphavet = true;

                    }
                    if (numbers.Contains(i) == true)
                    {
                        flagnumbers = true;

                    }
                    if (specSymbols.Contains(i) == true)
                    {
                        flagspecSymbols = true;

                    }


                }
                //MessageBox.Show("ограничеиня после проверки");

                //MessageBox.Show(flagnumbers.ToString());
                //MessageBox.Show(flagLowAlphavet.ToString());
                //MessageBox.Show(flagUpAlphavet.ToString());
                //MessageBox.Show(flagspecSymbols.ToString());


                if (flagUpAlphavet && flagLowAlphavet && flagnumbers && flagspecSymbols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }



        public static int errcount = 3;

    }
}
