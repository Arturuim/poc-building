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
    public class InvestigationNotesController : ApiController
    {

        private readonly IInvestigationsService _investigationsService;

        public InvestigationNotesController(IInvestigationsService investigationsService)
        {
            _investigationsService = investigationsService;
        }

        [Authorize(Roles = "Overseer")]
        [HttpPost]
        [Route("api/investigations/{investigationId}/notes")]
        public IHttpActionResult AddNote(string investigationId, [FromBody]string note)
        {
            this._investigationsService.AddNoteToInvestigation(investigationId, User.Identity.GetUserId(), note);
            return Ok();
        }
    }
}
