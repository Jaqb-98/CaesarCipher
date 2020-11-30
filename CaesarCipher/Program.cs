using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Program
    {
        private static Dictionary<char, char> charsDictionary = new Dictionary<char, char>();

        private static char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ".ToCharArray();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter shift");
            int shift = int.Parse(Console.ReadLine());
            charsDictionary = CaesarCipher(shift);

            do
            {
                Console.WriteLine("1. Cipher");
                Console.WriteLine("2. Decipher");
                int input = int.Parse(Console.ReadLine());
                string s;
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Text to cipher: ");
                        s = Console.ReadLine();
                        Console.WriteLine(Cipher(s));
                        break;
                    case 2:
                        Console.WriteLine("Text to decipher: ");
                        s = Console.ReadLine();
                        Console.WriteLine(Decipher(s));
                        break;
                    default:
                        Console.Clear(); 
                        break;

                }
            } while (true);
        }

        private static Dictionary<char, char> CaesarCipher(int shift)
        {
            var charsDictionary = new Dictionary<char, char>();

            while (shift >= Alphabet.Length)
                shift -= Alphabet.Length;
            for (int i = 0; i < Alphabet.Length; i++)
            {
                if (shift == Alphabet.Length)
                    shift = 0;

                charsDictionary.Add(Alphabet[i], Alphabet[shift]);
                shift++;
            }
            return charsDictionary;
        }

        private static string Decipher(string txt)
        {
            StringBuilder b = new StringBuilder();
            string character;

            for (int i = 0; i < txt.Length; i++)
            {
                character = txt.Substring(i, 1);
                char c = char.Parse(character.ToUpper());

                foreach (var item in charsDictionary)
                {
                    if (item.Value == c)
                    {
                        b.Append(item.Key.ToString().ToLower());
                        break;
                    }
                }
            }

            return b.ToString();
        }
        private static string Cipher(string txt)
        {
            StringBuilder b = new StringBuilder();
            string character;

            for (int i = 0; i < txt.Length; i++)
            {
                character = txt.Substring(i, 1);
                char c = char.Parse(character.ToUpper());

                foreach (var item in charsDictionary)
                {
                    if (item.Key == c)
                    {
                        b.Append(item.Value.ToString().ToLower());
                        break;
                    }
                }
            }

            return b.ToString();
        }

    }

}
