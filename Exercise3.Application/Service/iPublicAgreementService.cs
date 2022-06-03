using Exercise3.ViewModels.Agreements;
using Exercise3.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Application.Service
{
    public interface iPublicAgreementService
    {

        Task<List<AgreementViewModel>> GetAll();

        Task<int> Create(AgreementsCreateRequest request);

        Task<AgreementViewModel> GetById(int id);

        Task<int> Update(AgreementsUpdateRequest request);

        Task<int> Delete(int productId);
        Task<PagedResult<AgreementViewModel>> GetAllPaging(GetAgreementsFilter request);

    }
}
