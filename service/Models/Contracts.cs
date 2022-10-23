using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace service.Models
{
    public partial class Contracts
    {
        public Contracts()
        {
            ContractsCovers = new HashSet<ContractsCovers>();
        }

        public string Id { get; set; }
        public string ContractNumber { get; set; }
        public string CertificateNumber { get; set; }
        public string ClientName { get; set; }
        public string CarBrand { get; set; }
        public string CarLicensePlate { get; set; }
        public string CarModel { get; set; }
        public string CarProductionYear { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }
        public string ClientAddress { get; set; }

        public virtual MasterDatas CarBrandNavigation { get; set; }
        public virtual MasterDatas CarModelNavigation { get; set; }
        public virtual ICollection<ContractsCovers> ContractsCovers { get; set; }
        
        [NotMapped]
        public string CarBrandText { get; set; }
        [NotMapped]
        public string CarModelText { get; set; }
    }
}
