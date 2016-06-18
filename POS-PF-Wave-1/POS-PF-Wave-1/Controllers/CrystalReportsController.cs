using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS_PF_Wave_1.Models;
using POS_PF_Wave_1.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace POS_PF_Wave_1.Controllers
{
    public class CrystalReportsController : Controller
    {
        POS_PFEntities mde = new POS_PFEntities();
        public ActionResult MayorVenta()
        {
            ViewBag.ListProducts = mde.productosMasVendidos.ToList();

            return View();
        }
      
        public ActionResult MayorVentaPorCajero()
        {
            ViewBag.ListProducts = mde.productosMasVendidosPorCajero.ToList();
            return View();
        }
        public ActionResult BajoInventario()
        {
            ViewBag.ListProducts = mde.bajoInventario.ToList();
            return View();
        }
        public ActionResult tiempoPromedioCajero()
        {
            ViewBag.ListProducts = mde.tiempoPromedioCajero.ToList();
            return View();
        }
      
        
    }
}