using System.Diagnostics;

namespace PasswordCracker;

public class PasswordCrack
{

    private string _password;

    public string Password
    {
        get => _password;
        set => _password = value;
    }
    private static readonly List<string> ZnakiHasla = new List<string>()
    {
        // Małe litery
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",

        // Wielkie litery
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
        "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

        // Cyfry
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",

        // Znaki specjalne
        "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+",
        "[", "]", "{", "}", ";", ":", "'", "\"", "\\", "|", ",", "<", ".", ">", "/", "?"
    };
    public int Attempt { get; private set; }
    

    public PasswordCrack(string password)
    {
        Password = password;
        Attempt = 0;
    }

    public string CrackPassword()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        string crackPassword = "";
        Random random = new Random();
        while (crackPassword != Password)
        {
            crackPassword = "";
            for (int i = 0; i < Password.Length; i++)
            {
                crackPassword += ZnakiHasla[random.Next(0, ZnakiHasla.Count)];
            }
            
            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
            Console.WriteLine(elapsedTime + " Attempt: " + Attempt + " Password: " + crackPassword);

            Attempt++;
        }
        stopwatch.Stop();
        return crackPassword;
    }
}