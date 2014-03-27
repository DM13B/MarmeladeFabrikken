using Common.Interfaces;
namespace Model.Products
{
    public class Ingredient : IIngredient
    {
        public int Id { get; set; }
        public string Amount { get; set; }
    }
}
