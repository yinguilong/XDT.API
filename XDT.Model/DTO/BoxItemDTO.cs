using System;
using System.Collections.Generic;
using System.Text;
using XDT.Model.Enums;

namespace XDT.Model.DTO
{
    public class BoxItemDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long BoxId { get; set; }
        public long WareItemId { get; set; }
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
        public DictItemType ItemType { get; set; }

        #region Query property
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        #endregion
    }
}

