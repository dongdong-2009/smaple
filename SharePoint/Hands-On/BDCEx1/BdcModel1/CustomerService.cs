using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDCEx1.BdcModel1
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class CustomerService
    {
        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer</returns>
        public static Customer GetCustomer(int id)
        {
            Customer e = new Customer(); 
            e.CustomerId = id; 
            e.Message = e.CustomerId + " Item Data"; 
            e.FirstName = e.CustomerId + " First Name"; 
            e.LastName = e.CustomerId + "Last Name"; 
            return e;
        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static Customer[] GetAllCustomers() //IEnumerable<Customer>
        {
            List<Customer> customerList = new List<Customer>(); 
            for (int i = 0; i < 10; i++) 
            { 
                Customer e = new Customer(); 
                e.CustomerId = i; 
                e.Message = e.CustomerId + " Item Data"; 
                e.FirstName = e.CustomerId + " First Name"; 
                e.LastName = e.CustomerId + "Last Name"; 
                customerList.Add(e);                 
            } 
            return customerList.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<short> GetAllCustomersIDs()
        {
            List<short> customerList = new List<short>();
            for (short i = 0; i < 10; i++)
            {

                customerList.Add(i);
            }
            return customerList.ToArray();
        }
    }
}
