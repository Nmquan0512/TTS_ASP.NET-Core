using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class Products
	{
		public int Id { get; set; }
		[Required, MaxLength(100)]
		public string Name { get; set; } = null!;
		public int CategoryId { get; set; }
		public Category Category { get; set; } = null!;
		public decimal Price { get; set; }
		public string Status { get; set; } = "Active";

		public ICollection<ProductWarehouse> ProductWarehouses { get; set; } = new List<ProductWarehouse>();
	}

	
}
