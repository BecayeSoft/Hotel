using Hotel.Models;
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
		public ReservationController(IRepository<Reservation> repository)
		{
			Repository = repository;
		}

		[HttpGet]
		public ActionResult<List<Reservation>> GetAll()
		{
			return Repository.GetAll();
		}


	}
}
