using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practis
{
    class Utility
    {
        public static int Get_ID(ComboBox value)
        {
            StringBuilder id = new StringBuilder("");

            for (int i = 0; char.IsDigit(value.SelectedItem.ToString()[i]) && i < value.SelectedItem.ToString().Length; i++)
                id.Append(value.SelectedItem.ToString()[i]);

            return Convert.ToInt32(id.ToString());
        }

        public static int Get_ID(string value)
        {
            StringBuilder id = new StringBuilder("");

            for (int i = 0; char.IsDigit(value[i]) && i < value.Length; i++)
                id.Append(value[i]);

            return Convert.ToInt32(id.ToString());
        }

        /// <summary>
        /// Проверки полей
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        public static bool Cor_name(string name)
        {
            if (name.Length < 2)
                return false;

            for (int i = 0; i < name.Length; i++)
            {
                if (!Cor_name_char(name[i]))
                    return false;
            }

            return true;
        }

        public static bool Cor_email(string mail)
        {
            if (mail.Length < 2)
                return false;

            if (mail[0] == '.' || mail[mail.Length - 1] == '.')
                return false;

            for (int i = 0; i < mail.Length; i++)
            {
                if (!Cor_mail_char(mail[i]))
                    return false;

                if (i > 0 && i < (mail.Length - 1))
                    if (mail[i] == '.' && mail[i + 1] == '.')
                        return false;
            }

            return true;
        }

        public static bool Cor_phone(string phone)
        {
            if (phone.Length < 6)
                return false;

            for (int i = 0; i < phone.Length; i++)
            {
                if (!Cor_phone_char(phone[i], i))
                    return false;
            }

            return true;
        }

        public static bool Corr_digit(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                    return false;
            }

            return true;
        }


        private static bool Cor_name_char(char c)
        {
            return (c >= 'А' && c <= 'я') || c == '-';
        }

        private static bool Cor_phone_char(char c, int num)
        {
            if (c == '+' && num == 0)
                return true;

            return char.IsDigit(c) || c == '-' || c == '(' || c == ')';
        }

        private static bool Cor_mail_char(char c)
        {
            if (c == '\\')
                return false;

            bool OneOfSeparate = c == '!' || c == '=';
            bool FromFirstGroup = c >= '#' && c <= '+';
            bool FromSecondGroup = c >= '-' && c <= '9';
            bool FromThirdGroup = c >= '?' && c <= '~';

            return OneOfSeparate || FromFirstGroup || FromSecondGroup || FromThirdGroup;
        }
    }
}
