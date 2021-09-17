using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expect_Kasir
{
    public class Menu
    {
        private string name;
        private double price;
        private int orderCount = 0;

        public Menu(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string getName()
        {
            return this.name;
        }

        public double getPrice()
        {
            return this.price;
        }

        public double getTotalPrice()
        {
            return this.orderCount * this.price;
        }

        public int getOrderCount()
        {
            return this.orderCount;
        }

        public void setOrderCount(int orderCount)
        {
            this.orderCount = orderCount;
        }
    }
}
