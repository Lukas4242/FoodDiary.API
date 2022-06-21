namespace FoodDiary.API.Dtos
{
    public class MealToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carb { get; set; }
        public int MassOfPortion { get; set; }
        public int AmountOfPortions { get; set; }
        public int Type { get; set; } 
    }
}