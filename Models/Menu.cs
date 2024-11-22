using Register.Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Register.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public string Class {  get; set; }
         public DateTime CreatedAt { get; set; }

         public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual IList<MenuProfil> MenuProfils { get; set; }
        
    }
}
