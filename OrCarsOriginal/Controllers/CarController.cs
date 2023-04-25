using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrCarsOriginal.Data;
using OrCarsOriginal.Models;
using static OrCarsOriginal.Models.Enumerators;

namespace OrCarsOriginal.Controllers
{
    public class CarController : Controller
    {

        private static int maxNoImages = 6;
        private static int maxImageWidth = 1200;
        private static int maxImageHeight = 1000;
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString, CarBrand brandFilter)
        {
            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";       
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "date";
            ViewData["YearSortParm"] = sortOrder == "year" ? "year_desc" : "year";
            ViewData["CurrentFilter"] = searchString;


            IQueryable<Car> car;
            if ((int)brandFilter > 0)
            {
                car = from s in _context.Car
                      where (s.CBrand.Equals(brandFilter))
                      select s;
            }
            else
            {
                car = from s in _context.Car
                      select s;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                car = car.Where(s => s.Description.Contains(searchString) ||
                s.Model.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "date_desc":
                    car = car.OrderByDescending(s => s.InDate);
                    break;
                case "Date":
                    car = car.OrderBy(s => s.InDate);
                    break;
                case "year_desc":
                    car = car.OrderByDescending(s => s.Year);
                    break;
                case "year":
                    car = car.OrderBy(s => s.Year);
                    break;
                default:
                    car = car.OrderBy(s => s.Description);
                    break;
            }
            return View(await car.AsNoTracking().ToListAsync());
        }
        // GET: Car
        public async Task<IActionResult> Index()
        {
            return _context.Car != null ?
                        View(await _context.Car.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Car'  is null.");
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            //get number of the files in the folder
            var path = Directory.GetCurrentDirectory() + "/wwwroot/Car";

            ViewBag.NoOfImageFiles = Directory.GetFiles(path, car.Id.ToString() + "-*_m.jpg", SearchOption.TopDirectoryOnly).Length;
            //end file count
            return View(car);
        }

        // GET: Car/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Price,HorsePower,UploadedBy,Telephone,CBrand,SState,ImageLink,Description,Year,Gear,Fuel,Km,NewOrUsed,EngineSize,BBody,Color,InDate,PSteering,DualFrontAirbags,AntiLockBraking,AC,AntiTheft,BrakeAssist,CruiseControl,CentralLocking,RemoteKey,BrakeEBFC,HeadAirbags,EngineImmobiliser,MultiFunctionScreen,PowerMirrors,MirrorIndicators,FrontPowerWindows,RearPowerWindows,ReversingCamera,SideFrontAirbags,TripComputer,TractionControlSystem,VehicleStabilityControl")] Car car)
        {
            if (ModelState.IsValid)
            {
                car.UploadedBy = User.Identity.Name;
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Price,HorsePower,UploadedBy,Telephone,CBrand,SState,ImageLink,Description,Year,Gear,Fuel,Km,NewOrUsed,EngineSize,BBody,Color,InDate,PSteering,DualFrontAirbags,AntiLockBraking,AC,AntiTheft,BrakeAssist,CruiseControl,CentralLocking,RemoteKey,BrakeEBFC,HeadAirbags,EngineImmobiliser,MultiFunctionScreen,PowerMirrors,MirrorIndicators,FrontPowerWindows,RearPowerWindows,ReversingCamera,SideFrontAirbags,TripComputer,TractionControlSystem,VehicleStabilityControl")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (User.Identity.Name != null && car.UploadedBy.Equals(User.Identity.Name))
                {


                    try
                    {
                        _context.Update(car);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CarExists(car.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    return View("UnauthorizedAction");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Car/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Car'  is null.");
            }
            var car = await _context.Car.FindAsync(id);
            //allow delete only to upload user
            if (car.UploadedBy.Equals(User.Identity.Name))
            {
                _context.Car.Remove(car);
                await _context.SaveChangesAsync();
            }
            else
            {
                return View("Deleted");
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return (_context.Car?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> UnauthorizedAction()
        {
            return View();
        }

        //Deleted
        public async Task<IActionResult> Deleted()
        {
            return View();
        }

        //Getting photos with it's id and numbering them.
        public IActionResult FileUploadPage(int id)
        {
            var car = _context.Car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> FileUploadPage(List<IFormFile> files, int? Id)
        {



            var car = await _context.Car.FindAsync(Id);
            //allow upload only to uploaded user
            if (car.UploadedBy.Equals(User.Identity.Name))
            {


                #region upload
                var fileSize = files.Sum(m => m.Length);
                var fileNameS = new List<string>();


                ViewBag.Message = " Files uploaded ";

                int fileNumber = 0;
                foreach (var file in files)
                {
                    if (fileNumber < maxNoImages)
                    {
                        fileNumber++;
                        string imageFolder = "\\wwwroot\\Car";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory() + imageFolder,
                             Id.ToString() + "-" + fileNumber.ToString() + ".jpg");
                        fileNameS.Add(file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            // modifications ImageSharp
                            using var image = Image.Load(file.OpenReadStream());
                            if (image.Width > maxImageWidth || image.Height > maxImageHeight)
                            {
                                return Ok("Image is too big (Image,Height)" + image.Width + ","
                                    + image.Height);
                            }
                            image.Mutate(x => x.Resize(200, 120));
                            image.SaveAsJpeg("wwwroot/car/" + Id.ToString() + "-" + fileNumber.ToString() + "_s.jpg");
                            // end modification
                            await file.CopyToAsync(stream);
                        }

                        var filePathTwo = Path.Combine(Directory.GetCurrentDirectory() + imageFolder,
                              "temp.jpg");
                        fileNameS.Add(file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            // modifications ImageSharp
                            using var image = Image.Load(file.OpenReadStream());
                            if (image.Width > maxImageWidth || image.Height > maxImageHeight)
                            {
                                return Ok("Image is too big (Image,Height)" + image.Width + ","
                                    + image.Height);
                            }
                            image.Mutate(x => x.Resize(1000, 600));
                            image.SaveAsJpeg("wwwroot/car/" + Id.ToString() + "-" + fileNumber.ToString() + "_m.jpg");
                            image.Dispose();
                            // end modification
                            // await file.CopyToAsync(stream);                          
                        }
                        ViewBag.Message += file.FileName + ", ";
                    }
                }
                return View();
                #endregion
            }
            else
            {
                return View("UnauthorizedAction");
            }

        }

    }
}
