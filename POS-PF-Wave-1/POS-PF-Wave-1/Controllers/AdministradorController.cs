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
        public ActionResult Index()
        {
            ViewBag.Title = "Vista Administrador ";

            return View();
        }

        /*Se hace la operacion READ SOBRE SUCURSALES*/
        public JsonResult READSucursales()
        {
            var db = new POS_PFEntities();
            var tb = db.SUCURSAL.ToList();
            return Json(tb, JsonRequestBehavior.AllowGet);

        }
        /*Se intenta usar un query */
        public JsonResult READCajeros(int num)
        {
            using (var ctx = new POS_PFEntities())
            {
                var tb = ctx.USUARIO.SqlQuery("Select NickName from USUARIO AS U, RANGO_USUARIO AS RU where U.RANGO_USUARIO==RU.Id_usuario and RU.Id_usuario==3").ToList();
                return Json(tb, JsonRequestBehavior.AllowGet);
            }

        }

    }
}