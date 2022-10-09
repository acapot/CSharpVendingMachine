using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Food : Product
    {
        public Food(string? name, double price, int count, double weight, WeightUnitEnum unit, FoodTypeEnum foodType) : base(name, price, count)
        {
            FoodType = foodType;
            Weight = weight;
            Unit = unit;
            
        }

        public double Weight { get; set; }
        public WeightUnitEnum Unit { get; set; }
        public FoodTypeEnum FoodType { get; set; }
        public bool Frozen { get; set; }

        public override string Examine
        {
            get
            {

                return $"{Name}" +
                      $"\nFood Type: {FoodType}" +
                      $"\nWeight: {Weight} {Unit}" +
                      $"Price: {Price} kr";
            }
        }

        public override string Use
        {
            get
            {
                StringBuilder useTextBuilder = new StringBuilder();

                if (FoodType == FoodTypeEnum.Chinese)
                {
                    useTextBuilder.Append("Chinese food contains a lot of salt ");
                }

                else if (FoodType == FoodTypeEnum.Japanese)
                {
                    useTextBuilder.Append("\nJapanese food is very healthy");
                }

                else
                {
                    useTextBuilder.Append("\nIf you want you can slide the pizza before");
                }

                return useTextBuilder.ToString();
            }
        }
    }

    public enum WeightUnitEnum
    {
        KG,
        G,
        MG
    }
    public enum FoodTypeEnum
    {
        Pizza,
        Chinese,
        Japanese
    }

    
}
