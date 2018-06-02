using CeylaninMutfagi.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeylaninMutfagi.Areas.Admin.Controllers
{
    public class yemekController : AdminController
    {
        yemekTatliEntities db = new yemekTatliEntities();
        // GET: Admin/yemek
        public ActionResult Index()
        {
            var model = db.yemek.OrderByDescending(x => x.yemekID).ToList();
            return View(model);
        }
        public ActionResult Add()
        {
            ViewBag.yKategoriID = new SelectList(db.yemekKategori.ToList(), "yKategoriID", "yKategoriAdi");
            return View();
        }
        const string resimDosyaYolu = "/Content/yemek_resim/";
        public ActionResult AddYemek(YemekModdel model)
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
                yemek nesneYemek = new yemek();

                nesneYemek.yemekAdi = model.yemekAdi;
                nesneYemek.yemekKategori = model.yemekKategori;
                nesneYemek.malzemeler = model.malzemeler;
                nesneYemek.yapilisi = model.yapilisi;
                nesneYemek.ResimYolu = resimDosyaYolu + filename;
                nesneYemek.populerlik = model.populerlik;

                db.yemek.Add(nesneYemek);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.yemek.Find(id);
            ViewBag.yKategoriID = new SelectList(db.yemekKategori.ToList(), "yKategoriID", "yKategoriAdi");
            db.yemek.FirstOrDefault(x => x.yemekID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(yemek model)
        {

            if (ModelState.IsValid)
            {
                ViewBag.yKategoriID = new SelectList(db.yemekKategori.ToList(), "yKategoriID", "yKategoriAdi");
                var yemekKayit = db.yemek.Find(model.yemekID);
                TryUpdateModel(yemekKayit);
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
            ViewBag.yKategoriID = new SelectList(db.yemekKategori.ToList(), "yKategoriID", "yKategoriAdi");
            var model = db.yemek.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var model = db.yemek.Find(id);
            db.yemek.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult kategoriIndex()
        {
            var model = db.yemekKategori.OrderBy(x => x.yKategoriID).ToList();
            return View(model);


        }
        public ActionResult KategoriEkle()
        {

            return View();

        }
        public ActionResult AddKategoriEkle(kategoriEkleModel model)
        {


            yemekKategori nesneKategori = new yemekKategori();

            nesneKategori.yKategoriAdi = model.KategoriAd;


            db.yemekKategori.Add(nesneKategori);
            db.SaveChanges();
        
            return RedirectToAction("KategoriEkle");
    }

        [HttpGet]
        public ActionResult kategoriEdit(int id)
        {
            var model = db.yemekKategori.Find(id);
            db.yemekKategori.FirstOrDefault(x => x.yKategoriID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult kategoriEdit(yemekKategori model)
        {
            if (ModelState.IsValid)
            {

                var attached = db.yemekKategori.Attach(model);
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
            var model = db.yemekKategori.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult kategoriDeleteConfirm(int id)
        {
            var model = db.yemekKategori.Find(id);
            db.yemekKategori.Remove(model);
            db.SaveChanges();
            return RedirectToAction("kategoriIndex");
        }
    }
}