using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstracts;
using Data.Contexts;
using Data.Entities;
using Data.Entities.Customer;
using Data.Repositories.Repos;
using Data.Repositories.UoWs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantSaas.Infrastructures.Helpers;

namespace MultiTenantSaas.Controllers
{
    [Route("api/{tenantDomain}/[controller]")]
    [Produces("application/json")]
    public class TestController : Controller
    {
        private readonly ISystemUnitOfWork _sytemRepository;

        public TestController(ISystemUnitOfWork sytemRepository)
        {
            _sytemRepository = sytemRepository;
        }
        // GET api/values
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetMessageViaEachTenant(string tenantDomain)
        {
            var tenant = _sytemRepository.GetSingle(x => x.SubDomain == tenantDomain);
            var _tenanContext = ChangDbConStr.Set(tenant);

            var customer = _tenanContext.Customer.ToList();
            return ApiHelper.Success("Get Data Success", customer);
        }
    }
}