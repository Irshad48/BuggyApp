using BuggyAppAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BuggyAppAPI.Models
{
    public class InvoiceItem
    {
        [Key]
        public int ItemID { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public Invoice Invoice { get; set; } = null!;
    }

}


