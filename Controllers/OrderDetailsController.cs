using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manager.Data;
using ManagerInvoice.Models;
using System.Net.Mail;
using System.Net;

namespace Manager.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ManagerContext _context;

        public OrderDetailsController(ManagerContext context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderDetail.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> ListOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = await _context.Order
                .Where(od => od.H_ORDER_INT == id)
                .FirstOrDefaultAsync();
            var orderDetails = await _context.OrderDetail
                .Where(od => od.D_ORDER_NO == id)
                .ToListAsync();

            if (!orderDetails.Any())
            {
                return NotFound();
            }
            ViewBag.Order = order;
            return View(orderDetails);
        }
        public async Task<IActionResult> SendMail(int? id)
        {
            string fromMail = "spotifyrep81@gmail.com";
            string fromPassword = "xlkvwzkqgtyxkiat";

            MailMessage message = new MailMessage
            {
                From = new MailAddress(fromMail),
                Subject = "Test",
                Body = "<html><body> Test Body </body></html>",
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress("emcuahoi1223@gmail.com"));

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            // Use SendMailAsync for async operation
            await smtpClient.SendMailAsync(message);

            // Redirect to Index action after sending the mail
           return RedirectToAction("ListOrder", new { id = id });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .FirstOrDefaultAsync(m => m.D_ORDER_NO == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }
        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DETAIL_ORDER_NO,D_ORDER_NO,D_ORDER_INT,D_LINE,D_ART_NO,D_ART_DVT,D_MMUNT,D_ARTNAME,D_QTY,D_GOLDVAT,D_GOLD_PRICE,D_SUPVAT,D_SUP_PRICE,D_UPDATEBY,H_CREATED_DATE,H_UPDATED_DATE,D_STATUS,D_COMMENT")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DETAIL_ORDER_NO,D_ORDER_NO,D_ORDER_INT,D_LINE,D_ART_NO,D_ART_DVT,D_MMUNT,D_ARTNAME,D_QTY,D_GOLDVAT,D_GOLD_PRICE,D_SUPVAT,D_SUP_PRICE,D_UPDATEBY,H_CREATED_DATE,H_UPDATED_DATE,D_STATUS,D_COMMENT")] OrderDetail orderDetail)
        {
            if (id != orderDetail.DETAIL_ORDER_NO)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.DETAIL_ORDER_NO))
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
            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .FirstOrDefaultAsync(m => m.DETAIL_ORDER_NO == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetail.Remove(orderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetail.Any(e => e.DETAIL_ORDER_NO == id);
        }
    }
}
