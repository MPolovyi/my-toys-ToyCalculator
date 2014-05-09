using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Node
    {
        private List<Node> _descNodes;
        private Token _token;

        public Node(Token token, List<Node> descNodes = null)
        {
            _token = token;
            _descNodes = descNodes;
        }

        public Token Evaluate()
        {
            var e = _token.GetFunction(new List<Token>(_descNodes.ConvertAll(n => n.GetToken())));
            return new NumToken(e.ToString());
        }

        public Token GetToken()
        {
            return Evaluate();
        }
    }
}
