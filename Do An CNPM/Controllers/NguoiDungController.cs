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
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        ModelNguoiDung nguoiDung = null;
        List<ModelNguoiDung> listNguoiDung = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listNguoiDung = nguoiDungDAO.findAll();
            return View(listNguoiDung);
        }

        public ActionResult Details(int id)
        {
            nguoiDung = nguoiDungDAO.findById(id);
            return View(nguoiDung);
        }

        public ActionResult Create()
        {
            return View(new ModelNguoiDung());
        }

        [HttpPost]
        public ActionResult Create(ModelNguoiDung temp)
        {
            if (nguoiDungDAO.check(temp))
            {
                ModelState.AddModelError("MaNhanVien", "Mã nhân viên đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                nguoiDungDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            nguoiDung = nguoiDungDAO.findById(id);
            return View(nguoiDung);
        }
        [HttpPost]
        public ActionResult Edit(ModelNguoiDung temp, int id)
        {
            if (nguoiDungDAO.check(temp))
            {
                ModelState.AddModelError("MaNhanVien", "Mã nhân viên trùng với mã nhân viên khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                nguoiDungDAO.update(temp, id);
                nguoiDung = nguoiDungDAO.findById(id);
                return View(nguoiDung);
            }

        }
        public ActionResult Delete(int id)
        {
            nguoiDung = nguoiDungDAO.findById(id);
            return View(nguoiDung);
        }

        [HttpPost]
        public ActionResult Delete(ModelNguoiDung temp, int id)
        {
            nguoiDungDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            nguoiDungDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listNguoiDung = nguoiDungDAO.findByCode(text);
            return View(listNguoiDung);
        }
    }
}
