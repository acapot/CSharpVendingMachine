using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using VendingMachine.Models;

namespace VendingMachine.Data
{
    public class VendingData
    {
        private static List<Product> products = new List<Product>
        {
            new Drink("Ica Juice",25.99,33,TypeEnum.Juice,JuiceFlavorEnum.Strawberry,SizeEnum.ml_250),
            new Drink("Multivitamin",21.99,9,TypeEnum.Juice,JuiceFlavorEnum.Strawberry,SizeEnum.ml_250),
            new Drink("Ica Juice",25.99,10,TypeEnum.Juice,JuiceFlavorEnum.Papaya,SizeEnum.ml_250),
            new Drink("Ica Juice",25.99,76,TypeEnum.Juice,JuiceFlavorEnum.Orange,SizeEnum.ml_250),
            new Drink("Ica Juice",25.99,44,TypeEnum.Juice,JuiceFlavorEnum.Raspberry, SizeEnum.ml_250),
            new Drink("Multivitamin",21.99,15,TypeEnum.Juice,JuiceFlavorEnum.Raspberry, SizeEnum.ml_250 ),
            new Drink("Multivitamin",21.99,34,TypeEnum.Juice,JuiceFlavorEnum.Strawberry, SizeEnum.ml_250),
            new Drink("Multivitamin",21.99,98,TypeEnum.Juice,JuiceFlavorEnum.Melon, SizeEnum.ml_250 ),

            new Drink("Fanta",9.99,44,TypeEnum.Soda,SodaContainerEnum.Jar, SizeEnum.ml_350),
            new Drink("Seven Up",9.99,43,TypeEnum.Soda,SodaContainerEnum.Jar,SizeEnum.ml_350),
            new Drink("Pepsi",9.99,22,TypeEnum.Soda,SodaContainerEnum.Jar,SizeEnum.ml_350),
            new Drink("Sprite",9.99,77,TypeEnum.Soda,SodaContainerEnum.Jar,SizeEnum.ml_350),

            new Drink("Fanta",56,44,TypeEnum.Soda,SodaContainerEnum.Bottle,SizeEnum.ml_500),
            new Drink("Seven Up",76,43,TypeEnum.Soda,SodaContainerEnum.Bottle,SizeEnum.ml_500),
            new Drink("Pepsi",13.99,43,TypeEnum.Soda,SodaContainerEnum.Bottle,SizeEnum.ml_500),
            new Drink("Sprite",13.99,55,TypeEnum.Soda,SodaContainerEnum.Bottle, SizeEnum.ml_500),

            
            new Food("Pizza Primavera",90,10,300,WeightUnitEnum.G,FoodTypeEnum.Pizza),
            new Food("Pizza Margarita",90,0,300,WeightUnitEnum.G,FoodTypeEnum.Pizza),
            new Food("Sushi",190,6,400,WeightUnitEnum.G,FoodTypeEnum.Japanese),
            new Food("Chicken Peking",120,3,400,WeightUnitEnum.G,FoodTypeEnum.Chinese),
            
            new Toy("Mini Car",120.90,6,Material.Wood),
            new Toy("Ball",150.15,3,Material.Plastic)

        };

        public static List<Product> Products { get => products; }




        private static double totalAmount = 0;

        public static double TotalAmount { get => totalAmount; }

        public static void AddAmmount(double amount)
        {
            totalAmount += amount;
        }

        public static void DecreaseAmount(double amount)
        {
            totalAmount -= amount;
        }


        public static void ResetAmount()
        {
            totalAmount = 0;
        }
    }
}
