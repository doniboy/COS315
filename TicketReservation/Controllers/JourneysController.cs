using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketReservation.Data;
using TicketReservation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TicketReservation.Controllers
{
    public class JourneysController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public JourneysController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Journeys
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Journey.ToListAsync());
        }

        // GET: Journeys/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journey = await _context.Journey
                .SingleOrDefaultAsync(m => m.Id == id);
            if (journey == null)
            {
                return NotFound();
            }

            return View(journey);
        }

        // GET: Journeys/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Journeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To,Date,IsActive,TotalSeatsLeftDirection,TotalSeatsRightDirection")] Journey journey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journey);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(journey);
        }

        // GET: Journeys/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journey = await _context.Journey.SingleOrDefaultAsync(m => m.Id == id);
            if (journey == null)
            {
                return NotFound();
            }
            return View(journey);
        }

        // POST: Journeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,From,To,Date,IsActive,TotalSeatsLeftDirection,TotalSeatsRightDirection")] Journey journey)
        {
            if (id != journey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JourneyExists(journey.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(journey);
        }

        // GET: Journeys/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journey = await _context.Journey
                .SingleOrDefaultAsync(m => m.Id == id);
            if (journey == null)
            {
                return NotFound();
            }

            return View(journey);
        }

        // POST: Journeys/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journey = await _context.Journey.SingleOrDefaultAsync(m => m.Id == id);
            _context.Journey.Remove(journey);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Buy(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var journey = await _context.Journey.SingleOrDefaultAsync(m => m.Id == id);

            var seat = new Seat { JourneyId = id, Direction = "Left", Number = "SomeNumber", UserId = user.Id };

            _context.Add(seat);

            journey.TotalSeatsLeftDirection -= 1;

            _context.Update(journey);

            await _context.SaveChangesAsync();

            return View(seat);
        }

        private bool JourneyExists(int id)
        {
            return _context.Journey.Any(e => e.Id == id);
        }
    }
}
