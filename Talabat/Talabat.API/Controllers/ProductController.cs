using Microsoft.AspNetCore.Http;
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
		public async Task<IActionResult> Index()
		{
			return await _genaricRepository.GetAllAsync();
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return await _genaricRepository.GetByIdAsync(id);
		}
    }
}
