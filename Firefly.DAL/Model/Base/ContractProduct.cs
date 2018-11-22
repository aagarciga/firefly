using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class ContractProduct
    {
        public ContractProduct()
        {
            ContractProductPrices = new HashSet<ContractProductPrice>();
            ContractProductSupplements = new HashSet<ContractProductSupplement>();
        }

        public int ContractProductId { get; set; }
        public int ContractId { get; set; }
        public int ProductId { get; set; }

        public Contract Contract { get; set; }
        public Product Product { get; set; }

        public ICollection<ContractProductPrice> ContractProductPrices { get; set; }
        public ICollection<ContractProductSupplement> ContractProductSupplements { get; set; }
    }
}
