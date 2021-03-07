using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleBuyWebAPI.Models
{
    public class Validators
    {
        public static bool IsCnpj(string Cnpj)
        {
            int[] Multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] Multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int Soma;
            int Resto;
            string Digito;
            string TempCnpj;

            Cnpj = Cnpj.Trim();
            Cnpj = Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (Cnpj.Length != 14)
                return false;

            TempCnpj = Cnpj.Substring(0, 12);

            Soma = 0;
            for (int i = 0; i < 12; i++)
                Soma += int.Parse(TempCnpj[i].ToString()) * Multiplicador1[i];

            Resto = (Soma % 11);
            if (Resto < 2)
                Resto = 0;
            else
                Resto = 11 - Resto;

            Digito = Resto.ToString();

            TempCnpj = TempCnpj + Digito;
            Soma = 0;
            for (int i = 0; i < 13; i++)
                Soma += int.Parse(TempCnpj[i].ToString()) * Multiplicador2[i];

            Resto = (Soma % 11);
            if (Resto < 2)
                Resto = 0;
            else
                Resto = 11 - Resto;

            Digito = Digito + Resto.ToString();

            return Cnpj.EndsWith(Digito);
        }
        public static bool IsCpf(string Cpf)
        {
            int[] Multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] Multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCpf;
            string Digito;
            int Soma;
            int Resto;

            Cpf = Cpf.Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");

            if (Cpf.Length != 11)
                return false;

            TempCpf = Cpf.Substring(0, 9);
            Soma = 0;

            for (int i = 0; i < 9; i++)
                Soma += int.Parse(TempCpf[i].ToString()) * Multiplicador1[i];

            Resto = Soma % 11;
            if (Resto < 2)
                Resto = 0;
            else
                Resto = 11 - Resto;

            Digito = Resto.ToString();

            TempCpf = TempCpf + Digito;

            Soma = 0;
            for (int i = 0; i < 10; i++)
                Soma += int.Parse(TempCpf[i].ToString()) * Multiplicador2[i];

            Resto = Soma % 11;
            if (Resto < 2)
                Resto = 0;
            else
                Resto = 11 - Resto;

            Digito = Digito + Resto.ToString();

            return Cpf.EndsWith(Digito);
        }
    }
}