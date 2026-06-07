using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;


namespace MyApp.Controllers
{
    public class ItemsController : Controller
    {
        // Khai báo biến _context để làm việc với Database thông qua Entity Framework Core.
        // readonly Chỉ được gán giá trị một lần trong constructor.
        private readonly MyAppContext _context;

        public ItemsController(MyAppContext context)
        {
            _context = context;
        }

        // Hiển thị ds sản phẩm
        public async Task<IActionResult> Index()
        {
            // Truyền danh sách các Item từ database vào view để hiển thị.
            var item = await _context.Items.ToListAsync();
            return View(item);
        }

        // Hiển thị trang thêm các sản phẩm
        public IActionResult Create()
        {
            return View();
        }

        // Thêm sản phẩm vào database
        /* [Bind("Id", "Name", "Price")]: chỉ định những thuộc tính được nhận từ form 
         và gán vào đối tượng Item khi form được submit. */
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "Name", "Price")] Item item)
        {
            // kta dữ liệu ở phần Models -> Item.cx
            if(ModelState.IsValid)
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                // nếu thành công thì chuyển sang trang index (ds sản phẩm)
                return RedirectToAction("Index");
            }
            // nếu ko hợp lệ thì Hiển thị lại form Create và giữ nguyên dữ liệu người dùng đã nhập.
            return View(item);
        }

        // Sửa sản phẩm
        [HttpGet]
        // Hiển thị dữ liệu sẵn trên form
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Price")] Item item)
        {
            if (id != item.Id)
            {
                NotFound();
            }    

            if(ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }    

            return View(item);
        }

        //public async Task<IActionResult> Delete(int id, [Bind("Id", "Name", "Price")] Item item)
        //{
        //    if (id == item.Id)
        //    {
        //        _context.Items.Remove(item);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(item);
        //}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
