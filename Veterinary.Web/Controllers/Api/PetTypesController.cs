using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PetTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public PetTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PetTypes
        [HttpGet]
        public IEnumerable<PetType> GetPetTypes()
        {
            return _context.PetTypes.OrderBy(pt => pt.Name);
        }


    }
}