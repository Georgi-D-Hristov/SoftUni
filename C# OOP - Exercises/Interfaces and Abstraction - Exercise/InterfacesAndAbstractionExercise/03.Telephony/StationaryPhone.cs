namespace _03.Telephony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StationaryPhone : ICalling
{
    public void Calling(string number)
    {

        foreach (char ch in number)
        {
            if (!char.IsDigit(ch))
            {
                Console.WriteLine("Invalid number!");
                return;
            }
        }


        if (number.Length == 10)
        {
            Console.WriteLine($"Calling... {number}");
        }
        if (number.Length == 7)
        {
            Console.WriteLine($"Dialing... {number}");
        };
    }
}
