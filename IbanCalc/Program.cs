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
            int mi = 0;
            int ri = 0;
            bool result;
            int[] bban = new int[14];
            int[] acc = new int[14];
            int[] numero = new int[20];
            int[] mtunnus = new int[6] { 1, 5, 1, 8, 0, 0 };
            int z = (14 - 6 - (s.Length - 6));
            for (int c = 0; c < s.Length; c++)
            {
                result = int.TryParse(s[c].ToString(), out bban[i]);
                if (result == false)
                { z = z+1; }
                else
                i++;
            }
            i = 0;
            if (bban[0] == 4 || bban[0] == 5){ mi = 7; }
            else { mi = 6; }
            for (int c = 0; c < mi; c++)
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
            for (int c = 0; c < 14; c++)
            {
                acc[c] = numero[c];
            }
            i = 14;
            for (int c = 0; c < 6;c++)
            {
                numero[i] = mtunnus[c];
                i++; 
            }

            string acn = string.Join("", numero);
            decimal jakoj = (decimal.Parse(acn) % 97);
            decimal tarkiste = 98 - jakoj;
            string account = string.Join("", acc);            
            string iban = "FI" + tarkiste + account + "";
            return iban;
        }
        static void Main(string[] args)
        {
            string s = "562009-4147118";
            string tulos = IbanCalc(s);
            Console.WriteLine(tulos);
            Console.ReadKey();
        }
    }
}
