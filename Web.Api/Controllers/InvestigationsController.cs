using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Api.Controllers
{
    public class InvestigationsController : ApiController
    {
        private readonly IInvestigationsService _investigationsService;

        public InvestigationsController(IInvestigationsService investigationsService)
        {
            _investigationsService = investigationsService;
        }

        [HttpPost]
        [Route("api/investigations/{dealId}")]
        public IHttpActionResult StartInvestigation(string dealId, [FromBody]List<string> investigatorsIds)
        {
            this._investigationsService.StartInvestigation(dealId, investigatorsIds);
            return Ok();
        }
    }
}
