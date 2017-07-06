using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Model.DTO
{
    public class PriceItemDTO
    {
        public long Id { get; set; }
        public long? WareItemId { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal? ActivityPrice { get; set; }
        public string UpdateDay { get; set; }
        public string Note { get; set; }
    }
}