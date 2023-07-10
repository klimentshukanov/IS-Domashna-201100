using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiletiApp.Domain.DomainModels;
using BiletiApp.Web.Data;
using Microsoft.Extensions.Logging;
using BiletiApp.Service.Interface;

namespace BiletiApp.Web.Controllers
{
    public class BiletController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBiletService _productService;
        private readonly ILogger<BiletController> _logger;

        public BiletController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bilet
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bileti.ToListAsync());
        }

        public async Task<IActionResult> List(DateTime Datum)
        {
            ViewData["CurrentFilter"] = Datum;
            List<Bilet> bileti = await _context.Bileti.ToListAsync(); //da se promeni
            bileti=bileti.Where(b => b.BrDostapni>0).ToList();
            if(Datum!=DateTime.MinValue)
            {
                bileti=bileti.Where(b => b.Datum.Date==Datum.Date).ToList();
            }
            return View(bileti);
        }

        // GET: Bilet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bileti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        /*// GET: Bilet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bilet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Opis,Cena,BrDostapni,Datum")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                bilet.Id = Guid.NewGuid();
                _context.Add(bilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bilet);
        }*/

        public IActionResult Create()
        {
            _logger.LogInformation("User Request -> Get create form for Product!");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Ime,Opis,Cena,BrDostapni,Datum")] Bilet bilet)
        {
            _logger.LogInformation("User Request -> Insert Product in DataBase!");
            if (ModelState.IsValid)
            {
                bilet.Id = Guid.NewGuid();
                this._productService.KreirajBilet(bilet);
                return RedirectToAction(nameof(Index));
            }
            return View(bilet);
        }


        // GET: Bilet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bileti.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }
            return View(bilet);
        }

        // POST: Bilet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Ime,Opis,Cena,BrDostapni,Datum")] Bilet bilet)
        {
            if (id != bilet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bilet);
        }

        // GET: Bilet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bileti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bilet = await _context.Bileti.FindAsync(id);
            _context.Bileti.Remove(bilet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletExists(Guid id)
        {
            return _context.Bileti.Any(e => e.Id == id);
        }
    }
}
