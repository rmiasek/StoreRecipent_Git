using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipentStore.Data;
using RecipentStore.Dto;
using RecipentStore.Models;
using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace RecipentStore.Controllers
{
    public class StoreController : Controller
    {
        private int UserID ;
        private readonly AppDbContext _context;

        public StoreController(AppDbContext context)
        {
            UserID = 1;
            _context = context;
        }
   
        public IActionResult Index()
        {
            return View();
        }

        // GET: Store/ShopView
        public IActionResult ShopView()
        {
            var viewShop = (from sp in _context.Shops
               where sp.UserID == UserID
               select new ShopDto()
               {
                   ShopId = sp.Id,
                   ShopName = sp.Name,
                   NIP = sp.NIP
               });
            return View(viewShop);
        }
        // GET: Store/ShopCreate
        public ActionResult ShopCreate()
        {

            return View();
        }
        // POST: Store/ShopCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShopCreate(Shop collection)
        {


            return RedirectToAction(nameof(ShopView));
        }

        // GET: Store/BillView
        public IActionResult BillView()
        {
            var viewBill = (from bi in _context.Bills
                        join bt in _context.BillTypes on bi.BillTypeID equals bt.Id
                        join sp in _context.Shops on bi.ShopID equals sp.Id
                        where sp.UserID == UserID
                        select new BillDto()
                                   {Name = bi.Name,
                                    Price = bi.Price,
                                    File = bi.File,
                                    BillTypeID = bi.BillTypeID,
                                    CreateDate = bi.CreateDate,
                                    FileExtension = bi.FileExtension,
                                    ShopID = bi.ShopID,
                                    ShopName = sp.Name,
                                    ShopNip = sp.NIP,
                                    BillTypeName = bt.Name,
                                    Id = bi.Id }
                        );
            return View(viewBill);
        }
        // GET: Store/BillCreate
        public ActionResult BillCreate()
        {
            //download data and create list with data to select filed 
            ViewBag.BillType = new List<SelectListItem>();
            ViewBag.BillType = _context.BillTypes
                                            .Select(a => new SelectListItem()
                                            {
                                                Value = a.Id.ToString(),
                                                Text = a.Name,
                                            })
                                            .ToList();

            ViewBag.Shops = new List<SelectListItem>();
            ViewBag.Shops = _context.Shops
                                       .Where(t => UserID == t.UserID)
                                       .Select(a => new SelectListItem()
                                       {
                                           Value = a.Id.ToString(),
                                           Text = a.Name + "; Nip:" + a.NIP
                                          
                                       }) 
                                       .ToList();
            return View();
        }

        // POST: Store/BillCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BillCreate(BillCreateDto collection)
        {
            var memoryStream = new MemoryStream();
            collection.FileUpload.CopyToAsync(memoryStream);
            var file = memoryStream.ToArray();
            Bill bill = new Bill();
            bill.Name = collection.Name;
            bill.Price = collection.Price;
            bill.ShopID = collection.ShopID;
            bill.CreateDate = collection.CreateDate;
            bill.BillTypeID = collection.BillTypeID;
            bill.File = file.ToString();
            bill.FileExtension = collection.FileUpload.FileName.Split('.').Last();;
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return RedirectToAction(nameof(BillView));
        }

        // GET: Store/ShopingView
        public IActionResult ShopingView()
        {
            var viewBill = _context.Shops
                .Where(t => UserID == t.UserID)
                .Join(_context.Bills,
                      s => s.Id,
                      b => b.ShopID,
                      (s, b) => new {
                          ShopID = s.Id,
                          ShopName = s.Name,
                          BillID = b.Id,
                          BillName = b.Name
                      })
                .Join(_context.Shopings,
                      n => n.BillID,
                      sps => sps.BillID,
                      (n, sps) => new {
                          ShopingID = sps.Id,
                          ShopingName = sps.Name,
                          sps.Price,
                          sps.BillID,
                          n.BillName,
                          n.ShopID,
                          n.ShopName,
                          sps.CategoryID
                      })
                .Join(_context.Categories,
                      n => n.CategoryID,
                      no => no.Id,
                      (n, no) => new ShopingDto() {
                          ID = n.ShopingID,
                          ShopingName = n.ShopingName,
                          Price = n.Price,
                          BillID = n.BillID,
                          BillName = n.BillName,
                          ShopID = n.ShopID,
                          ShopName = n.ShopName,
                          CategoryID = n.CategoryID,
                          CategoryName = no.Name
                      }).ToList();
            return View(viewBill);
        }
        // GET: Store/ShopingCreate
        public ActionResult ShopingCreate()
        {
            //download data and create list with data to select filed 
            ViewBag.BillList = new List<SelectListItem>();
            ViewBag.BillList = _context.Bills.Join(_context.Shops, 
                                                b => b.ShopID,
                                                s => s.Id,
                                                (b,s) => new {
                                                    b.Id,
                                                    b.Name,
                                                    shop = s.Name,
                                                
                                                })
                                            .Select(a => new SelectListItem()
                                            {
                                                Value = a.Id.ToString(),
                                                Text = a.Name +"; "+ a.shop,
                                            });
            ViewBag.CategoryList = new List<SelectListItem>();
            ViewBag.CategoryList = _context.Categories
                                            .Select(a => new SelectListItem()
                                            {
                                                Value = a.Id.ToString(),
                                                Text = a.Name,
                                            });
            return View();
        }

        // POST: Store/ShopingCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShopingCreate(ShopingCreateDto collection)
        {
            Shoping shoping = new Shoping();
            shoping.Name = collection.ShopingName;
            shoping.Price = collection.Price;
            shoping.CategoryID = collection.CategoryID;
            shoping.BillID = collection.BillID;
            _context.Shopings.Add(shoping);
            _context.SaveChanges();
            return RedirectToAction("ShopingView");
        }
            // GET: Store/Privacy
            public IActionResult Privacy()
        {
            return View();
        }
        // GET: Store/Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}