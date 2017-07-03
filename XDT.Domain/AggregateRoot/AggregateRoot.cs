using System;
using System.Collections.Generic;
using System.Text;

namespace XDT.Domain
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public long ID
        {
            get;
            set;
        }

        #region Object Member

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            IAggregateRoot ar = obj as IAggregateRoot;
            if (ar == null)
                return false;
            return this.ID == ar.ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        #endregion
    }
}

