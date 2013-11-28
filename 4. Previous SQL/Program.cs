using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        //4. Previous using SQL
        SqlConnection dbCon = new SqlConnection("Server=SVETLANA; " +
        "Database=Northwind; Integrated Security=true");
        dbCon.Open();
        using (dbCon)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT c.ContactName 
                                FROM Customers c
                                INNER JOIN Orders o 
                                ON o.CustomerID = c.CustomerID " +
                                "WHERE (YEAR(o.OrderDate) = @orderDate AND o.ShipCountry = @country);");

            cmd.Parameters.AddWithValue("@orderDate", new DateTime(1997, 01, 01));
            cmd.Parameters.AddWithValue("@counter", "Canada");

            var reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["ContactName"];
                    Console.WriteLine(name);
                }
            }
        }
    }
}
