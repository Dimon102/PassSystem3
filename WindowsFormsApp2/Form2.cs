using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        User user;
        public Form2()
        {
            InitializeComponent();
            user = new User();
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
        }
    }
}
