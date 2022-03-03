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
		public IRepository Repository { get; }
		public ChambreController(IRepository repository)
		{
			Repository = repository;
		}

		//TODO
		/*
		[HttpGet]
		public ActionResult<List<Chambre>> GetAll()
		{
			//TODO: return Repository.Get();
		}
		*/
	}
}
