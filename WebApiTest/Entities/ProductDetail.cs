using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Entities
{
    [Table("ProductDetails")]
    public class ProductDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductDetailId { get; set; }
        public string ProductDetailName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float ShellPrice { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual ProductDetail Parent { get; set; }
        public virtual List<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; }
    }
}
