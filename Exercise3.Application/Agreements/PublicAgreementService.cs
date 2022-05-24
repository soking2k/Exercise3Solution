using Exercise3.Data.EF;
using Exercise3.ViewModels.Agreements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Application.Agreements
{
    public class PublicAgreementService : iPublicAgreementService
    {
        private readonly Exercise3DbContext _context;
        public PublicAgreementService(Exercise3DbContext context)
        {
            _context = context;
        }

        public async Task<List<AgreementViewModel>> GetAll()
        {
            var query = from p in _context.Agreements select new {p };
            var data = await query.Select(x => new AgreementViewModel()
            {
                Id = x.p.Id,
                Status = x.p.Status,
                QuoteNumber = x.p.QuoteNumber,
                AgreementName = x.p.AgreementName,
                AgreementType = x.p.AgreementType,
                DistributorName = x.p.DistributorName,
                EffectiveDate = x.p.EffectiveDate,
                ExpirationDate = x.p.ExpirationDate,
                CreatedDate = x.p.CreatedDate,
                DaysUntilExpiration = x.p.DaysUntilExpiration
            }).ToListAsync();
            return data;
        }
    }
}
