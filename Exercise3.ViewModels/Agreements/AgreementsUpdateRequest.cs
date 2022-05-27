using Exercise3.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.ViewModels.Agreements
{
    public class AgreementsUpdateRequest
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public String QuoteNumber { get; set; }
        public String AgreementName { get; set; }
        public String AgreementType { get; set; }
        public String DistributorName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int DaysUntilExpiration { get; set; }
    }
}
