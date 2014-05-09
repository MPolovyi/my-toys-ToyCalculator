using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    internal class Parser
    {
        protected List<Token> m_Tokens = new List<Token>();

        protected bool MParsed = false;
        protected double MResult = double.NaN;

        public double Result
        {
            get { return MResult; }
        }

        public void TryParse(string str)
        {
            str = str.ToLower();
            foreach (char ch in str)
            {
                AddToken(ch);
            }
            MParsed = TryParse();
        }

        public bool TryParse()
        {
            List<Token> combinedTokens = new List<Token>();
            double prev = 0;

            string next = "";

            CombineTokens(combinedTokens);
            MResult = CreateExpresionTree(combinedTokens).Evaluate();
            return true;
        }

        protected void AddToken(char c)
        {
            if (c==' ')
            {
                return;
            }
            if (ActionToken.Dictionary.Contains(c))
            {
                AddToken(new ActionToken(c));
            }
            else if (NumToken.Dictionary.Contains(c))
            {
                AddToken(new NumToken(c));
            }
            else if (PriorityToken.Dictionary.Contains(c))
            {
                AddToken(new PriorityToken(c));
            }
            else if (FunctionToken.Dictionary.Contains(c))
            {
                AddToken(new FunctionToken(c));
            }
        }
        protected void AddToken(Token token)
        {
            m_Tokens.Add(token);
        }
        private void CombineTokens(List<Token> combinedTokens)
        {
            int i = 0;
            int prToCount = 0;
            while (i < m_Tokens.Count)
            {
                var nextToken = m_Tokens[i];
                if (nextToken is NumToken)
                    combinedTokens.Add(new NumToken());
                while (nextToken is NumToken)
                {
                    combinedTokens.Last().AddStr(nextToken.GetStr());
                    try
                    {
                        nextToken = m_Tokens[++i];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        break;
                    }
                }
                if (nextToken is FunctionToken)
                    combinedTokens.Add(new FunctionToken());
                while (nextToken is FunctionToken)
                {
                    combinedTokens.Last().AddStr(nextToken.GetStr());
                    try
                    {
                        nextToken = m_Tokens[++i];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        break;
                    }
                }                if (nextToken is ActionToken)
                    combinedTokens.Add(new ActionToken());
                while (nextToken is ActionToken)
                {
                    combinedTokens.Last().AddStr(nextToken.GetStr());
                    try
                    {
                        nextToken = m_Tokens[++i];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        break;
                    }
                }
                if (nextToken is PriorityToken)
                {
                    combinedTokens.Add(new PriorityToken());
                    combinedTokens.Last().AddStr(nextToken.GetStr());
                    i++;
                }
            }
        }
        private Token CreateExpresionTree(List<Token> tokens)
        {
            SetPriorities(tokens);
            while (tokens.Count > 1)
            {
                int maxInd = 0;
                int maxPr = 0;
                for (int index = 0; index < tokens.Count; index++)
                {
                    var token = tokens[index];
                    if (token.Priority > maxPr)
                    {
                        maxPr = token.Priority;
                        maxInd = index;
                    }
                }

                Token thisToken = tokens[maxInd];
                Token nextToken;
                try
                {
                    nextToken = tokens[maxInd + 1];
                }
                catch (Exception)
                {
                    nextToken = null;
                }
                Token prevToken;
                try
                {
                    prevToken = tokens[maxInd - 1];
                }
                catch (Exception)
                {
                    prevToken = null;
                }

                thisToken.AddDescendats(new List<Token> {prevToken, nextToken});
                tokens.Remove(prevToken);
                tokens.Remove(nextToken);
                thisToken.Priority = 0;
            }
            return tokens.First();
        }

        private void SetPriorities(List<Token> tokens)
        {
            foreach (var token in tokens)
            {
                token.Prioritise();
            }
            int prBoost = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                if (token is PriorityToken)
                {
                    prBoost += token.Priority;
                    tokens.Remove(token);
                }
                else if (token is ActionToken)
                {
                    token.Priority += prBoost;
                }
            }
        }
    }
}