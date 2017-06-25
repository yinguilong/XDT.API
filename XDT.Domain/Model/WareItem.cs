using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using XDT.Domain.Repositories;
using XDT.Model.Enums;

namespace XDT.Domain.Model
{
    /// <summary>
    /// 商品
    /// </summary>
    public class WareItem : AggregateRoot
    {
        public WareItem(string url)
        {
            ListenUrl = url;
        }
        public WareItem() { }
        public BoxItem BoxItem { get; set; }
        /// <summary>
        /// 记录首次添加的人
        /// </summary>
        public User Operator { get; set; }
        public string ListenUrl { get; set; }
        public string ItemName { get; set; }
        public DateTime? FirstListenTime { get; set; }
        public DateTime? LastListenTime { get; set; }
        /// <summary>
        /// 商品类别
        /// </summary>
        public DictItemType ItemType { get; set; }
        public DictWareItemStatus Status { get; set; }
        public DictPriceTrend Trend { get; set; }
        /// <summary>
        /// 条目来源 比如：淘宝，天猫，京东自营，京东店铺，
        /// </summary>
        public DictWareItemSource ItemSource { get; set; }
        public string ItemImage { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            WareItem other = obj as WareItem;
            if ((object)other == null)
                return false;
            return (this.Id == other.Id || this.ListenUrl == other.ListenUrl);
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public void Init()
        {
            //初始化数据
            var urlHost = XDT.Infrastructure.UrlHelper.GetDomainFromUrl(ListenUrl);
            var enumItemSource = Enum.Parse(typeof(DictWareItemSourcePy), urlHost, true);
            ItemSource = (urlHost == "" ? DictWareItemSource.未知 : (DictWareItemSource)((byte)enumItemSource));
            CreateTime = DateTime.Now;

        }
        public void InitItemType(string keyName = null)
        {
            if (!string.IsNullOrEmpty(keyName))
            {
                ItemType = GetItemTypeByName(keyName);
                return;
            }
            ItemType = GetItemTypeByName(this.ItemName);
        }
        /// <summary>
        ///     手机=0,
        //外设=1,
        //电脑=2,
        //外套=3,
        //裤子=4,
        //皮鞋=5,
        //运动鞋=6,
        //运动装=7
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private DictItemType GetItemTypeByName(string keyName)
        {
            string regshouji = "手机";
            string regpixie = "皮鞋";
            string regwaishe = "(鼠标|键盘)";
            string regyundongxie = "运动鞋";
            string regkuzi = @"(运动|[\S]+)裤";
            string regyundongfu = "运动(服|装)";
            string regwaitao = "外套";
            if (Regex.IsMatch(keyName, regshouji))
            {
                return DictItemType.手机;
            }
            else if (Regex.IsMatch(keyName, regwaishe))
            {
                return DictItemType.外设;
            }
            else if (Regex.IsMatch(keyName, regpixie))
            {
                return DictItemType.皮鞋;
            }
            else if (Regex.IsMatch(keyName, regyundongxie))
            {
                return DictItemType.运动鞋;
            }
            else if (Regex.IsMatch(keyName, regkuzi))
            {
                return DictItemType.裤子;
            }
            else if (Regex.IsMatch(keyName, regyundongfu))
            {
                return DictItemType.运动装;
            }
            else if (Regex.IsMatch(keyName, regwaitao))
            {
                return DictItemType.外套;
            }
            else return DictItemType.其他;
        }
        public BoxItem CreateBoxItem(long userId)
        {
            var ppboxItem = new BoxItem();
            var _ppBoxRepository = ServiceLocator.Instance.GetService<IBoxRepository>();
            ppboxItem.Box = _ppBoxRepository.GetByExpression(x => x.User.Id == userId);
            ppboxItem.PPismItem = this;
            ppboxItem.CreateTime = DateTime.Now;
            return ppboxItem;
        }
        public UrlHistoryItem CreateHistoryUrl()
        {
            var historyUrl = new UrlHistoryItem()
            {
                WareItem = this,
                UpdateTime = DateTime.Now,
                Url = this.ListenUrl
            };
            return historyUrl;
        }
    }
}

