using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Domain.Repositories;
using XDT.Model.Contracts;
using XDT.Model.DTO;

namespace XDT.Service.ServiceImplementations
{
    public class UserServiceImp : ApplicationService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBoxRepository _boxRepository;
        //private readonly IDomainService _domainService;
        public UserServiceImp(IRepositoryContext repositoryContext,
            IUserRepository userRepository, IBoxRepository boxRepository)
            : base(repositoryContext)
        {
            _userRepository = userRepository;
            _boxRepository = boxRepository;
            //_domainService = domainService;
        }


        #region IUserService Members
        public IList<UserDTO> CreateUsers(List<UserDTO> userDtos)
        {
            if (userDtos == null)
                throw new ArgumentNullException("userDtos");
            var userInserts = new List<UserDTO>();
            var count = userDtos.Count;
            for (int i = 0; i < count; i++)//验证是否存在账号
            {
                var testUser = userDtos[i];
                var user = _userRepository.GetByExpression(x => x.LoginAccount.Equals(testUser.LoginAccount));
                if (user == null)
                    userInserts.Add(testUser);
            }
            return PerformCreateObjects<List<UserDTO>, UserDTO, User>(userInserts,
                _userRepository,
                dto =>
                {
                    if (dto.RegisteredDate == null)
                        dto.RegisteredDate = DateTime.Now;
                },
                ar =>
                {
                    var ppBox = ar.CreateBox();
                    _boxRepository.Add(ppBox);
                });
        }

        public UserDTO ValidateUser(string loginAccount, string password)
        {
            if (string.IsNullOrEmpty(loginAccount))
                throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            var user = _userRepository.CheckPassword(loginAccount, password);
            if (user != null)
                return Mapper.Map<User, UserDTO>(user);
            else
            {
                return null;
            }
        }

        public bool DisableUser(UserDTO userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException("userDto");
            User user;
            if (userDto.Id>0)
                user = _userRepository.GetByKey(userDto.Id);
            else if (!string.IsNullOrEmpty(userDto.UserName))
                user = _userRepository.GetByExpression(u => u.UserName == userDto.UserName);
            else if (!string.IsNullOrEmpty(userDto.Email))
                user = _userRepository.GetByExpression(u => u.Email == userDto.Email);
            else
                throw new ArgumentNullException("userDto", "Either ID, UserName or Email should be specified.");
            user.Disable();
            _userRepository.Update(user);
            RepositorytContext.Commit();
            return user.IsDisabled;
        }

        public bool EnableUser(UserDTO userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException("userDto");
            User user;
            if (userDto.Id>0)
                user = _userRepository.GetByKey(userDto.Id);
            else if (!string.IsNullOrEmpty(userDto.UserName))
                user = _userRepository.GetByExpression(u => u.UserName == userDto.UserName);
            else if (!string.IsNullOrEmpty(userDto.Email))
                user = _userRepository.GetByExpression(u => u.Email == userDto.Email);
            else
                throw new ArgumentNullException("userDto", "Either ID, UserName or Email should be specified.");
            user.Enable();
            _userRepository.Update(user);
            RepositorytContext.Commit();
            return user.IsDisabled;
        }

        public IList<UserDTO> UpdateUsers(List<UserDTO> userDataObjects)
        {
            return PerformUpdateObjects<List<UserDTO>, UserDTO, User>(userDataObjects, _userRepository,
                userDto => userDto.Id,
                (u, userDto) =>
                {
                    if (!string.IsNullOrEmpty(userDto.Contact))
                        u.Contact = userDto.Contact;
                    if (!string.IsNullOrEmpty(userDto.PhoneNumber))
                        u.PhoneNumber = userDto.PhoneNumber;

                    if (userDto.LastLoginDate != null)
                        u.LastLoginDate = userDto.LastLoginDate;
                    if (userDto.RegisteredDate != null)
                        u.RegisteredDate = userDto.RegisteredDate.Value;
                    if (!string.IsNullOrEmpty(userDto.Email))
                        u.Email = userDto.Email;

                    if (userDto.IsDisabled != null)
                    {
                        if (userDto.IsDisabled.Value)
                            u.Disable();
                        else
                            u.Enable();
                    }

                    if (!string.IsNullOrEmpty(userDto.Password))
                        u.Password = userDto.Password;
                });
        }

        public void DeleteUsers(List<UserDTO> userDtos)
        {
            if (userDtos == null)
                throw new ArgumentNullException("userDtos");
            foreach (var userDto in userDtos)
            {
                User user = null;
                if (userDto.Id>0)
                    user = _userRepository.GetByKey(userDto.Id);
                else if (!string.IsNullOrEmpty(userDto.UserName))
                    user = _userRepository.GetByExpression(u => u.UserName == userDto.UserName);
                else if (!string.IsNullOrEmpty(userDto.Email))
                    user = _userRepository.GetByExpression(u => u.Email == userDto.Email);
                else
                    throw new ArgumentNullException("userDtos", "Either ID, UserName or Email should be specified.");
                _userRepository.Remove(user);
            }

            RepositorytContext.Commit();
        }

        public UserDTO GetUserByKey(long id)
        {
            var user = _userRepository.GetByKey(id);
            var userDto = Mapper.Map<User, UserDTO>(user);
            return userDto;
        }

        public UserDTO GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("email");
            var user = _userRepository.GetByExpression(u => u.Email == email);
            var userDto = Mapper.Map<User, UserDTO>(user);
            return userDto;
        }

        public UserDTO GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("userName");
            var user = _userRepository.GetByExpression(u => u.UserName.Equals(userName));
            var userDto = Mapper.Map<User, UserDTO>(user);
            return userDto;
        }
        /// <summary>
        /// 根据账号获取用户实体
        /// </summary>
        /// <param name="loginAccount"></param>
        /// <returns></returns>
        public UserDTO GetUserByLoginAccount(string loginAccount)
        {
            if (string.IsNullOrEmpty(loginAccount))
            {
                return null;
            }
            return Mapper.Map<User, UserDTO>(_userRepository.GetByExpression(x => x.LoginAccount.Equals(loginAccount)));
        }


        public IList<UserDTO> GetUsers()
        {
            var users = _userRepository.GetAll();
            if (users == null)
                return null;
            var result = new List<UserDTO>();
            foreach (var user in users)
            {
                var userDto = Mapper.Map<User, UserDTO>(user);
                result.Add(userDto);
            }
            return result;
        }
        #endregion
    }
}
