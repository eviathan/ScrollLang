using Scroll.Exceptions;
using Scroll.Parser;

namespace Scroll 
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Scroll 0.1");
            Console.WriteLine("Type \"help\" for more information and \"quit\" to exit.");

            // TODO: Add args and read in filename then call Lexer.Run on each line
            RunPrompt();
        }

        private static void RunPrompt()
        {
            do
            {
                try
                {
                    Console.Write("> ");
                    var line = Console.ReadLine();

                    if (line == "quit")
                        break;
                    else if(line == "help")
                        Console.WriteLine("You are on your own!");
                    else if(string.IsNullOrWhiteSpace(line))
                        continue;

                    Lexer.Run(line);
                }
                catch(CodeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Fatal Exception:");
                    Console.WriteLine(ex.Message);
                }
            } 
            while(true);
        }
    }
}