using System.Collections.Generic;
using lab5.Data.Models;

namespace lab5.Data.IRepository
{
    public interface ICityRepository: IBaseRepository<City>
    {
        IEnumerable<City> GetCitiesByCountry(int countryId);
    }
}
