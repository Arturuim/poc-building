using AutoMapper;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using System.Web.Http;
using System.Web.Mvc;
using Web.Api.Models.Buildings;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Web.Api.Controllers
{
    [System.Web.Http.Authorize(Roles = "Client")]
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

        [Route("api/buildings/{buildingId}")]
        public IHttpActionResult Put(string buildingId, [FromBody]BuildingCreateDTO buildingInfo)
        {
            var serviceModel = Mapper.Map<Services.Interfaces.DTO.BuildingCreateDto>(buildingInfo);
            serviceModel.OwnerId = User.Identity.GetUserId();

            _buildingsService.UpdateBuildingInfo(serviceModel, buildingId);

            return Ok();
        }
    }
}
