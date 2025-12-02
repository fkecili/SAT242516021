using System;

namespace SAT242516021.Models
{
    public class Gider
    {
        public int gider_id { get; set; }          // d.gider_id
        public string KullaniciAd { get; set; } = ""; // u.ad AS KullaniciAd
        public string Kategori { get; set; } = "";    // k.kategori_adi AS Kategori
        public decimal miktar { get; set; }        // d.miktar
        public DateTime tarih { get; set; }        // d.tarih
        public string? aciklama { get; set; }      // d.aciklama

        // Blazor'da kullanmak için alias property'ler
        public int Id
        {
            get => gider_id;
            set => gider_id = value;
        }

        public string Aciklama
        {
            get => aciklama ?? "";
            set => aciklama = value;
        }

        public decimal Tutar
        {
            get => miktar;
            set => miktar = value;
        }

        public DateTime Tarih
        {
            get => tarih;
            set => tarih = value;
        }

        public string KategoriAdi
        {
            get => Kategori;
            set => Kategori = value;
        }
    }
}
