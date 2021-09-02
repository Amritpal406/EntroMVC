using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entro.Data;
using Entro.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Entro.Controllers
{
        public class TicketsController : Controller
        {
            private readonly EntroContext _context;

            public TicketsController(EntroContext context)
            {
                _context = context;
            }

        // GET: Tickets
        public async Task<IActionResult> Index()
            {
               return View(await _context.Tickets.ToListAsync());               
            }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Tickets = await _context.Tickets
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Tickets == null)
                {
                    return NotFound();
                }

                return View(Tickets);
            }
        public IActionResult TicketNotFound()
        {
            return View();
        }
         public IActionResult TicketBooked()
        {
            return View();
        }
        
        // GET: Tickets/Create
        public IActionResult Create()
            {
            var Concepts = _context.Concepts.ToList();
            if (Concepts.Count > 0)
            {
                Concepts.Insert(0, new Concepts { Id = 0, ConceptName = "Select Concepts" });
                ViewBag.ListConcepts = Concepts;
                return View();
            }
            else
            {
                return RedirectToAction(nameof(TicketNotFound));
            }
            }



        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,Name,Contact,NumberOfPersons,Date,ConceptId")] Tickets Tickets)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Tickets);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(TicketBooked));
                }
                return View(Tickets);
            }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Tickets = await _context.Tickets.FindAsync(id);
                if (Tickets == null)
                {
                    return NotFound();
                }
                return View(Tickets);
            }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,NumberOfPersons,Date,ConceptId")] Tickets Tickets)
            {
                if (id != Tickets.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Tickets);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TicketsExists(Tickets.Id))
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
                return View(Tickets);
            }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Tickets = await _context.Tickets
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Tickets == null)
                {
                    return NotFound();
                }

                return View(Tickets);
            }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Tickets = await _context.Tickets.FindAsync(id);
                _context.Tickets.Remove(Tickets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool TicketsExists(int id)
            {
                return _context.Tickets.Any(e => e.Id == id);
            }
        }
    }
