using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Model.DTO
{
    public class WareItemDiscussDTO
    {
        public long Id { get; set; }
        public long WareItemId { get; set; }
        public long UserId { get; set; }
        public string Discuss { get; set; }
        public string Additional { get; set; }
        public string ResId { get; set; }
    }
}

