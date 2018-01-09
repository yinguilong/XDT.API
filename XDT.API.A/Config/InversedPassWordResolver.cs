using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDT.Domain.Model;
using XDT.Infrastructure;
using XDT.Model.DTO;

namespace XDT.API.A.Config
{
    public class InversedPassWordResolver : IMemberValueResolver<User, UserDTO, string, string>
    {

        public string Resolve(User source, UserDTO destination, string sourceMember, string destMember, ResolutionContext context)
        {
            if (source != null && !string.IsNullOrEmpty(sourceMember))
                return CryptHelper.Decrypto(sourceMember);
            else
                return string.Empty;
        }
    }
}