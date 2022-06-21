using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodDiary.API.Data;
using FoodDiary.API.Dtos;
using FoodDiary.API.Models;

namespace FoodDiary.API.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public MealService(IMealRepository mealRepo, IUserRepository userRepo, IMapper mapper)
        {
            _mealRepo = mealRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<bool> CreateMeal(int userId, MealForCreationDto mealForCreationDto) {
            mealForCreationDto.UserId = userId;
            var meal = _mapper.Map<Meal>(mealForCreationDto);
            meal.Created = DateTime.Now;
            var user = await _userRepo.GetUser(userId);
            user.Meals.Add(meal);

            if (await _userRepo.SaveAll())
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMeal(int userId, int mealId)
        {
            var meal = await _mealRepo.GetMeal(mealId);

            if (meal == null)
                return false;

            if (userId != meal.UserId)
                return false;

            _mealRepo.Delete(meal);

            if (await _mealRepo.SaveAll())
                return true;

            return false;
        }

        public async Task<IEnumerable<MealsForListDto>> GetMealsByDate(int userId, string date) 
        {
            var parsedDate = DateTime.Parse(date);
            var meals = await _mealRepo.GetMealsByDate(parsedDate, userId);
            var mealsToReturn = _mapper.Map<IEnumerable<MealsForListDto>>(meals);
            return mealsToReturn;
        }

        public async Task<bool> UpdateMeal(int userId, int mealId, MealForUpdateDto mealForUpdateDto)
        {
            var mealFromRepo = await _mealRepo.GetMeal(mealId);
            mealForUpdateDto.Created = DateTime.Now;

            _mapper.Map(mealForUpdateDto, mealFromRepo);

            if (await _mealRepo.SaveAll())
                return true;
            return false;
        }
    }
}