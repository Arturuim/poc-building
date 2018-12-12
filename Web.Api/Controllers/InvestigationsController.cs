using Microsoft.AspNet.Identity;
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

        [Authorize(Roles = "Overseer")]
        [HttpGet]
        [Route("api/investigations/{investigationId}")]
        public IHttpActionResult GetById(string investigationId)
        {
            return Ok(this._investigationsService.GetInvestigationInfoById(investigationId));
        }

        [Authorize(Roles = "Overseer")]
        [HttpGet]
        [Route("api/investigations/{investigationId}/check")]
        public IHttpActionResult CheckIfParticipant(string investigationId)
        {
            return Ok(this._investigationsService.CheckIfPartOfInvestigation(investigationId, User.Identity.GetUserId()));
        }

        [Authorize(Roles = "SeniorOverseer")]
        [HttpPost]
        [Route("api/investigations/{dealId}")]
        public IHttpActionResult StartInvestigation(string dealId, [FromBody]List<string> investigatorsIds)
        {
            this._investigationsService.StartInvestigation(dealId, investigatorsIds);
            return Ok();
        }

        [Authorize(Roles = "Overseer")]
        [HttpPut]
        [Route("api/investigations/{investigationId}/status")]
        public IHttpActionResult StartInvestigation(string investigationId, [FromBody]string status)
        {
            this._investigationsService.ChangeStatus(investigationId, status);
            return Ok();
        }
    }
}
