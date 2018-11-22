using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class Price : IAuditable
    {
        public Price()
        {
            ContractProductPrices = new HashSet<ContractProductPrice>();
            ContractProductSupplementPrices = new HashSet<ContractProductSupplementPrice>();
        }

        public long PriceId { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalesPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<ContractProductPrice> ContractProductPrices { get; set; }
        public ICollection<ContractProductSupplementPrice> ContractProductSupplementPrices { get; set; }
    }
}
