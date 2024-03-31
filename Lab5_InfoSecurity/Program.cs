// See https://aka.ms/new-console-template for more information
using System.Net.Security;

Console.WriteLine("Hello, World!");
int main()
{
    var symbols_crypt = new Dictionary<char, int>();
    var symbols_rus = new Dictionary<char, int>();
    String line;
    try
    {
        StreamReader sr = new StreamReader("D:\\input_rus.txt");
        line = sr.ReadLine();
        symbols_rus.Add('\n', 0);
        symbols_rus.Add('\r', 0);
        while (line != null)
        {
            foreach(char i in line)
            {
                if(!symbols_rus.ContainsKey(i))
                {
                    symbols_rus.Add(i, 1);
                } else
                {
                    symbols_rus[i]++;
                }
            }
            line = sr.ReadLine();
        }
        

        sr.Close();

        sr = new StreamReader("D:\\input_encrypt.txt");
        line = sr.ReadLine();
        string ecrypted_file = "";
        symbols_crypt.Add('\n', 0);
        symbols_crypt.Add('\r', 0);
        while (line != null)
        {
            foreach (char i in line)
            {
                if (!symbols_crypt.ContainsKey(i))
                {
                    symbols_crypt.Add(i, 1);
                }
                else
                {
                    symbols_crypt[i]++;
                }
            }
            ecrypted_file += line + '\n';
            line = sr.ReadLine();
        }
        symbols_rus = symbols_rus.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        symbols_crypt = symbols_crypt.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        
        sr.Close();
        foreach (var person in symbols_rus)
        {
            Console.WriteLine($"key: {person.Key}  value: {person.Value}");
        }
        Console.WriteLine("-------------------------------------------------------------------");
        foreach (var person in symbols_crypt)
        {
            Console.WriteLine($"key: {person.Key}  value: {person.Value}");
        }

        char[] crypt_alphabet = symbols_crypt.Keys.ToArray();
        char[] rus_alphabet = symbols_rus.Keys.ToArray();
        string decrypted_file = "";
        int index = 0;
        foreach(char i in ecrypted_file)
        {
            if(i == '\n')
            {
                decrypted_file += '\n';
            } else
            {
                index = Array.IndexOf(crypt_alphabet, i);
                decrypted_file += rus_alphabet[index];
            }
        }
        Console.WriteLine(decrypted_file);
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.Message);
    }
    finally
    {
        Console.WriteLine("Executing finally block.");
    }

    return 0;
}
main();