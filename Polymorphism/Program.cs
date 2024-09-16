using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BaseGeometrikSekil
{
    public double Genislik { get; set; }
    public double Yukseklik { get; set; }

    // Constructor
    public BaseGeometrikSekil(double genislik, double yukseklik)
    {
        Genislik = genislik;
        Yukseklik = yukseklik;
    }

    // Polimorfizm ile override edilecek metod
    public virtual double AlanHesapla()
    {
        return Genislik * Yukseklik; // Kare ve Dikdörtgen için varsayılan alan hesaplama yöntemi
    }
}

class Kare : BaseGeometrikSekil
{
    // Kare olduğu için sadece bir kenar bilgisi yeterli, yukseklik de aynı olacak.
    public Kare(double kenar) : base(kenar, kenar) { }

    // Kare için BaseGeometrikSekil'deki hesaplama yöntemi uygundur, override edilmesine gerek yok.
}

class Dikdortgen : BaseGeometrikSekil
{
    // Dikdörtgenin genişlik ve yükseklik bilgisi ile oluşturulması
    public Dikdortgen(double genislik, double yukseklik) : base(genislik, yukseklik) { }

    // Dikdörtgen için de BaseGeometrikSekil'deki hesaplama uygundur, override edilmesine gerek yok.
}

class DikUcgen : BaseGeometrikSekil
{
    // Dik Üçgen için özel alan hesaplaması gerekecek
    public DikUcgen(double genislik, double yukseklik) : base(genislik, yukseklik) { }

    // Alan hesaplamasını polimorfizm ile override ediyoruz
    public override double AlanHesapla()
    {
        return (Genislik * Yukseklik) / 2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Kare örneği
        BaseGeometrikSekil kare = new Kare(5);
        Console.WriteLine("Karenin Alanı: " + kare.AlanHesapla());

        // Dikdörtgen örneği
        BaseGeometrikSekil dikdortgen = new Dikdortgen(4, 6);
        Console.WriteLine("Dikdörtgenin Alanı: " + dikdortgen.AlanHesapla());

        // Dik Üçgen örneği
        BaseGeometrikSekil dikUcgen = new DikUcgen(4, 6);
        Console.WriteLine("Dik Üçgenin Alanı: " + dikUcgen.AlanHesapla());
    }
}