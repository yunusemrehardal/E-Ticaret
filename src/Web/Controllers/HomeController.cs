﻿using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using Web.Interfaces;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeViewModelService _homeViewModelService;
        public HomeController(IHomeViewModelService homeViewModelService)
        {
            _homeViewModelService = homeViewModelService;
        }
        public async Task<IActionResult> Index(int? categoryId, int? brandId, int pageId = 1)
        {
            var vm = await _homeViewModelService.GetHomeViewModelAsync(categoryId, brandId, pageId);
            return View(vm);
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