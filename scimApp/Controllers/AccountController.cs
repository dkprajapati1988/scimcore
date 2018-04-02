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
    public class AccountController : Controller
    {
        ApplicationContext db;
        Entity e;

        public AccountController(ApplicationContext _db)
        {
            db = _db;
            e = new Entity(db);
        }

        [HttpPost]
        [Route("api/Account/CreateAccount")]
        public string CreateAccount(Account account)
        {
            string returnValue = "";
            try
            {             
                returnValue = e.AddAccount(account);
            }
            catch (Exception ex)
            {
                returnValue = ex.Message;
            }
            return returnValue;
        }

        [HttpGet]
        [Route("api/Account/Get")]
        public IEnumerable<Account> Get()
        {
            return e.GetAccount();
        }

        [Route("api/Account/AccountById/{id}")]
        public IEnumerable<Account> Get(int id)
        {
            return e.GetAccountById(id);
        }

        [HttpPut]
        [Route("api/Account/UpdateAccount")]
        public bool Put(Account account)
        {
            return e.UpdateAccount(account);
        }

        [HttpDelete]
        [Route("api/Account/DeleteAccountByID/{id}")]
        public bool Delete(int id)
        {
            return e.DeleteAccount(id);
        }
    }
}
