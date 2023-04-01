using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class VanBanController : Controller
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        // GET: VanBan
        public ActionResult Index()
        {
            return RedirectToAction("viewVanBan");
        }
        public ActionResult viewVanBan()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    var model1 = (from vanban in dbContext.VANBANDENs select vanban).ToList();

                    return View(model1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }

        [HttpPost]
        public ActionResult viewVanBan(VANBANDEN x)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    return View(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }
        public ActionResult viewChiTietVanBan(string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int idvanban = Convert.ToInt32(id);
                    var model1 = dbContext.VANBANDENs.SingleOrDefault(x => x.ID_VanBanDen == idvanban);

                    return View(model1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }

        /*[HttpPost]
        public ActionResult viewChiTietVanBan(string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int idvanban = Convert.ToInt32(id);
                    var model1 = dbContext.VANBANDENs.SingleOrDefault(x => x.ID_VanBanDen == idvanban);

                    return View(model1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }*/
        public ActionResult insertVanBan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertVanBan(VANBANDEN vanban)
        {
            try
            {
                if (string.IsNullOrEmpty(vanban.TenVanBanDen))
                {
                    ModelState.AddModelError("", "Thieu thong tin bai viet");
                    return View(vanban);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    dbContext.VANBANDENs.InsertOnSubmit(vanban);
                    dbContext.SubmitChanges();
                    return View(vanban);
                }
            }
            catch (Exception ex)
            {
                
                ViewBag.check = ex.Message;
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }
        public ActionResult updateVanBan(string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int idvanban = Convert.ToInt32(id);
                    var model2 = dbContext.VANBANDENs.SingleOrDefault(x => x.ID_VanBanDen == idvanban);
                    return View(model2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }
        [HttpPost]
        public ActionResult updateVanBan(VANBANDEN vanban, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int idvanban = Convert.ToInt32(id);
                    var model = dbContext.VANBANDENs.SingleOrDefault(x => x.ID_VanBanDen == idvanban);
                    model.TenVanBanDen = vanban.TenVanBanDen;
                    model.TrichYeuVanBanDen = vanban.TrichYeuVanBanDen;
                    model.SoHieuGocVanBanDen = vanban.SoHieuGocVanBanDen;
                    model.NgayVanBanDen = vanban.NgayVanBanDen;
                    model.NgayBanHanhVanBanDen = vanban.NgayBanHanhVanBanDen;
                    model.NoiLuuVanBanDen = vanban.NoiLuuVanBanDen;
                    model.SoBanPhatHanhVanBanDen = vanban.SoBanPhatHanhVanBanDen;
                    model.NgayDuyetVanBanDen = vanban.NgayDuyetVanBanDen;
                    model.NgayLuuSoVanBanDen = vanban.NgayLuuSoVanBanDen;
                    model.NoiLuuVanBanDen = vanban.NoiLuuVanBanDen;
                    model.VanBanLienQuanVanBanDen = vanban.VanBanLienQuanVanBanDen;
                    model.ID_VANBANDEN_NGUOIDUNG = vanban.ID_VANBANDEN_NGUOIDUNG;
                    dbContext.SubmitChanges();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ModelState.AddModelError("",ex.Message);
                return View();
            }
        }

        public ActionResult deleteVanBan(string id)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                int idvanban = Convert.ToInt32(id);
                var model3 = dbContext.VANBANDENs.SingleOrDefault(x => x.ID_VanBanDen == idvanban);
                return View(model3);
            }
        }
        [HttpPost]
        public ActionResult deleteVanBan(VANBANDEN vanban, string id)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                int idvanban = Convert.ToInt32(id);
                VANBANDEN model = dbContext.VANBANDENs.SingleOrDefault(x => x.ID_VanBanDen == idvanban);
                dbContext.VANBANDENs.DeleteOnSubmit(model);
                dbContext.SubmitChanges();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}