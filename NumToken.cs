using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class NumToken : Token
    {
        public static string Dictionary = "1234567890.,";
        public override int Priority { get { return 0; }set{throw new FieldAccessException();} }
        public NumToken(char c) : base(c) { }

        public NumToken() : base()
        {
        }

        public NumToken(string s) : base(s)
        {
        }

        protected override void CreateFunction()
        {
            MFunction = lstT => Convert.ToDouble(GetStr());
        }

        public override void Prioritise()
        {
            return;
        }
    }
}
