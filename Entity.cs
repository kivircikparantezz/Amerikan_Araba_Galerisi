using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amerikan_Araba_Galerisi
{
   public class Musteri
    {
        public Guid ID { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Telefon { get; set; }

        public string Mail { get; set; }

        public string Adres { get; set; }

        public override string ToString()
        {
            return $"{Ad} {Soyad}";
        }
   }

    public class Araba
    {
        public Guid ID { get; set; }

        public string Marka { get; set; }

        public double Fiyat { get; set; }

        public double Adet { get; set;}

        public string Detay { get; set; }

        public override string ToString()
        {
            return $"{Marka} {Detay}";
        }
    }

    public class Satis
    {
        public Guid ID { get; set; }

        public Guid MusteriID { get; set; }

        public Guid ArabaID { get; set; }

        public DateTime Tarih { get; set; }

        public double Fiyat { get; set; }
    }

    public class Odeme
    {
        public Guid ID { get; set; }

        public Guid MusteriID { get; set; }

        public DateTime Tarih { get; set; }

        public double Tutar { get; set; }

        public string Tur { get; set; }

        public string Aciklama { get; set; }
    }
}
