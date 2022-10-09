using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class VendingMachineService : IVending
    {
        public List<int> ValidMoney { get => new List<int> { 1, 5, 10, 20, 50, 100, 500, 1000 }; }

        public string Details(int productId)
        {
            Product? product = VendingData.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("This product is not existed!");
            }

            return $"{product.Examine} \n" +
                $"\n" + $"Use: \n" +
                $"{product.Use}";
        }

        public Dictionary<int, int> EndTransaction()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            double moneyLeft = VendingData.TotalAmount;

            for (int i = ValidMoney.Count - 1; i >= 0; i--)
            {
                if (ValidMoney[i] <= moneyLeft)
                {
                    int numberOfUnit = (int)Math.Floor(moneyLeft / ValidMoney[i]);
                    result.Add(ValidMoney[i], numberOfUnit);
                    moneyLeft -= ValidMoney[i] * numberOfUnit;
                }
            }
            return result;
        }

        public void InsertMoney(int amount)
        {
            if (!ValidMoney.Contains(amount))
            {
                throw new ArgumentException("There was an error inserting the money");
            }

            VendingData.AddAmmount(amount);
        }

        public Product Purchase(int productId)
        {
            Product? product = VendingData.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("Sorry, Product does not exist.");
            }

            else if (product.Count == 0)
            {
                throw new Exception("We do not have this product in stock at this time!");
            }

            else if (product.Price > VendingData.TotalAmount)
            {
                throw new Exception("Insert more money to make your purchase!");
            }
            else
            {
                VendingData.DecreaseAmount(product.Price);
                product.Count--;
            }
            
            return product;
        }

        public List<string> ShowAll()
        {
            return VendingData.Products.Select(p => p.ToString()).ToList();
        }
    }
}
