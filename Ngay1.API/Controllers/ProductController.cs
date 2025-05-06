using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ngay1.Infrastructure.Repositories;

namespace Ngay1.API.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _repo;

		public ProductController(IProductRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var data = await _repo.GetAllAsync();
			return Ok(data);
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search(string keyword)
		{
			var data = await _repo.SearchAsync(keyword);
			return Ok(data);
		}

		[HttpGet("paged")]
		public async Task<IActionResult> GetPaged(int page = 1, int pageSize = 10)
		{
			var data = await _repo.GetPagedAsync(page, pageSize);
			return Ok(data);
		}

		[HttpGet("with-category")]
		public async Task<IActionResult> GetWithCategory()
		{
			var data = await _repo.GetWithCategoryAsync();
			return Ok(data);
		}
	}
}
