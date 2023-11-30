namespace CifrulPlusN
{
    internal class Program
    {
        static string Encrypt(string input, int key)
        {
            string toR = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]))

                    toR += input[i];
                else
                {
                    char baseChar = char.IsUpper(input[i]) ? 'A' : 'a';
                    string c = "";
                    c += (char)((input[i] + key - baseChar) % 26 + baseChar);
                    toR += c;

                }
            }

            return toR;
        }

        static string Decrypt(string input, int key)
        {
            string toR = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]))

                    toR += input[i];
                else
                {

                    char baseChar = char.IsUpper(input[i]) ? 'A' : 'a';
                    string c = "";
                    c += (char)((input[i] + (26 - key) - baseChar) % 26 + baseChar);
                    toR += c;

                };
            }

            return toR;
        }

        static void CryptAnalyze(string input)
        {
            for (int i = 1; i < 27; i++)
            {
                string test = input;
                string toShow = "";
                for (int j = 0; j < test.Length; j++)
                {
                    if (!Char.IsLetter(test[j]))
                        toShow += test[j];
                    else
                    {
                        char baseChar = char.IsUpper(test[j]) ? 'A' : 'a';
                        string c = "";
                        c += (char)((test[j] + i - baseChar) % 26 + baseChar);
                        toShow += c;

                    }
                }
                Console.WriteLine($"{toShow}, Key: {26 - i}");
            }
        }

        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Type in the text purposed for encryption or decryption");
            input = Console.ReadLine();

            Console.WriteLine("Would you like to encrypt or decrypt said text? Type one for encrypt, two for decrypt. Type 3 for Cryptanalization.");
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("Type in the key for shifting");
                int key = int.Parse(Console.ReadLine());

                Console.WriteLine("The encrypted text is:");
                Console.WriteLine(Encrypt(input, key));
            }
            else if (n == 2)
            {
                Console.WriteLine("Type in the key for shifting");
                int key = int.Parse(Console.ReadLine());

                Console.WriteLine("The decrypted text is:");
                Console.WriteLine(Decrypt(input, key));
            }
            else if (n == 3)
            {
                Console.WriteLine("The cryptanalyzation of the text is one of these:");
                CryptAnalyze(input);
            }
            else
                Console.WriteLine("Error. Incorrect input");
        }
    }
}