using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Core.Entities
{
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Piece { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Basket")]
        public virtual Product Product { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Basket")]
        public virtual User User { get; set; }
    }
}
