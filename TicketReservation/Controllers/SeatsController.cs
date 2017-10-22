using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketReservation.Data;
using Microsoft.EntityFrameworkCore;

namespace TicketReservation.Controllers
{
    public class SeatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Seat.ToListAsync());
        }

        public async Task<IActionResult> Buy()
        {
            return View(await _context.Seat.ToListAsync());
        }
    }
}