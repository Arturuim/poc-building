
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Repositories;
using Domain.Interfaces;
using Services.Interfaces;
using Services.Interfaces.DTO;
using AutoMapper;

namespace WebApplication1.Controllers
{
    public class BuildingsController : ApiController
    {
        private readonly IBuildingsService _buildingsService;

        public BuildingsController(IBuildingsService buildingsService)
        {
            this._buildingsService = buildingsService;
        }

        // GET api/values
        public IEnumerable<BuildingInfoDTO> Get([FromUri]Filter filter)
        {
            var test = this._buildingsService.GetByFilter(filter);
            return test;
        }

        // GET api/values/5
        public BuildingInfoDTO Get(string id)
        {
            return this._buildingsService.GetById(id);
        }

        [HttpGet]
        public BuildingInfoDTO GetByAdrress(string address)
        {
            return this._buildingsService.GetByAddress(address);
        }

        // POST api/values
        public void Post([FromBody]API.DTO.BuildingCreateDTO newBuilding)
        {
            this._buildingsService.AddNewBuilding(Mapper.Map<BuildingCreateDto>(newBuilding));
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
