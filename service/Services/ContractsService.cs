using Microsoft.EntityFrameworkCore;
using service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service.Services
{
    public class ContractsService
    {
        private readonly demoContext DbContext;

        public ContractsService()
        {
            DbContext = new demoContext();
        }

        public async Task<List<Contracts>> Get()
        {
            var result = await DbContext.Contracts.ToListAsync();
            return result;
        }

        public async Task<List<Contracts>> Search(string keyword = "")
        {
            if (keyword == null)
            {
                var all = await DbContext.Contracts.ToListAsync();
                return all;
            }
            var result = await DbContext.Contracts.Where(x => x.ContractNumber.Contains(keyword) ||
                                                              x.CertificateNumber.Contains(keyword) ||
                                                              x.ClientName.Contains(keyword)).ToListAsync();
            return result;
        }

        public async Task<Contracts> Get(string id = "")
        {
            var result = await DbContext.Contracts.Where(x => x.Id.Equals(id)).Include(x => x.ContractsCovers).FirstOrDefaultAsync();

            result.CarBrandText = DbContext.MasterDatas.Where(x => x.Id.Equals(result.CarBrand)).FirstOrDefault().Name;
            result.CarModelText = DbContext.MasterDatas.Where(x => x.Id.Equals(result.CarModel)).FirstOrDefault().Name;

            foreach (var item in result.ContractsCovers)
            {
                item.ContractNameText = DbContext.MasterDatas.Where(x => x.Id.Equals(item.CoverName)).FirstOrDefault().Name;
            }

            return result;
        }
    }
}
