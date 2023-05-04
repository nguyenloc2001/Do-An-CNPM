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
    public class QuyenHanController : Controller
    {
        // GET: QuyenHan
        QuyenDAO quyenDAO = new QuyenDAO();
        ModelQuyenHan quyenHan = null;
        List<ModelQuyenHan> listQuyenHan = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listQuyenHan = quyenDAO.findAll();
            return View(listQuyenHan);
        }

        public ActionResult Details(int id)
        {
            quyenHan = quyenDAO.findById(id);
            return View(quyenHan);
        }

        public ActionResult Create()
        {
            return View(new ModelQuyenHan());
        }

        [HttpPost]
        public ActionResult Create(ModelQuyenHan temp)
        {
            if (quyenDAO.check(temp))
            {
                ModelState.AddModelError("MaQuyen", "Mã quyền đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                quyenDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            quyenHan = quyenDAO.findById(id);
            return View(quyenHan);
        }
        [HttpPost]
        public ActionResult Edit(ModelQuyenHan temp, int id)
        {
            if (quyenDAO.check(temp))
            {
                ModelState.AddModelError("MaQuyen", "Mã quyền trùng với mã quyền khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                quyenDAO.update(temp, id);
                quyenHan = quyenDAO.findById(id);
                return View(quyenHan);
            }

        }
        public ActionResult Delete(int id)
        {
            quyenHan = quyenDAO.findById(id);
            return View(quyenHan);
        }

        [HttpPost]
        public ActionResult Delete(ModelQuyenHan temp, int id)
        {
            quyenDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            quyenDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listQuyenHan = quyenDAO.findByCode(text);
            return View(listQuyenHan);
        }
    }
}