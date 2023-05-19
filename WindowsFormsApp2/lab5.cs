using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class lab5
    {
        public double CheckPassBruteTime(string password, int speed)
        {

            bool upper = false;
            bool lower = false;
            bool digits = false;
            bool special = false;
            string speacials = "!\"#$%&\\()*+-./:;<=>?@[\\]^_`{|}~";
            foreach (char c in password)
            {
                if (Char.IsLetter(c))
                {
                    if (Char.IsUpper(c))
                        upper = true;
                    if (Char.IsLower(c))
                        lower = true;
                }
                if (Char.IsDigit(c))
                    digits = true;
                if (speacials.Contains(c))
                    special = true;
            }

            float power = 0;
            if (upper)
                power += 26;
            if (lower)
                power += 26;
            if (digits)
                power += 10;
            if (special)
                power += 33;


            return (double)(Math.Pow(power, password.Length)) / speed;
        }
    }
}
