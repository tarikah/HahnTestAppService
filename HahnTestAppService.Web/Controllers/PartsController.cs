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
        public async Task<List<GetPartResponse>> Get()
        {
            return await _partsService.GetParts(CancellationToken.None);
        }
    }
}
