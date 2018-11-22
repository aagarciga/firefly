using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class SupplementCategory : INameable, IAuditable, IArchibable
    {
        public SupplementCategory()
        {
            Supplements = new HashSet<Supplement>();
        }

        public int SupplementCategoryId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsArchived { get; set; }

        public ICollection<Supplement> Supplements { get; set; }
        
    }
}
