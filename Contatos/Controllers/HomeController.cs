﻿using Contatos.Filters;
using Contatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Contatos.Controllers
{
    public class HomeController : Controller
    {
       [PaginaParaUsuarioLogado]

        public IActionResult Index()
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