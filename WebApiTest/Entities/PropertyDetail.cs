using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Entities
{
    [Table("PropertyDetails")]
    public class PropertyDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyDetailId { get; set; }
        public int PropertyId { get; set; }
        public string PropertyDetailCode { get; set; }
        public string PropertyDetailDetail { get; set; }
        public virtual Property Property { get; set; }
        public virtual List<ProductDetailPropertyDetail> ProductDetailPropertyDetails { get; set; }
    }
}
