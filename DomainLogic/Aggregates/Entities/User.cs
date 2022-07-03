using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DomainLogic.DomainException;
using DomainLogic.Shared;

namespace DomainLogic.Aggregates
{
    //TODO : validaty and integrity for all classes
    public class User : AggregateRootGuid
    {
        public const int maxNameLenth = 15;
        public const int minNameLenth = 3;
        private User() { }
        public User(Guid id, string userName, string email, GenderEnum gender) : base(id)
        {
            SetEmail(email);
            SetUserName(userName);
            SetGender(gender);
        }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Phone { get; protected set; }
        public int CountOfSubscribes { get; private set; } = 0;
        public GenderEnum Gender { get; protected set; }
        public Guid? ChannelId { get; protected set; }
        public Guid? AvatarId { get; protected set; }


        public void SetChannel(Guid id) => ChannelId = SetId(id);

        public void SetAvatar(Guid id) => AvatarId = SetId(id);

        public void IncreaseSubscribes() => CountOfSubscribes++;

        public void DecreaseSubscribes() 
        {
            if (--CountOfSubscribes >= 0) CountOfSubscribes--;
        }

        public bool SetGender(GenderEnum genderEnum)
        {
            if (Gender != genderEnum)
            {
                Gender = genderEnum;
                return true;
            }
            return false;
        }

        public void SetEmail(string email) => Email = email;

        public void SetPhone(string phone) => Phone = phone;

        public void SetUserName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmptyException();
            }

            if (UserName == name)
            {
                throw new AlreadyExistsException();
            }

            if (name.Length < minNameLenth || name.Length > maxNameLenth)
            {
                throw new LengthException(minNameLenth, maxNameLenth);
            }
            //return name;
        }


    }
}
