using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scroll.Parser
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Lexeme { get; set; }
        public object? Literal { get; set; }
        public int Line { get; set; }

        public Token(TokenType type, string lexeme, object? literal, int line)
        {
            Type = type;
            Lexeme = lexeme;
            Literal = literal;
            Line = line;
        }

        public override string ToString() =>
            $"{Type} {Lexeme} {Literal}";
    }
}