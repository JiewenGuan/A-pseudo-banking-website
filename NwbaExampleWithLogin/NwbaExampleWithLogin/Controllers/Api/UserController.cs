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
    public class UserController : ControllerBase
    {
        private readonly CustomerManager _customerRepo;
        public UserController(CustomerManager customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerRepo.GetDto(_customerRepo.GetAll());
        }

        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _customerRepo.GetDto(_customerRepo.Get(id));
        }

        [HttpGet("[action]/{id}")]
        public int Lock(int id)
        {
            return _customerRepo.Lock(id);
        }
        [HttpGet("[action]/{id}")]
        public int UnLock(int id)
        {
            return _customerRepo.UnLock(id);
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            _customerRepo.Delete(id);
            return id;
        }
        
        
    }
}