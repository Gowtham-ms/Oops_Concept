using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Linq.Program;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var Customers = new List<int> { 1, 2, 3, 4, 5 };
            //// query syntax
            //var evenNumbers = from c in Customers where c % 2 == 0 select c;
            //// method syntax
            //var evenNumbersMethod = Customers.Where(c => c % 2 == 0);

            //foreach (var num in evenNumbersMethod)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.ReadLine();
            var customers = new List<Customer>
            {
                new Customer {CustomerId = 1, Name ="Gowtham"},
                new Customer {CustomerId = 2, Name ="Akhila"}
            };

            var orders = new List<Order>
            {
                new Order {OrderId=1, ProductName="Laptop", CustomerId=1},
                new Order {OrderId=2, ProductName="Phone", CustomerId=2},
            };

            // Join Query in Linq
            var CustomerOrder = from c in customers
                                join o in orders on
                                c.CustomerId equals o.CustomerId
                                where c.CustomerId == 1
                                select new { c.Name, o.ProductName };

            // Method 
            var CustomerOrderMethod = customers.Join(orders,
                c => c.CustomerId,
                o => o.OrderId,
                (c, o) => new
                {
                    c.CustomerId,
                    c.Name,
                    o.ProductName
                }).Where(c => c.CustomerId == 1);

            foreach (var co in CustomerOrderMethod)
            {
                Console.WriteLine(co.Name + "Ordered this product: " + co.ProductName);
            }
            Console.ReadLine();
        }

        //models class
        public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
        }
        //models class
        public class Order
        {
            public int OrderId { get; set; }
            public int CustomerId { get; set; }
            public string ProductName { get; set; }
        }
    }
}
