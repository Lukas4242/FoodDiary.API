using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDiary.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.API.Data
{
    public class MealRepository : IMealRepository
    {
        private readonly DataContext _context;

        public MealRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Meal> GetMeal (int id) 
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(u => u.Id == id);
            return meal;
        }

        public async Task<IEnumerable<Meal>> GetMealsByDate (DateTime date, int userId) 
        {
            var meals = await _context.Meals.Where(u => u.UserId == userId)
                .Where(d => d.Date.Date == date.Date).ToListAsync();
            return meals;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}