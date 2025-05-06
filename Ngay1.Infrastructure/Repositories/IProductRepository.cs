using Ngay1.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Repositories
{
	public interface IProductRepository
	{
		Task<IEnumerable<Products>> GetAllAsync();
		Task<Products?> GetByIdAsync(int id);
		Task<IEnumerable<Products>> SearchAsync(string keyword);
		Task<IEnumerable<Products>> GetPagedAsync(int page, int pageSize);
		Task<IEnumerable<Products>> GetWithCategoryAsync();
	}
}
