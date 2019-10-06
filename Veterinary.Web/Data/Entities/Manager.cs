using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Web.Data.Entities
{
    [Table("TblManager")]
    public class Manager
    {
        public int Id { get; set; }

        public User User { get; set; }
    }

}
