using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _20GRPED.MVC1.TP2.Models;
using _20GRPED.MVC1.TP2.Repositories;
using _20GRPED.MVC1.TP2.Constants;

namespace _20GRPED.MVC1.TP2.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorHistoryRepository _calculatorHistoryRepository;

        public CalculatorController(
            CalculatorHistoryRepository calculatorHistoryRepository)
        {
            _calculatorHistoryRepository = calculatorHistoryRepository;
        }

        public IActionResult Index(string order)
        {
            IEnumerable<CalculatorModel> history
                = _calculatorHistoryRepository.GetAll();

            var calculatorIndexViewModel = new CalculatorIndexViewModel
            {
                History = history
            };
            return View(calculatorIndexViewModel);
        }

        public IActionResult Add(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left + calculatorModel.Right;

            calculatorModel.Operator = Operator.ADD_SIGN;
            calculatorModel.Result =
                $"{calculatorModel.Left} {Operator.ADD_SIGN} {calculatorModel.Right} = {result}";

            _calculatorHistoryRepository.Insert(calculatorModel);

            return View("Result", calculatorModel);
        }

        public IActionResult Divide(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left / calculatorModel.Right;

            calculatorModel.Operator = Operator.DIVIDE_SIGN;
            calculatorModel.Result =
                $"{calculatorModel.Left} {Operator.DIVIDE_SIGN} {calculatorModel.Right} = {result}";

            _calculatorHistoryRepository.Insert(calculatorModel);

            return View("Result", calculatorModel);
        }

        public IActionResult Subtract(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left - calculatorModel.Right;

            calculatorModel.Operator = Operator.SUBTRACT_SIGN;
            calculatorModel.Result =
                $"{calculatorModel.Left} {Operator.SUBTRACT_SIGN} {calculatorModel.Right} = {result}";

            _calculatorHistoryRepository.Insert(calculatorModel);

            return View("Result", calculatorModel);
        }

        public IActionResult Multiply(CalculatorModel calculatorModel)
        {
            var result = calculatorModel.Left * calculatorModel.Right;

            calculatorModel.Operator = Operator.MULTIPLY_SIGN;
            calculatorModel.Result =
                $"{calculatorModel.Left} {Operator.MULTIPLY_SIGN} {calculatorModel.Right} = {result}";

            _calculatorHistoryRepository.Insert(calculatorModel);

            return View("Result", calculatorModel);
        }

        public IActionResult History()
        {
            IEnumerable<CalculatorModel> history
                = _calculatorHistoryRepository.GetAll();

            return View(history);
        }
    }
}