using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class ContractProductSupplement
    {
        public ContractProductSupplement()
        {
            ContractProductSupplementPrices = new HashSet<ContractProductSupplementPrice>();
        }

        public int ContractProductSupplementId { get; set; }
        public int SupplementId { get; set; }
        public int ContractProductId { get; set; }

        public ContractProduct ContractProduct { get; set; }
        public Supplement Supplement { get; set; }

        public ICollection<ContractProductSupplementPrice> ContractProductSupplementPrices { get; set; }
    }
}
