using lab5.Data.IRepository;
using lab5.Data.Models;

namespace lab5.Data.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(lab8Context repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
