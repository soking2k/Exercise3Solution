using Exercise3.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.ViewModels.Agreements
{
    public class AgreementsCreateRequest
    {
        public string Status { get; set; }
        public string QuoteNumber { get; set; }
        public string AgreementName { get; set; }
        public string AgreementType { get; set; }
        public string DistributorName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DaysUntilExpiration { get; set; }
    }
}
