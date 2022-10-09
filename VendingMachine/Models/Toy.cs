using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    public class Toy : Product
    {
        public Toy(string? name, double price, int count, Material material) : base(name, price, count)
        {
            Material = material;
        }

        public Material Material { get; set; }
        public override string Examine => Name +
                                          $"\nType: {Material}" +
                                          $"\nPrice: {Price}";

        public override string Use
        {
            get
            {
                if (Material == Material.Wood)
                {
                    return "The paint of this wood's toy is safe for children and It's ready to play";
                }

                return "The material is plast and it's ready to play";


            }
        }
    }

    public enum Material
    {
        Wood,
        Plastic
    }
}