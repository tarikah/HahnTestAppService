using HahnTestAppService.Contracts.Request;
using HahnTestAppService.Contracts.Response;
using HahnTestAppService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnTestAppService.Web.Controllers
{
   
    public class PartsController : ApiBaseController
    {
        private readonly IPartsService _partsService;

        public PartsController(IPartsService partsService)
        {
            _partsService = partsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPartResponse>>> Get()
        {
            return Ok(await _partsService.GetParts(CancellationToken.None));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPartResponse>> Get(int id)
        {
            return Ok(await _partsService.GetPart(id,CancellationToken.None));
        }
        [HttpGet("form-data/{id}")]
        public async Task<ActionResult<GetPartFormResponse>> GetPartForm(int id)
        {
            return Ok(await _partsService.GetPartForm(id));
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromBody]AddPartRequest request)
        {
            await _partsService.Add(request);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdatePartRequest request)
        {
            await _partsService.Update(request);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _partsService.Delete(id);
            return Ok();
        }
        [HttpGet("form-data")]
        public async Task<ActionResult<GetDataForAddUpdateFormResponse>> GetFormData()
        {
            return Ok(await _partsService.GetFormData());
        }
    }
}
