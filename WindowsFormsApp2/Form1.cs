using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Users_operations users_Operations;
        bool account = false;


        public Form1()
        {
            InitializeComponent();
            users_Operations = new Users_operations();
            textBox1.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            account = users_Operations.User_Log_in(textBox2.Text, textBox1.Text);

            if (account == true)
            {
                this.Hide();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBank.password_restrictionsPath = File.ReadLines(DataBank.password_restrictionsPath).ToString();


            bool answer;
            if (DataBank.password_restrictions == true)
            {
                answer = DataBank.PasswordCheck(textBox1.Text);
                if (answer == true)
                {
                    users_Operations.Users_add(textBox2.Text, textBox1.Text);

                }
                else
                {
                    MessageBox.Show("Пароль должен быть больше 8 символов");

                }
            }
            else
            {
                users_Operations.Users_add(textBox2.Text, textBox1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
