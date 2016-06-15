using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_PF_Wave_1.Controllers
{
    public class AdministradorController : Controller
    {
        private POS_PFEntities db = new POS_PFEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Vista Administrador ";
            return View();
        }


        public ActionResult AdministrarEmpleado()
        {
            return View();
        }

        public ActionResult AdministrarProductos()
        {
            return View();
        }

        public ActionResult AdministrarProveedor()
        {
            return View();
        }

        public ActionResult AdministrarSucursal()
        {
            return View();
        }




        //======================================================================================================
        //=================== Administrar Productos ============================================================
        //======================================================================================================
    
        public JsonResult GetProducts()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FindProduct(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            PRODUCTO myProduct = new PRODUCTO();
            myProduct.Id_producto = id;

            myProduct = db.PRODUCTO.Find(id);
            return Json(myProduct, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddProduct(PRODUCTO product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public JsonResult RemoveProduct(int id) {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult UpdateProduct(PRODUCTO product)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var original = db.PRODUCTO.Find(product.Id_producto);

            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(product);
                db.SaveChanges();
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        //======================================================================================================
        //=================== Administrar Sucursales ===========================================================
        //======================================================================================================



        //======================================================================================================
        //=================== Administrar Prooveedores =========================================================
        //======================================================================================================


        public JsonResult GetProviders()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var providers = db.PROVEEDOR.ToList();

            return Json(providers, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FindProvider(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AddProvider(PRODUCTO product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        public JsonResult RemoveProvider(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProvider(PRODUCTO product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(null, JsonRequestBehavior.AllowGet);
        }



        //======================================================================================================
        //=================== Administrar Empleados ============================================================
        //======================================================================================================




        [HttpGet]
        /*Se hace la operacion READ SOBRE SUCURSALES*/
        public JsonResult READSucursales()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var tb = db.SUCURSAL.ToList();
            return Json(tb, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        /*Se intenta usar un query */
        public JsonResult READCajeros()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var tb = db.USUARIO.ToList();
            return Json(tb, JsonRequestBehavior.AllowGet);

        }

    }
}