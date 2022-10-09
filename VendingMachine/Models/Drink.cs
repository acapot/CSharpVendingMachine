using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Drink : Product
    {

        //Constructor for only Juice which has flavor
        public Drink(string? name, double price, int count, TypeEnum typeDrink, JuiceFlavorEnum flavor, SizeEnum size) : base(name, price, count)
        {
            TypeDrink = typeDrink;
            JuiceFlavor = flavor;
            Size = size;

        }

        //Constructor for only Soda which has two type of container (jar or bottle)
        public Drink(string? name, double price, int count, TypeEnum typeDrink, SodaContainerEnum sodaContainer, SizeEnum size) : base(name, price, count)
        {
            TypeDrink = typeDrink;
            SodaContainer = sodaContainer;
            Size = size;
        }

        public JuiceFlavorEnum JuiceFlavor { get; set; }
        public TypeEnum TypeDrink { get; set; }
        public SodaContainerEnum SodaContainer { get; set; }
        public SizeEnum Size { get; set; }
        


        public override string Examine
        {           
     
            get
            {
                string drinkType = (TypeDrink == TypeEnum.Juice) ? ("Juice flavor: " + JuiceFlavor) : ("Container: " + SodaContainer);

                return $"{Name}" +
                  $"\n{drinkType}" +
                  $"\nSize: {Size}" +
                  $"\nPrice: {Price} kr";
            }
        }


        public override string Use
        {
            get
            {
                StringBuilder useTextBuilder = new StringBuilder();

                if (TypeDrink == TypeEnum.Juice)
                {
                    useTextBuilder.Append("This drink does not contain gas and its flavor is " + JuiceFlavor);
                }

                else
                {
                    useTextBuilder.Append(SodaContainer + " drink contain gas");
                }

                return useTextBuilder.ToString();

            }
        }
    }

    public enum JuiceFlavorEnum
    {
        Orange,
        Papaya,
        Melon,
        Strawberry,
        Raspberry
    }

    public enum SodaContainerEnum
    {
        Jar,
        Bottle
    }

    public enum TypeEnum
    {
        Juice,
        Soda
    }

    public enum SizeEnum
    {
        ml_350,
        ml_500,
        ml_250

    }
}
