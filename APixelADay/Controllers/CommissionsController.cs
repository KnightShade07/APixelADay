using APixelADay.Data;
using APixelADay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Controllers
{
    public class CommissionsController : Controller
    {
        private readonly PixelDBContext _context;

        public CommissionsController(PixelDBContext context, IConfiguration config)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Commissions(int? id)
        {
            int pageNum = id ?? 1;
            const int PageSize = 3;
            ViewData["CurrentPage"] = pageNum;

            int numCommissions = await PixelDBManager.GetTotalCommissionsAsync(_context);
            //prevent integer division.
            int totalPages = (int)Math.Ceiling((double)numCommissions / PageSize);
            ViewData["MaxPage"] = totalPages;

            List<CommissionsLog> commissionsLogs = await PixelDBManager.GetPageOfCommissionsAsync(_context, PageSize, pageNum);
            return View(commissionsLogs);
        }

        // GET: CommissionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommissionsController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: CommissionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Add(CommissionsLog c)
        {
            _context.Commissions.Add(c);
            await _context.SaveChangesAsync();
            return RedirectToAction("Commissions");
        }

        // GET: CommissionsController/Edit/5
        public async Task <ActionResult> Edit(int id)
        {
            CommissionsLog c = await PixelDBManager.GetSingleCommissionAsync(id, _context);
            return View(c);
        }

        // POST: CommissionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(CommissionsLog c)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();

                ViewData["Message"] = "The Commission Entry was updated successfully!";
            }

            return View(c);
        }

        // GET: CommissionsController/Delete/5
        public async Task <ActionResult> Delete(int id)
        {
            CommissionsLog c = await PixelDBManager.GetSingleCommissionAsync(id, _context);
            return View(c);
        }

        // POST: CommissionsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Commissions));
            }
            catch
            {
                return View();
            }
        }
    }
}
