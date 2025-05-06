using Ngay1.Infrastructure.Data;

public static class SeedData
{
	public static void Initialize(AppDbContext context)
	{
		var categories = new List<Category>
{
	new Category { Name = "Thiết bị ngoại vi" },
	new Category { Name = "Âm thanh" }
};
		context.Categories.AddRange(categories);
		context.SaveChanges();

		var warehouses = new List<Warehouse>
{
	new Warehouse { Name = "Kho Hà Nội", Location = "Hà Nội" },
	new Warehouse { Name = "Kho TP. HCM", Location = "TP. Hồ Chí Minh" }
};
		context.Warehouses.AddRange(warehouses);
		context.SaveChanges();

		var products = new List<Products>
{
	new Products { Name = "Chuột không dây", CategoryId = categories[0].Id, Price = 250, Status = "Active" },
	new Products { Name = "Bàn phím cơ", CategoryId = categories[0].Id, Price = 900, Status = "Inactive" },
	new Products { Name = "Tai nghe Bluetooth", CategoryId = categories[1].Id, Price = 1200, Status = "Active" }
};
		context.Products.AddRange(products);
		context.SaveChanges();
	}
	}