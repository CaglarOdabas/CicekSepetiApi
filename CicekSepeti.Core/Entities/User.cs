using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CicekSepeti.Core.Entities
{
    public class User
    {
        public User()
        {
            Basket = new HashSet<Basket>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        [InverseProperty("User")]
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
