using System;

namespace FoodDiary.API.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public float Mass { get; set; }
    }
}