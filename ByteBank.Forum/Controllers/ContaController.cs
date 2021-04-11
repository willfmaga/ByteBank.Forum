using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(ContaRegistrarViewModel modelo)
        {

            if (ModelState.IsValid)
            {
                //podemos incluir o usuario 
                var dbContext = new IdentityDbContext<UsuarioAplicacao>("Data Source=localhost;Initial Catalog=ByteBank.Forum;User ID=sa;Password=Banco@2020;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                var userStore = new UserStore<UsuarioAplicacao>(dbContext);
                var userManager = new UserManager<UsuarioAplicacao>(userStore);

                var novoUsuario = new UsuarioAplicacao();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.NomeCompleto = modelo.NomeCompleto;

                userManager.Create(novoUsuario, modelo.Senha);

                return RedirectToAction("Index", "Home"); 
            }

            //Alguma coisa aconteceu de errado !
            return View(modelo);
        }
    }
}
