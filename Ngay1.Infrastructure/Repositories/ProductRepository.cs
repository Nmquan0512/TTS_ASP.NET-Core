using Microsoft.EntityFrameworkCore;
using Ngay1.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;

		public ProductRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Products>> GetAllAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Products?> GetByIdAsync(int id)
		{
			return await _context.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<Products>> SearchAsync(string keyword)
		{
			return await _context.Products
				.Where(p => p.Name.Contains(keyword))
				.ToListAsync();
		}

		public async Task<IEnumerable<Products>> GetPagedAsync(int page, int pageSize)
		{
			return await _context.Products
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<IEnumerable<Products>> GetWithCategoryAsync()
		{
			return await _context.Products
				.Include(p => p.Category)
				.Include(p => p.ProductWarehouses)
					.ThenInclude(pw => pw.Warehouse)
				.ToListAsync();
		}
	}
}
