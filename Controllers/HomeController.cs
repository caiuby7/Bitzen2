using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bitzen.Models;
using Microsoft.AspNetCore.Http;
using Bitzen.Data;

namespace Bitzen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Falha()
        {
            return View();
        }
        public ActionResult Sucesso()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Inscreva()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public ActionResult Index(FormCollection frmLogin)
        {

            return RedirectToAction("Sucesso", "Home");

        }
        [HttpPost]
        public async Task<ActionResult<DefaultViewModel>> Inscreva([FromServices] DataContext context, [FromBody] Usuario model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            model.Permissao = new Permissao("Administrador");
            model.IdPermissao = 1;
            context.Usuarios.Add(model);
            await context.SaveChangesAsync();
            return new DefaultViewModel(true, "Usuário criado com sucesso!", model);
        }
        public ActionResult Logout()
        {
            
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Troca_senha()
        {


            return View();
        }
       
    }
}
