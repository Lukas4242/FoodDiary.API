using System.Threading.Tasks;
using FoodDiary.API.Dtos;
using System.Collections.Generic;

namespace FoodDiary.API.Services
{
    public interface IWeightService
    {
         Task<bool> CreateWeight(int userId, WeightForCreationDto weightForCreationDto);
         Task<bool> DeleteWeight(int userId, int weightId);
         Task<IEnumerable<WeightForListDto>> GetWeights(int userId);
    }
}