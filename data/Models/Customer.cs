using System.ComponentModel.DataAnnotations.Schema;

namespace JsonReports.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}