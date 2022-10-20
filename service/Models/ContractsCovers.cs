using System;
using System.Collections.Generic;

namespace service.Models
{
    public partial class ContractsCovers
    {
        public string ContractId { get; set; }
        public string CoverName { get; set; }
        public int? CoverValue { get; set; }

        public virtual Contracts Contract { get; set; }
        public virtual MasterDatas CoverNameNavigation { get; set; }
    }
}
