using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sentry;
using SentryPoc.Models;
using SentryPoc.Services;
using SentryPoc.Utils;

namespace SentryPoc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int toplamStok = 800;
        int siparistekiStok = 0;
        try
        {
            var productService = HttpContext.RequestServices.GetRequiredService<IProductService>();
            ViewBag.Tahmin = productService.TahminiStokHesapla(toplamStok, siparistekiStok);
        }
        catch (Exception ex)
        {
            SentryId sentryId = ex.SentToSentry();
            string hataMesaji = $"SentryID: {sentryId} Message: O'a bölme hatası ile karşılaşıldı. Toplam Stok: {toplamStok}, Siparişteki Stok: {siparistekiStok}. Sistemin Mesajı => {ex.Message}";
            hataMesaji.SentToSentry();
        }
        return View();
    }

    public async Task<IActionResult> Privacy()
    {
        await Task.Delay(5000);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
