using BuggyAppAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuggyAppAPI.Data;
using Microsoft.EntityFrameworkCore;

using BuggyAppAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BuggyAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.InvoiceItems)
                .FirstOrDefaultAsync(i => i.InvoiceID == id);

            if (invoice == null)
                return NotFound("No invoice found");

            var result = new
            {
                invoice.InvoiceID,
                invoice.CustomerName,
                items = invoice.InvoiceItems.Select(ii => new
                {
                    name = ii.Name,
                    price = ii.Price
                }).ToList()
            };

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Select(invoice => new
                {
                    invoice.InvoiceID,
                    invoice.CustomerName,
                    items = invoice.InvoiceItems.Select(ii => new
                    {
                        name = ii.Name,
                        price = ii.Price
                    }).ToList()
                })
                .ToListAsync();

            return Ok(invoices);
        }
    }
}
