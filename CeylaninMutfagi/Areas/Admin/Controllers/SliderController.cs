using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CeylaninMutfagi.Areas.Admin.Models;

namespace CeylaninMutfagi.Areas.Admin.Controllers
{

    public class SliderController :AdminController
    {
        // GET: Admin/Slider
        yemekTatliEntities db = new yemekTatliEntities();
        public ActionResult Index()
        {
            var model = db.Slider.OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        public ActionResult Add()
        {

            return View();
        }
        const string resimDosyaYolu = "/Content/slider_resim/";
        public ActionResult AddSlider(SliderModel model)
        {
            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if (model.Resim!=null&& model.Resim.ContentLength>0)
                {
                     filename = model.Resim.FileName;
                    var path= System.IO.Path.Combine(Server.MapPath("~"+resimDosyaYolu),filename);
                    model.Resim.SaveAs(path);
                }
                Slider slider = new Slider();
                slider.BaslangicTarihi = model.BaslangicTarihi;
                slider.BitisTarihi = model.BitisTarihi;
                slider.SliderText = model.SliderText;
                slider.ResimYolu = resimDosyaYolu + filename;
                db.Slider.Add(slider);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           var model=db.Slider.Find(id);
            db.Slider.FirstOrDefault(x=>x.ID==id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Slider model)
        {
            if (ModelState.IsValid)
            {

                var attached = db.Slider.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else {
                return View(model);
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Slider.Find(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            var model = db.Slider.Find(id);
            db.Slider.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}