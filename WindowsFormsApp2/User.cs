using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class User
    {
        string Login = DataBank.Login;
        public virtual void User_Change_Password(string NewPassword, string OldPassword)
        {
            string[] LogPass;
            string str = "";
            string text = "";
            string[] lines = File.ReadAllLines(DataBank.path);
            foreach (string s in lines)
            {
                LogPass = s.Split(',');
                if (LogPass[0] == Login)
                {
                    LogPass[1] = NewPassword;
                }
                str = LogPass[0] + "," + LogPass[1];
                text = text + str + "\n";

            }
            MessageBox.Show("Вы сменили пароль");

            //MessageBox.Show("весь текст\n" + text);

            using (StreamWriter file = new StreamWriter(DataBank.path))
            {
                file.Write(text);
            }
        }
    }
}
