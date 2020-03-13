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

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var calculatorModel = _calculatorHistoryRepository.GetById(id);

            return View("Result", calculatorModel);
        }

        public IActionResult History(string @operator)
        {
            IEnumerable<CalculatorModel> history
                = _calculatorHistoryRepository
                    .GetAllOfThisOperator(@operator);

            return View(history);
        }


        // GET: Calculator/Edit/5
        public ActionResult Edit(int id)
        {
            var calculator = _calculatorHistoryRepository.GetById(id);
            return View(calculator);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CalculatorModel updatedCalculatorModel)
        {
            try
            {
                // TODO: Add update logic here
                _calculatorHistoryRepository.Update(updatedCalculatorModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Calculator/Delete/5
        public ActionResult Delete(int id)
        {
            var calculator = _calculatorHistoryRepository.GetById(id);
            return View(calculator);
        }

        // POST: Calculator/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CalculatorModel calculatorModel)
        {
            try
            {
                // TODO: Add delete logic here
                _calculatorHistoryRepository.Remove(calculatorModel.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}