using Do_An_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        public ActionResult Index()
        {
            return RedirectToAction("Search");
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(TimKiem param)
        {
            if (param == null)
            {
                ViewBag.check = "Chua nhap thong tin";
                return View();
            }
            else
            {
                string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
                try
                {
                    using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                    {
                        string temp = deleteSpace(param);
                        if (param.thoiGianSearch != null)
                        {
                            //var ketqua = from vanban in dbContext.VANBANDENs where vanban.NgayVanBanDen.Date.CompareTo(param.thoiGianSearch.Date) select vanban;
                            var ketqua = dbContext.VANBANDENs.Where(x => DateTime.Compare(x.NgayVanBanDen.Date, param.thoiGianSearch.Date) <= 0).Select(x => x).ToList();
                            return RedirectToAction("viewVanBan", "VanBan",ketqua);  
                        }
                        if (temp.Equals("vanbanden"))
                        {
                            
                        }
                        else if (temp.Equals("vanbandi"))
                        {

                        }
                        else if (temp.Equals("vanbannoibo"))
                        {

                        }
                        else
                        {
                            ViewBag.check = "loi";
                            return View();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.check = ex.Message;
                    return View();
                }
            }


            return View();
        }
        private string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private string deleteSpace(TimKiem param)
        {
            string[] arr = param.GetType().GetProperties().Select(prop => {
                object value = prop.GetValue(param, null);
                return value == null ? null : value.ToString();
            }).ToArray();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                stringBuilder.Append(arr[i]);
            }
            string temp = stringBuilder.ToString().Trim().Replace(" ", "").ToLower();
            convertToUnSign(temp);
            return temp;
        }
    }
}
