using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XDT.Domain.Model
{
    [Table("Users1")]
    public class User : AggregateRoot
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginAccount { get; set; }
        public string Email { get; set; }
        public string HeaderImg { get; set; }
        public string PhoneNumber { get; set; }
        public string Career { get; set; }

        public bool IsDisabled { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public string Contact { get; set; }

        public override string ToString()
        {
            return this.UserName;
        }

        #region Public Methods

        public void Disable()
        {
            this.IsDisabled = true;
        }

        public void Enable()
        {
            this.IsDisabled = false;
        }

        // 为当前用户创建盒子。
        public Box CreateBox()
        {
            var ppBox = new Box { User = this };
            return ppBox;
        }
        #endregion
    }
}

