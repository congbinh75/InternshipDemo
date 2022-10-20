using System;
using System.Collections.Generic;

namespace service.Models
{
    public partial class MasterTables
    {
        public MasterTables()
        {
            MasterDatas = new HashSet<MasterDatas>();
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
        public bool Deleted { get; set; }
        public bool Check { get; set; }
        public string GroupMenu { get; set; }
        public bool IsMenu { get; set; }
        public bool IsPrice { get; set; }
        public string Url { get; set; }
        public string UrlPrice { get; set; }

        public virtual ICollection<MasterDatas> MasterDatas { get; set; }
    }
}
