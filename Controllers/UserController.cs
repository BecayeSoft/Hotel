using Hotel.Entities;
using Hotel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public IRepository<User> Repository { get; }
		public UserController(IRepository<User> repository)
		{
			Repository = repository;
		}

        // GET: api/class/
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Repository.GetAll().Result);
        }

        // GET: api/class/1
        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            if (id.Equals(""))
                return BadRequest("L'Id reçu en paramètre est invalid");
            else
            {
                User obj = Repository.GetById(id).Result;
                if (obj == null)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return Ok(obj);
            }
        }

        // POST: api/class/{obj}
        [HttpPost]
        public ActionResult Add(User obj)
        {
            try
            {
                Repository.Add(obj);
            }
            catch (Exception e)
            {
            }

            return Ok(obj);
        }

        // PUT: api/class/{obj}
        [HttpPut]
        public ActionResult Put(User obj)
        {
            Repository.Update(obj);
            return Ok(obj);
        }

        // DELETE: api/class/{obj}
        [HttpDelete]
        public ActionResult Delete(User obj)
        {
            Repository.Delete(obj);
            return Ok(obj);
        }
    }
}
