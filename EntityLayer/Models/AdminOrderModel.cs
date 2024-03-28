using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class AdminOrderModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public decimal Total { get; set; }
        public int Count { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
