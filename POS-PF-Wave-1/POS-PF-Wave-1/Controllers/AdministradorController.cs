using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_PF_Wave_1.Models;
namespace POS_PF_Wave_1.Controllers
{
    public class AdministradorController : Controller
    {
        private POS_PFEntities db = new POS_PFEntities();
        private const string CASA_FARMACEUTICA = "farmacia";
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


        [HttpPost]
        public JsonResult AddProduct(PRODUCTO product)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.PRODUCTO.Add(product);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveProduct(int id) {
            //db.Configuration.ProxyCreationEnabled = false;
            
            PRODUCTO toDelete = db.PRODUCTO.Find(id);
            if (toDelete != null)
            {
                db.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch(Exception e){}
                
            }
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

        public JsonResult GetBranchOffice()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var providers = db.SUCURSAL.ToList();

            return Json(providers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindBranchOffice(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            db.Configuration.ProxyCreationEnabled = false;
            SUCURSAL myBranchOffice = new SUCURSAL();
            myBranchOffice.Id_sucursal = id;

            myBranchOffice = db.SUCURSAL.Find(id);

            return Json(myBranchOffice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBranchOffice(SUCURSAL branchOffice)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //En esta seccion se selecciona farmatica o phishel
            //branchOffice.Id_farmacia_sucursal = (int)Session[CASA_FARMACEUTICA];
            branchOffice.Id_farmacia_sucursal = 1;
            db.SUCURSAL.Add(branchOffice);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveBranchOffice(SUCURSAL branchOffice)
        {
            SUCURSAL toDelete = db.SUCURSAL.Find(branchOffice.Id_sucursal);
            if (toDelete != null)
            {
                db.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) { }

            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateBranchOffice(SUCURSAL branchOffice)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var original = db.SUCURSAL.Find(branchOffice.Id_sucursal);

            if (original != null)
            {
                //db.SUCURSAL.Attach(branchOffice);
                //db.Entry(branchOffice).State = System.Data.Entity.EntityState.Modified;
                db.Entry(original).CurrentValues.SetValues(branchOffice);
                db.SaveChanges();
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }


        //======================================================================================================
        //=================== Administrar Prooveedores =========================================================
        //======================================================================================================


        public JsonResult GetProviders()
        {
            db.Configuration.ProxyCreationEnabled = false;

            var providers = db.PROVEEDOR.ToList();

            return Json(providers, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddProvider(PROVEEDOR provider)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.PROVEEDOR.Add(provider);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveProvider(PROVEEDOR provider)
        {
            PROVEEDOR toDelete = db.PROVEEDOR.Find(provider.Id_proveedor);
            if (toDelete != null)
            {
                db.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) { }

            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateProvider(PROVEEDOR provider)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var original = db.PROVEEDOR.Find(provider.Id_proveedor);

            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(provider);
                db.SaveChanges();
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }



        //======================================================================================================
        //=================== Administrar Empleados ============================================================
        //======================================================================================================



        public JsonResult GetEmployees()
        {
            db.Configuration.ProxyCreationEnabled = false;
            int[] rolesId = new int [] { 1, 2, 3, 4, 5 };
            var employees = db.RANGO_USUARIO
                             .Where(r => rolesId.Contains(r.Id_rango))
                             .SelectMany(x => x.USUARIO.Select(e => new { e.PERSONA, e.Id_usuario, e.Nickname }))
                             ;

            return Json(employees.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEmployee(USUARIO usuario,PERSONA persona)
        {
            db.Configuration.ProxyCreationEnabled = false;
            db.PERSONA.Add(persona);
            db.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RemoveEmployee(int IdUsuario)
        {
            USUARIO toDelete = db.USUARIO.Find(IdUsuario);
            if (toDelete != null)
            {
                db.Entry(toDelete).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e) { }

            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateEmployee(PERSONA persona)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var original = db.PERSONA.Find(persona.Id_usuario_persona);

            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(persona);
                db.SaveChanges();
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }










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