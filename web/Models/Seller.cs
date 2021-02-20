using System.ComponentModel.DataAnnotations.Schema;

namespace JsonReports.Web.Models
{
    public class Seller
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}