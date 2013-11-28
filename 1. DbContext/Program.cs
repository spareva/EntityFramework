using System;
using System.Collections.Generic;
using System.Linq;
using Entity.Library;
using System.Data.SqlClient;

class Program //problems 1, 3, 4
{
    static void Main()
    {
        using (var db = new NorthwindEntities())
        {            
            //2.
            //db.DeleteCustomer("ALFKI"); Comment in partial
            //db.SaveChanges();

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


            //5.
            var sales = from sale in db.Sales_Totals_by_Amounts
                         where sale.ShippedDate.Value > new DateTime(1997, 01, 01) && 
                            sale.ShippedDate.Value < new DateTime(2005, 01, 01) &&
                            sale.OrderID == db.Orders.FirstOrDefault(x => x.OrderID == sale.OrderID && x.ShipRegion == "RJ").OrderID
                         select sale;
            var groupedSales = sales.GroupBy(x => x.ShippedDate);
            foreach (var sale in groupedSales)
            {
                Console.WriteLine(sale.Key);
            }

            Console.WriteLine();
        }
    }
}
