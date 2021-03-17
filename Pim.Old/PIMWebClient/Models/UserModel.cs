using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIMWebClient.Models
{
    [Table("User")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public int Attempts { get; set; }
        public int ObservatoryId { get; set; }
        public virtual ObservatoryModel Observatory { get; set; }
    }
}
