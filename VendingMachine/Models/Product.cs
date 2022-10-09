using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Services;

namespace VendingMachine.Models
{
    public abstract class Product
    {
        protected Product(string? name, double price, int count)
        {
            if (name == null)  throw new ArgumentNullException("you have to write a name of product");
            
            Id = ProductSequencer.IncrementId;
            Name = name;
            Price = price;
            Count = count;
        }

        public int Id { get; init; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }       
        public abstract string Examine { get; }
        public abstract string Use { get; }

        public override string? ToString()
        {

            return $"Product id: {Id}" +
                 $"\nProduct name: {Name}" +
                 $"\nPrice: {Price}" +
                 $"\nCount: {Count}";
        }
    }
}
