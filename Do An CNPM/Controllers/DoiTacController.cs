using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class DoiTacController : Controller
    {
        // GET: DoiTac
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
                    var model = (from tempcrud in dbContext.DOITACs select tempcrud).ToList();

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
                    var model = (from tempcrud in dbContext.DOITACs select tempcrud).ToList();

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
                    var model = dbContext.DOITACs.SingleOrDefault(x => x.ID_DOITAC == temp);

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
                    var model = (from tempcrud in dbContext.DOITACs select tempcrud).ToList();

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
        public ActionResult CreateCRUD(DOITAC tempCRUD)
        {
            try
            {
                if (string.IsNullOrEmpty(tempCRUD.TenDoiTac))
                {
                    ModelState.AddModelError("", "Thieu thong tin");
                    return View(tempCRUD);
                }
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    dbContext.DOITACs.InsertOnSubmit(tempCRUD);
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
                    var model = dbContext.DOITACs.SingleOrDefault(x => x.ID_DOITAC == temp);
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
        public ActionResult EditCRUD(DOITAC user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    var model = dbContext.DOITACs.SingleOrDefault(x => x.ID_DOITAC == temp);
                    model.TenDoiTac = user.TenDoiTac;
                    model.PhanLoai = user.PhanLoai;
                    model.ID_DOITAC_TRANGTHAIVANBAN = user.ID_DOITAC_TRANGTHAIVANBAN;
                    model.ID_DOITAC_VANBANDEN = user.ID_DOITAC_VANBANDEN;
                    model.ID_DOITAC_VANBANDI = user.ID_DOITAC_VANBANDI;
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
                var model = dbContext.DOITACs.SingleOrDefault(x => x.ID_DOITAC == temp);
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult DeleteCRUD(DOITAC user, string id)
        {
            try
            {
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    int temp = Convert.ToInt32(id);
                    DOITAC model = dbContext.DOITACs.SingleOrDefault(x => x.ID_DOITAC == temp);
                    dbContext.DOITACs.DeleteOnSubmit(model);
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