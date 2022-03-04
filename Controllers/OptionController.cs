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
	public class OptionController : ControllerBase
	{
		public IRepository<Option> Repository { get; }
		public OptionController(IRepository<Option> repository)
		{
			Repository = repository;
		}

		//TODO
		/*
		[HttpGet]
		public ActionResult<List<Option>> GetAll()
		{
			//TODO: return Repository.Get();
		}
		*/
	}
}
