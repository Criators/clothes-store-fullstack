using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clothes.Store.Domain
{
    public static class Extensions
    {
        public static bool IsValidEmail(this string email)
        {
            if (!email.IsNullOrEmpty()) 
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                return Regex.Match(email, pattern).Success;
            }

            return false;
        }

        public static bool IsValidCPF(this string cpf)
        {
            if (!cpf.IsNullOrEmpty())
            {
                string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
                Regex regex = new Regex(pattern);

                cpf = Regex.Replace(cpf, @"[^\d]", "");

                if (cpf.Length != 11)
                {
                    return false;
                }

                int[] multipliers1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multipliers2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                string tempCpf = cpf.Substring(0, 9);
                int sum = 0;

                for (int i = 0; i < 9; i++)
                {
                    sum += int.Parse(tempCpf[i].ToString()) * multipliers1[i];
                }

                int rest = sum % 11;
                int digit1 = rest < 2 ? 0 : 11 - rest;

                tempCpf = tempCpf + digit1;
                sum = 0;

                for (int i = 0; i < 10; i++)
                {
                    sum += int.Parse(tempCpf[i].ToString()) * multipliers2[i];
                }

                rest = sum % 11;
                int digit2 = rest < 2 ? 0 : 11 - rest;

                return cpf.EndsWith($"{digit1}{digit2}");
            }

            return false;
        }
    }
}
