using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GAP.Seguros.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
           
            if (this.Request.IsAuthenticated)
            {
                // Si el usuario está autenticado 
                // retorna la Vista de administración.
                return RedirectToAction("Index", "Home1");
            }
            else
            {
                // Si no, retorna la Vista de Login.
                return RedirectToAction("Login2", "Admin");
            }
        }

        // GET: Admin/Login
        public ActionResult Login()
        {
            // Retorna la Vista de Login
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public ActionResult Login(string usr, string pwd, string rme)
        {
            if (string.IsNullOrEmpty(usr) || string.IsNullOrEmpty(pwd))
            {
                return View();
            }
            else
            {
                bool _rememberMe = rme == "on" ? true : false;

                // Valida el usuario con los registrados en la
                // seccion <authentication/> del Web.config
                if (FormsAuthentication.Authenticate(usr, pwd))
                {
                    // Crea la Cookie con el Ticket de autenticación 
                    // para el usuario.
                    FormsAuthentication.SetAuthCookie(usr, _rememberMe);
                    // Redirige a la Accion 'Index'
                    return RedirectToAction("Index");
                }
                else

                {
                    // Si no es un usuario válido, retorna la
                    // Vista de Login.
                    return View();
                }
            }
        }

        // GET: Admin/Logout
        public ActionResult Logout()
        {
            // Elimina la Cookie con el Ticket de autenticación 
            // para el usuario.
            FormsAuthentication.SignOut();
            // Redirige a la Accion 'Index'
            return this.RedirectToAction("Index");
        }

        // GET: Admin/Login
        public ActionResult Login2()
        {
            // Retorna la Vista de Login
            return View();
        }
    }
}