using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Products> Products => Set<Products>();
		public DbSet<Category> Categories => Set<Category>();
		public DbSet<Warehouse> Warehouses => Set<Warehouse>();
		public DbSet<ProductWarehouse> ProductWarehouses => Set<ProductWarehouse>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductWarehouse>()
				.HasKey(pw => new { pw.ProductId, pw.WarehouseId });

			modelBuilder.Entity<ProductWarehouse>()
				.HasOne(pw => pw.Product)
				.WithMany(p => p.ProductWarehouses)
				.HasForeignKey(pw => pw.ProductId);

			modelBuilder.Entity<ProductWarehouse>()
				.HasOne(pw => pw.Warehouse)
				.WithMany(w => w.ProductWarehouses)
				.HasForeignKey(pw => pw.WarehouseId);
		}
	}
}
