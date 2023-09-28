using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artikel_Hersteller.Models;
using IronBarCode;
using Microsoft.Extensions.Hosting;

namespace Artikel_Hersteller
{
    public class HerstellersController : Controller
    {
        private readonly HerstellerContext _context;

        public HerstellersController(HerstellerContext context)
        {
            _context = context;
        }

        // GET: Herstellers
        public async Task<IActionResult> Index(string? search = null)
        {
            List<Hersteller> herstellers = _context.Herstellers.Include(x => x.Arts).ToList();
            if (!String.IsNullOrEmpty(search))
            {
                herstellers = herstellers.Where(h => h.HerName.Contains(search)).ToList();
            }

            return _context.Herstellers != null ?
                        View(herstellers) :
                        Problem("Entity set 'HerstellerContext.Herstellers'  is null.");
        }

        // GET: Herstellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Herstellers == null)
            {
                return NotFound();
            }

            var hersteller = await _context.Herstellers.Include(x => x.Arts)
                .FirstOrDefaultAsync(m => m.HerId == id);
            if (hersteller == null)
            {
                return NotFound();
            }

            try
            {
                GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(hersteller.HerName, 200);
                barcode.AddBarcodeValueTextBelowBarcode();
                // Styling a QR code and adding annotation text
                barcode.SetMargins(10);
                barcode.ChangeBarCodeColor(Color.BlueViolet);
                string path = Path.Combine("C:\\Users\\Haunschmied.Bastian\\Desktop\\test", "GeneratedQRCode");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filePath = Path.Combine("C:\\Users\\Haunschmied.Bastian\\Desktop\\test", "GeneratedQRCode/qrcode.png");
                barcode.SaveAsPng(filePath);
                string fileName = Path.GetFileName(filePath);
                string imageUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}" + "/GeneratedQRCode/" + fileName;
                ViewBag.QrCodeUri = imageUrl;
            }
            catch (Exception)
            {
                throw;
            }

            return View(hersteller);
        }

        // GET: Herstellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Herstellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HerId,HerName")] Hersteller hersteller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hersteller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hersteller);
        }

        // GET: Herstellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Herstellers == null)
            {
                return NotFound();
            }

            var hersteller = await _context.Herstellers.FindAsync(id);
            if (hersteller == null)
            {
                return NotFound();
            }
            return View(hersteller);
        }

        // POST: Herstellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HerId,HerName")] Hersteller hersteller)
        {
            if (id != hersteller.HerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hersteller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerstellerExists(hersteller.HerId))
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
            return View(hersteller);
        }

        // GET: Herstellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Herstellers == null)
            {
                return NotFound();
            }

            var hersteller = await _context.Herstellers
                .FirstOrDefaultAsync(m => m.HerId == id);
            if (hersteller == null)
            {
                return NotFound();
            }

            return View(hersteller);
        }

        // POST: Herstellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Herstellers == null)
            {
                return Problem("Entity set 'HerstellerContext.Herstellers'  is null.");
            }
            var hersteller = await _context.Herstellers.FindAsync(id);
            if (hersteller != null)
            {
                _context.Herstellers.Remove(hersteller);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerstellerExists(int id)
        {
            return (_context.Herstellers?.Any(e => e.HerId == id)).GetValueOrDefault();
        }
    }
}
