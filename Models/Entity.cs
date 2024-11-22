using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class Entity
    {    

        [Key]
        public int Id { get; set; }
        public int Tax_registration_number { get; set; }
        public string Trad_registration { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public string Exploitation_code { get; set; }

        public string   Adress { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Creation_Date { get; set; }

        public int  RNE { get; set; }

        public string Social_security_sheme { get; set; }


    }
}
