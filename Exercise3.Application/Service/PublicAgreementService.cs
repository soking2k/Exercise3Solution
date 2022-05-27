using Exercise3.Data.EF;
using Exercise3.Data.Entities;
using Exercise3.ViewModels.Agreements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Exercise3.Application.Service;
using Exercise3.ViewModels.Common;

namespace Exercise3.Application.Service
{
    public class PublicAgreementService : iPublicAgreementService
    {
        private readonly Exercise3DbContext _context;
        public PublicAgreementService(Exercise3DbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AgreementsCreateRequest request)
        {
            var agree = new Agreements()
            {
                Status = request.Status,
                QuoteNumber = request.QuoteNumber,
                AgreementName = request.AgreementName,
                AgreementType = request.AgreementType,
                DistributorName = request.DistributorName,
                EffectiveDate = request.EffectiveDate,
                ExpirationDate = request.ExpirationDate,
                CreatedDate = request.CreatedDate,
                DaysUntilExpiration = request.DaysUntilExpiration
            };
            _context.Agreements.Add(agree);

            return await _context.SaveChangesAsync();

        }

  
        public async Task<List<AgreementViewModel>> GetAll()
        {
            var query = from p in _context.Agreements select new {p };
            var data = await query.Select(x => new AgreementViewModel()
            {
             //   Id = x.p.Id,
                Status = x.p.Status,
                QuoteNumber = x.p.QuoteNumber,
                AgreementName = x.p.AgreementName,
                AgreementType = x.p.AgreementType,
                DistributorName = x.p.DistributorName,
                EffectiveDate = x.p.EffectiveDate,
                ExpirationDate = x.p.ExpirationDate,
                CreatedDate = x.p.CreatedDate,
                DaysUntilExpiration = x.p.DaysUntilExpiration,
            }).ToListAsync();
            return data;
        }

        public async Task<AgreementViewModel> GetById(int id)
        {
            var agreements = await _context.Agreements.FindAsync(id);
            var agreementsviewmodel = new AgreementViewModel()
            {
               // Id = agreements.Id,
                Status = agreements.Status,
                QuoteNumber = agreements.QuoteNumber,
                AgreementName = agreements.AgreementName,
                AgreementType = agreements.AgreementType,
                DistributorName = agreements.DistributorName,
                EffectiveDate = agreements.EffectiveDate,
                ExpirationDate = agreements.ExpirationDate,
                CreatedDate = agreements.CreatedDate,
                DaysUntilExpiration = agreements.DaysUntilExpiration

            };
            return agreementsviewmodel;
        }

        public async Task<int> Update(AgreementsUpdateRequest request)
        {
            var agreement = await _context.Agreements.FindAsync(request.Id);
            var agreements = await _context.Agreements.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (agreement == null) throw new Exception($"Cannot find a product with id: {request.Id}");
            agreements.Status = request.Status;
            agreements.QuoteNumber = request.QuoteNumber;
            agreements.AgreementName = request.AgreementName;
            agreements.AgreementType = request.AgreementType;
            agreements.DistributorName = request.DistributorName;
            agreements.EffectiveDate = request.EffectiveDate;
            agreements.ExpirationDate = request.ExpirationDate;
            agreements.CreatedDate = request.CreatedDate;
            agreements.DaysUntilExpiration = request.DaysUntilExpiration;

            return await _context.SaveChangesAsync();

        }
        public async Task<int> Delete(int productId)
        {
            var product = await _context.Agreements.FindAsync(productId);
            if (product == null) throw new Exception($"Cannot find a product: {productId}");

        
            _context.Agreements.Remove(product);

            return await _context.SaveChangesAsync();
        }

       
   
        public async Task<PagedResult<AgreementViewModel>> GetAllPaging(GetAgreementsFilter request)
        {
            var query = from p in _context.Agreements select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.status))
                query = query.Where(x => x.p.Status.Contains(request.status));
            if (!string.IsNullOrEmpty(request.quotenumber))
                query = query.Where(x => x.p.QuoteNumber.Contains(request.quotenumber));
            if (!string.IsNullOrEmpty(request.agreementname))
                query = query.Where(x => x.p.AgreementName.Contains(request.agreementname));
            if (!string.IsNullOrEmpty(request.agreementtype))
                query = query.Where(x => x.p.AgreementType.Contains(request.agreementtype));
            if (!string.IsNullOrEmpty(request.disbutorname))
                query = query.Where(x => x.p.DistributorName.Contains(request.disbutorname));



            //3. Paging

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new AgreementViewModel()
                {
                    //Id = x.p.Id,
                    Status = x.p.Status,
                    QuoteNumber = x.p.QuoteNumber,
                    AgreementName = x.p.AgreementName,
                    AgreementType = x.p.AgreementType,
                    DistributorName = x.p.DistributorName,
                    EffectiveDate = x.p.EffectiveDate,
                    ExpirationDate = x.p.ExpirationDate,
                    CreatedDate = x.p.CreatedDate,
                    DaysUntilExpiration = x.p.DaysUntilExpiration,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<AgreementViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }


    }
}
