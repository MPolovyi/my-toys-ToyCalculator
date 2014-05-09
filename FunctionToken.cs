using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class FunctionToken : ActionToken
    {
        public new static string Dictionary = "absdefghijklmnopqrstuvwxyz";

        protected override void CreateFunction()
        {
            switch (GetStr())
            {
                case "sin":
                    MFunction = lstT => Math.Sin(lstT[1].Evaluate());
                    break;
                case "cos":
                    MFunction = lstT => Math.Cos(lstT[1].Evaluate());
                    break;
            }
        }

        public FunctionToken(char c) : base(c)
        {
        }
        public FunctionToken()
        {
        }
    }
}
