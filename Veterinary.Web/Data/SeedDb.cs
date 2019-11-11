using System;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Helpers;
using Veterinary.Web.Models.Data;

namespace Veterinary.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _dataContext = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            var manager = await CheckUserAsync("98761214", "Nelson Andrés", "Patino Puerta", "mercamascotas@gmail.com", "3192650744", "Carrera 76 #20A 55", "Admin");
            var customer = await CheckUserAsync("1017143113", "Duvan José", "Baena Puerta", "djbpuerta@hotmail.com", "3122988419", "Calle Luna Calle Sol", "Customer");
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
            await CheckOwnerAsync(customer);
            await CheckManagerAsync(manager);
            await CheckPetSexAsync();
            await CheckPetRaceAsync();
            await CheckPetsAsync();            
            //await CheckAgendasAsync();
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);

                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

            }

            return user;
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_dataContext.PetTypes.Any())
            {
                _dataContext.PetTypes.Add(new PetType { Name = "Perro" });
                _dataContext.PetTypes.Add(new PetType { Name = "Gato" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckServiceTypesAsync()
        {
            if (!_dataContext.ServiceTypes.Any())
            {
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Consulta" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Urgencia" });
                _dataContext.ServiceTypes.Add(new ServiceType { Name = "Vacunación" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetsAsync()
        {
            if (!_dataContext.Pets.Any())
            {
                var owner = _dataContext.Owners.FirstOrDefault();
                var petType = _dataContext.PetTypes.FirstOrDefault();
                var petSex = _dataContext.PetSexes.FirstOrDefault();
                var petRace = _dataContext.PetRaces.FirstOrDefault();
                AddPet("Jacko", owner, petType, petSex, petRace);
                AddPet("Sasi", owner, petType, petSex, petRace);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddPet(string name, Owner owner, PetType petType, PetSex petSex, PetRace petRace)
        {
            _dataContext.Pets.Add(new Pet
            {
                Born = DateTime.Now.AddYears(-2),
                Name = name,
                Owner = owner,
                PetType = petType,
                PetRace = petRace,
                PetSex = petSex,

            });
        }


        private async Task CheckOwnerAsync(User user)
        {
            if (!_dataContext.Owners.Any())
            {
                _dataContext.Owners.Add(new Owner { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }


        private async Task CheckManagerAsync(User user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager { User = user });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetSexAsync()
        {
            if (!_dataContext.PetSexes.Any())
            {
                _dataContext.PetSexes.Add(new PetSex { Name = "Macho" });
                _dataContext.PetSexes.Add(new PetSex { Name = "Hembra" });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckPetRaceAsync()
        {
            if (!_dataContext.PetRaces.Any())
            {
                _dataContext.PetRaces.Add(new PetRace { Name = "Pitbull " });
                _dataContext.PetRaces.Add(new PetRace { Name = "Bulldog americano" });
                await _dataContext.SaveChangesAsync();
            }
        }


        private async Task CheckAgendasAsync()
        {
            if (!_dataContext.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _dataContext.Agendas.Add(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvailable = true
                            });

                            initialDate = initialDate.AddMinutes(30);
                        }

                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }
            }

            await _dataContext.SaveChangesAsync();
        }
    }

}
