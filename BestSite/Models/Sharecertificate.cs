using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestSite
{
    public partial class Sharecertificate
    {
        [DisplayName("Id")]
        public int ScId { get; set; }
        [DisplayName("Количество")]
        public int BuySharecount { get; set; }
        [DisplayName("Дата покупки")]
        public DateTime Buyinfo { get; set; }
        [DisplayName("Стоимость за шт.")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Priceforone { get; set; }
        [DisplayName("Общая сумма")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Totalprice { get; set; }
        [DisplayName("Id акции")]
        public int Shareinfoid { get; set; }
        [DisplayName("Id владельца")]
        public int Shareholderid { get; set; }
        [DisplayName("Общая сумма")]
        [Column(TypeName = "decimal(10,2)")]

        public virtual Shareholder Shareholder { get; set; } = null!;
        public virtual Shareinfo Shareinfo { get; set; } = null!;
    }
}
