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
                Chambre obj = Repository.GetById(id).Result;
                if (obj == null)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return Ok(obj);
            }
        }

        // POST: api/class/{obj}
        [HttpPost]
        public ActionResult Add(Chambre obj)
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
        public ActionResult Put(Chambre obj)
        {
            Repository.Update(obj);
            return Ok(obj);
        }

        // DELETE: api/class/{obj}
        [HttpDelete]
        public ActionResult Delete(Chambre obj)
        {
            Repository.Delete(obj);
            return Ok(obj);
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
