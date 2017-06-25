using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Model.Enums
{
    public enum DictAdviceLevel : byte
    {
        普通 = 0,
        中级 = 1,
        高级 = 2
    }
    public enum DictAdviceStatus : byte
    {
        未处理 = 0,
        已处理 = 1
    }
    public enum DictNoticeStatus : byte
    {
        未读 = 0,
        已读 = 1
    }
    public enum DictItemType
    {
        手机 = 8,
        外设 = 1,
        电脑 = 2,
        外套 = 3,
        裤子 = 4,
        皮鞋 = 5,
        运动鞋 = 6,
        运动装 = 7,
        图书 = 9,
        食品 = 10,
        水具 = 11,
        电子产品 = 12,
        其他 = 0

    }
    public enum DictReturnStaus : int
    {
        未知错误 = 0,
        成功 = 1,
        失败 = -1
    }
    public enum DictWareItemSource : byte
    {
        淘宝 = 0,
        天猫 = 1,
        京东 = 2,
        当当 = 3,
        苏宁 = 4,
        国美 = 5,
        一号店 = 6,
        未知 = 10
    }
    public enum DictWareItemSourcePy : byte
    {
        taobao = 0,
        tmall = 1,
        jd = 2,
        dangdang = 3,
        suning = 4,
        gome = 5,
        yhd = 6
    }
    public enum DictWareItemStatus : byte
    {
        新建 = 0,
        观察中 = 1,
        已关闭 = 2,
        链接失效 = 3
    }
    public enum DictPriceTrend : byte
    {
        无变化 = 0, 降价 = 1, 涨价 = 2
    }
}

