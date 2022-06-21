using System.Threading.Tasks;
using FoodDiary.API.Models;

namespace FoodDiary.API.Data
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity)  where T: class;
        Task<bool> SaveAll();
        Task<User> GetUser(int id);   
    }
}