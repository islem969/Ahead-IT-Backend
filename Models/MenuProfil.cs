using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class MenuProfil
    {
        [Key]
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; } // Marked as virtual

        [Key]
        public int ProfilId { get; set; }
        public virtual Profil Profil { get; set; } // Marked as virtual
    }
}
