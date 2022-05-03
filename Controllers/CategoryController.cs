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
        [HttpGet("{id}", Name = "GetCategorie")]
        public ActionResult Get(Guid id)
        {
            if (id.Equals(""))
                return BadRequest("L'Id reçu en paramètre est invalide");
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
            if (obj == null)
            {
                return BadRequest();
                
			}
            Repository.Add(obj);

            return CreatedAtRoute("GetCategorie", new { id = obj.Id }, obj);
        }

        // PUT: api/class/{obj}
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Categorie obj)
        {
            //Repository.Update(obj);
            //return Ok(obj);

            if (obj == null || obj.Id != id)
            {
                return BadRequest();
            }

            var temp = Repository.GetById(id).Result;
            if (temp == null)
            {
                return NotFound();
            }

            Repository.Update(obj);
            //return Ok(Repository.Update(obj).IsCompletedSuccessfully);
            return Ok(obj);
            //return new NoContentResult();
        }

        // DELETE: api/class/{obj}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            //Repository.Delete(obj);
            //return Ok(obj);
            var obj = Repository.GetById(id).Result;
            if (obj == null)
            {
                return NotFound();
            }

            Repository.Delete(obj);
            return new NoContentResult();
        }
    }
}
