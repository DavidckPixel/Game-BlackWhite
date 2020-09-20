using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_White
{
    class CCStruct // Console Command Struct
    {
        public string Parent { get; }
        public string Command { get; }

        List<string> Variable { get; }
        public List<string> VariableInf { get; }
        public string Info { get; }
        string Func { get; }

        public CCStruct(string Parent, string Command, List<string> Variable, List<string> VariableInf, string Info, string Func)
        {
            this.Parent = Parent;
            this.Command = Command;
            this.Variable = Variable;
            this.VariableInf = VariableInf;
            this.Info = Info;
            this.Func = Func;
        }

    }
}
