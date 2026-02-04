using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FerreteriaDiego.Models;

namespace FerreteriaDiego.Controllers
{
    public class Detalle_FacturaController : Controller
    {
        private Entities db = new Entities();

        // GET: Detalle_Factura
        public ActionResult Index()
        {
            var detalle_Factura = db.Detalle_Factura.Include(d => d.Factura).Include(d => d.Producto);
            return View(detalle_Factura.ToList());
        }

        // GET: Detalle_Factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            if (detalle_Factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Create
        public ActionResult Create()
        {
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "numero_fatura");
            ViewBag.id_producto = new SelectList(db.Producto, "id_producto", "codigo");
            return View();
        }

        // POST: Detalle_Factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalle,id_factura,id_producto,descricion,cantidad,precio_unitario,descuento_porcentaje,descuento_valor,iva_porcentaje,iva_valor,subtotal,total")] Detalle_Factura detalle_Factura)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Factura.Add(detalle_Factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "numero_fatura", detalle_Factura.id_factura);
            ViewBag.id_producto = new SelectList(db.Producto, "id_producto", "codigo", detalle_Factura.id_producto);
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            if (detalle_Factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "numero_fatura", detalle_Factura.id_factura);
            ViewBag.id_producto = new SelectList(db.Producto, "id_producto", "codigo", detalle_Factura.id_producto);
            return View(detalle_Factura);
        }

        // POST: Detalle_Factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalle,id_factura,id_producto,descricion,cantidad,precio_unitario,descuento_porcentaje,descuento_valor,iva_porcentaje,iva_valor,subtotal,total")] Detalle_Factura detalle_Factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "numero_fatura", detalle_Factura.id_factura);
            ViewBag.id_producto = new SelectList(db.Producto, "id_producto", "codigo", detalle_Factura.id_producto);
            return View(detalle_Factura);
        }

        // GET: Detalle_Factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            if (detalle_Factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Factura);
        }

        // POST: Detalle_Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Factura detalle_Factura = db.Detalle_Factura.Find(id);
            db.Detalle_Factura.Remove(detalle_Factura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
