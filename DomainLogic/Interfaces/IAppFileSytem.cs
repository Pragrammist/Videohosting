using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Interfaces
{
    public interface IAppFileSytem
    {
        public Stream GetStream(string path);
        public Stream GetByte(string path);
    }
}
