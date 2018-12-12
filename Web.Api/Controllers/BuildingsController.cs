using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Services.Interfaces;
using System.Linq;
using System.Web.Http;
using Web.Api.Models.Buildings;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Web.Api.Controllers
{
    public class BuildingsController : ApiController
    {
        private readonly IBuildingsService _buildingsService;

        public BuildingsController(IBuildingsService buildingsService)
        {
            _buildingsService = buildingsService;
        }

        public IHttpActionResult Get([FromUri]Filter filter)
        {
            var res = this._buildingsService.Get(filter)
                .Select(b => Mapper.Map<BuildingInfoDTO>(b))
                .ToList();

            return Ok(res);
        }

        [HttpGet]
        [Route("api/buildings/{buildingId}")]
        public IHttpActionResult GetById(string buildingId)
        {
            var res = Mapper.Map<BuildingInfoDTO>(this._buildingsService.GetBuildingById(buildingId));
            return Ok(res);
        }

        //[HttpGet]
        //public IHttpActionResult GetByAddress(string address)
        //{
        //    var res = this._buildingsService.GetBuildingsByAddress(address)
        //        .Select(b => Mapper.Map<BuildingInfoDTO>(b))
        //        .ToList();

        //    return Ok(res);
        //}

        [Authorize(Roles ="Owner")]
        public IHttpActionResult Post(BuildingCreateDTO newBuild)
        {
            var serviceModel = Mapper.Map<Services.Interfaces.DTO.BuildingCreateDto>(newBuild);
            serviceModel.OwnerId = User.Identity.GetUserId();
            _buildingsService.AddNewBuilding(serviceModel);

            return Ok();
        }

        [Authorize(Roles = "Owner")]
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
