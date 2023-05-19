using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Model
    {
        List<User> users;
        public string firstLogin;
        public string firstPass;

        int wrongAttempts;
        int allowedAttempts;
        public int AllowedAttempts { get { return this.allowedAttempts; } }
        public bool exit;

        string pathToSavedUsers = "Userlist.txt";
        string pathToDictionary = "Dictionary.txt";
        string[] dictionary;

        long startTime;
        public delegate void TryPassword(string pass);
        public event TryPassword OnTryPassword;
        DateTimeOffset dto;
        public bool bruteStop;


        public Model(int allowedAttempts = 3)
        {
            firstLogin = "";
            firstPass = "";
            wrongAttempts = 0;
            this.allowedAttempts = allowedAttempts;
            exit = false;

            startTime = 0;
            bruteStop = false;
            //this.dto = new DateTimeOffset(DateTime.UtcNow);
            this.dto = DateTime.Now;
            /*
                        string temp = "";
                        foreach (User user in users)
                        {
                            temp += user.ToString();
                        }
                        MessageBox.Show(temp);
            */
        }

        public bool TryBrute(string name, int passLength, TextBox textbox, Label label, Label label3)
        {
            //string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&()*+-.\\/:;<=>?@[]^_`{|}~";
            string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&()*+-.\\/:;<=>?@[]^_`{|}~";
            //string alphabet = "abcdefghijklmnopqr0123456789stuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&()*+-.\\/:;<=>?@[]^_`{|}~";
            int counter = 0;
            float seconds = 0;
            //this.startTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            this.startTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds();
            decimal totalCombinations = 0;
            for (int i = 1; i < passLength + 1; i++)
                totalCombinations += (decimal)Math.Pow(alphabet.Length, i);
            for (int n = 1; n < passLength + 1; n++)
            {
                int[] indexes = new int[n];
                for (int i = 0; i < indexes.Length; i++)
                    indexes[i] = 0;

                bool leave = false;
                while (indexes[0] < alphabet.Length && !leave)
                {
                    //MessageBox.Show(indexes.ToString());
                    string temp = "";
                    for (int i = 0; i < indexes.Length; i++)
                        temp += alphabet[indexes[i]];
                    //MessageBox.Show(temp);

                    textbox.Text = temp;
                    //TryLogin(name, temp);
                    OnTryPassword?.Invoke(temp);
                    if (bruteStop || exit)
                    {
                        bruteStop = false;
                        return false;
                    }
                    counter++;
                    seconds = (((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds() - this.startTime) / 1000f;

                    if (seconds != 0)
                    {
                        float speed = counter / seconds;
                        float timeRequired = (float)totalCombinations / speed;
                        label.Text = $"Количество паролей: {counter}\r\n" +
                            $"Длительность: {seconds} сек.\r\n" +
                            $"Средняя скорость: {speed} паролей/сек.\r\n" +
                            $"Количество комбинаций: {totalCombinations}\r\n" +
                            $"Необходимое время перебора: {timeRequired} сек.\r\n" +
                            $"Осталось времени: {timeRequired - seconds} сек.";
                    }


                    indexes[n - 1] += 1;
                    for (int i = indexes.Length - 1; i >= 0; i--)
                    {
                        if (indexes[i] >= alphabet.Length)
                        {
                            if (i == 0)
                            {
                                leave = true;
                                break;
                            }
                            else
                            {
                                indexes[i] = 0;
                                indexes[i - 1] += 1;
                            }
                        }
                    }
                }
            }
            this.startTime = 0;
            return false;
        }
    }
}
