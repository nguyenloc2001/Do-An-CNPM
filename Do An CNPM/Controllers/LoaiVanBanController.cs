using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class LoaiVanBanController : Controller
    {
        // GET: LoaiVanBan
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
                    var model = (from tempcrud in dbContext.LOAIVANBANs select tempcrud).ToList();

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
                    var model = (from tempcrud in dbContext.LOAIVANBANs select tempcrud).ToList();

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
                    var model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID_LOAIVANBAN == temp);

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
                    var model = (from tempcrud in dbContext.LOAIVANBANs select tempcrud).ToList();

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
        public ActionResult CreateCRUD(LOAIVANBAN tempCRUD)
        {
            try
            {
                if (string.IsNullOrEmpty(tempCRUD.TenLoaiVanBan))
                {
                    ModelState.AddModelError("", "Thieu thong tin");
                    return View(tempCRUD);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    dbContext.LOAIVANBANs.InsertOnSubmit(tempCRUD);
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
                    var model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID_LOAIVANBAN == temp);
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
        public ActionResult EditCRUD(LOAIVANBAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID_LOAIVANBAN == temp);
                    model.TenLoaiVanBan = user.TenLoaiVanBan;
                    model.LinhVucVanBan= user.LinhVucVanBan;
                    model.CapDo = user.CapDo;
                    model.ID_LOAIVANBAN_VANBANDEN = user.ID_LOAIVANBAN_VANBANDEN;
                    model.ID_LOAIVANBAN_VANBANDI = user.ID_LOAIVANBAN_VANBANDI;
                    model.ID_LOAIVANBAN_VANBANNOIBO = user.ID_LOAIVANBAN_VANBANNOIBO;
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
                var model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID_LOAIVANBAN == temp);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult DeleteCRUD(LOAIVANBAN user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    LOAIVANBAN model = dbContext.LOAIVANBANs.SingleOrDefault(x => x.ID_LOAIVANBAN == temp);
                    dbContext.LOAIVANBANs.DeleteOnSubmit(model);
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