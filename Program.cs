namespace PasswordCracker;

class Program
{
    static void Main(string[] args)
    {
        PasswordCrack pc = new PasswordCrack("MrBeast123");

        Console.WriteLine("Password: " + pc.CrackPassword());
        Console.WriteLine("Attempt: " + pc.Attempt);
        Console.ReadKey();
    }
}
