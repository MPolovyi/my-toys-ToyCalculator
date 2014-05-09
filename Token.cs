using System;
using System.Collections.Generic;

namespace Calculator
{
    internal class Token
    {
        protected List<Token> DescTokens = new List<Token>();
        protected Func<List<Token>, double> MFunction;
        private string _mToken = "";

        public Token()
        {
        }

        public Token(char c)
        {
            _mToken += c;
        }

        public Token(string c)
        {
            _mToken += c;
        }

        public Func<List<Token>, double> GetFunction
        {
            get
            {
                if (MFunction != null)
                {
                    return MFunction;
                }
                else
                {
                    CreateFunction();
                    return MFunction;
                }
            }
        }

        public virtual int Priority { get; set; }

        public void AddDescendats(List<Token> tokens)
        {
            DescTokens.AddRange(tokens);
        }

        public virtual void AddStr(string c)
        {
            _mToken += c;
        }

        public double Evaluate()
        {
            return GetFunction(DescTokens);
        }

        public string GetStr()
        {
            return _mToken.Replace('.', ',');            
        }

        public virtual void Prioritise()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Priority.ToString() + " " + _mToken;
        }

        protected virtual void CreateFunction()
        {
            throw new NotImplementedException();
        }
    }
}