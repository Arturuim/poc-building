
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Repositories;
using Domain.Interfaces;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IBuildingsRepository _buildingsRepo;

        public ValuesController(IBuildingsRepository buildingsRepo)
        {
            _buildingsRepo = buildingsRepo;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var test = this._buildingsRepo.GetBuildings(new Filter {Page = 0, PageSize = 2});
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
