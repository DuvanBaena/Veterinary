using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Veterinary.Web.Data.Entities;

namespace Veterinary.Web.Models
{
    public class PetViewModel : Pet
    {
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Pet Type")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a pet type.")]
        public int PetTypeId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [Display(Name = "Pet Sex")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a pet Sex.")]     
        public int PetSexId {  get; set; }

        [Display(Name = "Pet Race")]
        public int PetRaceId { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }   

        public IEnumerable<SelectListItem> PetTypes { get; set; }

        public IEnumerable<SelectListItem> PetSexs { get; set; }

        public IEnumerable<SelectListItem> PetRaces { get; set; }
       
    }
}
