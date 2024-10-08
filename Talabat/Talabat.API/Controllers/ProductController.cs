﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Interfaces;
using Talabat.Core.Models;

namespace Talabat.API.Controllers
{
	[Route("Talabat/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IGenaricRepository<Product> _genaricRepository;

		public ProductController(IGenaricRepository<Product> genaricRepository)
        {
			_genaricRepository = genaricRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
		{
			var product = await _genaricRepository.GetAllAsync();
			if (product == null)
			{
				return NotFound(new {message="Not Found",CodeStatus=404});
			}
			return Ok(product);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			return Ok(await _genaricRepository.GetByIdAsync(id));
		}
    }
}
