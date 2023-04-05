using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest.Entities
{
    [Table("Properties")]
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyId { get; set; }
        public int ProductId { get; set; }
        public string PropertyName { get; set; }
        public int PropertySort { get; set; }
        public virtual Product Products { set; get; }
        public virtual List<PropertyDetail> PropertyDetails { get; set; }
    }
}
