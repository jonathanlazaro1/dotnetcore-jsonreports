using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonReports.Web.Models
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int SellerId { get; set; }

        public virtual Seller Seller { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Range(0.01, int.MaxValue)]
        public decimal Amount { get; set; }
    }
}