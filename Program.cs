using System;

namespace Sork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.Write(">");
                string input = Console.ReadLine();
                input = input.ToLower();
                input = input.Trim();
                if (input == "lol")
                {
                    Console.WriteLine("You laugh out loud");
                }
                else if (input == "dance")
                {
                    Console.WriteLine("Cha cha cha");
                }
                else if (input == "sing")
                {
                    Console.WriteLine("Play Freebird!");
                }
                else if (input == "whistle")
                {
                    Console.WriteLine("What a lovely tune");
                }
                else if (input == "exit")
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Unknown command");
                }
            } while (true);
        }
    }
}
