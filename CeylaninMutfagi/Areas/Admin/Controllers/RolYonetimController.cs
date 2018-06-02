using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using CeylaninMutfagi.Models;
using Microsoft.AspNet.Identity;
using CeylaninMutfagi.Areas.Admin.Models;
using CeylaninMutfagi.Areas.Admin.Controllers;

namespace CeylaninMutfagi.Areas.Admin.Controllers
{
    public class RolYonetimController : AdminController
    {
        // GET: RolYonetim
        ApplicationDbContext context = new ApplicationDbContext();
       
        public ActionResult Index()
        {
            var roleStote =new  RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStote);
             var model=roleManager.Roles.ToList();
            return View(model);
        }
        public ActionResult RolEkle()
        {

            return View("");

        }
        [HttpPost]
        public ActionResult RolEkle(RolEkleModel rol)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (roleManager.RoleExists(rol.RolAd) == false)
            {
                roleManager.Create(new IdentityRole(rol.RolAd));
            }

            return RedirectToAction("Index");
        }
        public ActionResult RolKullaniciEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RolKullaniciEkle(RolKullaniciEkleModel model)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            var kullanici = userManager.FindByName(model.KullaniciAdi);

            if (!userManager.IsInRole(kullanici.Id, model.RolAdi))
            {
                userManager.AddToRole(kullanici.Id, model.RolAdi);
            }

            return RedirectToAction("Index");
        }
    }
}