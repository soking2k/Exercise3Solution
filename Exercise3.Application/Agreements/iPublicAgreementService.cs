using Exercise3.ViewModels.Agreements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Application.Agreements
{
    public interface iPublicAgreementService
    {
        Task<List<AgreementViewModel>> GetAll();

    }
}
