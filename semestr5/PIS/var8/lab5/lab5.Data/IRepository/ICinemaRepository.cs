using lab5.Data.Models;

namespace lab5.Data.IRepository
{
    public interface ICinemaRepository : IBaseRepository<Cinema>
    {
        Cinema FindCinemaByName(string name);
    }
}
