using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Rezervation:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDate { get; set; } // Rezervasyonun yapılacağı tarih
        public TimeSpan StartTime { get; set; } // Rezervasyonun başlangıç saati
        public TimeSpan EndTime { get; set; } // Rezervasyonun bitiş saati
        public string Description { get; set; }

        //Realtion Propertie

        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int? TableId { get; set; }
        public virtual Table Table { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
//Uygulama Notları
//Rezervasyonların yönetimi sırasında, aynı TableId için çakışan StartTime ve EndTime değerlerine sahip rezervasyonların olup olmadığını kontrol etmek önemlidir. Bu, rezervasyon işlemi sırasında uygulamanızın bir parçası olarak gerçekleştirilmelidir.
//Rezervasyon sürelerinin çakışmaması için uygulama katmanında mantıksal kontroller eklemeniz gerekebilir. Örneğin, yeni bir rezervasyon yapılmak istendiğinde, seçilen masa için belirtilen zaman dilimi içinde zaten mevcut bir rezervasyon olup olmadığı kontrol edilir.
//Bu yapı, müşterilere esnek rezervasyon seçenekleri sunmanıza ve masaların kullanımını maksimize etmenize olanak tanır