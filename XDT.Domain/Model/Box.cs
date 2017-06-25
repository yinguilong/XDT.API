using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain.Model
{
    public class Box : AggregateRoot
    {
        public virtual User User { get; set; }
    }
}

