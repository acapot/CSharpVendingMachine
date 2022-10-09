using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;

namespace VendingMachine.Services
{
    internal class OutputServices
    {
        public static void ShowProductsList(ref VendingMachineService vendingMachine)
        {
            Console.Clear();
            Console.WriteLine("||=========================================||");
            Console.WriteLine("||                                         ||");
            Console.WriteLine("||   *** Welcome to vending machine ****   ||");
            Console.WriteLine("||                                         ||");
            Console.WriteLine("||=========================================||");
            Console.WriteLine();


            List<string> productList = vendingMachine.ShowAll();

            foreach (var product in productList)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine(product);
                
                
            }
            Console.WriteLine();
            Console.WriteLine("||=========================================||");
            Console.WriteLine($"    Total input: {VendingData.TotalAmount}");
            Console.WriteLine("||=========================================||");
            Console.WriteLine();
        }


        public static char SelectOption()
        {
           
            Console.WriteLine();
            Console.WriteLine("||=========================================||");
            Console.WriteLine("||   1. Insert money                       ||");
            Console.WriteLine("||   2. Select Product                     ||");
            Console.WriteLine("||   3. Return money                       ||");
            Console.WriteLine("||=========================================||");
            Console.WriteLine();
            char select;

            bool validSelect;

            do
            {
                select = Console.ReadKey().KeyChar;

                switch (select)
                {
                    case '1':
                    case '2':
                    case '3':
                        validSelect = true;
                        break;
                    default:
                        Console.WriteLine();
                        Alert("Wrong choice, try agin");
                        validSelect = false;
                        break;
                }

            } while (!validSelect);

            return select;
        }



        public static void InsertMoneyOutput(ref VendingMachineService vendingMachine)
        {
            Console.WriteLine("Insert one of these money unit");
            Console.WriteLine();
            Console.WriteLine("or insert \"B\" to go back");
            Console.WriteLine();
            foreach (int unit in vendingMachine.ValidMoney)
            {
                Console.Write($"{unit}kr ");
            }
            Console.WriteLine();
            string? amount;

            bool validInput;

            do
            {
                Console.Write("Input: ");
                amount = Console.ReadLine();

                if (amount.ToLower() == "b") break;

                try
                {
                    vendingMachine.InsertMoney(int.Parse(amount));
                    validInput = true;
                }
                catch (Exception ex)
                {
                    Alert(ex.Message);
                    validInput = false;
                }
            } while (!validInput);

        }

        public static void SelectProductOutput(ref VendingMachineService vendingMachine)
        {
            bool purchaseIsDone = false;

            Console.WriteLine();

            do
            {
                Console.WriteLine();
                Console.WriteLine("Insert ID of product");
                Console.WriteLine("or insert \"B\" to go back");

                Console.Write("ID: ");

                string? productIdText = Console.ReadLine();

                if (productIdText.ToLower() == "b")
                {
                    break;
                }

                int productId;

                bool isNumber = int.TryParse(productIdText, out productId);

                while (!isNumber)
                {
                    Alert("It's wrong , tray again!");

                    productIdText = Console.ReadLine();

                    isNumber = int.TryParse(productIdText, out productId);
                }

                Console.WriteLine();
                Console.WriteLine("||=========================================||");
                Console.WriteLine("||   1. buy product                        ||");
                Console.WriteLine("||   2. Show details                       ||");
                Console.WriteLine("||=========================================||");
                Console.WriteLine();

                char productChoice;

                bool validChoice = false;

                do
                {
                    productChoice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (productChoice)
                    {
                        case '1':
                            try
                            {
                                validChoice = true;
                                vendingMachine.Purchase(productId);
                                purchaseIsDone = true;
                            }
                            catch (Exception ex)
                            {
                                Alert(ex.Message);
                                continue;
                            }
                            break;
                        case '2':
                            validChoice = true;
                            Console.WriteLine(vendingMachine.Details(productId));
                            break;
                        default:
                            Alert("Wrong choice");
                            break;

                    }

                } while (!validChoice);

            } while (!purchaseIsDone);
        }


        public static void EndTrasictionalOutput(ref VendingMachineService vendingMachine)
        {
            Dictionary<int, int> returned = vendingMachine.EndTransaction();

            Console.WriteLine();
            Console.WriteLine("Returned money: ");
            Console.WriteLine();
            foreach (int key in returned.Keys)
            {
                Console.WriteLine(key + "kr = " + returned[key]);
            }

            Console.WriteLine();
            Console.WriteLine("Transaction ends. Thanks for using our vending machine!!");

        }






        //Helper methods
        private static void Alert(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Beep();
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
