using AutoMapper;
using FoodDiary.API.Dtos;
using FoodDiary.API.Models;

namespace FoodDiary.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MealForCreationDto, Meal>();
            CreateMap<Meal, MealsForListDto>();
            CreateMap<Meal, MealToReturnDto>();
            CreateMap<MealForUpdateDto, Meal>();
            
            CreateMap<WeightForCreationDto, Weight>();
            CreateMap<Weight, WeightForListDto>();
            CreateMap<WeightForUpdateDto, Weight>();
        }
        
    }
}