using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class DeliveryHistory
	{
		public int Id { get; set; }
		public int DeliveryNoteId { get; set; }
		public string Status { get; set; }
		public DateTime Timestamp { get; set; }

		[JsonIgnore]
		public DeliveryNote? DeliveryNote { get; set; }
	}
}
