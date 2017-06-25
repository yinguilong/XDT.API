using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.DTO;

namespace XDT.Model.Contracts
{
    public interface IUserService
    {
        #region Methods

        IList<UserDTO> CreateUsers(List<UserDTO> userDtos);

        UserDTO ValidateUser(string loginAccount, string password);

        bool DisableUser(UserDTO userDto);

        bool EnableUser(UserDTO userDto);

        void DeleteUsers(List<UserDTO> userDtos);

        IList<UserDTO> UpdateUsers(List<UserDTO> userDataObjects);

        UserDTO GetUserByKey(long id);

        UserDTO GetUserByEmail(string email);

        UserDTO GetUserByName(string userName);
        UserDTO GetUserByLoginAccount(string loginAccount);
        IList<UserDTO> GetUsers();
        #endregion
    }
}
