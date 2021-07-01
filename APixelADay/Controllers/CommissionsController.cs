﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Controllers
{
    public class CommissionsController : Controller
    {
        // GET: CommissionsController
        public ActionResult Commissions()
        {
            return View();
        }

        // GET: CommissionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommissionsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommissionsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CommissionsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommissionsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CommissionsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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