using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _20GRPED.MVC1.TP2.Models;
using Microsoft.Extensions.Configuration;

namespace _20GRPED.MVC1.TP2.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly string _name;

        public CalculatorController(
            IConfiguration configuration)
        {
            _name = configuration.GetValue<string>("Nome");
        }

        public IActionResult Index()
        {
            ViewBag.Controller = nameof(CalculatorController);
            ViewBag.Action = _name;

            return View();
        }

        public IActionResult Add(CalculatorModel calculatorModel)
        {
            ViewBag.Controller = nameof(CalculatorController);
            ViewBag.Action = nameof(Add);

            var result = calculatorModel.Left + calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} + {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }

        public IActionResult Divide(CalculatorModel calculatorModel)
        {
            ViewBag.Controller = nameof(CalculatorController);
            ViewBag.Action = nameof(Divide);

            var result = calculatorModel.Left / calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} / {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }

        public IActionResult Subtract(CalculatorModel calculatorModel)
        {
            ViewBag.Controller = nameof(CalculatorController);
            ViewBag.Action = nameof(Subtract);

            var result = calculatorModel.Left - calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} - {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }

        public IActionResult Multiply(CalculatorModel calculatorModel)
        {
            ViewBag.Controller = nameof(CalculatorController);
            ViewBag.Action = nameof(Multiply);

            var result = calculatorModel.Left * calculatorModel.Right;

            calculatorModel.Result =
                $"{calculatorModel.Left} * {calculatorModel.Right} = {result}";

            return View("Result", calculatorModel);
        }
    }
}