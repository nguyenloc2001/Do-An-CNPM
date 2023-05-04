﻿using Do_An_CNPM.DAO;
using Do_An_CNPM.Mapper;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Do_An_CNPM.Controllers
{
    public class UploadController : Controller
    {
        // GET: UploadController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UploadFiles()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles(ModelVanBanDen vanBan,HttpPostedFileBase[] files)
        {
            URLVanBanDenDAO uRLVanBanDenDAO = new URLVanBanDenDAO();
            VanBanDenDAO vanBanDenDAO = new VanBanDenDAO();
            string FileName, FileUrl;
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                        uRLVanBanDenDAO.insert(vanBan.MaVanBan,InputFileName,ServerSavePath);
                        vanBan.NoiDungVanBan = (string) InputFileName;
                        vanBan.urlVanBanLienQuanVanBan = (string) ServerSavePath;
                    }
                }
               
                vanBanDenDAO.insert(vanBan);
                ViewBag.message = "thanh cong";

            }
            return View(vanBan);
        }
    }
}