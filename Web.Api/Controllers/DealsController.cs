using AutoMapper;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using Services.Interfaces.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Api.Models.Deals;

namespace Web.Api.Controllers
{
    public class DealsController : ApiController
    {
        private readonly IDealService _dealService;

        public DealsController(IDealService dealService)
        {
            _dealService = dealService;
        }

        [Authorize(Roles = "Client")]
        public IHttpActionResult Post(DealCreateDTO dealCreate)
        {
            var mappedModel = Mapper.Map<CreateDealDTO>(dealCreate);
            mappedModel.ClientId = User.Identity.GetUserId();

            this._dealService.CreateDeal(mappedModel);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Route("api/deals/{dealId}/accept")]
        public IHttpActionResult AcceptDeal(string dealId)
        {
            this._dealService.AcceptDeal(dealId, User.Identity.GetUserId());
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        [Route("api/deals/{dealId}/decline")]
        public IHttpActionResult DeclineDeal(string dealId)
        {
            this._dealService.DeclineDeal(dealId, User.Identity.GetUserId());
            return Ok();
        }

    }
}
