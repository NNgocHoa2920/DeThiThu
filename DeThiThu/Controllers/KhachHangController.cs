using DeThiThu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Newtonsoft.Json;

namespace DeThiThu.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly AppDbContext _db;
        public KhachHangController(AppDbContext db) {_db = db;}
        public IActionResult Index()
        {
           var listKH=  _db.KhachHangs.ToList();
            return View(listKH);
        }
        public IActionResult Details(Guid id) 
        { 
            //tìm khach hang muon xem
            var kh = _db.KhachHangs.Find(id);
            return View(kh);
        }
        //dùng để tạo view create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(KhachHang kh)
        {
            _db.KhachHangs.Add(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)//tạo trang edit có chứa thông tin cần edit
        {
            //tìm khach hang muon xem
            var kh = _db.KhachHangs.Find(id);
            var jsonData = JsonConvert.SerializeObject(kh);
            //lưu dư liệu vào sesion
            HttpContext.Session.SetString("edited", jsonData);
            return View(kh);
        }
        [HttpPost]
        public IActionResult Edit( KhachHang kh)
        {
           
            _db.KhachHangs.Update(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id) 
        {
            var kh = _db.KhachHangs.Find(id);
            //ép kiểu dữ liệu của kh vừa tìm sang json
            var jsonData = JsonConvert.SerializeObject(kh);
            //lưu dư liệu vào sesion
            HttpContext.Session.SetString("deleted", jsonData);
            _db.KhachHangs.Remove(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult RollBack()
        {
            if(HttpContext.Session.Keys.Contains("edited"))
            {
                //var jsonData = HttpContext.Session.GetString("deleted");
                var jsonData = HttpContext.Session.GetString("edited");
                //tạo 1 đối tượng mố có dữ liệu y hệt dữ liệu cũ
                var deletedKH = JsonConvert.DeserializeObject<KhachHang>(jsonData);
                //add lại vào db
                //  _db.KhachHangs.Add(deletedKH);
                _db.KhachHangs.Update(deletedKH);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Không có ");
            }
        }
    }
}
