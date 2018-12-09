using AutoMapper;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Web.Api.Models.Buildings;
using Microsoft.AspNet.Identity;

namespace Web.Api.Controllers
{
    public class BuildingsController : ApiController
    {
        private readonly IBuildingsService _buildingsService;

        public BuildingsController(IBuildingsService buildingsService)
        {
            _buildingsService = buildingsService;
        }

        public IHttpActionResult Post(BuildingCreateDTO newBuild)
        {
            var serviceModel = Mapper.Map<Services.Interfaces.DTO.BuildingCreateDto>(newBuild);
            serviceModel.OwnerId = User.Identity.GetUserId();
            _buildingsService.AddNewBuilding(serviceModel);
            return Ok();
        }

        public IHttpActionResult Put(BuildingCreateDTO buildingInfo)
        {
            throw new NotImplementedException();
            //_buildingsService.AddNewBuilding(Mapper.Map<Services.Interfaces.DTO.BuildingCreateDto>(newBuild));
            //return Ok();
        }
    }
}
