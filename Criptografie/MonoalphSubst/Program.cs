using System.Net.NetworkInformation;

namespace MonoalphSubst
{
    internal class Program
    {
        static void Start()
        {
            int ok = 0;

            while(ok == 0)
            {

                Console.WriteLine("Would you like to encrypt, decrypt, or cryptanalize a text?");
                Console.WriteLine("Type '1' for encryption, '2' for decryption, and '3' for cryptanalization.");
                int status = int.Parse(Console.ReadLine());
                string s, key;

                switch (status)
                {
                    case 1:
                        Console.WriteLine("Random key generation...");

                        key = RandomAlphabet(26);
                        Console.WriteLine($"Generated key: {key}");

                        Console.WriteLine("Type in the text you want to encrypt.");
                        s = Console.ReadLine();

                        Console.WriteLine("The encrypted text is:");
                        Console.WriteLine(Encrypt(s, key));

                        break;

                    case 2:
                        Console.WriteLine("Type in the text you want to decrypt");
                        s = Console.ReadLine();

                        Console.WriteLine("Type in the key used to decrypt said text.");
                        key = Console.ReadLine();

                        Console.WriteLine("The decrypted text is:");
                        Console.WriteLine(Decrypt(s, key));

                        break;

                    case 3:
                        Console.WriteLine("Type in the text you want to cryptanalize");
                        s = Console.ReadLine();
                        List<string> list= Cryptanalize(s);

                        Console.WriteLine("The decrypted text could be one of the lines from the file out.txt");

                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine(list[i]);
                        }
                        break;

                    default:
                        Console.WriteLine("Error. Invalid input");
                        break;

                }

                Console.WriteLine("Would you like to exit? Type 1 for yes, 0 for no.");
                ok = int.Parse(Console.ReadLine());
            }
        }

        static List<string> Cryptanalize (string s)
        {
            List<string> decrypted = new List<string>();
            List<string> tried = new List<string>();

            int i = 1;

            while (i < 100)
            {
                bool ok = true;
                string key = RandomAlphabet(26);

                if (tried.Count() == 0)
                    tried.Add(key);
                else
                {
                    for (int j = 0; j < tried.Count() && ok; j++)
                        if (key == tried[j])
                            ok = false;
                }

                if (ok)
                {
                    string decrypt = Decrypt(s, key);
                    decrypted.Add(decrypt);
                    i++;
                }
            }

            return decrypted;
        }

        static string Encrypt(string s, string key)
        {
            string toR = "";
            string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string abc = "abcdefghijklmnopqrstuvwxyz";
            string KEY = key.ToLower();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    bool ok = true;
                    for (int j = 0; j < 26 && ok == true; j++)
                    {
                        if (ABC[j] == c)
                        {
                            toR += key[j];
                            ok = false;
                        }
                        if (abc[j] == c)
                        {
                            toR += KEY[j];
                            ok = false;
                        }
                    }
                }
                else
                {
                    toR += c;
                }
            }

            return toR;
        }

        static string Decrypt(string s, string key)
        {
            string toR = "";
            string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string abc = "abcdefghijklmnopqrstuvwxyz";
            string KEY = key.ToLower();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    bool ok = true;
                    for (int j = 0; j < 26 && ok == true; j++)
                    {
                        if (key[j] == c)
                        {
                            toR += ABC[j];
                            ok = false;
                        }
                        if (KEY[j] == c)
                        {
                            toR += abc[j];
                            ok = false;
                        }
                    }
                }
                else
                {
                    toR += c;
                }
            }

            return toR;
        }

        static String RandomAlphabet(int n)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G',
                        'H', 'I', 'J', 'K', 'L', 'M', 'N',
                        'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                        'V', 'W', 'X', 'Y', 'Z' };

            int[] frecv = new int[26];

            Random random = new Random();
            String toR = "";

            int i = 0;
            while (i < n)
            {
                int l = random.Next(0, n);
                if (frecv[l] == 0)
                {
                    toR += alphabet[l];
                    i++;
                    frecv[l] = 1;
                }
            }

            return toR;
        }

        static void Main(string[] args)
        {
            Start();
        }
    }
}