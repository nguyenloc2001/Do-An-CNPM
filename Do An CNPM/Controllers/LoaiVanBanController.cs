using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class LoaiVanBanController : Controller
    {
        // GET: LoaiVanBan
        LoaiDAO loaiDAO = new LoaiDAO();
        ModelLoaiVanBan loaiVanBan = null;
        List<ModelLoaiVanBan> listLoaiVanBan = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            
            listLoaiVanBan = loaiDAO.findAll();
                        
            return View(listLoaiVanBan);
        }

        public ActionResult Details(int id)
        {
            loaiVanBan = loaiDAO.findById(id);
            return View(loaiVanBan);
        }

        public ActionResult Create()
        {
            return View(new ModelLoaiVanBan());
        }

        [HttpPost]
        public ActionResult Create(ModelLoaiVanBan temp)
        {
            if (loaiDAO.check(temp))
            {
                ModelState.AddModelError("MaLoaiVanBan", "Mã loại văn bản đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                loaiDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            loaiVanBan = loaiDAO.findById(id);
            return View(loaiVanBan);
        }
        [HttpPost]
        public ActionResult Edit(ModelLoaiVanBan temp, int id)
        {
            if (loaiDAO.check(temp))
            {
                ModelState.AddModelError("MaLoaiVanBan", "Mã loại văn bản trùng với mã loại văn bản khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                loaiDAO.update(temp, id);
                loaiVanBan = loaiDAO.findById(id);
                return View(loaiVanBan);
            }
        }
        public ActionResult Delete(int id)
        {
            loaiVanBan = loaiDAO.findById(id);
            return View(loaiVanBan);
        }

        [HttpPost]
        public ActionResult Delete(ModelLoaiVanBan temp, int id)
        {
            loaiDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            loaiDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listLoaiVanBan = loaiDAO.findByCode(text);
            return View(listLoaiVanBan);
        }

        public JsonResult CheckMa(string code)
        {
            if (loaiDAO.check(code) == true)
                return Json(false, JsonRequestBehavior.AllowGet);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}