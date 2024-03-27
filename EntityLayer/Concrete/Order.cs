using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderLine> OrderLines { get; set; }



        public string? FullName { get; set; }       
        public string? AdressHeader { get; set; }       
        public string? Adress { get; set; }       
        public string? City { get; set; }    
        public string? District { get; set; }       
        public string? PostCode { get; set; }

    }
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


    }
}
