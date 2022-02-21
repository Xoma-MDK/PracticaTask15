using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace PracticaTask15
{
    internal class Program
    {
        static String encryption(String text) {
            String encryptText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (text[i] == 'я' || text[i] == 'Я')
                    {
                        encryptText += text[i] == 'я' ? "а" : "А";
                    }
                    else
                    {
                        if (text[i] != 'e' || text[i] != 'Е')
                        {
                            encryptText += (char)((int)(text[i]) + 1);
                        }
                        else
                        {
                            encryptText += (char)((int)(text[i]) + 2);
                        }
                    }
                }
                else
                {
                    encryptText += text[i];
                }
            }
            return encryptText;
        }
        static String decryption(String text)
        {
            String decryptText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (text[i] == 'а' || text[i] == 'А')
                    {
                        decryptText += text[i] == 'а' ? "я" : "Я";
                    }
                    else
                    {
                        if (text[i] != 'e' || text[i] != 'Е')
                        {
                            decryptText += (char)((int)(text[i]) - 1);
                        }
                        else
                        {
                            decryptText += (char)((int)(text[i]) - 2);
                        }
                    }
                }
                else
                {
                    decryptText += text[i];
                }
            }
            return decryptText;
        }
        static List<String> Spliting(String text) {
            List<String> subStrings = new List<String>();
            Regex r = new Regex(@"\B(\S*)\b");
            MatchCollection match = r.Matches(text);
            foreach (Match m in match) {
                subStrings.Add(m.Value.Remove(0, 1));
            }
            return subStrings;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку для шифрования: ");
            String text = Console.ReadLine();
            Console.WriteLine("Шифрованная строка: " + encryption(text));

            Console.Write("Введите строку для дешифрования: ");
            text = Console.ReadLine();
            Console.WriteLine("Дешифрованная строка: " + decryption(text));
            
            Console.Write("Введите строку для разделения: ");
            text = Console.ReadLine();
            foreach (String s in Spliting(text)) {
                Console.WriteLine(s);
            }
        }
    }
}
