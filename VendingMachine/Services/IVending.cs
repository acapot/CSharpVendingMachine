using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IVending
    {
        //        Purchase, to buy a product, get product if able to buy otherwise return null or throw 
        //exception.

        //o ShowAll, show all products, get list of string´s with Id/Name/Cost of product.

        //o Details, show detailed information of a selected product, get a string with
        //information about the product including its unique data.

        //o InsertMoney, add money to the pool.

        //o EndTransaction, returns money left in appropriate amount of change (Dictionary<int,
        //int>).

        Product Purchase(int productId);
        List<string> ShowAll();
        string Details(int productId);
        void InsertMoney(int amount);
        Dictionary<int, int> EndTransaction();


    }
}
