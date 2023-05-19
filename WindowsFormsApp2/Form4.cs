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

        public Form4()
        {
            InitializeComponent();
            lab_5 = new lab5();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //проверка на сложность
            int speed = 700;
            label2.Text = $"Максимальное время взлома\nпри скорости {speed} символов/сек.: \n{lab_5.CheckPassBruteTime(textBox1.Text, speed):F3} сек.";
        }
    }
}
