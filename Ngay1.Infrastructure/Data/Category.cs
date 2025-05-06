using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngay1.Infrastructure.Data
{
	public class Category
	{
		public int Id { get; set; }
		[Required, MaxLength(50)]
		public string Name { get; set; } = null!;
		public ICollection<Products> Products { get; set; } = new List<Products>();

	}
}
