using System;
using System.Collections.Generic;

namespace FoodDiary.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Meal>  Meals { get; set; }
        public ICollection<Weight>  Weights { get; set; }
        public User()
        {
            Meals = new HashSet<Meal>();
            Weights = new HashSet<Weight>();
        }
    }
}