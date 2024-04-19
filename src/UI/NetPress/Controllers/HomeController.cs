﻿using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Contracts.Persistence;
using NetPress.Application.Features.Post.Queries.GetPostsList;
using NetPress.Domain.Entities;
using NetPress.Models;
using System.Diagnostics;

namespace NetPress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}