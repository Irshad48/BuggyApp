using System.ComponentModel.DataAnnotations;

namespace BuggyAppAPI.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        public ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
    }
}





