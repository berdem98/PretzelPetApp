using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Product
	{
		public int ProductId { get; set; }
		[Required(ErrorMessage ="Ürün adı gereklidir.")]
		public string? ProductName { get; set; }
        [Required(ErrorMessage ="Fiyat gereklidir.")]
		public string? Price { get; set; }
        [Required(ErrorMessage = "Stok bilgisi gereklidir.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Açıklama gereklidir.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Resim URL gereklidir.")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Kategori ID gereklidir.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
