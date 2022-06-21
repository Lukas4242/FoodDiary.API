using System;

namespace FoodDiary.API.Dtos
{
    public class WeightForListDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Mass { get; set; }
    }
}