using System;

namespace SAT242516021.Models
{
    public class Gelir
    {
        // SQL'deki kolon isimleri (sp_GetGelirler için)
        public int gelir_id { get; set; }          // SELECT g.gelir_id
        public string KullaniciAd { get; set; } = ""; // u.ad AS KullaniciAd
        public string Kategori { get; set; } = "";    // k.kategori_adi AS Kategori
        public decimal miktar { get; set; }        // g.miktar
        public DateTime tarih { get; set; }        // g.tarih
        public string? aciklama { get; set; }      // g.aciklama

        // Blazor bileşeninde daha okunaklı kullanmak için ek property'ler
        public int Id
        {
            get => gelir_id;
            set => gelir_id = value;
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
