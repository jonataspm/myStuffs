using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberR
{
    public class Romain
    {
        public Romain() { }

        Dictionary<decimal, string> _romanNumber = new Dictionary<decimal, string>()
    {
        { 1 , "I" },
        { 2 , "II"},
        { 3 , "III"},
        { 4 , "IV"},
        { 5 , "V"},
        { 9 , "IX"},
        { 10 , "X"},
        { 40 , "XL"},
        { 50 , "L"},
        { 100 , "C"},
        { 500 , "D"},
        { 1000 , "M"}
    };

        public string GetRoman(decimal value)
        {

            var romanValue = "";
            foreach (var key in _romanNumber.Keys.OrderByDescending(k => k))
            {
                while (value >= key)
                {
                    romanValue += _romanNumber[key];
                    value -= key;
                }
            }
            Console.WriteLine(romanValue);
            return romanValue;
        }
    }
}
