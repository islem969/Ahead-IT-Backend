using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Register.Models
{
    public class Carrier
    {
        [Key]
        public int Id { get; set; }
        public int Salary { get; set; }
        public int Bban { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int RIB { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// //////////////////Relation/////////////////
        /// </summary>
        [Required(ErrorMessage = "The UserId field is required.")]
        public int? UserId { get; set; }


        public virtual Qualification Qualification { get; set; }
        public int? QualificationId { get; set; }

        public virtual Civil_Status Civil_Status { get; set; }
        public int? Civil_StatusId { get; set; }


        public virtual User User { get; set; }
    }
}
