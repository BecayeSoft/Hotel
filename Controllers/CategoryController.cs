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

		// GET: api/<CategoryController>
		[HttpGet]
		public ActionResult<List<Categorie>> GetAll()
		{
			return Repository.GetAll();
		}

		
		// GET api/<CategoryController>/5
		[HttpGet("{id}")]
		public ActionResult<Categorie> GetById(string id)
		{
			return Repository.GetById(id);
		}

		// POST api/<CategoryController>
		[HttpPost]
		public void Add(Categorie categorie)
		{
			Repository.Add(categorie);
		}

		// PUT api/<CategoryController>/5
		[HttpPut("{id}")]
		public void Update(Categorie categorie)
		{
			Repository.Update(categorie);
		}

		// DELETE api/<CategoryController>/5
		[HttpDelete("{id}")]
		public void Delete(Categorie categorie)
		{
			Repository.Delete(categorie);
		}
	}
}
