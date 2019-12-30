using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Web.Data.Entities
{
    [Table("TblOwner")]
    public class Owner
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
     
    }

}
