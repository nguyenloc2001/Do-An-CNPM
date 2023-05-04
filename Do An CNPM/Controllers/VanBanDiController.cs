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
    public class VanBanDiController : Controller
    {
        VanBanDiDAO vanBanDiDAO = new VanBanDiDAO();
        ModelVanBanDi vanBanDi = null;
        List<ModelVanBanDi> listVanBanDi = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listVanBanDi = vanBanDiDAO.findAll();
            return View(listVanBanDi);
        }

        public ActionResult Details(int id)
        {
            vanBanDi = vanBanDiDAO.findById(id);
            return View(vanBanDi);
        }

        public ActionResult Create()
        {
            ViewBag.ListLoaiVB = vanBanDiDAO.findLoaiVB();
            return View(new ModelVanBanDi());
        }

        [HttpPost]
        public ActionResult Create(ModelVanBanDi temp)
        {
            if (vanBanDiDAO.check(temp))
            {
                ModelState.AddModelError("MaVanBan", "Mã văn bản đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                ViewBag.ListLoaiVB = vanBanDiDAO.findLoaiVB();
                vanBanDiDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ListLoaiVB = vanBanDiDAO.findLoaiVB();
            vanBanDi = vanBanDiDAO.findById(id);
            return View(vanBanDi);
        }
        [HttpPost]
        public ActionResult Edit(ModelVanBanDi temp, int id)
        {
            if (vanBanDiDAO.check(temp))
            {
                ModelState.AddModelError("MaVanBan", "Mã văn bản trùng với mã văn bản khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                ViewBag.ListLoaiVB = vanBanDiDAO.findLoaiVB();
                vanBanDiDAO.update(temp, id);
                vanBanDi = vanBanDiDAO.findById(id);
                return View(vanBanDi);
            }

        }
        public ActionResult Delete(int id)
        {
            vanBanDi = vanBanDiDAO.findById(id);
            return View(vanBanDi);
        }

        [HttpPost]
        public ActionResult Delete(ModelVanBanDi temp, int id)
        {
            vanBanDiDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            vanBanDiDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listVanBanDi = vanBanDiDAO.findByCode(text);
            return View(listVanBanDi);
        }
    }
}
