using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }     
        public string? OrderNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

        public virtual List<OrderLineModel> OrderLines { get; set; }


        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? AdressHeader { get; set; }
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? PostCode { get; set; }
    }
    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
