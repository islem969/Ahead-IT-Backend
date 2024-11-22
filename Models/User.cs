using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;

namespace Register.Models
{
    public class User

    {
        [Key]

        public int Id { get; set; }


        public string Username { get; set; }

     
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Email { get; set; }

        public string RegistrationNumber { get; set; }

        public string PhoneNumber { get; set; }

       
        public string Password { get; set; }

      
        public string Cin { get; set; }

     
        public string Cnss { get; set; }

        
        public string Sex { get; set; }

        
        public string Bban { get; set; }

        public int Leavebalance { get; set; }

        
        public int Numberofchildren { get; set; }

        //public bool Householder { get; set; }


       // public DateTime UpdatedAt { get; set; }

      
        //public DateTime CreatedAt { get; set; }

       
        public DateTime birthdate { get; set; }

       
        public DateTime Hiringdate { get; set; }

        
        public DateTime Leavebalancedate { get; set; }

       
        public float Salary { get; set; }
         public String Role { get; set; }

        public String Token { get; set; }

      
       public virtual Qualification Qualification { get; set; }
       public int? QualificationId { get; set; }

        public virtual Civil_Status Civil_Status { get; set; }
        public int? Civil_StatusId { get; set; }

        [JsonIgnore]
        public virtual IList<Carrier> Carrieres { get; set; }

        public virtual Profil Profil { get; set; }
        public int? ProfilId { get; set; }


    }
}
