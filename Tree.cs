using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Tree
    {
        private int _topNode = 0;
        private List<Node> _nodes;

        public Tree(List<Node> nodes, int topNode)
        {
            _nodes = nodes;
            _topNode = topNode;
        }

        public Token Evaluate()
        {
            return _nodes[_topNode].Evaluate();
        }
    }
}
