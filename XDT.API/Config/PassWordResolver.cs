using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDT.Model.DTO;
using XDT.Domain.Model;
using XDT.Infrastructure;

namespace XDT.API.Config
{
    public class PassWordResolver : IMemberValueResolver<UserDTO, User,string,string>
    {

        public string Resolve(UserDTO source, User destination, string sourceMember, string destMember, ResolutionContext context)
        {
            if (source != null && !string.IsNullOrEmpty(sourceMember))
                return CryptHelper.Encrypto(sourceMember);
            else
                return string.Empty;
        }
    }
}
