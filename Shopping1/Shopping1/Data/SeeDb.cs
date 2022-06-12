using Shopping1.Data.Entities;
using Shopping1.Enums;
using Shopping1.Helpers;

namespace Shopping1.Data
{
    public class SeeDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeeDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1112624205", "Cristian", "Montoya", "cristianmontoya0075@gmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);
            await CheckUserAsync("1112624206", "Pilar", "Cordoba", "cristianmontoya@gmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.User);


        }

        private async Task<User> CheckUserAsync(
       string document,
       string firstName,
       string lastName,
       string email,
       string phone,
       string address,
       UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
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
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "1234567");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        public async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            Name="Antioquia",
                            Cities= new List<City>()
                            {
                                new City { Name = "Medellín"},
                                new City { Name = "Envigado"},
                                new City { Name = "Bello"},
                                new City { Name = "Rionegro"},
                                new City { Name = "Itaguí"},

                            }
                        },
                           new State
                        {
                            Name="Bogotá",
                            Cities= new List<City>()
                            {
                                new City { Name = "Bosa"},
                                new City { Name = "Chapinero"},
                                new City { Name = "Useme"},
                                new City { Name = "Santa fé"},
                                new City { Name = "Usaquen"},

                            }

                        },
                              new State
                        {
                            Name="Valle del Cauca",
                            Cities= new List<City>()
                            {
                                new City { Name = "Roldanillo"},
                                new City { Name = "Cartago"},
                                new City { Name = "Anserma Nuevo"},
                                new City { Name = "Obando"},
                                new City { Name = "La Victoria"},
                                new City { Name = "La Unión"},
                                new City { Name = "Versalles"},
                                new City { Name = "El Dovio"},
                                new City { Name = "Bolivar"},
                                new City { Name = "Tulua"},
                                new City { Name = "Buga"},
                                new City { Name = "BugalaGrande"},
                                new City { Name = "Sevilla"},
                                new City { Name = "Palmira"},
                                new City { Name = "Calí"},
                                new City { Name = "Yumbo"},
                                new City { Name = "Yotoco"},

                            }

                        },
                    }
                });

                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>() {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                            }
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "San Antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El Paso" },
                            }
                        },
                    }
                });

            }

            await _context.SaveChangesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Tecnología" });
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Calzado" });
                _context.Categories.Add(new Category { Name = "Belleza" });
                _context.Categories.Add(new Category { Name = "Nutrición" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
