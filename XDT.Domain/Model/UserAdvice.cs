using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.Enums;

namespace XDT.Domain.Model
{
    /// <summary>
    /// 用户建议
    /// </summary>
    public class UserAdvice : AggregateRoot
    {
        public UserAdvice()
        {

        }
        public UserAdvice(string content)
        {
            Content = content;
        }
        public DictAdviceStatus Status { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }

        public User User { get; set; }

        public DictAdviceLevel Level { get; set; }
        public void Read()
        {
            this.Status = DictAdviceStatus.已处理;
        }

    }
}

