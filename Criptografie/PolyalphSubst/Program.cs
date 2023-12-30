namespace PolyalphSubst
{
    internal class Program
    {
        static void Start()
        {
            int ok = 0;

            while (ok == 0)
            {

                Console.WriteLine("Would you like to encrypt or decrypt a text?");
                Console.WriteLine("Type '1' for encryption, '2' for decryption.");
                int status = int.Parse(Console.ReadLine());
                string s;
                List<string> keys = new List<string>();

                switch (status)
                {
                    case 1:
                        Console.WriteLine("How many keys would you like to use?");
                        int n = int.Parse(Console.ReadLine());

                        Console.WriteLine("Random key generation...");


                        for (int i = 0; i < n; i++)
                        {
                            string key = RandomAlphabet(26);
                            keys.Add(key);
                            Console.Write($"{i}. key: ");
                            Console.WriteLine(key);

                        }

                        Console.WriteLine("      : ABCDEFGHIJKLMNOPQRSTUVWXYZ");

                        Console.WriteLine("Type in the text you want to encrypt.");
                        s = Console.ReadLine();

                        Console.WriteLine("The encrypted text is:");
                        Console.WriteLine(Encrypt(s, keys, n));

                        break;

                    case 2:
                        Console.WriteLine("How many keys would you like to use?");
                        n = int.Parse(Console.ReadLine());

                        Console.WriteLine("Type in the keys used to decrypt said text.");
                        for (int i = 0; i < n; i++)
                        {
                            string key = Console.ReadLine();
                            keys.Add(key);
                        }

                        Console.WriteLine("Type in the text you want to decrypt");
                        s = Console.ReadLine();

                        Console.WriteLine("The decrypted text is:");
                        Console.WriteLine(Decrypt(s, keys, n));

                        break;

                    default:
                        Console.WriteLine("Error. Invalid input");
                        break;

                }

                Console.WriteLine("Would you like to exit? Type 1 for yes, 0 for no.");
                ok = int.Parse(Console.ReadLine());
            }
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

        static string Encrypt(string s, List<string> keys, int n)
        {
            string toR = "";
            string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int j = 0;

            for (int i = 0; i < s.Length; i++)
            {

                char c = s[i];
                if (c >= 'A' && c <= 'Z')
                {
                    string key = keys[j];
                    bool ok = true;
                    for (int k = 0; k < 26 && ok == true; k++)
                    {
                        if (ABC[k] == c)
                        {
                            toR += key[k];
                            ok = false;
                        }
                    }
                    j++;
                    if (j >= n)
                        j = 0;
                }
                else
                {
                    toR += c;
                }
            }

            return toR;
        }

        static string Decrypt(string s, List<string> keys, int n)
        {
            string toR = "";
            string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int j = 0;

            for (int i = 0; i < s.Length; i++)
            {

                char c = s[i];
                if (c >= 'A' && c <= 'Z')
                {
                    string key = keys[j];
                    bool ok = true;
                    for (int k = 0; k < 26 && ok == true; k++)
                    {
                        if (key[k] == c)
                        {
                            toR += ABC[k];
                            ok = false;
                        }
                    }
                    j++;
                    if (j >= n)
                        j = 0;
                }
                else
                {
                    toR += c;
                }
            }

            return toR;
        }
    }
}