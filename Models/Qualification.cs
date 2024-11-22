using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading;

namespace Register.Models
{
    public class Qualification
    {
        [Key]
        public int id { get; set; }
        public string nom { get; set; }
        public string code { get; set; }



        [JsonIgnore]
        public virtual IList<User> Users { get; set; }

       [JsonIgnore]
        public virtual IList<Carrier> Carriers { get; set; }
    }
}




