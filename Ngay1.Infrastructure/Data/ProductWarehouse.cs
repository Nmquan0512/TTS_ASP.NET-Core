using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class ProductWarehouse
	{
		public int ProductId { get; set; }
		public Products Product { get; set; } = null!;

		public int WarehouseId { get; set; }
		public Warehouse Warehouse { get; set; } = null!;

		public int Quantity { get; set; }
	}
	}
