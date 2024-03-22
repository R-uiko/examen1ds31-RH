using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using examen1ds31_RH.Models;

namespace examen1ds31_RH.Controllers
{
    public class HomeController : Controller
    {
        DAOUsuario dao = new DAOUsuario();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult helper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult recibeForm(string txtNombre, string txtPass, string combo)
        {

            string nombre = txtNombre;
            string pass = txtPass;
            string nivel = combo;


            return RedirectToAction("helper");
        }
        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Usuarios(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                if (dao.insertar(u))
                {
                    ViewBag.ins = "true";
                    ViewBag.user = u.nombre_usuario;
                }
                else
                {
                    ViewBag.ins = "false";
                }
            }


            return View();
        }
        //---------------- actualizar y Eliminar--------------------- Usuario
        [HttpPost]
        public ActionResult ActualizarUsuario(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                if (dao.actualizar(u))
                {
                    ViewBag.actualizacion = "true";
                    ViewBag.user = u.nombre_usuario;
                }
                else
                {
                    ViewBag.actualizacion = "false";
                }
            }

            return View("Usuarios", u);
        }

        [HttpPost]
        public ActionResult EliminarUsuario(int cod_user)
        {
            if (dao.eliminar(cod_user))
            {
                ViewBag.eliminacion = "true";
            }
            else
            {
                ViewBag.eliminacion = "false";
            }

            return RedirectToAction("Usuarios");
        }

        //Producto------------------------
        DAOProducto daop = new DAOProducto();

        public ActionResult Productos()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Productos(Productos p)
        {
            if (ModelState.IsValid)
            {
                if (daop.insertar(p))
                {
                    ViewBag.ins = "true";
                    ViewBag.user = p.descripcion;
                }
                else
                {
                    ViewBag.ins = "false";
                }
            }


            return View();
        }
        //---------------- actualizar y Eliminar--------------------- Para Producto
        [HttpPost]
        public ActionResult ActualizarProducto(Productos p)
        {
            if (ModelState.IsValid)
            {
                if (daop.actualizar(p))
                {
                    ViewBag.actualizacion = "true";
                    ViewBag.user = p.descripcion;
                }
                else
                {
                    ViewBag.actualizacion = "false";
                }
            }

            return View("Usuarios", p);
        }

        [HttpPost]
        public ActionResult EliminarProducto(int cod_prod)
        {
            if (daop.eliminar(cod_prod))
            {
                ViewBag.eliminacion = "true";
            }
            else
            {
                ViewBag.eliminacion = "false";
            }

            return RedirectToAction("Productos");

        }
        

        // ----------------  login

        public ActionResult Login(string txtUser, string txtContra)
        {

            string nombre_usuario = txtUser;
            string contra = txtContra;

            string nivel_usuario = dao.login(nombre_usuario, contra);

            if (!string.IsNullOrEmpty(nivel_usuario))
            {
                System.Web.HttpContext.Current.Session["nivel"] = nivel_usuario;
                System.Web.HttpContext.Current.Session["usuario"] = nombre_usuario;

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult CerrarSesion()
        {
            Session["nivel"] = null;
            Session["usuario"] = null;

            return RedirectToAction("Login");
        }

        //------------------------------cliente
        DAOCliente daoc = new DAOCliente();

        public ActionResult Clientes()
        {
            
            List<Clientes> clientes = daoc.GetTabla();
            return View(clientes);
        }

  


        [HttpPost]
        public ActionResult Clientes(Clientes c)
        {
            if (ModelState.IsValid)
            {
                DAOCliente daoc = new DAOCliente();
                if (daoc.Insertar(c))
                {
                    ViewBag.ins = "true";
                    ViewBag.user = c.nombres + " " + c.apellidos;
                }
                else
                {
                    ViewBag.ins = "false";
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ActualizarCliente(Clientes c)
        {
            if (ModelState.IsValid)
            {
                DAOCliente daoc = new DAOCliente();
                if (daoc.Actualizar(c))
                {
                    ViewBag.actualizacion = "true";
                    ViewBag.user = c.nombres + " " + c.apellidos;
                }
                else
                {
                    ViewBag.actualizacion = "false";
                }
            }

            return View("Clientes", c);
        }
        //----------- enverdad penze que funcianiria ,son las 11:30 y aun no lo logro... encerio vi el video unas 3 veces pero es con userid int no vachar ahhhhhh
        [HttpPost]
        public ActionResult EliminarCliente(string cod_clientes)
        {
            string nivelUsuario = (string)Session["nivel"];

            if (nivelUsuario == "admin")
            {
                // mil errores por string
                if (int.TryParse(cod_clientes, out int cod_cliente))
                {
                    DAOCliente daoCliente = new DAOCliente();

                 
                    bool eliminacionExitosa = daoCliente.EliminarCliente(cod_cliente);
                    if (eliminacionExitosa)
                    {
                        ViewBag.eliminacion = "true";
                    }
                    else
                    {
                        ViewBag.eliminacion = "false";
                    }
                }
                else
                {
                   
                    ViewBag.Error = "El codigo de cliente no es valido.";
                }
            }
            else
            {
             
                ViewBag.Error = "No tienes permiso para realizar esta accion.";
            }

            return RedirectToAction("Clientes");
        }
        //---------------- queria que me lo pueda editar, pero me dio error varias veses no lo quise borrar por alguna razon no me deja borrar :(
        public ActionResult EditarCliente(int id)
        {
            
            DAOCliente daoc = new DAOCliente();

            
            Clientes cliente = daoc.ObtenerClientePorId(id);

            if (cliente != null)
            {
               
                return View("EditarCliente", cliente);
            }
            else
            {
                
                return View("Error");
            }
        }
    }
}







    