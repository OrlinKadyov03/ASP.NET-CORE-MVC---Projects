using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OrCarsOriginal.Data;
using OrCarsOriginal.Models;

namespace OrCarsOriginal.Controllers
{
    public class CarController : Controller
    {

        private static int maxNoImages = 1;
        private static int maxImageWidth = 900;
        private static int maxImageHeight = 600;
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,HorsePower,UploadedBy,Telephone,CBrand,SState,ImageLink,Description,Year,Gear,Fuel,Km,NewOrUsed,EngineSize,BBody,Color,InDate")] Car car)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,HorsePower,UploadedBy,Telephone,CBrand,SState,ImageLink,Description,Year,Gear,Fuel,Km,NewOrUsed,EngineSize,BBody,Color,InDate")] Car car)
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


            ViewBag.Message = " Files uploaded " ;

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
                        image.Mutate(x => x.Resize(256, 256));
                        image.SaveAsJpeg("wwwroot/car/" + Id.ToString() + "-" + fileNumber.ToString() + "_s.jpg");
                        // end modification
                        await file.CopyToAsync(stream);
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
