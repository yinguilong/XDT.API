using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.Enums;

namespace XDT.Model.DTO
{
    public class WareItemDTO
    {
        public long Id { get; set; }
        public string ListenUrl { get; set; }
        public string ItemName { get; set; }
        public DateTime? FirstListenTime { get; set; }
        public DateTime? LastListenTime { get; set; }
        public DictWareItemStatus Status { get; set; }
        public DictPriceTrend Trend { get; set; }
        /// <summary>
        /// 条目来源 比如：淘宝，天猫，京东自营，京东店铺，
        /// </summary>
        public DictWareItemSource ItemSource { get; set; }
        public string ItemImage { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Description { get; set; }
        public BoxItemDTO PPBoxItemDto { get; set; }
        public UserDTO Operator { get; set; }
        public DictItemType ItemType { get; set; }
    }
}

