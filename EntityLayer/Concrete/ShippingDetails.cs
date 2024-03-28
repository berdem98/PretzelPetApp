using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ShippingDetails
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Lütfen Ad Soyad bilgisini giriniz.")]
        public string? FullName { get; set; }
        [Required(ErrorMessage ="Lütfen adres başlığını giriniz.")]
        public string? AdressHeader { get; set; }
        [Required(ErrorMessage = "Lütfen adres detaylarını giriniz.")]
        public string? Adress { get; set; }
        [Required(ErrorMessage = "Lütfen şehir giriniz..")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Lütfen ilçe giriniz..")]
        public string? District { get; set; }
        [Required(ErrorMessage = "Lütfen posta kodu giriniz..")]
        public string? PostCode { get; set; }

    }
}
