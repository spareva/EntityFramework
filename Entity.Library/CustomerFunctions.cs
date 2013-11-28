using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Objects;

namespace Entity.Library
{
    public partial class NorthwindEntities
    {
        public void InsertCustomer(Customer newcustomer)
        {   
            this.Customers.Add(newcustomer);
            this.SaveChanges();
        }

        public void ModifyCustomer(string id, Customer modified) // Well writing different functions for each would be too much.
        {
            var customer = this.Customers.First(x => x.CustomerID == id);
            customer.Address = modified.Address;
            customer.City = modified.City;
            customer.CompanyName = modified.CompanyName;
            customer.ContactName = modified.ContactName;
            customer.ContactTitle = modified.ContactTitle;
            customer.Country = modified.Country;
            customer.CustomerDemographics = modified.CustomerDemographics;
            customer.CustomerID = modified.CustomerID;
            customer.Fax = modified.Fax;
            customer.Orders = modified.Orders;
            customer.Phone = modified.Phone;
            customer.PostalCode = modified.PostalCode;
            customer.Region = modified.Region;
            this.SaveChanges();
        }

        public void DeleteCustomer(string id)
        {
            var customer = this.Customers.First(x => x.CustomerID == id);
            this.Customers.Remove(customer); // Remove doesn't work for rows containing FK,
            this.SaveChanges();             // DeleteObject is not supported since Entity 4.0
        }                                   // so we're fucked :)
    }
}
