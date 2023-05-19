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
    public partial class Form4 : Form
    {
        Model model;

        lab5 lab_5;
        Users_operations users_Operations;
        bool account = false;
        bool bruteInProcess;




        public Form4(Model model)
        {
            InitializeComponent();
            lab_5 = new lab5();
            users_Operations = new Users_operations();
            this.bruteInProcess = false;


            InitializeComponent();
            textBox1.Focus();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.model = model;
            this.bruteInProcess = false;

            this.VisibleChanged += LoginMenu_VisibleChanged;
            this.Disposed += LoginMenu_VisibleChanged;
            this.FormClosed += LoginMenu_VisibleChanged;
            this.Disposed += LoginMenu_Disposed;

            foreach (InputLanguage Lng in InputLanguage.InstalledInputLanguages)
                if (Lng.Culture.EnglishName.ToUpper().StartsWith("EN"))
                    InputLanguage.CurrentInputLanguage = Lng;

            if (model.AllowedAttempts == 0)
                this.textBox2.UseSystemPasswordChar = false;
            //model.OnTryPassword += button1_Click;
            model.OnTryPassword += DoEvents;

        }
        private void DoEvents(string pass)
        {
            button1_Click(this, EventArgs.Empty);
            Application.DoEvents();
        }

        private void LoginMenu_Disposed(object sender, EventArgs e)
        {
            model.exit = true;
            Application.Exit();
        }

        private void LoginMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                label3.Text = "";
                textBox1.Focus();
            }
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
            //вход в акк
            account = users_Operations.User_Log_in(textBox2.Text, textBox3.Text);

            if (account == true)
            {
                this.Hide();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //брутфорс
            int passLength = 1;
            try
            {
                passLength = int.Parse(textBox3.Text);
            }
            catch
            {
                return;
            }
            if (bruteInProcess)
            {
                model.bruteStop = true;
                return;
            }
            bruteInProcess = true;
            bool answer = model.TryBrute(textBox1.Text, passLength, this.textBox2, this.label4, this.label3);
            bruteInProcess = false;
            if (answer)
            {
                this.Hide();

                MessageBox.Show("Вы вошли в аккаунт как админ");
                LoadData();
                DataBank.Login = textBox2.Text;
                Form form3 = new Form3();
                form3.Show();
            }
            if (model.exit)
                this.Dispose();
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
