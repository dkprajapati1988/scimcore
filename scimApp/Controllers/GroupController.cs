using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scimApp.Models;
using scimApp.Services;

namespace scimApp.Controllers
{
    [Produces("application/json")]   
    public class GroupController : Controller
    {
        ApplicationContext db;
        Entity e;

        public GroupController(ApplicationContext _db)
        {
            db = _db;
            e = new Entity(db);
        }

        [HttpPost]
        [Route("api/Group/CreateGroup")]
        public string CreateAccount(Group group)
        {
            string returnValue = "";
            try
            {
                returnValue = e.AddGroup(group);
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }
            return returnValue;
        }
       
        [HttpGet]
        [Route("api/Group/Get")]
        public IEnumerable<Group> Get()
        {
            return e.GetGroups();
        }

        [Route("api/Group/GroupById/{id}")]
        public IEnumerable<Group> Get(int id)
        {
            return e.GetGroupsById(id);
        }

        [HttpPut]
        [Route("api/Group/UpdateGroup")]
        public bool Put(Group group)
        {
           return e.UpdateGroup(group);           
        }
                
        [HttpDelete]
        [Route("api/Group/DeleteGroupByID/{id}")]
        public bool Delete(int id)
        {
            return e.DeleteGroup(id);
        }
    }
}
