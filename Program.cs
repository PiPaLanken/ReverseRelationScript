using System;
using System.Text.RegularExpressions;

namespace ReverseRelationScript
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"[0-9/{}[,\]]");
            string input;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Give me Relations without blanks: example: {[1,2],[2,3],[30,500]}\n");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid format!\nPress any key to try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }
                else break;
            }

            string output = "{";
            bool longNumber = false;

            for (int i=input.Length-1; i >0; i--)
            {
                switch (input[i])
                {
                    case '{': { i = 0; break; }
                    case '}': { output += "["; break; }
                    case ',': { if (input[i - 1] == ']') output += ",["; else output += ","; longNumber = false; break; }
                    case ']': {  break; }
                    case '[': { output += "]"; break; }
                    default:
                        {
                            string helper = "";
                            if (!longNumber)
                            {
                                for (int j = 1; j < 10; j++)
                                {
                                    if (char.IsNumber(input[i - j]))
                                    {
                                        helper += input[i - j];
                                        longNumber = true;
                                    }
                                    else
                                    {
                                        char[] charArray = helper.ToCharArray();
                                        Array.Reverse(charArray);
                                        output += new string(charArray);
                                        output += input[i].ToString();
                                        j = 10;
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            output += "}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nThe Answer:\n\n{output}\n");
            Console.ReadLine();
        }
    }
}
