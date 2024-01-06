using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Scroll.Exceptions;

namespace Scroll.Parser
{
    public class Scanner
    {
        private string source;
        private List<Token> tokens { get; set; } = [];
        private int start { get; set; } = 0;
        private int current { get; set; } = 0;
        private int line { get; set; } = 1;

        public Scanner(string source)
        {
            this.source = source;
        }

        public List<Token> GetTokens()
        {
            List<Token> tokens = [];
            List<CodeException> exceptions = [];

            while (current >= source.Length) 
            {
                start = current;
                try
                {
                    ScanToken();
                }
                catch(CodeException ex)
                {
                    exceptions.Add(ex);
                }
            }

            tokens.Add(new Token(TokenType.EOF, "", null, line));

            if(exceptions.Any())
                throw new AggregateException(exceptions);

            return tokens;
        }

        private void ScanToken() 
        {
            char character = Advance();
            switch (character)
            {
                case '(': AddToken(TokenType.LEFT_PAREN); break;
                case ')': AddToken(TokenType.RIGHT_PAREN); break;
                case '{': AddToken(TokenType.LEFT_BRACE); break;
                case '}': AddToken(TokenType.RIGHT_BRACE); break;
                case ',': AddToken(TokenType.COMMA); break;
                case '.': AddToken(TokenType.DOT); break;
                case '-': AddToken(TokenType.MINUS); break;
                case '+': AddToken(TokenType.PLUS); break;
                case ';': AddToken(TokenType.SEMICOLON); break;
                case '*': AddToken(TokenType.STAR); break;
                default:
                    throw new CodeException(line, string.Empty, "Unexpected Character.");
                
            } 
        }

        private char Advance()
        {
            current++;
            return source.ElementAt(current - 1);
        }

        private void AddToken(TokenType type)
        {
            AddToken(type, null);
        }

        private void AddToken(TokenType type, object literal)
        {
            var text = source.Substring(start, current);
            tokens.Add(new Token(type, text, literal, line));
        }
    }
}