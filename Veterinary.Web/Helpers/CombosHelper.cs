using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            var list = _dataContext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Pet Type...]",
                Value = "0",
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboPetSex()
        {        
            var list = _dataContext.PetSexes.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = $"{p.Id}"
            })
                .OrderBy(p => p.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Pet Sex...]",
                Value = "0",
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboPetRace()
        {
            var list = _dataContext.PetRaces.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = $"{p.Id}"
            })
                .OrderBy(p => p.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a Race...]",
                Value = "0",
            });

            return list;

        }


        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContext.ServiceTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a service Type...]",
                Value = "0",
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboOwners()
        {
            var list = _dataContext.Owners.Select(p => new SelectListItem
            {
                Text = p.User.FullNameWithDocument,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select an owner...)",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboPets(int ownerId)
        {
            var list = _dataContext.Pets.Where(p => p.Owner.Id == ownerId).Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a pet...)",
                Value = "0"
            });

            return list;
        }

   
    }
}
