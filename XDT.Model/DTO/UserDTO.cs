using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Model.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginAccount { get; set; }
        public string Email { get; set; }
        public string HeaderImg { get; set; }
        public string PhoneNumber { get; set; }
        public string Career { get; set; }

        public bool? IsDisabled { get; set; }

        public DateTime? RegisteredDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string Contact { get; set; }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}

