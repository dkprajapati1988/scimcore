using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroupApp.IRepositories;
using GroupApp.Repositories;
using GroupApp.DomainModel;
namespace GroupApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Group")]
    public class GroupController : Controller
    {        
        IGroupRepository repository = new GroupRepository();
        // GET: api/Group
        [HttpGet]
        public IEnumerable<Group> Get()
        {           
           return  repository.GetAll();
        }

        // GET: api/Group/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Group
        [HttpPost]
        public Group Post(Group group)
        {
            return repository.Add(group);
        }
        
        // PUT: api/Group/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
