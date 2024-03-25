using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string? CustomerName { get; set; }
		public string? CustomerSurname { get; set; }
		public string? CustomerMail { get; set; }
		public string? CustomerPassword { get; set; }
		public string? CustomerAdress { get; set; }
	}
}
