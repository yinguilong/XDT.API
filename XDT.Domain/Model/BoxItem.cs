using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain.Model
{
    /// <summary>
    /// 盒子子项
    /// </summary>
    public class BoxItem : AggregateRoot
    {
        public Box Box { get; set; }
        public virtual PPismItem PPismItem { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

