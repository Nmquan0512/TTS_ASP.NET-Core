using Ngay1.Infrastructure.Data;

namespace Ngay1.Infrastructure.Repositories;

public class InMemoryProductRepository
{
	private readonly List<SanPham> _products = new();

	public void Add(SanPham product) => _products.Add(product);

	public IEnumerable<SanPham> GetAll() => _products;

	public SanPham? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);
}