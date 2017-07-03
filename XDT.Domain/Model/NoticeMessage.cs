using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.Enums;

namespace XDT.Domain.Model
{
    public class NoticeMessage : AggregateRoot
    {
        public NoticeMessage()
        {

        }
        public NoticeMessage(string content)
        {
            Content = content;
        }
        public DictNoticeStatus Status { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }

        public User User { get; set; }

        public void Read()
        {
            this.Status = DictNoticeStatus.已读;
        }
    }
}

