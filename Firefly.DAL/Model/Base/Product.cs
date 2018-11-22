using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public abstract partial class Product : INameable, IAuditable, IArchibable
    {
        public Product()
        {
            ContractProducts = new HashSet<ContractProduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsArchived { get; set; }
        public int ProductType { get; set; }
        public string Category { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBePurchased { get; set; }
        public string InternalReference { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? CustomerTaxes { get; set; }
        public decimal? Cost { get; set; }

        public ICollection<ContractProduct> ContractProducts { get; set; }
        
    }
}
