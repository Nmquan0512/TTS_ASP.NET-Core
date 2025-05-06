using Microsoft.AspNetCore.Mvc;
using Ngay1.Application.Products.Interfaces;
using Ngay1.Infrastructure.Data;

namespace Ngay1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private readonly IProductService _service;

	public ProductsController(IProductService service) => _service = service;

	[HttpPost("dienThoai")]
	public IActionResult ThemDienThoai(string name, double weight)
	{
		var product = new DienThoai { Ten = name, KhoiLuong = weight };
		_service.AddProduct(product);
		return Ok(product);
	}

	[HttpPost("phanMem")]
	public IActionResult ThemPhanMem(string name, double size)
	{
		var product = new PhanMem { Ten = name, DungLuongMB = size };
		_service.AddProduct(product);
		return Ok(product);
	}

	[HttpGet]
	public IActionResult GetAll() => Ok(_service.GetAll());

	[HttpPut("{id}/voHieuHoa")]
	public IActionResult Disable(Guid id)
	{
		_service.Disable(id);
		return NoContent();
	}
}