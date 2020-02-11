using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NwbaExample.Models;
using NwbaExampleWithLogin.Models.DataManager;

namespace NwbaExampleWithLogin.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly CustomerManager _customerRepo;
        public UpdateController(CustomerManager customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet("{id}")]
        public void Update(int id, string name, string tfn, string address, string city, string state, string postcode, string phone)
        {
            _customerRepo.Update(id, name, tfn, address, city, state, postcode, phone);
        }
    }
}