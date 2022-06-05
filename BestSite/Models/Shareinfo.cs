using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BestSite
{
    public partial class Shareinfo
    {
        public Shareinfo()
        {
            Sharecertificates = new HashSet<Sharecertificate>();
        }

        [DisplayName("Id")]
        public int SiId { get; set; }
        [DisplayName("Эмитент")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z\s]*$", ErrorMessage = "Используйте только буквы!")]
        public string Issuer { get; set; } = null!;
        [DisplayName("Вид акции")]
        public string Sharetype { get; set; } = null!;
        [DisplayName("Количество")]
        public int Sharecount { get; set; }
        [DisplayName("Дата выпуска")]
        public DateTime Shareissuedate { get; set; }
        [DisplayName("Уставной капитал")]
        public decimal ShareAuthorizedcapital { get; set; }
        [DisplayName("Дата выпуска")]
        public string strShareissuedate
        {
            get { return Shareissuedate.ToString("d"); }
        }

        public virtual ICollection<Sharecertificate> Sharecertificates { get; set; }
    }
}
