using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IUserAppService
    {
        public Task<UserOutputDto> Create(CreateUserDto createUserData);
        public Task<UserOutputDto> Get(GetUserDto getUserCriteries);
        public Task<UserOutputDto> ChangeName(Guid userId, string name);
        public Task<UserOutputDto> Delete(DeleteUserDto deleteUserCriteries);
        public Task<UserOutputDto> SetRole(Guid userId, string role);
    }
}
