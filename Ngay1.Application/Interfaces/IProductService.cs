using Ngay1.Infrastructure.Data;

namespace Ngay1.Application.Products.Interfaces;

public interface IProductService
{
	void AddProduct(SanPham product);
	IEnumerable<SanPham> GetAll();
	void Disable(Guid id);
}