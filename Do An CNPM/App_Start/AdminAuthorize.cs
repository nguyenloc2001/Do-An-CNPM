using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Do_An_CNPM.Commons
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();

        public int idChucNang { set; get; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //1. Check session : Da dang nhap => cho thuc hien filter
            //Nguoc lai thi cho tro lai trang dang nhap 

            ModelNguoiDung nguoiDungSession = (ModelNguoiDung) HttpContext.Current.Session["User"];

            if(nguoiDungSession != null)
            {
                #region //2. Check quyen : co quyen thi => cho thuc hien Filter
                // Nguoc lai thi cho quay ve trang dang nhap
                using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
                {
                    var data = (from temp in dbContext.PHANQUYENs select temp).ToList();
                    var count = data.Count(m => m.NguoiDungId == nguoiDungSession.ID && m.QuyenHanId == idChucNang);
                    if ((int)count != 0)
                    {
                        return;
                    }
                    else
                    {
                        var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                            new
                            {
                                controller = "BaoLoi",
                                action = "Index",
                                /*area = "Admin",*/
                                returnUrl = returnUrl.ToString()
                            })); 
                    }
                }
                #endregion
                return;
            }
            else
            {
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "Login",
                        /*area = "Admin",*/
                        returnUrl = returnUrl.ToString()
                    }));
            }    
        }
    }
}