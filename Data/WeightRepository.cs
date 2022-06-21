using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDiary.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDiary.API.Data
{
    public class WeightRepository : IWeightRepository
    {
        private readonly DataContext _context;

        public WeightRepository(DataContext context)
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

        public async Task<Weight> GetWeight(int id)
        {
            var weight = await _context.Weights.FirstOrDefaultAsync(u => u.Id == id);
            return weight;
        }

        public async Task<IEnumerable<Weight>> GetWeights(int userId)
        {
            var weights = await _context.Weights.Where(u => u.UserId == userId).ToListAsync();
            return weights;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}