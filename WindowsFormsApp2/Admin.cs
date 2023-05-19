using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    class Admin : User
    {
        public void CheckSymbols(string user, bool checkBox)
        {
            if (checkBox == true)
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + ",true";
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы ограничили символы");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }
            else
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + ",false";
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы убрали ограничение на символы");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }

        }
        public void CheckBigLetters(string user, bool checkBox)
        {
            if (checkBox == true)
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + ",true," + LogPass[7];
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы ограничили большие буквы");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }
            else
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + ",false," + LogPass[7];
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы убрали ограничение на большие буквы");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }

        }
        public void CheckSmalLetters(string user, bool checkBox)
        {
            if (checkBox == true)
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + ",true," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы ограничили маленькие буквы");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }
            else
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + ",false," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы убрали ограничение на маленькие буквы");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }

        }
        public void CheckNumbers(string user, bool checkBox)
        {
            if (checkBox == true)
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + ",true," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы ограничили цифры");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }
            else
            {
                string[] LogPass;
                string str = "";
                string text = "";
                string[] lines = File.ReadAllLines(DataBank.path);
                foreach (string s in lines)
                {
                    LogPass = s.Split(',');
                    if (LogPass[0] == user)
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + ",false," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }
                    else
                    {
                        str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                        text = text + str + "\n";
                    }


                }
                //MessageBox.Show("Вы убрали ограничение на цифры");

                using (StreamWriter file = new StreamWriter(DataBank.path))
                {
                    file.Write(text);
                }
            }

        }
        public void Restriction(string user, string lenPass)
        {
            string[] LogPass;
            string str = "";
            string text = "";
            string[] lines = File.ReadAllLines(DataBank.path);
            foreach (string s in lines)
            {
                LogPass = s.Split(',');
                if (LogPass[0] == user)
                {
                    str = LogPass[0] + "," + LogPass[1] + ",true" + "," + lenPass + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                    text = text + str + "\n";
                }
                else
                {
                    str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                    text = text + str + "\n";
                }
                

            }
            //MessageBox.Show("Вы ограничили пароль");

            using (StreamWriter file = new StreamWriter(DataBank.path))
            {
                file.Write(text);
            }
        }
        public void unRestriction(string user)
        {
            string[] LogPass;
            string str = "";
            string text = "";
            string[] lines = File.ReadAllLines(DataBank.path);
            foreach (string s in lines)
            {
                LogPass = s.Split(',');
                if (LogPass[0] == user)
                {
                    //str = LogPass[0] + "," + LogPass[1] + ",false" + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                    str = LogPass[0] + "," + LogPass[1] + ",false" + "," + LogPass[3] + ",false,false,false,false";

                    text = text + str + "\n";
                }
                else
                {
                    str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2] + "," + LogPass[3] + "," + LogPass[4] + "," + LogPass[5] + "," + LogPass[6] + "," + LogPass[7];
                    text = text + str + "\n";
                }


            }
            //MessageBox.Show("Вы убрали ограничение пароля");


            using (StreamWriter file = new StreamWriter(DataBank.path))
            {
                file.Write(text);
            }
        }

        public void BlockUser(string user_to_block)
        {
            if ((DataBank.Block_Users.Contains(user_to_block)) == true)
            {
                MessageBox.Show("Пользователь уже заблокирован");
            }
            else
            {
                DataBank.Block_Users.Add(user_to_block);
                using (StreamWriter writer = new StreamWriter(DataBank.BlockUsersPath, append: true))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(user_to_block);
                }

            }
        }
        public void unBlockUser(string user_to_unblock)
        {
            string text = "";
            DataBank.Block_Users.Remove(user_to_unblock);
            string[] lines = File.ReadAllLines(DataBank.BlockUsersPath);
            foreach (string s in lines)
            {
                if (s != user_to_unblock)
                {
                    text = text + s + "\n";
                }

            }
            using (StreamWriter writer = new StreamWriter(DataBank.BlockUsersPath))
            {
                writer.Write(text);
            }

        }
        public void AddUser(string Login)
        {
            String trueLogin;
            string line = "";
            string[] LogPass;
            Boolean account = false;

            using (StreamReader sr = new StreamReader(DataBank.path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    LogPass = line.Split(',');
                    trueLogin = (LogPass[0]);

                    if (trueLogin == Login)
                    {
                        account = true;
                    }

                }
            }

            if (account == true)
            {
                MessageBox.Show("Аккаунт с таким логином уже существует");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(DataBank.path, append: true))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(Login + ", " + ",false,8,false,false,false,false");
                }

                MessageBox.Show("Вы зарегестрировали пользователя");
                LoadData();
            }
        }

        private void LoadData()
        {
            string[] text = File.ReadAllLines(DataBank.path);
            DataBank.Users_List = new string[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                DataBank.Users_List[i] = text[i].Split(',')[0];
            }
        }
    }
}
