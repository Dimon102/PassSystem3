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
    public partial class Form4 : Form
    {
        lab5 lab_5;
        Users_operations users_Operations;
        bool account = false;



        public Form4()
        {
            InitializeComponent();
            lab_5 = new lab5();
            users_Operations = new Users_operations();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка на сложность
            int speed = 700;
            label2.Text = $"Максимальное время взлома\nпри скорости {speed} символов/сек.: \n{lab_5.CheckPassBruteTime(textBox1.Text, speed):F3} сек.";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            account = users_Operations.User_Log_in(textBox2.Text, textBox3.Text);

            if (account == true)
            {
                this.Hide();

            }
        }
    }
}
