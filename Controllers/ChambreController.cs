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
    public class ChambreController : ControllerBase
    {
        public IRepository<Chambre> Repository { get; }
		public IChambreCategory ChambreCategoryRepository { get; }

		public ChambreController(IRepository<Chambre> repository, IChambreCategory chambreCategory)
        {
            Repository = repository;
			ChambreCategoryRepository = chambreCategory;
		}
        // GET: api/class/
        [HttpGet]
        public ActionResult Get()
        {
            //return Ok(Repository.GetAll().Result);
            return Ok(Repository.GetIncludes(d => d.Categorie));
        }

        // GET: api/class/1
        [HttpGet("{id}", Name = "GetChambre")]
        public ActionResult Get(Guid id)
        {
            if (id.Equals(""))
                return BadRequest("L'Id reçu en paramètre est invalide");
            else
            {
                Chambre obj = Repository.GetById(id).Result;
                if (obj == null)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return new ObjectResult(obj);
            }
        }

        // POST: api/class/{obj}
        [HttpPost]
        public ActionResult Add(Chambre obj)
        {
            if (obj == null)
            {
                return BadRequest();

            }
            Repository.Add(obj);

            return CreatedAtRoute("GetChambre", new { id = obj.Id }, obj);
        }

        // PUT: api/class/{obj}
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Chambre obj)
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

        // GET: api/
        [HttpGet("byCategorie/{id}", Name = "GetByCategory")]
        public ActionResult GetByCategory(Guid id)
        {
            if (id.Equals(""))
                return BadRequest("L'Id reçu en paramètre est invalid");
            else
            {
                IEnumerable<Chambre> chambres = ChambreCategoryRepository.GetChambresByCategory(id).Result;

                if (chambres == null)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return Ok(chambres); 
            }
        }
    }
}
