using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Users_operations
    {
        public void Users_add(string Login, string Password)
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
                    writer.WriteLine(Login + "," + Password + ",false");
                }

                MessageBox.Show("Вы зарегестрировались");
            }
        }
        public bool User_Log_in(string Login, string Password)
        {
            string[] lines = File.ReadAllLines(DataBank.BlockUsersPath);
            foreach (string s in lines)
            {
                if (DataBank.Block_Users.Contains(s) == false)
                {
                    DataBank.Block_Users.Add(s);

                }
            }

            String trueLogin;
            String truePassword;
            string line;
            string[] LogPass;
            bool account = false;

            using (StreamReader sr = new StreamReader(DataBank.path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    LogPass = line.Split(',');
                    trueLogin = (LogPass[0]);
                    truePassword = (LogPass[1]);

                    if (trueLogin == Login & truePassword == Password)
                    {

                        if (Login == "ADMIN")
                        {
                            account = true;
                            MessageBox.Show("Вы вошли в аккаунт как админ");
                            LoadData();
                            DataBank.Login = Login;
                            Form form3 = new Form3();
                            form3.Show();

                        }
                        else
                        {
                            if ((DataBank.Block_Users.Contains(trueLogin)) == true)
                            {
                                MessageBox.Show("Ваш аккаунт заблокирован");
                                Application.Exit();


                            }
                            else
                            {
                                account = true;
                                MessageBox.Show("Вы вошли в аккаунт");
                                DataBank.Login = Login;
                                Form form2 = new Form2();
                                form2.Show();

                            }
                            

                        }

                    }

                }
                if (account == false)
                {
                    MessageBox.Show("Неверный пароль или логин");
                    DataBank.errcount = DataBank.errcount - 1;
                    MessageBox.Show("Попыток осталось: " + DataBank.errcount);

                    if (DataBank.errcount == 0)
                    {
                        MessageBox.Show("Вход заблокирован");
                        Application.Exit();
                    }
                }
            }

            return account;
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
