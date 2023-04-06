using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Entities
{
    [Table("ProductDetailPropertyDetails")]
    public class ProductDetailPropertyDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductDetailPropertyDetailId { get; set; }
        public int ProductDetailId { get; set; }
        public int PropertyDetailId { get; set; }
        public int? ProductId { get; set; }
        public virtual PropertyDetail PropertyDetail { get; set; }
        public virtual Product Product { get; set; }
    }
}
