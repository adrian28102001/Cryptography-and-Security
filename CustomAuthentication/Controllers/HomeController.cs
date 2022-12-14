using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CustomAuthentication.Models;
using Lab1.CaesarCipher;
using Microsoft.AspNetCore.Authorization;
using CaesarCipher = CustomAuthentication.Models.CaesarCipher;

namespace CustomAuthentication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICaesarCipher _caesarCipher;
    
    public HomeController(ILogger<HomeController> logger, ICaesarCipher caesarCipher)
    {
        _logger = logger;
        _caesarCipher = caesarCipher;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize]
    [HttpPost]
    public IActionResult CaesarCipher(string textToEncrypt, int key)
    {
        var model = new CaesarCipher();
        var caesarEncrypt = _caesarCipher.Encrypt(textToEncrypt, key);
        var caesarDecrypt = _caesarCipher.Decrypt(caesarEncrypt, key);
        
        model.Encrypted = caesarEncrypt;
        model.Decrypted = caesarDecrypt;
        
        return View(model);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}