using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public enum EnumOrderState
    {
        [Display(Name ="Siparişiniz Onay Bekleniyor")]
        Beklemede,
        [Display(Name = "Siparişiniz Onaylandı")]
        Onaylandı,
        [Display(Name = "Siparişiniz Kargoya Verildi")]
        Kargoda,
        [Display(Name = "Siparişiniz Teslim Edildi")]
        Tamamlandı

    }
}
