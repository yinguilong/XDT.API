using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.Enums;

namespace XDT.Model.DTO
{
    /// <summary>
    /// 通知信息
    /// </summary>
    public class NoticeMessageDTO
    {
        public long Id { get; set; }
        public DictNoticeStatus Status { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }

        public long UserId { get; set; }
    }
}

