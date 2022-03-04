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
	public class LitController : ControllerBase
	{
		public IRepository<Lit> Repository { get; }
		public LitController(IRepository<Lit> repository)
		{
			Repository = repository;
		}

		[HttpGet]
		public ActionResult<List<Lit>> GetAll()
		{
			return Repository.GetAll();
		}
	}
}
