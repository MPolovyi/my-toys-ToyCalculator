using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class ActionToken : Token
    {
        public static string Dictionary = "+-*/";
        
        
        public ActionToken(char c) : base(c) {}

        public ActionToken() : base()
        {
        }

        protected override void CreateFunction()
        {
            switch (GetStr())
            {
                case "+":
                    MFunction = lstT => lstT[0].Evaluate() + lstT[1].Evaluate();
                    break;
                case "-":
                    MFunction = lstT => lstT[0].Evaluate() - lstT[1].Evaluate();
                    break;
                case "*":
                    MFunction = lstT => lstT[0].Evaluate() * lstT[1].Evaluate();
                    break;
                case "/":
                    MFunction = lstT => lstT[0].Evaluate() / lstT[1].Evaluate();
                    break;
            }
        }

        public override void Prioritise()
        {
            var str = GetStr();
            if ("+-".Contains(str))
            {
                Priority = 1;
            }
            if ("*/".Contains(str))
            {
                Priority = 2;
            }        
        }

    }
}
