using System.Collections.Generic;
using System.Linq;
using lab5.Data.IRepository;
using lab5.Data.Models;

namespace lab5.Data.Repository
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(lab8Context repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<City> GetCitiesByCountry(int countryId)
        {
            return this.RepositoryContext.Cities.Where(x => x.CountryId == countryId);
        }
    }
}
