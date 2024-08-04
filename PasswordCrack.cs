using System.Diagnostics;

namespace PasswordCracker;

public class PasswordCrack
{
    // Private field to store the password
    private string _password;

    // Public property to get and set the password
    public string Password
    {
        get => _password;
        set => _password = value;
    }

    // Static readonly list of possible characters in the password
    private static readonly List<string> ZnakiHasla = new List<string>()
    {
        // Lowercase letters
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",

        // Uppercase letters
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
        "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

        // Digits
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",

        // Special characters
        "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+",
        "[", "]", "{", "}", ";", ":", "'", "\"", "\\", "|", ",", "<", ".", ">", "/", "?"
    };

    // Property to track the number of attempts
    public int Attempt { get; private set; }

    // Constructor to initialize the password and attempt count
    public PasswordCrack(string password)
    {
        Password = password;
        Attempt = 0;
    }

    // Method to attempt to crack the password
    public string CrackPassword()
    {
        // Start a stopwatch to measure the elapsed time
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        // Variable to store the generated password
        string crackPassword = "";
        Random random = new Random();
        
        // List to keep track of attempted passwords
        List<string> passwords = new List<string>() { " " };
        string tempPassword = "";
        
        // Loop until the generated password matches the target password
        while (crackPassword != Password)
        {
            // Generate a new password if the current one has been attempted before
            while (passwords.Contains(tempPassword))
            {
                crackPassword = "";
                for (int i = 0; i < Password.Length; i++)
                {
                    crackPassword += ZnakiHasla[random.Next(0, ZnakiHasla.Count)];
                }

                tempPassword = crackPassword; 
            }
            
            // Add the generated password to the list of attempted passwords
            passwords.Add(tempPassword);
            
            // Calculate and display the elapsed time and attempt number
            TimeSpan elapsed = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
            Console.WriteLine(elapsedTime + " Attempt: " + Attempt + " Password: " + crackPassword);

            // Increment the attempt count
            Attempt++;
        }

        // Stop the stopwatch
        stopwatch.Stop();

        // Display the total number of attempts
        Console.WriteLine(passwords.Count);
        
        // Return the cracked password
        return crackPassword;
    }
}
