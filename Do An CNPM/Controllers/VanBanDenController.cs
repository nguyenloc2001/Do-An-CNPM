using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO;
using Do_An_CNPM.DAO.Interface;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class VanBanDenController : Controller
    {
        VanBanDenDAO vanBanDenDAO = new VanBanDenDAO();
        ModelVanBanDen vanBanDen = null;
        List<ModelVanBanDen> listVanBanDen = null;

        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        public ActionResult View()
        {
            listVanBanDen = vanBanDenDAO.findAll();
            return View(listVanBanDen);
        }

        public ActionResult Details(int id)
        {
            vanBanDen = vanBanDenDAO.findById(id);
            return View(vanBanDen);
        }

        public ActionResult Create()
        {
            ViewBag.ListLoaiVB = vanBanDenDAO.findLoaiVB();
            return View(new ModelVanBanDen());
        }
        //lay loai van ban tu database
        public ActionResult ChooseLoaiVanBan()
        {
            LoaiDAO loaiDAO = new LoaiDAO();
            ModelLoaiVanBan lists = new ModelLoaiVanBan();
            lists.LoaiVanBanList = loaiDAO.findAll();
            return PartialView(lists);
        }


        [HttpPost]
        public ActionResult Create(ModelVanBanDen temp, HttpPostedFileBase file)
        {
            if (vanBanDenDAO.check(temp))
            {
                ModelState.AddModelError("MaVanBan", "Mã văn bản đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                ViewBag.ListLoaiVB = vanBanDenDAO.findLoaiVB();
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string FileName = Path.GetFileName(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), FileName);
                        file.SaveAs(path);
                        temp.NoiDungVanBan = FileName;
                        temp.urlNoiDungVanBan = path;

                    }
                    try
                    {
                        vanBanDenDAO.insert(temp);
                        ViewBag.Message = "File Uploaded Successfully!!";
                        return RedirectToAction("View");
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    
                }
                catch
                {
                    ViewBag.Message = "File upload failed!!";
                    return View();
                }
            }
        }

        public ActionResult test()
        {
            ViewBag.ListLoaiVB = vanBanDenDAO.findLoaiVB();
            return View(new ModelVanBanDen());
        }
        //lay loai van ban tu database
        
        [HttpPost]
        public ActionResult test(ModelVanBanDen temp)
        {
            if (vanBanDenDAO.check(temp))
            {
                ModelState.AddModelError("MaVanBan", "Mã văn bản đã tồn tại");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                ViewBag.ListLoaiVB = vanBanDenDAO.findLoaiVB();
                vanBanDenDAO.insert(temp);
                return RedirectToAction("View");
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ListLoaiVB = vanBanDenDAO.findLoaiVB();
            vanBanDen = vanBanDenDAO.findById(id);
            return View(vanBanDen);
        }
        [HttpPost]
        public ActionResult Edit(ModelVanBanDen temp, int id)
        {
            if (vanBanDenDAO.check(temp))
            {
                ModelState.AddModelError("MaVanBan", "Mã văn bản trùng với mã văn bản khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                vanBanDenDAO.update(temp, id);
                vanBanDen = vanBanDenDAO.findById(id);
                return View(vanBanDen);
            }

        }
        public ActionResult Delete(int id)
        {
            vanBanDen = vanBanDenDAO.findById(id);
            return View(vanBanDen);
        }

        [HttpPost]
        public ActionResult Delete(ModelVanBanDen temp, int id)
        {
            vanBanDenDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search(string text)
        {
            vanBanDenDAO.findByCode(text);
            return View();
        }

        [HttpPost]
        public ActionResult SearchText(string text)
        {
            listVanBanDen = vanBanDenDAO.findByCode(text);
            return View(listVanBanDen);
        }
    }
}