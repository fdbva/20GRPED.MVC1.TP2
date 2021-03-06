﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _20GRPED.MVC1.TP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _20GRPED.MVC1.TP2.Controllers
{
    public class AdditionController : Controller
    {
        public IActionResult Abacaxi()
        {
            ViewBag.Controller = nameof(AdditionController);
            ViewBag.Action = nameof(Index);

            return View("Input");
        }

        public IActionResult Add(CalculatorModel calculatorModel)
        {
            ViewBag.Controller = nameof(AdditionController);
            ViewBag.Action = nameof(Add);

            var result = calculatorModel.Left + calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} + {calculatorModel.Right} = {result}";

            return View("Answer", calculatorModel);
        }
    }
}