using System.Linq;
using lab5.Data.IRepository;
using lab5.Data.Models;

namespace lab5.Data.Repository
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(lab8Context repositoryContext) : base(repositoryContext)
        {
        }

        public Cinema FindCinemaByName(string name)
        {
            return this.RepositoryContext.Cinemas.FirstOrDefault(x => x.Name == name);
        }
    }
}
