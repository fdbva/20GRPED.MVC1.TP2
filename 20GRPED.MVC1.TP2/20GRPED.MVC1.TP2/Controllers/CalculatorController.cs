using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _20GRPED.MVC1.TP2.Models;

namespace _20GRPED.MVC1.TP2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left + calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} + {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }

        public IActionResult Divide(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left / calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} / {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }

        public IActionResult Subtract(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left - calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} - {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }

        public IActionResult Multiply(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left * calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} * {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }
    }
}