using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
