using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class Supplement: INameable, IAuditable, IArchibable
    {
        public Supplement()
        {
            ContractProductSupplements = new HashSet<ContractProductSupplement>();
        }

        public int SupplementId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsArchived { get; set; }
        public int SupplementCategoryId { get; set; }
        public SupplementCategory SupplementCategory { get; set; }

        public ICollection<ContractProductSupplement> ContractProductSupplements { get; set; }
    }
}
