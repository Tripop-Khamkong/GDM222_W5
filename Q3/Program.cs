using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int charCount, digitCount;
        string product;
        Dictionary<string, string> products = new Dictionary<string, string>();

        Console.Write("Enter the number of English characters: ");
        charCount = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of digits: ");
        digitCount = int.Parse(Console.ReadLine());

        string firstCode = GenerateFirstCode(charCount, digitCount);

        Console.WriteLine("Enter product names (type 'Stop' to stop):");

        while (true)
        {
            product = Console.ReadLine();
            if (product == "Stop")
                break;

            string code = GenerateNextCode(products.Count, charCount, digitCount);
            products.Add(code, product);
        }

        Console.Write("Enter a product code to search: ");
        string searchCode = Console.ReadLine();

        if (products.ContainsKey(searchCode))
        {
            string productName = products[searchCode];
            Console.WriteLine("Product found: " + productName);
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    static string GenerateFirstCode(int charCount, int digitCount)
    {
        string firstCode = new string('A', charCount) + new string('0', digitCount);
        return firstCode;
    }

    static string GenerateNextCode(int index, int charCount, int digitCount)
    {
        int totalCodes = (charCount + 1) * (int)Math.Pow(10, digitCount + 1);
        if (index >= totalCodes)
            throw new Exception("Cannot generate code. All possible codes have been assigned.");

        string code = "";
        int charIndex = index / (int)Math.Pow(10, digitCount + 1);
        int digitIndex = index % (int)Math.Pow(10, digitCount + 1);

        for (int i = 0; i < charCount; i++)
        {
            char c = (char)('A' + charIndex % 26);
            code = c + code;
            charIndex /= 26;
        }

        code += digitIndex.ToString().PadLeft(digitCount, '0');

        return code;
    }
}
