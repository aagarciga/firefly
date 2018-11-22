using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class ContractProductSupplementPrice
    {
        public int ContractProductSupplementPriceId { get; set; }
        public int ContractProductSupplementId { get; set; }
        public long PriceId { get; set; }

        public ContractProductSupplement ContractProductSupplement { get; set; }
        public Price Price {get; set;}
    }
}
