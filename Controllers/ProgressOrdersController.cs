using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manager.Data;
using ManagerInvoice.Models;

namespace Manager.Controllers
{
    public class ProgressOrdersController : Controller
    {
        private readonly ManagerContext _context;

        public ProgressOrdersController(ManagerContext context)
        {
            _context = context;
        }

        // GET: ProgressOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgressOrder.ToListAsync());
        }

        // GET: ProgressOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progressOrder = await _context.ProgressOrder
                .FirstOrDefaultAsync(m => m.PO_ID == id);
            if (progressOrder == null)
            {
                return NotFound();
            }

            return View(progressOrder);
        }

        // GET: ProgressOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgressOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PO_ID,H_ORDER_NO,H_ORDER_INT,HISTORY_ID,HISTORY_STATUS,HISTORY_COMMIT_BY,HISTORY_CREATED_DATE")] ProgressOrder progressOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(progressOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(progressOrder);
        }

        // GET: ProgressOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progressOrder = await _context.ProgressOrder.FindAsync(id);
            if (progressOrder == null)
            {
                return NotFound();
            }
            return View(progressOrder);
        }

        // POST: ProgressOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PO_ID,H_ORDER_NO,H_ORDER_INT,HISTORY_ID,HISTORY_STATUS,HISTORY_COMMIT_BY,HISTORY_CREATED_DATE")] ProgressOrder progressOrder)
        {
            if (id != progressOrder.PO_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progressOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgressOrderExists(progressOrder.PO_ID))
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
            return View(progressOrder);
        }

        // GET: ProgressOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progressOrder = await _context.ProgressOrder
                .FirstOrDefaultAsync(m => m.PO_ID == id);
            if (progressOrder == null)
            {
                return NotFound();
            }

            return View(progressOrder);
        }

        // POST: ProgressOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progressOrder = await _context.ProgressOrder.FindAsync(id);
            if (progressOrder != null)
            {
                _context.ProgressOrder.Remove(progressOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgressOrderExists(int id)
        {
            return _context.ProgressOrder.Any(e => e.PO_ID == id);
        }
    }
}
