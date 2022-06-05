using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BestSite
{
    public partial class Shareholder
    {
        public Shareholder()
        {
            Sharecertificates = new HashSet<Sharecertificate>();
        }
        [DisplayName("Id")]
        public int ShId { get; set; }
        [DisplayName("Фамилия")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z\s]*$", ErrorMessage = "Используйте только буквы!")]
        public string LastName { get; set; } = null!;
        [DisplayName("Имя")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z\s]*$", ErrorMessage = "Используйте только буквы!")]
        public string FirstName { get; set; } = null!;
        [DisplayName("Отчество")]
        [RegularExpression(@"^[А-ЯA-Z]+[а-яА-Яa-zA-Z\s]*$", ErrorMessage = "Используйте только буквы!")]
        public string? MiddleName { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Серия паспорта")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Введите серию пасспорта в формате XXXX")]
        public string PassportSerial { get; set; } = null!;
        [DisplayName("Номер паспорта")]
        [RegularExpression(@"\d{6}", ErrorMessage = "Введите номер пасспорта в формате XXXXXX")]
        public string PassportNumber { get; set; } = null!;
        [DisplayName("Телефон")]
        [RegularExpression(@"^8\d{10}", ErrorMessage = "Введите номер телефона в формате 8XXXXXXXXXX (11 цифр)")]
        public string PhoneNumber { get; set; } = null!;
        [DisplayName("Город")]
        [RegularExpression(@"^[а-яА-Яa-zA-Z\s]*$", ErrorMessage = "Используйте только буквы!")]
        public string City { get; set; } = null!;
        [DisplayName("Дата рождения")]
        public string strBirthDate
        {
            get { return BirthDate.ToString("d"); }
        }
        public virtual ICollection<Sharecertificate> Sharecertificates { get; set; }

    }
}
