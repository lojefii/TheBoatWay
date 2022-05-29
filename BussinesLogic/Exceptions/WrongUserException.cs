using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Exceptions
{
    public class WrongUserException : Exception
    {
        public WrongUserException(string Message) : base(Message) { }
    }
}
