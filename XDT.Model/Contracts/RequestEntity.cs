using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Model.Contracts
{
    /// <summary>
    /// 请求约束
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class RequestEntity<T> where T : class
    {
        /// <summary>
        /// 接口返回结果
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 集合数目
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 返回 的数据集合
        /// </summary>
        public IEnumerable<T> Items
        {
            get; set;
        }
    }
}

