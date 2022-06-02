using Exercise3.Application.Service;
using Exercise3.ViewModels.Agreements;
using Exercise3.ViewModels.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Exercise3.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AnotherPolicy")]
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
            return Json(agreements);
        }
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AgreementsCreateRequest request)
        {
            var agreementid = await _publicAgreementsService.Create(request);
            if (agreementid == 0)
                return BadRequest();

            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AgreementsUpdateRequest request)
        {
            var affectedResult = await _publicAgreementsService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agreement = await _publicAgreementsService.GetById(id);
            if (agreement == null)
                return BadRequest("Cannot find product");
            return Ok(agreement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _publicAgreementsService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();    
            return Ok();
        }

        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] GetAgreementsFilter request)
        {
            var agreements = await _publicAgreementsService.GetAllPaging(request);
            return Json(agreements);
        }
    }
}
