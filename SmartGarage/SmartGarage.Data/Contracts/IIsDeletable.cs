using System;
using System.Collections.Generic;
using System.Text;

namespace SmartGarage.Data.Contracts
{
    public interface IIsDeletable
    {
        bool IsDeleted { get; }
    }
}
