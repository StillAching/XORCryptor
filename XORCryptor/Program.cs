namespace XORCryptor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose: ");
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");

            switch (Console.ReadLine())
            {
                case "1":
                    XorEncrypt();
                    break;

                case "2":
                    XorDecrypt();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void XorDecrypt()
        {
            Console.Clear();
            Console.Write("Enter XorHexed string: ");
            string inp = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter key: ");
            string key = Console.ReadLine();
            Console.WriteLine($"\n{Utils.Decrypt(inp, key)}");
            Console.ReadKey();
        }

        public static void XorEncrypt()
        {
            Console.Clear();
            Console.Write("Enter string: ");
            string inp = Console.ReadLine();
            Console.Clear();
            Console.Write("Enter key: ");
            string key = Console.ReadLine();
            Console.WriteLine($"\n{Utils.Encrypt(inp, key)}");
            Console.ReadKey();
        }
    }
}