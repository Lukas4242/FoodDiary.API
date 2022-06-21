using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodDiary.API.Data;
using FoodDiary.API.Dtos;
using FoodDiary.API.Models;

namespace FoodDiary.API.Services
{
    public class WeightService : IWeightService
    {
        private readonly IWeightRepository _weightRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        
        public WeightService (IWeightRepository weightRepo, IUserRepository userRepo, IMapper mapper)
        {
            _weightRepo = weightRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<bool> CreateWeight(int userId, WeightForCreationDto weightForCreationDto) 
        {
            weightForCreationDto.UserId = userId;
            var weight = _mapper.Map<Weight>(weightForCreationDto);
            var user = await _userRepo.GetUser(userId);
            user.Weights.Add(weight);

            if (await _userRepo.SaveAll())
                return true;
            return false;
        }

        public async Task<bool> DeleteWeight(int userId, int weightId)
        {
            var meal = await _weightRepo.GetWeight(weightId);

            if (meal == null)
                return false;

            if (userId != meal.UserId)
                return false;

            _weightRepo.Delete(meal);

            if (await _weightRepo.SaveAll())
                return true;

            return false;
        }

        public async Task<IEnumerable<WeightForListDto>> GetWeights(int userId)
        {
            var weights = await _weightRepo.GetWeights(userId);
            var weightsToReturn = _mapper.Map<IEnumerable<WeightForListDto>>(weights);

            return weightsToReturn;
        }
        
    }
}