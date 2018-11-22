using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class ContractProductPrice
    {
        public int ContractProductPriceId { get; set; }

        public int ContractProductId { get; set; }
        public long PriceId { get; set; }

        public ContractProduct ContractProduct { get; set; }
        public Price Price { get; set; }
    }
}
