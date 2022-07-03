using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.DomainException
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() : base("AlreadyExistsException that value already exists") { }
    }
}
