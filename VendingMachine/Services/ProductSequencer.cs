using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Services
{
    public class ProductSequencer
    {
        private static int id = 0;

        public static int IncrementId
        {
            get { return ++id; }
        }
    }
}
