using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class Warehouse
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Location { get; set; } = null!;
		public ICollection<ProductWarehouse> ProductWarehouses { get; set; } = new List<ProductWarehouse>();
	}

	
}
