using Exercise3.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.ViewModels.Agreements
{
    public class GetAgreementsFilter: PagingRequestBase
    {
        public string? status { get; set; }
        public string? quotenumber { get; set; }
        public string? agreementname { get; set; }
        public string? agreementtype { get; set; }
        public string? disbutorname { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? DaysUntilExpiration { get; set; }

    }
}
