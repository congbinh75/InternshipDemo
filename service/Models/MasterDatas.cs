using System;
using System.Collections.Generic;

namespace service.Models
{
    public partial class MasterDatas
    {
        public MasterDatas()
        {
            ContractsCarBrandNavigation = new HashSet<Contracts>();
            ContractsCarModelNavigation = new HashSet<Contracts>();
            ContractsCovers = new HashSet<ContractsCovers>();
        }

        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string MasterTableCode { get; set; }
        public bool Deleted { get; set; }

        public virtual MasterTables MasterTableCodeNavigation { get; set; }
        public virtual ICollection<Contracts> ContractsCarBrandNavigation { get; set; }
        public virtual ICollection<Contracts> ContractsCarModelNavigation { get; set; }
        public virtual ICollection<ContractsCovers> ContractsCovers { get; set; }
    }
}
