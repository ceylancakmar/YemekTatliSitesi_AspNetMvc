using CeylaninMutfagi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeylaninMutfagi.Areas.Admin.Controllers
{
    public class TatliController : AdminController
    {
        // GET: Admin/Tatli
        yemekTatliEntities db = new yemekTatliEntities();
     
        public ActionResult Index()
        {
            var model = db.tatli.OrderByDescending(x => x.tatliID).ToList();
            return View(model);
        }
        public ActionResult Add()
        {
            ViewBag.tKategoriID = new SelectList(db.tatliKategori.ToList(), "tKategoriID", "tKategoriAdi");
            return View();
        }
        const string resimDosyaYolu = "/Content/tatli_resim/";
        public ActionResult AddTatli(TatliModel model)
        {
            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if (model.Resim != null && model.Resim.ContentLength > 0)
                {
                    filename = model.Resim.FileName;
                    var path = System.IO.Path.Combine(Server.MapPath("~" + resimDosyaYolu), filename);
                    model.Resim.SaveAs(path);
                }
                tatli nesneTatli = new tatli();

                nesneTatli.tatliAdi = model.tatliAdi;
                nesneTatli.tatliKategori = model.tatliKategori;
                nesneTatli.malzemeler = model.malzemeler;
                nesneTatli.yapilisi = model.yapilisi;
                nesneTatli.ResimYolu = resimDosyaYolu + filename;
                nesneTatli.populerlik = model.populerlik;

                db.tatli.Add(nesneTatli);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.tatli.Find(id);
            ViewBag.tKategoriID = new SelectList(db.tatliKategori.ToList(), "tKategoriID", "tKategoriAdi");
            db.tatli.FirstOrDefault(x => x.tatliID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tatli model)
        {

            if (ModelState.IsValid)
            {
                ViewBag.tKategoriID = new SelectList(db.yemekKategori.ToList(), "tKategoriID", "tKategoriAdi");
                var tatliKayit = db.tatli.Find(model.tatliID);
                TryUpdateModel(tatliKayit);
                db.SaveChanges();

            }
            else
            {


                return View(model);
            }

            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.tKategoriID = new SelectList(db.yemekKategori.ToList(), "tKategoriID", "tKategoriAdi");
            var model = db.tatli.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var model = db.tatli.Find(id);
            db.tatli.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriIndex()
        {
            var model = db.tatliKategori.OrderBy(x => x.tKategoriID).ToList();
            return View(model);


        }
        public ActionResult KategoriEkle()
        {

            return View();

        }
        public ActionResult AddKategoriEkle(kategoriEkleModel model)
        {


            tatliKategori nesneKategori = new tatliKategori();

            nesneKategori.tKategoriAdi = model.KategoriAd;


            db.tatliKategori.Add(nesneKategori);
            db.SaveChanges();

            return RedirectToAction("KategoriEkle");
        }

        [HttpGet]
        public ActionResult kategoriEdit(int id)
        {
            var model = db.tatliKategori.Find(id);
            db.tatliKategori.FirstOrDefault(x => x.tKategoriID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult kategoriEdit(tatliKategori model)
        {
            if (ModelState.IsValid)
            {

                var attached = db.tatliKategori.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return View(model);
            }


            return RedirectToAction("kategoriIndex");
        }
        [HttpGet]
        public ActionResult kategoriDelete(int id)
        {
            var model = db.tatliKategori.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult kategoriDeleteConfirm(int id)
        {
            var model = db.tatliKategori.Find(id);
            db.tatliKategori.Remove(model);
            db.SaveChanges();
            return RedirectToAction("kategoriIndex");
        }

    }
}