using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.DomainException
{
    public class PathNotExistsException : Exception
    {
        public PathNotExistsException() : base("PathNotExistException: Path is not exists") { }
    }

    public class EmptyException : Exception
    {
        public EmptyException() : base("EmptyException: value is empty") { }
    }

    public class LengthException : Exception
    {
        public LengthException(int min, int max) : base($"LengthException: value is too small or large. Min value can be: {min}, Max value can be: {max}") { }
    }

}
