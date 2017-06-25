using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Model.Contracts
{
    [Serializable]
    public class ResponseEntity<T> where T : class
    {
        /// <summary>
        /// 接口返回结果
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 集合数目
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 返回 的数据集合
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}

