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
    public partial class Form3 : Form
    {
        User user;
        Admin admin;
        public Form3()
        {
            InitializeComponent();
            user = new User();
            admin = new Admin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = Application.OpenForms[0];
            form1.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            user?.User_Change_Password(textBox2.Text, textBox1.Text);

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            label3.Text = "Пользователь: " + DataBank.Login;
            listBox1.Items.AddRange(DataBank.Users_List);
            listBox2.Items.Clear();
            listBox2.Items.AddRange(DataBank.Block_Users.ToArray());

            DataBank.password_restrictions = Convert.ToBoolean(File.ReadLines(DataBank.password_restrictionsPath).First());


            //MessageBox.Show(DataBank.password_restrictions.ToString());
            if (DataBank.password_restrictions == true)
            {
                checkBox1.Checked = true;
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //бан

            admin.BlockUser(listBox1.SelectedItem.ToString());
            //MessageBox.Show(DataBank.Block_Users[0].ToString());
            listBox2.Items.Clear();
            listBox2.Items.AddRange(DataBank.Block_Users.ToArray());



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            //разбан
            admin.unBlockUser(listBox2.SelectedItem.ToString());
            listBox2.Items.Clear();
            listBox2.Items.AddRange(DataBank.Block_Users.ToArray());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //добавление нового пользователя с пустым паролем

            if (textBox3.Text == "")
            {
                MessageBox.Show("Нужно обязательно ввести имя пользователя");

            }
            else
            {
                admin.AddUser(textBox3.Text);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(DataBank.Users_List);

            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ограничение при регистрации

            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                DataBank.password_restrictions = true;
                //MessageBox.Show(checkBox.Text + "  включены");
                
            }
            else
            {
                DataBank.password_restrictions = false;
                //MessageBox.Show(checkBox.Text + "  отключены");
            }
            using (StreamWriter writer = new StreamWriter(DataBank.password_restrictionsPath))
            {
                writer.WriteLine(DataBank.password_restrictions.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ограничение пароля при смене пароля
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("пользователь для ограничения не выбран");

            }
            else
            {
                if (textBox4.Text == null)
                {
                    MessageBox.Show("ограничение длины не выбрано");

                }
                else
                {
                    admin.Restriction(listBox1.SelectedItem.ToString(), textBox4.Text);

                }
            }
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //снять ограничение
            admin.unRestriction(listBox1.SelectedItem.ToString());

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //цифры
            CheckBox checkBox = (CheckBox)sender;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("пользователь для ограничения не выбран");

            }
            else
            {
                admin.CheckNumbers(listBox1.SelectedItem.ToString(), checkBox.Checked);

            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //маленькие буквы
            CheckBox checkBox = (CheckBox)sender;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("пользователь для ограничения не выбран");

            }
            else
            {
                admin.CheckSmalLetters(listBox1.SelectedItem.ToString(), checkBox.Checked);

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //больш буквы
            CheckBox checkBox = (CheckBox)sender;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("пользователь для ограничения не выбран");

            }
            else
            {
                admin.CheckBigLetters(listBox1.SelectedItem.ToString(), checkBox.Checked);

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //спец символы
            CheckBox checkBox = (CheckBox)sender;
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("пользователь для ограничения не выбран");

            }
            else
            {
                admin.CheckSymbols(listBox1.SelectedItem.ToString(), checkBox.Checked);

            }
        }
    }
}
