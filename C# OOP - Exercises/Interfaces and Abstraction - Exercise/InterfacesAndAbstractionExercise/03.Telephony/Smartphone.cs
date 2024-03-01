namespace _03.Telephony;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Smartphone : ICalling, IBrowsing
{
    public void Browsing(string url)
    {
        foreach (char ch in url)
        {
            if (char.IsDigit(ch))
            {
                Console.WriteLine("Invalid URL! ");
                return;
            }
        }
        Console.WriteLine($"Browsing: {url}!");
    }

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
        }
    }
}
