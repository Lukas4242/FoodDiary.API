using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDiary.API.Models;

namespace FoodDiary.API.Data
{
    public interface IWeightRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity)  where T: class;
        Task<bool> SaveAll();
        Task<Weight> GetWeight(int id); 
        Task<IEnumerable<Weight>> GetWeights(int userId);
    }
}