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
	public class PersonneController : ControllerBase
	{
		public IRepository Repository { get; }
		public PersonneController(IRepository repository)
		{
			Repository = repository;
		}

		//TODO
		/*
		[HttpGet]
		public ActionResult<List<Personne>> GetAll()
		{
			//TODO: return Repository.Get();
		}
		*/
	}
}
