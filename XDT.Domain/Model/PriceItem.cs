using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain.Model
{
    /// <summary>
    /// 价格
    /// </summary>
    public class PriceItem : AggregateRoot
    {
        public WareItem WareItem { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal? ActivityPrice { get; set; }
        public string Note { get; set; }
    }
}

