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
    public class GroupAccountController : Controller
    {
        ApplicationContext db;
        Entity e;

        public GroupAccountController(ApplicationContext _db)
        {
            db = _db;
            e = new Entity(db);
        }

        [HttpPost]
        [Route("api/GroupAccount/CreateGroupAccount")]
        public string CreateAccount(GroupAccount groupaccount)
        {
            string returnValue = "";
            try
            {
                returnValue = e.AddGroupAccount(groupaccount);
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }
            return returnValue;
        }

        [HttpGet]
        [Route("api/GroupAccount/Get")]
        public IEnumerable<GroupAccount> Get()
        {
            return e.GetGroupAccount();
        }

        [Route("api/GroupAccount/GroupAccountById/{id}")]
        public IEnumerable<GroupAccount> Get(int id)
        {
            return e.GetGroupAccountById(id);
        }

        [HttpPut]
        [Route("api/GroupAccount/UpdateGroupAccount")]
        public bool Put(GroupAccount groupaccount)
        {
            return e.UpdateGroupAccount(groupaccount);
        }

        [HttpDelete]
        [Route("api/GroupAccount/DeleteGroupAccountByID/{id}")]
        public bool Delete(int id)
        {
            return e.DeleteGroupAccount(id);
        }
    }
}
