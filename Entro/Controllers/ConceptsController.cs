using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entro.Data;
using Entro.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace Entro.Controllers
{
        public class ConceptsController : Controller
        {
            private readonly EntroContext _context;

            public ConceptsController(EntroContext context)
            {
                _context = context;
            }

            // GET: Concepts
            public async Task<IActionResult> Index()
            {
                
                    return View(await _context.Concepts.ToListAsync());
            }

            public async Task<IActionResult> UserView()
            {
                
                    return View(await _context.Concepts.ToListAsync());
            }
        
            // GET: Concepts/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Concepts = await _context.Concepts
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Concepts == null)
                {
                    return NotFound();
                }

                return View(Concepts);
            }

            // GET: Concepts/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Concepts/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,ConceptName,Time,TicketRate")] Concepts Concepts)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(Concepts);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Concepts);
            }

            // GET: Concepts/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Concepts = await _context.Concepts.FindAsync(id);
                if (Concepts == null)
                {
                    return NotFound();
                }
                return View(Concepts);
            }

            // POST: Concepts/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,ConceptName,Time,TicketRate")] Concepts Concepts)
            {
                if (id != Concepts.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Concepts);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ConceptsExists(Concepts.Id))
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
                return View(Concepts);
            }

            // GET: Concepts/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Concepts = await _context.Concepts
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Concepts == null)
                {
                    return NotFound();
                }

                return View(Concepts);
            }

            // POST: Concepts/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Concepts = await _context.Concepts.FindAsync(id);
                _context.Concepts.Remove(Concepts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ConceptsExists(int id)
            {
                return _context.Concepts.Any(e => e.Id == id);
            }
        }
    }