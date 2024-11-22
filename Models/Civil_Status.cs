using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Register.Models
{
    public class Civil_Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        [JsonIgnore]
        public virtual IList<User> Users { get; set; }
        [JsonIgnore]
        public virtual IList<Carrier> Carriers { get; set; }
    }
}
