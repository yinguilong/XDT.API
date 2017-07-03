using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain
{
    public interface IEntity
    {
        // 当前领域实体的全局唯一标识
        long ID { get; }
    }
}
