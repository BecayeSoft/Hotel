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
	public class ReservationController : ControllerBase
	{
		public IRepository<Reservation> Repository { get; }
        public IReservationRepository ReservationRepository { get; }

        public ReservationController(IRepository<Reservation> repository, IReservationRepository reservationRepository)
		{
			Repository = repository;
            ReservationRepository = reservationRepository;
		}

        // GET: api/class/
        [HttpGet]
        public ActionResult Get()
        {
            //return Ok(Repository.GetAll().Result);
            return Ok(Repository.GetIncludes(d => d.Chambre, e => e.User, f => f.Chambre.Categorie));
        }

        // GET: api/class/1
        [HttpGet("{id}", Name = "GetReservation")]
        public ActionResult Get(Guid id)
        {
            if (id.Equals(""))
                return BadRequest("L'Id reçu en paramètre est invalide");
            else
            {
                Reservation obj = Repository.GetById(id).Result;
                if (obj == null)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return new ObjectResult(obj);
            }
        }

        // POST: api/class/{obj}
        [HttpPost]
        public ActionResult Add(Reservation obj)
        {
            if (obj == null)
            {
                return BadRequest();
                
            }
            Repository.Add(obj);


            return CreatedAtRoute("GetReservation", new { id = obj.Id }, obj);
        }

        // PUT: api/class/{obj}
        [HttpPut("{id}")]
        public ActionResult Put(Guid id,[FromBody] Reservation obj)
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



        [HttpGet("byUser/{id}", Name = "GetByUser")]
        public ActionResult GetByUser(Guid id)
        {
            if (id.Equals(""))
                return BadRequest("L'Id reçu en paramètre est invalid");
            else
            {
                IEnumerable<Reservation> reservations = ReservationRepository.GetReservationByUserIncludes(id, d => d.Chambre, e => e.User, f => f.Chambre.Categorie);

                if (reservations.Count() == 0)
                    return NotFound("Aucun Objet trouvé avec cet Id");
                else
                    return Ok(reservations);
            }

        }

    }
}
