using VendingMachine.Services;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            VendingMachineService vendingMachine = new VendingMachineService();

            bool finish = false;

            do
            {
                OutputServices.ShowProductsList(ref vendingMachine);

                Console.WriteLine();

                char choies = OutputServices.SelectOption();

                OutputServices.ShowProductsList(ref vendingMachine);

                switch (choies)
                {
                    case '1':
                        OutputServices.InsertMoneyOutput(ref vendingMachine);
                        break;
                    case '2':
                        OutputServices.SelectProductOutput(ref vendingMachine);
                        break;
                    case '3':
                        OutputServices.EndTrasictionalOutput(ref vendingMachine);
                        finish = true;
                        break;
                    default:
                        Console.WriteLine("Worng choese");
                        break;
                }

            } while (!finish);



        }
    }
}