using Register.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Register.Models
{
    public class Profil
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Code { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        [JsonIgnore]
        public virtual IList<User> Users { get; set; }

        [JsonIgnore]
        public virtual IList<MenuProfil> MenuProfils { get; set; }










    }
}
