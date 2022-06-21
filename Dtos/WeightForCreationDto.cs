using System;

namespace FoodDiary.API.Dtos
{
    public class WeightForCreationDto
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public float Mass { get; set; }
    }
}