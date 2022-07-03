using DomainLogic.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Specifications
{
    public class UserExistsSpecification : ISpecification<User, Guid>
    {
        Guid _id;
        string _name;
        string _email;
        string _phone;
        public UserExistsSpecification(Guid id, string name, string email, string phone)
        {
            _id = id;
            _name = name;
            _email = email;
            _phone = phone;
        }

        public Expression<Func<User, bool>> ToExpression()
        {
            return u => u.Id == _id && u.Phone == _phone && u.Email == _email && u.UserName == _name;
        }
    }

    public class FileExistsSpecification : ISpecification<File, Guid>
    {
        string _filePath;
        Guid _id;
        public FileExistsSpecification(string filePath, Guid id)
        {
            _filePath = filePath;
            _id = id;
        }

        public Expression<Func<File, bool>> ToExpression()
        {
            return i => i.FilePath == _filePath && i.Id == _id;
        }
    }
}
