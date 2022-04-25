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
	public class CategoryController : ControllerBase
	{
		public IRepository<Categorie> Repository { get; }
		public CategoryController(IRepository<Categorie> repository)
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
                Categorie obj = Repository.GetById(id).Result;
                if (obj == null)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return Ok(obj);
            }
        }

        // POST: api/class/{obj}
        [HttpPost]
        public ActionResult Add(Categorie obj)
        {
            try
			{
                Repository.Add(obj);
			}
            catch(Exception e)
			{
            }

            return Ok(obj);
        }

        // PUT: api/class/{obj}
        [HttpPut]
        public ActionResult Put(Categorie obj)
        {
            Repository.Update(obj);
            return Ok(obj);
        }

        // DELETE: api/class/{obj}
        [HttpDelete]
        public ActionResult Delete(Categorie obj)
        {
            Repository.Delete(obj);
            return Ok(obj);
        }
    }
}
