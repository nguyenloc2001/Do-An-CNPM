using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class CongViecController : Controller
    {
        // GET: CongViec
        CongViecDAO congViecDAO = new CongViecDAO();
        ModelCongViec congViec = null;
        List<ModelCongViec> listCongViec = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listCongViec = congViecDAO.findAll();
            return View(listCongViec);
        }

        public ActionResult Details(int id)
        {
            congViec = congViecDAO.findById(id);
            return View(congViec);
        }

        public ActionResult Create()
        {
            return View(new ModelCongViec());
        }

        [HttpPost]
        public ActionResult Create(ModelCongViec temp)
        {
            if (congViecDAO.check(temp))
            {
                ModelState.AddModelError("MaCongViec", "Mã công việc đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                congViecDAO.insert(temp);
                return RedirectToAction("View");
            }
        }
        public ActionResult Edit(int id)
        {
            congViec = congViecDAO.findById(id);
            return View(congViec);
        }
        [HttpPost]
        public ActionResult Edit(ModelCongViec temp, int id)
        {
            if (congViecDAO.check(temp))
            {
                ModelState.AddModelError("MaCongViec", "Mã công việc trùng với mã công việc khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                congViecDAO.update(temp, id);
                congViec = congViecDAO.findById(id);
                return View(congViec);
            }
        }
        public ActionResult Delete(int id)
        {
            congViec = congViecDAO.findById(id);
            return View(congViec);
        }

        [HttpPost]
        public ActionResult Delete(ModelCongViec temp, int id)
        {
            congViecDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            congViecDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listCongViec = congViecDAO.findByCode(text);
            return View(listCongViec);
        }
    }
}
