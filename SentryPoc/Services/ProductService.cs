namespace SentryPoc.Services
{
    public class ProductService : IProductService
    {
        public int TahminiStokHesapla(int toplamStok, int siparistekiStok) => toplamStok / siparistekiStok;
    }
}
