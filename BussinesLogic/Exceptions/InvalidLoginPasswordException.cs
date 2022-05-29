using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Exceptions
{
    public class InvalidLoginPasswordException : Exception
    {
        public InvalidLoginPasswordException(string Message) : base(Message) { }
    }
}
