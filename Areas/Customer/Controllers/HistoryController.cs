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
            return View();
        }
    }
}
