using Do_An_CNPM.DAO;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Do_An_CNPM.Controllers
{
    public class HomeController : Controller
    {
        LoginDAO loginDAO = new LoginDAO();
        ModelNguoiDung nguoiDung = new ModelNguoiDung();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string MaNhanVien, string MatKhau)
        {
            /*string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();*/
            if (ModelState.IsValid)
            {
                /* using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                 {
                     var obj = (from temp in dbContext.NGUOIDUNGs where (temp.MaNhanVien.Contains(MaNhanVien) && temp.MatKhau.Contains(MatKhau)) select temp).ToList();
                     if (obj.Count > 0)
                     {
                         Session["UserID"] = obj.FirstOrDefault().ID.ToString();
                         Session["UserName"] = obj.FirstOrDefault().HoVaTen.ToString();
                         return RedirectToAction("UserDashBoard");
                     }   
                 }      */
                nguoiDung = loginDAO.findData(MaNhanVien, MatKhau);
                if (nguoiDung.MaNhanVien != null && nguoiDung.MatKhau != null)
                {
                    Session["User"] = nguoiDung;  
                    return RedirectToAction("UserDashBoard");
                }
            }
            ViewBag.Message = "Fail";
            return View(MaNhanVien, MatKhau);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["User"] != null)
            {
                ViewBag.User = (ModelNguoiDung) Session["User"];
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            FormsAuthentication.SignOut();//remove session form authent
            return RedirectToAction("Login");
        }

    }
}