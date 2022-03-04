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
	public class CategoryController : ControllerBase
	{
		public IRepository<Categorie> Repository { get; }
		public CategoryController(IRepository<Categorie> repository)
		{
			Repository = repository;
		}

		//TODO
		/*
		[HttpGet]
		public ActionResult<List<Categorie>> GetAll()
		{
			//TODO: return Repository.Get();
		}
		*/
	}
}
