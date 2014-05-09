using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class PriorityToken : Token
    {
        public static string Dictionary = "(){}[]";

        public override int Priority
        {
            get
            {
                var str = GetStr();
                if ("({[".Contains(str))
                {
                    return 2;
                }
                if (")}]".Contains(str))
                {
                    return -2;
                }
                return 0;
            } 
            set
            {
                throw new FieldAccessException();
            }
        }

        public PriorityToken() : base()
        {
        }

        public PriorityToken(char c) : base(c)
        {
        }

        public override void Prioritise()
        {
            return;
        }
    }
}
