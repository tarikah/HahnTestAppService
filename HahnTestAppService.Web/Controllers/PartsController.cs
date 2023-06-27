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
        [HttpPost]
        public async Task<ActionResult> Add(AddPartRequest request)
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
    }
}
