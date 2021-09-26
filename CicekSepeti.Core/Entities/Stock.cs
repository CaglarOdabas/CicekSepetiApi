using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Core.Entities
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Stock")]
        public virtual Product Product { get; set; }
    }
}
