using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.Enums;

namespace XDT.Model.DTO
{
    public class UserAdviceDTO
    {
        public int Id { get; set; }
        public DictAdviceStatus Status { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }

        public string UserId { get; set; }

        public DictAdviceLevel Level { get; set; }
    }
}

