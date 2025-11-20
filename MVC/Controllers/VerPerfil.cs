using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace MVC.Controllers
{
    public class VerPerfil : Controller
    {
        Sistema miSistema = Sistema.Instancia;
        
            public IActionResult Perfiles()
            {
                //Levantar al gerente
                int id = (int)HttpContext.Session.GetInt32("UsuarioId");
                Usuario u = miSistema.ObtenerUsuariobyID(id);


            PerfilViewModel nuevo = new PerfilViewModel(u, miSistema.GastosTotalesPorEquipoEnElMes(u.Pertenece, DateTime.Now));
                

                ;
                return View(nuevo);


            }
        public class PerfilViewModel
        {
            public Usuario usuario { get; set; }
            public double GastoEquipoMes { get; set; }
            public PerfilViewModel(Usuario unUsuario,double monto)
            {
                usuario = unUsuario;
                GastoEquipoMes = monto;
            }

       
        }




    }
}
