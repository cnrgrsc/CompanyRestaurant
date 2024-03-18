﻿using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.TableVM
{
    public class TableViewModel
    {
        public int Id { get; set; } // Masanın benzersiz kimliği

        [Required(ErrorMessage = "Masa numarası zorunludur.")]
        [Display(Name = "Masa Numarası")]
        public int TableNo { get; set; } // Masa numarası

        [Required(ErrorMessage = "Kişi kapasitesi zorunludur.")]
        [Display(Name = "Kişi Kapasitesi")]
        public int PersonCapacity { get; set; } // Masa kişi kapasitesi

        [Display(Name = "Rezervasyon Durumu")]
        public bool IsReserved { get; set; } // Masa rezervasyon durumu

        // Opsiyonel: Masanın konumu veya bölgesi gibi ek bilgiler
        [Display(Name = "Masa Konumu")]
        public string Location { get; set; } // Masanın bulunduğu konum veya bölge
    }
}
