using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scroll.Parser
{
    public class Lexer
    {
        public static void Run(string source)
        {
            var scanner = new Scanner(source);
            var tokens = scanner.GetTokens();

            // For now, just print the tokens.
            foreach (var token in tokens) 
            {
                Console.WriteLine(token);
            }
        }
    }
}