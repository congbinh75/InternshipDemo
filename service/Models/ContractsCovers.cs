using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace service.Models
{
    public partial class ContractsCovers
    {
        public string Id { get; set; }
        public string ContractId { get; set; }
        public string CoverName { get; set; }
        public int? CoverValue { get; set; }

        public virtual Contracts Contract { get; set; }
        public virtual MasterDatas CoverNameNavigation { get; set; }

        [NotMapped]
        public string ContractNameText { get; set; }
    }
}
