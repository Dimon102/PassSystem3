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

        public void Restriction(string user)
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
                    str = LogPass[0] + "," + LogPass[1] + ",true";
                    text = text + str + "\n";
                }
                else
                {
                    str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2];
                    text = text + str + "\n";
                }
                

            }
            MessageBox.Show("Вы ограничили пароль");

            //MessageBox.Show("весь текст\n" + text);

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
                    str = LogPass[0] + "," + LogPass[1] + ",false";
                    text = text + str + "\n";
                }
                else
                {
                    str = LogPass[0] + "," + LogPass[1] + "," + LogPass[2];
                    text = text + str + "\n";
                }


            }
            MessageBox.Show("Вы убрали ограничение пароля");

            //MessageBox.Show("весь текст\n" + text);

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
                    writer.WriteLine(Login + ",");
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
