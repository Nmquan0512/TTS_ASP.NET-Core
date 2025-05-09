using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ngay1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ngay1.API.Controllers
{
	[ApiController]
	[Route("api/v1/delivery-notes/{deliveryNoteId}/history")]
	public class DeliveryHistoryController : ControllerBase
	{
		private readonly AppDbContext _context;
		public DeliveryHistoryController(AppDbContext context) => _context = context;

		[HttpGet]
		public IActionResult GetHistories(int deliveryNoteId)
		{
			var history = _context.DeliveryHistory
				.Where(h => h.DeliveryNoteId == deliveryNoteId)
				.OrderBy(h => h.Timestamp)
				.ToList();

			if (!history.Any()) return NotFound($"Không tìm thấy lịch sử cho phiếu xuất kho Id={deliveryNoteId}.");
			return Ok(history);
		}

		[HttpPost]
		public IActionResult AddHistory(int deliveryNoteId, [FromBody] DeliveryHistory history)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var deliveryNote = _context.DeliveryNotes.Find(deliveryNoteId);
			if (deliveryNote == null)
				return NotFound($"Không tìm thấy phiếu xuất kho Id={deliveryNoteId}.");

			history.DeliveryNoteId = deliveryNoteId;
			_context.DeliveryHistory.Add(history);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetHistories), new { deliveryNoteId }, history);
		}
	}
}