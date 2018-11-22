using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class Contract : IAuditable, IArchibable
    {
        public Contract()
        {
            ContractProducts = new HashSet<ContractProduct>();
        }

        public int ContractId { get; set; }
        public bool IsClosed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsArchived { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public ICollection<ContractProduct> ContractProducts { get; set; }
        
    }
}
