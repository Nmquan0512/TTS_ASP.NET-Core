using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class DeliveryNote
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public int ?WarehouseId { get; set; }
		public DateTime ExportDate { get; set; }
		public string Status { get; set; }

		public Warehouse? Warehouse { get; set; }
		public ICollection<DeliveryHistory>? Histories { get; set; }
	}
}
