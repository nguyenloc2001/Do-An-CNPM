using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class QuyenHanController : Controller
    {
        // GET: QuyenHan
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
                    var model = (from tempcrud in dbContext.QUYENHANs select tempcrud).ToList();

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
                    var model = (from tempcrud in dbContext.QUYENHANs select tempcrud).ToList();

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
                    var model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID_QUYENHAN == temp);

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
                    var model = (from tempcrud in dbContext.QUYENHANs select tempcrud).ToList();

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
        public ActionResult CreateCRUD(QUYENHAN tempCRUD)
        {
            try
            {
                if (string.IsNullOrEmpty(tempCRUD.TenQuyenHan))
                {
                    ModelState.AddModelError("", "Thieu thong tin");
                    return View(tempCRUD);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    dbContext.QUYENHANs.InsertOnSubmit(tempCRUD);
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
                    var model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID_QUYENHAN == temp);
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
        public ActionResult EditCRUD(QUYENHAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID_QUYENHAN == temp);
                    model.TenQuyenHan = user.TenQuyenHan;
                    model.ID_QUYENHAN_NGUOIDUNG = user.ID_QUYENHAN_NGUOIDUNG;
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
                var model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID_QUYENHAN == temp);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult DeleteCRUD(QUYENHAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    QUYENHAN model = dbContext.QUYENHANs.SingleOrDefault(x => x.ID_QUYENHAN == temp);
                    dbContext.QUYENHANs.DeleteOnSubmit(model);
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