using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class LuuTruController : Controller
    {
        // GET: LUUTRU
        LuuTruDAO luuTruDAO = new LuuTruDAO();
        ModelLuuTru luuTru = null;
        List<ModelLuuTru> listluuTru = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listluuTru = luuTruDAO.findAll();
            return View(listluuTru);
        }

        public ActionResult Details(int id)
        {
            luuTru = luuTruDAO.findById(id);
            return View(luuTru);
        }

        public ActionResult Create()
        {
            ViewBag.listKL = luuTruDAO.getKieuLuu();
            return View(new ModelLuuTru());
        }

        [HttpPost]
        public ActionResult Create(ModelLuuTru temp, FormCollection formCollection)
        {
            if (luuTruDAO.check(temp))
            {
                ModelState.AddModelError("MaLuuTru", "Mã lưu trữ đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                ViewBag.listKL = luuTruDAO.getKieuLuu();
                temp.NoiLuu = formCollection["KLT"];
                luuTruDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.listKL = luuTruDAO.getKieuLuu();
            luuTru = luuTruDAO.findById(id);
            return View(luuTru);
        }
        [HttpPost]
        public ActionResult Edit(ModelLuuTru temp, int id, FormCollection formCollection)
        {
            if (luuTruDAO.check(temp))
            {
                ModelState.AddModelError("MaLuuTru", "Mã lưu trữ trùng với mã lưu trữ khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                ViewBag.listKL = luuTruDAO.getKieuLuu();
                temp.NoiLuu = formCollection["KLT"];
                luuTruDAO.update(temp, id);
                luuTru = luuTruDAO.findById(id);
                return View(luuTru);
            }
            
        }
        public ActionResult Delete(int id)
        {
            luuTru = luuTruDAO.findById(id);
            return View(luuTru);
        }

        [HttpPost]
        public ActionResult Delete(ModelLuuTru temp, int id)
        {
            luuTruDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            luuTruDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listluuTru = luuTruDAO.findByCode(text);
            return View(listluuTru);
        }
    }
}