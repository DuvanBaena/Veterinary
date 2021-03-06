﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinary.Web.Data.Entities
{
    [Table("TblPet")]
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Image")]       
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string ImageUrl { get; set; }

        //public string Race { get; set; }

        [Display(Name = "Born")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]       
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        //TODO: replace the correct URL for the image
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://TDB.azurewebsites.net{ImageUrl.Substring(1)}";

        [Display(Name = "Born")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BornLocal => Born;
        public int Age { get; set; }

        public string Reproductive { get; set; }

        public string Food { get; set; }

        public string Color { get; set; }
        public string Frequency { get; set; }

        public PetSex PetSex { get; set; }

        public PetType PetType { get; set; }

        public PetRace PetRace { get; set; }

        public Owner Owner { get; set; }   

        public ICollection<History> Histories { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
        
    }

}
