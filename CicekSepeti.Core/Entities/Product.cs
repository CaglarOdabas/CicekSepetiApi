using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CicekSepeti.Core.Entities
{
    public class Product
    {
        public Product()
        {
            Basket = new HashSet<Basket>();
            Stock = new HashSet<Stock>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        [InverseProperty("Product")]
        public virtual ICollection<Basket> Basket { get; set; }
        [JsonIgnore]
        [InverseProperty("Product")]
        public virtual ICollection<Stock> Stock { get; set; }
    }
}
