using System.Text;

namespace XORCryptor
{
    internal static class Utils
    {
        public static string FromHex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            byte[] anon = raw;
            string slin = Encoding.ASCII.GetString(anon, 0, anon.Length);

            return slin;
        }

        public static string Encrypt(string plaintext, string pad)
        {
            char[] data = plaintext.ToCharArray();
            char[] key = pad.ToCharArray();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (char)(data[i] ^ key[i % key.Length]);
            }
            return bytes(new string(data));
        }

        public static string Decrypt(string enctext, string pad)
        {
            var data = FromHex(enctext);
            char[] key = pad.ToCharArray();
            return Encoding.UTF8.GetString(data.Select((b, i) => (byte)(b ^ key[i % key.Length])).ToArray());
        }

        public static string bytes(string inse)
        {
            string decString = inse;
            byte[] bytes = Encoding.Default.GetBytes(decString);
            string hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            return hexString.ToLower();
        }

        public static string GenerateKey(int length)
        {
            Random _random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}