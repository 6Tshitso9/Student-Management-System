using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using StorageManagementSystem.Data;
using StorageManagementSystem.Models;

namespace StorageManagementSystem.Controllers
{
    public class DBStorageRentalsController : Controller
    {
        private readonly StorageContext _context;
        private readonly ApplicationUser _data;

        public DBStorageRentalsController(StorageContext context,ApplicationUser data)
        {
            _context = context;
            _data = data;
        }

        // GET: DBStorageRental

        public async Task<IActionResult> Index(string venueName, string searchString,string orderBy)
        {
            DbSet<DBVenue> c = _context.Venue;
            var venue = c.Where(camp => camp.Venue_Name.Contains(venueName));
            int id;
            if (venue.Count() > 0)
            {
                DBVenue answer = venue.First();
                id = answer.Venue_ID;
            }
            else
            {
                id = -1;
            }
           

            var rentals = from r in _context.StorageRental select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                rentals = rentals.Where(r => r.Rental_Locator.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(venueName))
            {
                rentals = rentals.Where(r => r.Venue_ID.Equals(id));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "checkin_date_desc":
                        rentals = rentals.OrderByDescending(r => r.Rental_CheckedIn);
                        break;
                    case "checkin_date_asc":
                        rentals = rentals.OrderBy(r => r.Rental_CheckedIn);
                        break;

                    case "checkout_date_desc":
                        rentals = rentals.OrderByDescending(r => r.Rental_EndDate);
                        break;
                    case "checkout_date_asc":
                        rentals = rentals.OrderBy(r => r.Rental_EndDate);
                        break;
                    case "Tracking_No_asc":
                        rentals = rentals.OrderBy(r => r.Rental_Locator);
                        break;
                    case "Tracking_No_desc":
                        rentals = rentals.OrderByDescending(r => r.Rental_Locator);
                        break;
                    case "Venue_id_desc":
                        rentals = rentals.OrderByDescending(r => r.Venue_ID);
                        break;
                    case "Venue_id_asc":
                        rentals = rentals.OrderBy(r => r.Venue_ID);
                        break;
                }
            }

            var sVR = new StorageVenueRental()
            {
                venueName = "",
                Rentals = await rentals.ToListAsync()
            };

            return View(sVR);
        }

        // GET: DBStorageRentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dBStorageRental = await _context.StorageRental
                .FirstOrDefaultAsync(m => m.Rental_Number == id);
            if (dBStorageRental == null)
            {
                return NotFound();
            }

            var ven = _context.Venue.Where(r => r.Venue_ID.Equals(dBStorageRental.Venue_ID));
          

            StorageRentalDetails details = new StorageRentalDetails();

            details.venueName = ven.First().Venue_Name;
     
            details.rental = dBStorageRental;
            return View(details);
        }

        // GET: DBStorageRentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DBStorageRentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rental_Number,Rental_StartDate,Rental_EndDate,Rental_Price,Rental_Locator,Rental_CheckedIn,Size_ID,Venue_ID,Student_ID")] DBStorageRental dBStorageRental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dBStorageRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dBStorageRental);
        }

        // GET: DBStorageRentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dBStorageRental = await _context.StorageRental.FindAsync(id);
            if (dBStorageRental == null)
            {
                return NotFound();
            }
            return View(dBStorageRental);
        }

        // POST: DBStorageRentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rental_Number,Rental_StartDate,Rental_EndDate,Rental_Price,Rental_Locator,Rental_CheckedIn,Size_ID,Venue_ID,Student_ID")] DBStorageRental dBStorageRental)
        {
            if (id != dBStorageRental.Rental_Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dBStorageRental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DBStorageRentalExists(dBStorageRental.Rental_Number))
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
            return View(dBStorageRental);
        }

        // GET: DBStorageRentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dBStorageRental = await _context.StorageRental
                .FirstOrDefaultAsync(m => m.Rental_Number == id);
            if (dBStorageRental == null)
            {
                return NotFound();
            }

            return View(dBStorageRental);
        }

        // POST: DBStorageRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dBStorageRental = await _context.StorageRental.FindAsync(id);
            _context.StorageRental.Remove(dBStorageRental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DBStorageRentalExists(int id)
        {
            return _context.StorageRental.Any(e => e.Rental_Number == id);
        }
    }
}
