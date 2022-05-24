using Exercise3.Application.Agreements;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementsController : Controller
    {
        private readonly iPublicAgreementService _publicAgreementsService;

        public AgreementsController(iPublicAgreementService publicAgreementService)
        {
            _publicAgreementsService = publicAgreementService;
        }
        //http://localhost:port/agreements
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agreements = await _publicAgreementsService.GetAll();
            return Ok(agreements);
        }
    }
}
