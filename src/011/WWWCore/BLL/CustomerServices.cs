using WestWindWholesale.DAL;
using WestWindWholesale.Models;

namespace WestWindWholesale;

public class CustomerServices
	{
		private readonly WestWindContext _context;

		internal CustomerServices(WestWindContext context)
		{
			_context = context;
		}

		/// <summary>
		/// blah blah
		/// </summary>
		/// <returns></returns>
		public List<Customer> GetAllCustomers()
		{
			return _context.Customers.ToList();
		}

		public Customer? GetCustomerById(string id) 
		{
			return _context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
		}

		public Customer? GetCustomerByContactName(string contactName) 
		{
			contactName = contactName.ToLower();
			Customer? customer = _context.Customers.Where(c => c.ContactName.ToLower().Contains(contactName)).FirstOrDefault();
			return customer;
		}

	}
