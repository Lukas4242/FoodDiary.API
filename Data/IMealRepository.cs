using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDiary.API.Models;

namespace FoodDiary.API.Data
{
    public interface IMealRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity)  where T: class;
        Task<bool> SaveAll();
        Task<Meal> GetMeal(int id); 
        Task<IEnumerable<Meal>> GetMealsByDate(DateTime date, int userId);
    }
}