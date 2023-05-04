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
    public class PhongBanController : Controller
    {
        PhongBanDAO phongBanDAO = new PhongBanDAO();
        ModelPhongBan phongBan = null;
        List<ModelPhongBan> listPhongBan = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listPhongBan = phongBanDAO.findAll();
            return View(listPhongBan);
        }

        public ActionResult Details(int id)
        {
            phongBan = phongBanDAO.findById(id);
            return View(phongBan);
        }

        public ActionResult Create()
        {
            return View(new ModelPhongBan());
        }

        [HttpPost]
        public ActionResult Create(ModelPhongBan temp)
        {
            if (phongBanDAO.check(temp))
            {
                ModelState.AddModelError("MaPhongBan", "Mã phòng ban đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                phongBanDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            phongBan = phongBanDAO.findById(id);
            return View(phongBan);
        }
        [HttpPost]
        public ActionResult Edit(ModelPhongBan temp, int id)
        {
            if (phongBanDAO.check(temp))
            {
                ModelState.AddModelError("MaPhongBan", "Mã phòng ban trùng với mã phòng ban khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                phongBanDAO.update(temp, id);
                phongBan = phongBanDAO.findById(id);
                return View(phongBan);
            }

        }
        public ActionResult Delete(int id)
        {
            phongBan = phongBanDAO.findById(id);
            return View(phongBan);
        }

        [HttpPost]
        public ActionResult Delete(ModelPhongBan temp, int id)
        {
            phongBanDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            phongBanDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listPhongBan = phongBanDAO.findByCode(text);
            return View(listPhongBan);
        }
    }
}