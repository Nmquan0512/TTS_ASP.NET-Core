using Ngay1.Infrastructure.Data;
using Ngay1.Application.Products.Interfaces;
using Ngay1.Infrastructure.Repositories;

namespace Ngay1.Application.Products.Services;

public class ProductService : IProductService
{
	private readonly InMemoryProductRepository _repo;

	public ProductService(InMemoryProductRepository repo) => _repo = repo;

	public void AddProduct(SanPham product) => _repo.Add(product);

	public IEnumerable<SanPham> GetAll() => _repo.GetAll();

	public void Disable(Guid id)
	{
		var p = _repo.GetById(id);
		if (p != null) p.KichHoat = false;
	}
}