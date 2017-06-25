using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain.Model
{
    public class WareItemDiscuss : AggregateRoot
    {
        public WareItem WareItem { get; set; }
        public User User { get; set; }
        public string Discuss { get; set; }
        public string Additional { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 回复的 聊天id默认的为空
        /// </summary>
        public long? ResId { get; set; }
    }
}

