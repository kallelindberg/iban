using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbanCalc
{
    class Program
    {
        static string IbanCalc(string s)
        {
            int i = 0;
            bool result;
            int[] bban = new int[14];
            int[] acc = new int[14];
            int[] numero = new int[20];

            int z = (14 - 6 - (s.Length - 6));
            for (int c = 0; c < s.Length; c++)
            {
                result = int.TryParse(s[c].ToString(), out bban[i]);
                if (result == false)
                { z = z+1; }
                else
                i++;
            }
            if (bban[0]== 4 || bban[0] == 5)
            {
                int ri = 0;
                i = 0;
                for (int c = 0; c < 7; c++)
                {
                    numero[i] = bban[ri];
                    i++;
                    ri++;
                }
                for (int c = 0; c < z; c++)
                {
                    numero[i] = 0;
                    i++;
                }
                while (i<14)
                {
                    numero[i] = bban[ri];
                    i++;
                    ri++;
                }
            }
            else
            {
                int ri = 0;
                i = 0;
                for (int c = 0; c < 6; c++)
                {
                    numero[i] = bban[ri];
                    i++;
                    ri++;
                }
                for (int c = 0; c < z; c++)
                {
                    numero[i] = 0;
                    i++;
                }
                while (i < 14)
                {
                    numero[i] = bban[ri];
                    i++;
                    ri++;
                }
            }
            for (int c = 0; c < 14; c++)
            {
                acc[c] = numero[c];
            }
            numero[14] = 1;
            numero[15] = 5;
            numero[16] = 1;
            numero[17] = 8;
            numero[18] = 0;
            numero[19] = 0;
            string acn = string.Join("", numero);
            decimal jakoj = (decimal.Parse(acn) % 97);
            decimal tarkiste = 98 - jakoj;
            string account = string.Join("", acc);            
            string iban = "FI" + tarkiste + account + "";
            return iban;
        }
        static void Main(string[] args)
        {
            string s = "123456-1234";
            string tulos = IbanCalc(s);
            Console.WriteLine(tulos);
            Console.ReadKey();
        }
    }
}
