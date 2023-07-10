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
        //private readonly ApplicationDbContext _context;
        private readonly IBiletService _biletService;
        private readonly ILogger<BiletController> _logger;

        public BiletController(/*ApplicationDbContext context,*/ ILogger<BiletController> logger, IBiletService biletService)
        {
            //_context = context;
            _logger = logger;
            _biletService = biletService;
        }

        // GET: Bilet
        public IActionResult Index()
        {
            return View(_biletService.ListajBileti());
        }

        public IActionResult List(DateTime Datum)
        {
            ViewData["CurrentFilter"] = Datum;
            //List<Bilet> bileti = await _context.Bileti.ToListAsync();
            List<Bilet> bileti = _biletService.ListajBileti();
            bileti =bileti.Where(b => b.BrDostapni>0).ToList();
            if(Datum!=DateTime.MinValue)
            {
                bileti=bileti.Where(b => b.Datum.Date==Datum.Date).ToList();
            }
            return View(bileti);
        }

        // GET: Bilet/Details/5
        
        public IActionResult Details(Guid? id)
        {
            _logger.LogInformation("User Request -> Get Details For Product");
            if (id == null)
            {
                return NotFound();
            }

            var bilet = this._biletService.DetaliZaBilet(id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilet/Create
        
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
                this._biletService.KreirajBilet(bilet);
                return RedirectToAction(nameof(Index));
            }
            return View(bilet);
        }


        // GET: Bilet/Edit/5

        public IActionResult Edit(Guid? id)
        {
            _logger.LogInformation("User Request -> Get edit form for Product!");
            if (id == null)
            {
                return NotFound();
            }

            var product = this._biletService.DetaliZaBilet(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Ime,Opis,Cena,BrDostapni,Datum")] Bilet bilet)
        {
            _logger.LogInformation("User Request -> Update Product in DataBase!");

            if (id != bilet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._biletService.AzhurirajBilet(bilet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoiBilet(bilet.Id))
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
        public IActionResult Delete(Guid? id)
        {
            _logger.LogInformation("User Request -> Get delete form for Product!");

            if (id == null)
            {
                return NotFound();
            }

            var bilet = this._biletService.DetaliZaBilet(id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _logger.LogInformation("User Request -> Delete Product in DataBase!");

            this._biletService.IzbrishiBilet(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PostoiBilet(Guid id)
        {
            return this._biletService.DetaliZaBilet(id) != null;
        }
    }
}
