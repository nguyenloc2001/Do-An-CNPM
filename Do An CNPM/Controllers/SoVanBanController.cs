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
    public class SoVanBanController : Controller
    {
        // GET: SOVANBAN
        SoVanBanDAO soVanBanDAO = new SoVanBanDAO();
        ModelSoVanBan soVanBan = null;
        List<ModelSoVanBan> listSoVanBan = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listSoVanBan = soVanBanDAO.findAll();
            return View(listSoVanBan);
        }

        public ActionResult Details(int id)
        {
            soVanBan = soVanBanDAO.findById(id);
            return View(soVanBan);
        }

        public ActionResult Create()
        {
            return View(new ModelSoVanBan());
        }

        [HttpPost]
        public ActionResult Create(ModelSoVanBan temp)
        {
            if (soVanBanDAO.check(temp))
            {
                ModelState.AddModelError("MaSoVanBan", "Mã sổ văn bản đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                soVanBanDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            soVanBan = soVanBanDAO.findById(id);
            return View(soVanBan);
        }
        [HttpPost]
        public ActionResult Edit(ModelSoVanBan temp, int id)
        {
            if (soVanBanDAO.check(temp))
            {
                ModelState.AddModelError("MaSoVanBan", "Mã sổ văn bản trùng với mã sổ văn bản khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                soVanBanDAO.update(temp, id);
                soVanBan = soVanBanDAO.findById(id);
                return View(soVanBan);
            }

        }
        public ActionResult Delete(int id)
        {
            soVanBan = soVanBanDAO.findById(id);
            return View(soVanBan);
        }

        [HttpPost]
        public ActionResult Delete(ModelSoVanBan temp, int id)
        {
            soVanBanDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            soVanBanDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listSoVanBan = soVanBanDAO.findByCode(text);
            return View(listSoVanBan);
        }
    }
}