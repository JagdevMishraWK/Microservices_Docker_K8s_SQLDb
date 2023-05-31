
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.API.Models
{
    [Table("product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("product_id")]
        public int Id { get; set; }
        [Column("product_name")]
        public string Name { get; set; }
        [Column("product_category")]
        public string Category { get; set; }
        [Column("product_desc")]
        public string Description { get; set; }
	}
}
