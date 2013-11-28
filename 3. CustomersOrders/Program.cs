using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Library;

class Program
{
    static void Main()
    {
        using (var db = new NorthwindEntities())
        {
            //3. Customers with orders since 1997 to Canada
            var orders = from order in db.Orders
                         where order.OrderDate.Value.Year >= 1997 && order.ShipCountry == "Canada"
                         select order;
            var groupedOrders = orders.GroupBy(x => x.Customer.ContactName);
            foreach (var order in groupedOrders)
            {
                Console.WriteLine(order.Key);
            }

            Console.WriteLine();
        }
    }
}
