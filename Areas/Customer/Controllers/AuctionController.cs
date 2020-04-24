using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISProject.Models;
using ISProject.Models.ViewModels;
using ISProject.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ISProject.Utils;

namespace ISProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class AuctionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AuctionController(ApplicationDbContext db)
        {
            _db=db;
        }
        
        [Authorize(Roles=SD.SellerUser)]
        public async Task<IActionResult> Select()
        {
            return View();
        }


    }
}
