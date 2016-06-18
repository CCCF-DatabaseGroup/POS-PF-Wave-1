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
        public ActionResult MayorVentaPorSurcursal()
        {
            return View();
        }
        public ActionResult MayorVentaPorCajero()
        {
            return View();
        }
        public ActionResult BajoInventario()
        {
            return View();
        }
        public ActionResult Export()
        {
       

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReportProducts.rpt"));
            rd.SetDataSource(mde.productosMasVendidos.ToList());
            
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
          
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "ListaDeProductosMasVendidos.pdf");

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}