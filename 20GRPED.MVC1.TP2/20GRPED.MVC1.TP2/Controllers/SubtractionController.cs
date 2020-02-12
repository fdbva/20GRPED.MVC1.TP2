using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20GRPED.MVC1.TP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20GRPED.MVC1.TP2.Controllers
{
    public class SubtractionController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Controller = nameof(SubtractionController);
            ViewBag.Action = nameof(Index);

            return View("Views/Calculator/Index.cshtml");
        }

        public IActionResult Subtract(CalculatorModel calculatorModel)
        {
            ViewBag.Controller = nameof(SubtractionController);
            ViewBag.Action = nameof(Subtract);

            var result = calculatorModel.Left - calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} - {calculatorModel.Right} = {result}";

            return View("Views/Calculator/Result.cshtml", calculatorModel);
        }
    }
}