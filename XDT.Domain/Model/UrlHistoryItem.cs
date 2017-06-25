using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain.Model
{
    /// <summary>
    /// 商品地址项
    /// </summary>
    public class UrlHistoryItem : AggregateRoot
    {
        public WareItem WareItem { get; set; }
        public string Url { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}

