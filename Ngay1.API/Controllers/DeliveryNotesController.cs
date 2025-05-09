using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ngay1.Infrastructure.Data;

namespace Ngay1.API.Controllers
{
	[ApiController]
	[Route("api/v1/delivery-notes")]
	public class DeliveryNotesController : ControllerBase
	{
		private readonly AppDbContext _context;
		public DeliveryNotesController(AppDbContext context) => _context = context;

		[HttpGet]
		public IActionResult GetAll() => Ok(_context.DeliveryNotes.Include(x => x.Warehouse));

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var note = _context.DeliveryNotes.Include(x => x.Histories).FirstOrDefault(x => x.Id == id);
			return note == null ? NotFound() : Ok(note);
		}

		[HttpPost]
		public IActionResult Create(DeliveryNote note)
		{
			_context.DeliveryNotes.Add(note);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
		}

		[HttpPut("{id}/status")]
		public IActionResult UpdateStatus(int id, [FromBody] string status)
		{
			var note = _context.DeliveryNotes.Find(id);
			if (note == null) return NotFound();
			note.Status = status;
			_context.SaveChanges();
			return NoContent();
		}

		[HttpGet("filter")]
		public IActionResult Filter(DateTime? date, string? status)
		{
			var query = _context.DeliveryNotes.AsQueryable();
			if (date.HasValue) query = query.Where(d => d.ExportDate.Date == date.Value.Date);
			if (!string.IsNullOrEmpty(status)) query = query.Where(d => d.Status == status);
			return Ok(query);
		}
	}
}
