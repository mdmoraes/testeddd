﻿using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AgendaContato.Domain.Entities;

namespace AgendaContato.Controllers
{
    public class ContatoController : Controller
    {
        private AgendaContatoContext db = new AgendaContatoContext();

        // GET: Contato
        public async Task<ActionResult> Index()
        {
            return View(await db.Contatoes.ToListAsync());
        }

        // GET: Contato/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = await db.Contatoes.FindAsync(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return PartialView(contato);
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdContato,Nome,Telefone,Email")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contatoes.Add(contato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        // GET: Contato/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = await db.Contatoes.FindAsync(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdContato,Nome,Telefone,Email")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: Contato/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = await db.Contatoes.FindAsync(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contato contato = await db.Contatoes.FindAsync(id);
            db.Contatoes.Remove(contato);
            await db.SaveChangesAsync();
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
