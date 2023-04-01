using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class PhongBanController : Controller
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();

        public ActionResult Index()
        {
            return RedirectToAction("ViewCRUD");
        }
        public ActionResult ViewCRUD()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    var model = (from tempcrud in dbContext.PHONGBANs select tempcrud).ToList();

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
        [HttpPost]
        public ActionResult ViewCRUD1()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    var model = (from tempcrud in dbContext.PHONGBANs select tempcrud).ToList();

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }
        public ActionResult DetailsCRUD(string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID_PHONGBAN == temp);

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }
        /*[HttpPost]
        public ActionResult DetailsApi()
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    var model = (from tempcrud in dbContext.PHONGBANs select tempcrud).ToList();

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }*/
        public ActionResult CreateCRUD()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCRUD(PHONGBAN tempCRUD)
        {
            try
            {
                if (string.IsNullOrEmpty(tempCRUD.TenPhongBan))
                {
                    ModelState.AddModelError("", "Thieu thong tin");
                    return View(tempCRUD);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    dbContext.PHONGBANs.InsertOnSubmit(tempCRUD);
                    dbContext.SubmitChanges();
                    return View(tempCRUD);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }
        public ActionResult EditCRUD(string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID_PHONGBAN == temp);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditCRUD(PHONGBAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID_PHONGBAN == temp);
                    model.TenPhongBan = user.TenPhongBan;
                    model.SoNhanVien = user.SoNhanVien;
                    model.ID_PHONGBAN_QUYENHAN = user.ID_PHONGBAN_QUYENHAN;
                    dbContext.SubmitChanges();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }

        public ActionResult DeleteCRUD(string id)
        {
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                int temp = Convert.ToInt32(id);
                var model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID_PHONGBAN == temp);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult DeleteCRUD(PHONGBAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    PHONGBAN model = dbContext.PHONGBANs.SingleOrDefault(x => x.ID_PHONGBAN == temp);
                    dbContext.PHONGBANs.DeleteOnSubmit(model);
                    dbContext.SubmitChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ViewBag.check = ex.Message;
                return View();
            }
        }
    }
}