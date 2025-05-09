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



		var deliveryNotes = new List<DeliveryNote>
{
	new DeliveryNote { Code = "PXK-2024-001", WarehouseId = 1, ExportDate = new DateTime(2024,12,20), Status = "Delivered" },
	new DeliveryNote { Code = "PXK-2024-002", WarehouseId = 2, ExportDate = new DateTime(2024,12,22), Status = "In Transit" },
};
		context.DeliveryNotes.AddRange(deliveryNotes);
		context.SaveChanges();

		// Sau đó lấy lại Id
		var savedNotes = context.DeliveryNotes.ToList();




		var deliveryHistories = new List<DeliveryHistory>
{
	new DeliveryHistory { DeliveryNoteId = savedNotes[0].Id, Status = "Đang xử lý", Timestamp = new DateTime(2024, 12, 20, 8, 0, 0) },
	new DeliveryHistory { DeliveryNoteId = savedNotes[1].Id, Status = "Đã giao thành công", Timestamp = new DateTime(2024, 12, 21, 15, 30, 0) },
	new DeliveryHistory { DeliveryNoteId = savedNotes[1].Id, Status = "Đang xử lý", Timestamp = new DateTime(2024, 12, 22, 9, 0, 0) }
};

		context.DeliveryHistory.AddRange(deliveryHistories);
		context.SaveChanges();
	}
}



	