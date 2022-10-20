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

        public async Task<List<Contracts>> Search(string keyword)
        {
            var result = await DbContext.Contracts.Where(x => x.ContractNumber.Contains(keyword) ||
                                                              x.CertificateNumber.Contains(keyword) ||
                                                              x.ClientName.Contains(keyword)).ToListAsync();
            return result;
        }

        public async Task<Contracts> Get(string id)
        {
            var result = await DbContext.Contracts.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }
    }
}
