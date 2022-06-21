using System.Threading.Tasks;
using FoodDiary.API.Dtos;
using System.Collections.Generic;

namespace FoodDiary.API.Services
{
    public interface IMealService
    {
         Task<bool> CreateMeal(int userId, MealForCreationDto mealForCreationDto);
         Task<bool> DeleteMeal(int userId, int mealId);
         Task<IEnumerable<MealsForListDto>> GetMealsByDate(int userId, string date);
         Task<bool> UpdateMeal(int userId, int mealId, MealForUpdateDto mealForUpdateDto);
    }
}