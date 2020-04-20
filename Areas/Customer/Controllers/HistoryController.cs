using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Models;
using ISProject.Utils;

namespace ISProject.Controllers
{
    [Area("Customer")]
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HistoryController(ApplicationDbContext db){
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var order = await _db.OrderHeader.Where(p => p.UserId == claim.Value).ToListAsync();
         
            return View(order);
        }

        public async Task<IActionResult> Details(int id)
        {
            var oDetails = await _db.OrderDetails.Where(p => p.OrderId == id).ToListAsync();
            return View(oDetails);
        }
    }
}
