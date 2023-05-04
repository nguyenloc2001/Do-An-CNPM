using Do_An_CNPM.Commons;
using Do_An_CNPM.DAO;
using Do_An_CNPM.Models;
using Do_An_CNPM.Models.Model;
using System.Collections.Generic;
using System.Web.Mvc;

using System.Linq;
using PagedList;
using Do_An_CNPM.Mapper;

namespace Do_An_CNPM.Controllers
{
    public class ChucVuController : Controller
    {
        // GET: CHUCVU
        ChucVuDAO chucVuDAO = new ChucVuDAO();
        ModelChucVu chucVu = null;
        List<ModelChucVu> listChucVu = null;

        
        public ActionResult Index()
        {
            return RedirectToAction("View");
        }
        
        public ActionResult View()
        {
            listChucVu = chucVuDAO.findAll();
            return View(listChucVu);
        }
        string connectString = System.Configuration.ConfigurationManager.ConnectionStrings["websiteDBConnectionString"].ToString();
        public ActionResult GetPaging (int? size, int? page)
        {
            
            
            using (DataWebsiteDataContext dbContext = new DataWebsiteDataContext(connectString))
            {
                
                List<SelectListItem> items = new List<SelectListItem>();
                items.Add(new SelectListItem { Text = "5", Value = "5" });
                items.Add(new SelectListItem { Text = "10", Value = "10" });
                items.Add(new SelectListItem { Text = "20", Value = "20" });
                items.Add(new SelectListItem { Text = "25", Value = "25" });
                items.Add(new SelectListItem { Text = "50", Value = "50" });
                items.Add(new SelectListItem { Text = "100", Value = "100" });
                items.Add(new SelectListItem { Text = "200", Value = "200" });

                // 1.1. Giữ trạng thái kích thước trang được chọn trên DropDownList
                foreach (var item in items)
                {
                    if (item.Value == size.ToString()) item.Selected = true;
                }

                // 1.2. Tạo các biến ViewBag
                ViewBag.size = items; // ViewBag DropDownList
                ViewBag.currentSize = size; // tạo biến kích thước trang hiện tại

                // 2. Nếu page = null thì đặt lại là 1.
                page = page ?? 1; //if (page == null) page = 1;

                // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
                // theo LinkID mới có thể phân trang.
                var chucvu = (from temp in dbContext.CHUCVUs orderby temp.ID select temp);
                // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
                // 4. Tạo kích thước trang (pageSize), mặc định là 5.
                int pageSize = (size ?? 5);

                // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
                // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
                int pageNumber = (page ?? 1);

                // 5. Trả về các Link được phân trang theo kích thước và số trang.

                return View(chucvu.ToPagedList(pageNumber, pageSize));
            } 

        }
        
        public ActionResult Details(int id)
        {
            chucVu = chucVuDAO.findById(id);
            return View(chucVu);
        }
        /*[AdminAuthorize(idChucNang = 2)]*/
        public ActionResult Create()
        {
            return View(new ModelChucVu());
        }

        [HttpPost]
        public ActionResult Create(ModelChucVu temp)
        {
            if (ModelState.IsValidField(temp.MaChucVu))
            {
                if (chucVuDAO.check(temp))
                {
                    ModelState.AddModelError("MaChucVu", "Mã chức vụ đã tồn tại");
                }
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                chucVuDAO.insert(temp);
                return RedirectToAction("View");
            }     
        }
        public ActionResult Edit(int id)
        {
            chucVu = chucVuDAO.findById(id);
            return View(chucVu);
        }
        [HttpPost]
        public ActionResult Edit(ModelChucVu temp, int id)
        {
            if (chucVuDAO.check(temp))
            {
                ModelState.AddModelError("MaChucVu", "Mã chức vụ trùng với mã chức vụ khác");
            }
            if (!ModelState.IsValid)
            {
                return View(temp);
            }
            else
            {
                chucVuDAO.update(temp, id);
                chucVu = chucVuDAO.findById(id);
                return View(chucVu);
            }
            
        }
        public ActionResult Delete(int id)
        {
            chucVu = chucVuDAO.findById(id);
            return View(chucVu);
        }

        [HttpPost]
        public ActionResult Delete(ModelChucVu temp, int id)
        {
            chucVuDAO.delete(id);
            return RedirectToAction("View");
        }
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string text)
        {
            listChucVu = chucVuDAO.findByCode(text);
            return View(listChucVu);
        }
    }
}