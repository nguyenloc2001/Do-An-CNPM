using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class TrangThaiVanBanController : Controller
    {
        // GET: TrangThaiVanBan
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
                    var model = (from tempcrud in dbContext.TRANGTHAIVANBANs select tempcrud).ToList();

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
                    var model = (from tempcrud in dbContext.TRANGTHAIVANBANs select tempcrud).ToList();

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
                    var model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID_TRANGTHAIVANBAN == temp);

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
                    var model = (from tempcrud in dbContext.TRANGTHAIVANBANs select tempcrud).ToList();

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
        public ActionResult CreateCRUD(TRANGTHAIVANBAN tempCRUD)
        {
            try
            {
                if (string.IsNullOrEmpty(tempCRUD.TenTrangThai))
                {
                    ModelState.AddModelError("", "Thieu thong tin");
                    return View(tempCRUD);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    dbContext.TRANGTHAIVANBANs.InsertOnSubmit(tempCRUD);
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
                    var model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID_TRANGTHAIVANBAN == temp);
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
        public ActionResult EditCRUD(TRANGTHAIVANBAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID_TRANGTHAIVANBAN == temp);
                    model.TenTrangThai = user.TenTrangThai;
                    model.ID_TRANGTHAIVANBAN_VANBANDEN = user.ID_TRANGTHAIVANBAN_VANBANDEN;
                    model.ID_TRANGTHAIVANBAN_VANBANDI = user.ID_TRANGTHAIVANBAN_VANBANDI;
                    model.ID_TRANGTHAIVANBAN_VANBANNOIBO = user.ID_TRANGTHAIVANBAN_VANBANNOIBO;
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
                var model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID_TRANGTHAIVANBAN == temp);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult DeleteCRUD(TRANGTHAIVANBAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    TRANGTHAIVANBAN model = dbContext.TRANGTHAIVANBANs.SingleOrDefault(x => x.ID_TRANGTHAIVANBAN == temp);
                    dbContext.TRANGTHAIVANBANs.DeleteOnSubmit(model);
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