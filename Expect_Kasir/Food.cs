using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect_Kasir
{
    class Food : Menu
    {
        private bool fried = false;
        public Food(string name, double price, bool fried) : base(name, price)
        {
            this.fried = fried;
        }

        public bool getFried()
        {
            return this.fried;
        } 
    }
}
