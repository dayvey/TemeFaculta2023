using System;
using System.Text;
using System.IO;

namespace CifrulCezar
{
    internal class Program
    {
        static string Encrypt(string input)
        {
            string toR = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]))

                    toR += input[i];
                else
                {

                    string c = "";
                    c += (char)(input[i] + 3);
                    toR += c;

                }
            }

            return toR;
        }

        static string Decrypt(string input)
        {
            string toR = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]))

                    toR += input[i];
                else
                {

                    string c = "";
                    c += (char)(input[i] - 3);
                    toR += c;

                };
            }

            return toR;
        }

        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Type in the text purposed for encryption or decryption");
            input = Console.ReadLine();

            Console.WriteLine("Would you like to encrypt or decrypt said text? Type one for encrypt, two for decrypt.");
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("The encrypted text is:");
                Console.WriteLine(Encrypt(input));
            }
            else if (n == 2)
            {
                Console.WriteLine("The decrypted text is:");
                Console.WriteLine(Decrypt(input));
            }
            else
            {
                Console.WriteLine("Error. Invalid input.");
            }
        }
    }
}