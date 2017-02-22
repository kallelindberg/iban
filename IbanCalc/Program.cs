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
            int i = 0; //write indexer
            int ni = 0; //zero position indexer
            int ri = 0; // read indexer
            bool result; //for parsing
            int[] bban = new int[14]; //bban constructor repository
            int[] acc = new int[14]; //iban account repository
            int[] numero = new int[20]; //account construct repository
            int[] mtunnus = new int[6] { 1, 5, 1, 8, 0, 0 }; //country identifier
            int z = (14 - 6 - (s.Length - 6)); //zero count
            for (int c = 0; c < s.Length; c++)
            {
                result = int.TryParse(s[c].ToString(), out bban[i]);
                if (result == false)
                { z = z+1; }
                else
                i++;
            }
            i = 0;
            if (bban[0] == 4 || bban[0] == 5){ ni = 7; }
            else { ni = 6; }
            for (int c = 0; c < ni; c++)
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
            Console.WriteLine(IbanCalc(s));
            Console.ReadKey();
        }
    }
}
